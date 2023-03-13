using System;
using System.Collections.Generic;
using Yugen.MotoGP.App.Models.LiveTiming;

namespace Yugen.MotoGP.App.Models.Args;

public class LiveTimingEventArgs : EventArgs
{
    public LiveTimingEventArgs(Head head, IEnumerable<RiderDetails> riderDetails)
    {
        Head = head;
        RiderDetailsList = riderDetails;
    }

    public Head Head { get; }

    public IEnumerable<RiderDetails> RiderDetailsList { get; }
}