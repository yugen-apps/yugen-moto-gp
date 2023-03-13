using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.LiveTiming;

namespace Yugen.MotoGP.App.Services
{
    public class LiveTimingService
    {
        public EventHandler<LiveTimingEventArgs> LiveTimingChanged;

        private readonly IHttpClientService _httpClientService;
        private readonly int _currentEventId = 687;

        private Timer _timer;
        private int _eventId;

        public LiveTimingService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public void Initialize(int? eventId = null)
        {
            _eventId = eventId ?? _currentEventId;

            SetTimer();

            _ = GetLiveTiming();
        }

        private void SetTimer()
        {
            _timer = new Timer(5000);
            _timer.Elapsed += async (s, e) => await GetLiveTiming();
        }

        private async Task GetLiveTiming()
        {
            var response = await _httpClientService.GetLiveTiming(_eventId);

            using var jsonDocument = JsonDocument.Parse(response);
            var ltJsonElement = jsonDocument
                .RootElement
                .GetProperty("lt");

            var head = ltJsonElement
                .GetProperty("head")
                .Deserialize<Head>();

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