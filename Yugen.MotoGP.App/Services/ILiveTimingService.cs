using System;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Args;

namespace Yugen.MotoGP.App.Services
{
    public interface ILiveTimingService
    {
        event EventHandler<LiveTimingEventArgs> LiveTimingChanged;

        Task Initialize();

        void DeInitialize();
    }
}