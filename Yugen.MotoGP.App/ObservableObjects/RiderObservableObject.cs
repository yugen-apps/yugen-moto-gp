using CommunityToolkit.Mvvm.ComponentModel;
using Yugen.MotoGP.App.Models.Base;
using Yugen.MotoGP.App.Models.LiveTimingLites;

namespace Yugen.MotoGP.App.ObservableObjects;

public partial class RiderObservableObject : ObservableObject, IPosition
{
    [ObservableProperty]
    public partial int RiderId { get; set; }

    [ObservableProperty]
    public partial string Name { get; set; }

    [ObservableProperty]
    public partial string Surname { get; set; }

    [ObservableProperty]
    public partial string Number { get; set; }

    [ObservableProperty]
    public partial bool OnPit { get; set; }

    [ObservableProperty]
    public partial int Position { get; set; }

    [ObservableProperty]
    public partial string LastLapTime { get; set; }

    [ObservableProperty]
    public partial string LapTime { get; set; }

    [ObservableProperty]
    public partial int NumLap { get; set; }

    [ObservableProperty]
    public partial int LastLap { get; set; }

    [ObservableProperty]
    public partial string GapPrev { get; set; }

    [ObservableProperty]
    public partial string GapFirst { get; set; }

    public RiderObservableObject(RiderDto model)
    {
        RiderId = model.RiderId;
        Name = model.RiderName;
        Surname = model.RiderSurname;
        Number = model.RiderNumber;
        Position = model.Pos;
        OnPit = model.OnPit;
        LastLapTime = model.LastLapTime;
        LapTime = model.LapTime;
        NumLap = model.NumLap;
        LastLap = model.LastLap;
        GapPrev = model.GapPrev;
        GapFirst = model.GapFirst;
    }

    int IPosition.Position => Position;
}