using CommunityToolkit.Mvvm.ComponentModel;
using Yugen.MotoGP.App.Models.Base;
using Yugen.MotoGP.App.Models.LiveTiming;

namespace Yugen.MotoGP.App.ObservableObjects
{
    public partial class RiderDetailsObservableObject : ObservableObject, IPosition
    {
        [ObservableProperty]
        private string _riderId;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _surname;

        [ObservableProperty]
        private string _number;

        [ObservableProperty]
        private string _onPit;

        [ObservableProperty]
        private string _position;

        [ObservableProperty]
        private string _lastLapTime;

        [ObservableProperty]
        private string _lapTime;

        [ObservableProperty]
        private string _numLap;

        [ObservableProperty]
        private string _lastLap;

        [ObservableProperty]
        private string _gapPrev;

        [ObservableProperty]
        private string _gapFirst;

        public RiderDetailsObservableObject(RiderDetails model)
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

        int IPosition.Position
        {
            get
            {
                if (int.TryParse(Position, out int pos))
                {
                    return pos;
                }
                return 0;
            }
        }
    }
}