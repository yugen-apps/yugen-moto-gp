using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Base;
using Yugen.MotoGP.App.Models.WorldStanding;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class ClassificationViewModel: ObservableObject, IPosition
    {
        private Classification _model;
        
        public string Id => _model.Id;

        public int Position => _model.Position;

        public int Number => _model.Rider.Number;
        
        public string FullName => _model.Rider?.FullName;

        public string TeamName => _model.Team?.Name;

        public string Country => _model.Rider?.Country?.Name;

        public int Points => _model.Points;

        public ClassificationViewModel(Classification model)
        {
            _model = model;
        }

    }
}
