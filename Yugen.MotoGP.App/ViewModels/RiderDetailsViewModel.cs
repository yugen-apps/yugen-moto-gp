using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Base;
using Yugen.MotoGP.App.Models.LiveTiming;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class RiderDetailsViewModel: ObservableObject, IPosition
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

        public RiderDetailsViewModel(RiderDetails model)
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
