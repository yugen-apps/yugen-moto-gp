using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.LiveTiming;

namespace Yugen.MotoGP.App.Services
{
    public class LiveTimingService : ILiveTimingService
    {
        public event EventHandler<LiveTimingEventArgs> LiveTimingChanged;

        private readonly ICalendarService _calendarService;
        private readonly IHttpClientService _httpClientService;
        
        private Timer _timer;
        private int _eventId;

        public LiveTimingService(
            ICalendarService calendarService,
            IHttpClientService httpClientService)
        {
            _calendarService = calendarService;
            _httpClientService = httpClientService;
        }

        public async Task Initialize(int? eventId = null)
        {
            if (eventId == null)
            {
                var currentEvent = await _calendarService.GetCurrentEvent();
                eventId = currentEvent?.TimingId;
            }
            if (eventId == null)
            {
                return;
            }

            _eventId = (int)eventId;

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