using CommunityToolkit.Mvvm.ComponentModel;
using System.Globalization;
using Yugen.MotoGP.App.Helpers;
using Yugen.MotoGP.App.Models.Calendar;

namespace Yugen.MotoGP.App.ObservableObjects
{
    public class EventObservableObject : ObservableObject
    {
        private Event _event;

        public EventObservableObject(Event eventModel)
        {
            _event = eventModel;
        }

        public string Name => _event.Name;

        public string Hashtag => _event.Hashtag;

        public string CardPath => AssetsHelper.GetDPIAwaredAssetPath(_event.Assets, "card");

        public string FlagPath => AssetsHelper.GetDPIAwaredAssetPath(_event.Assets, "flag");

        public string StartDay => _event.DateStart.Day.ToString("00");

        public string StartMonth => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(_event.DateStart.Month).ToUpperInvariant();

        public string StartDate => _event.DateStart.ToString();

        public string Kind => _event.Kind;

        public string CircuitName => _event.Circuit?.Name ?? string.Empty;

        public string CircuitCountry => _event.Circuit?.Country?.ToUpperInvariant() ?? string.Empty;
    }
}