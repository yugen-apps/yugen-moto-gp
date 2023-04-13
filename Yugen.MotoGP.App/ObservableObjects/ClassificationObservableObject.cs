using CommunityToolkit.Mvvm.ComponentModel;
using Yugen.MotoGP.App.Models.Base;
using Yugen.MotoGP.App.Models.Results.WorldStanding;

namespace Yugen.MotoGP.App.ObservableObjects
{
    public partial class ClassificationObservableObject : ObservableObject, IPosition
    {
        private Classification _model;

        public ClassificationObservableObject(Classification model)
        {
            _model = model;
        }

        public string Id => _model.Id;

        public int Position => _model.Position;

        public int Number => _model.Rider.Number;

        public string FullName => _model.Rider?.FullName;

        public string TeamName => _model.Team?.Name;

        public string Country => _model.Rider?.Country?.Name;

        public int Points => _model.Points;
    }
}