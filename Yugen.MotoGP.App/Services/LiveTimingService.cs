using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Timers;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.LiveTiming;

namespace Yugen.MotoGP.App.Services
{
    public class LiveTimingService : ILiveTimingService
    {
        private readonly ICalendarService _calendarService;

        private readonly IHttpClientService _httpClientService;

        private Timer _timer;

        public LiveTimingService(
            ICalendarService calendarService,
            IHttpClientService httpClientService)
        {
            _calendarService = calendarService;
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
            var response = await _httpClientService.GetLiveTiming(1);

            using var jsonDocument = JsonDocument.Parse(response);

            JsonSerializerOptions options = new()
            {
                NumberHandling =
                    JsonNumberHandling.AllowReadingFromString |
                    JsonNumberHandling.WriteAsString,
                WriteIndented = true
            };

            var ltJsonElement = jsonDocument
                .RootElement
                .GetProperty("lt");

            var head = ltJsonElement
                .GetProperty("head")
                .Deserialize<Head>(options);

            var riderJsonElement = ltJsonElement
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
    }
}