using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;
using Yugen.MotoGP.App.Constants;
using Yugen.MotoGP.App.Helpers;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.LiveTimingLites;
using Yugen.MotoGP.App.Services.HttpClientService;

namespace Yugen.MotoGP.App.Services.LiveTimingService;

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

        if (string.IsNullOrWhiteSpace(response))
        {
            return;
        }

        using var jsonDocument = JsonDocument.Parse(response);

        var head = jsonDocument
            .RootElement
            .GetProperty("head")
            .Deserialize<Head>(AppConstants.JsonSerializerOptions);

        var riderJsonElement = jsonDocument
            .RootElement
            .GetProperty("rider");

        var riderDtoList = riderJsonElement
            .Clone()
            .EnumerateObject()
            .Select(riderJson => riderJson.Value.Deserialize<RiderDto>());


        if (SessionStatusHelper.GetSessionStatus(head.SessionStatusId) == SessionStatus.Finished)
        {
            _timer.Stop();
        }
        else
        {
            _timer.Start();
        }

        LiveTimingChanged?.Invoke(this, new LiveTimingEventArgs(head, riderDtoList));
    }
}