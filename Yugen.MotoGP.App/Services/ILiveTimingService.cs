using System;
using Yugen.MotoGP.App.Models.Args;

namespace Yugen.MotoGP.App.Services
{
    public interface ILiveTimingService
    {
        event EventHandler<LiveTimingEventArgs> LiveTimingChanged;

        void Initialize(int? eventId = null);
    }
}