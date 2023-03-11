using Microsoft.UI.Xaml;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Yugen.MotoGP.App.Services
{
    public class LiveTimingService
    {
        public EventHandler<JsonElement> LiveTimingChanged;

        private readonly HttpClientService _httpClientService;

        private DispatcherTimer dispatcherTimer;

        public LiveTimingService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public int CurrentEventId { get; private set; } = 687;

        public void Initialize(int currentEventId)
        {
            CurrentEventId = currentEventId;
        }

        public void Initialize()
        {
            SetTimer();

            _ = GetLiveTiming();
        }

        private void SetTimer()
        {
            dispatcherTimer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 5)
            };
            dispatcherTimer.Tick += async (s, e) => await GetLiveTiming();
            dispatcherTimer.Start();
        }

        private async Task GetLiveTiming()
        {
            var response = await _httpClientService.GetLiveTiming(CurrentEventId);

            using var jsonDocument = JsonDocument.Parse(response);
            var ltJsonElement = jsonDocument
                .RootElement
                .GetProperty("lt");

            LiveTimingChanged?.Invoke(this, ltJsonElement);
        }
    }
}