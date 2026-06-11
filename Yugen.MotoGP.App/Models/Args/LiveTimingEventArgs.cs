using System;
using System.Collections.Generic;
using System.Linq;
using Yugen.MotoGP.App.Models.LiveTimingLites;

namespace Yugen.MotoGP.App.Models.Args;

public class LiveTimingEventArgs : EventArgs
{
	public LiveTimingEventArgs(Head head, IEnumerable<RiderDetails> riderDetails)
	{
		Head = head;
		RiderDetailsList = riderDetails.ToList();
	}

	public Head Head { get; }

	public IEnumerable<RiderDetails> RiderDetailsList { get; }
}