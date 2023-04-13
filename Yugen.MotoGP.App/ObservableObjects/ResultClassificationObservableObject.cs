using CommunityToolkit.Mvvm.ComponentModel;
using Yugen.MotoGP.App.Models.Base;
using Yugen.MotoGP.App.Models.Results.Classification;

namespace Yugen.MotoGP.App.ObservableObjects
{
    public partial class ResultClassificationObservableObject : ObservableObject, IPosition
    {
        private Classification _model;

        public ResultClassificationObservableObject(Classification model)
        {
            _model = model;
        }

        public string Id => _model.Id;

        public int Position => _model.Position ?? 0;

        public int Number => _model.Rider.Number;

        public string FullName => _model.Rider?.FullName;

        public string TeamName => _model.Team?.Name;

        public string Country => _model.Rider?.Country?.Name;

        public int Points => _model.Points;
    }
}