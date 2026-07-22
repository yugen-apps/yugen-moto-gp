using System;
using System.Collections.Generic;
using System.Linq;
using Yugen.MotoGP.App.Models.LiveTimingLites;

namespace Yugen.MotoGP.App.Models.Args;

public class LiveTimingEventArgs : EventArgs
{
    public LiveTimingEventArgs(Head head, IEnumerable<RiderDto> riderDtos)
    {
        Head = head;
        RiderDtoList = riderDtos.ToList();
    }

    public Head Head { get; }

    public IEnumerable<RiderDto> RiderDtoList { get; }
}