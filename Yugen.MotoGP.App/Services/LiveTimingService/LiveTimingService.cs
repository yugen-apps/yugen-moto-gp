using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Timers;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.LiveTimingLites;
using Yugen.MotoGP.App.Services.HttpClientService;

namespace Yugen.MotoGP.App.Services.LiveTimingService
{
	public class LiveTimingService : ILiveTimingService
	{
		private readonly IHttpClientService _httpClientService;

		private Timer _timer;

		public LiveTimingService(
			IHttpClientService httpClientService)
		{
			_httpClientService = httpClientService;
		}

		public event EventHandler<LiveTimingEventArgs> LiveTimingChanged;

		public async Task Initialize()
		{
			SetTimer();

			await GetLiveTiming();
		}

		public void DeInitialize()
		{
			_timer?.Dispose();
		}

		private void SetTimer()
		{
			_timer = new Timer(5000);
			_timer.Elapsed += async (s, e) => await GetLiveTiming();
		}

		private async Task GetLiveTiming()
		{
			var response = await _httpClientService.GetLiveTimingLite();

			using var jsonDocument = JsonDocument.Parse(response);

			var head = jsonDocument
				.RootElement
				.GetProperty("head")
				.Deserialize<Head>(jsonSerializerOptions);

			var riderJsonElement = jsonDocument
				.RootElement
				.GetProperty("rider");

			var riderDetailsList = riderJsonElement
				.Clone()
				.EnumerateObject()
				.Select(riderJson => riderJson.Value.Deserialize<RiderDetails>());

			if (head.SessionStatusId == "F")
			{
				_timer.Stop();
			}
			else
			{
				_timer.Start();
			}

			LiveTimingChanged?.Invoke(this, new LiveTimingEventArgs(head, riderDetailsList));
		}

		private static readonly JsonSerializerOptions jsonSerializerOptions = new(JsonSerializerDefaults.Web)
		{
			NumberHandling =
					JsonNumberHandling.AllowReadingFromString |
					JsonNumberHandling.WriteAsString,
			WriteIndented = true
		};
	}
}