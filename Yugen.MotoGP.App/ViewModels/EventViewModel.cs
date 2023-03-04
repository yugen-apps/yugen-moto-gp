using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Helpers;
using Yugen.MotoGP.App.Models;

namespace Yugen.MotoGP.App.ViewModels
{
    public class EventViewModel : ObservableObject
    {
        private Event _event;

        public EventViewModel(Event eventModel)
        {
            _event = eventModel;
        }

        public string Name => _event.name;

        public string Hashtag => _event.hashtag;

        public string CardPath => AssetsHelper.GetDPIAwaredAssetPath(_event.assets, "card");

        public string FlagPath => AssetsHelper.GetDPIAwaredAssetPath(_event.assets, "flag");

        public string StartDay => _event.date_start.Day.ToString("00");

        public string StartMonth => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(_event.date_start.Month).ToUpperInvariant();

        public string StartDate => _event.date_start.ToString();

        public string Kind => _event.kind;

        public string CircuitName => _event.circuit.name;

        public string CircuitCountry => _event.circuit.country.ToUpperInvariant();
    }
}
