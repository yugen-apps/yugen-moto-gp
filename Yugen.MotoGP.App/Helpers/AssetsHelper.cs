using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Yugen.MotoGP.App.Models;

namespace Yugen.MotoGP.App.Helpers
{
    public static class AssetsHelper
    {
        private static Dictionary<double, string> _scaleQualityMap;
        private static string[] qualityMap = { "@1x", "@2x", "@3x", "@4x" };

        public static string GetDPIAwaredAssetPath(Asset[] asset, string type)
        {
            /* DisplayInformation is no longer supported in WinUI 3 desktop 
             * (https://github.com/microsoft/microsoft-ui-xaml/issues/4228)
             * Until we find a way to determinate the DPI in WinUI3, we'll 
             * just return the best quality found.
             */

            type = type.ToLowerInvariant();
            var typeFiltered = asset
                .Where(x => x.type.ToLowerInvariant() == type)
                .ToArray();

            if (typeFiltered.Length > 0)
            {
                return typeFiltered[typeFiltered.Length - 1].path;
            }
            return null;

            //if (typeFiltered.Length == 1)
            //{
            //    return typeFiltered[0].path;
            //}
            //var _displayInformation = DisplayInformation.GetForCurrentView();
            //var dpi = (int)_displayInformation.RawPixelsPerViewPixel;
            //while (dpi > typeFiltered.Length)
            //{
            //    dpi--;
            //}
            //return typeFiltered[dpi].path;
        }
    }
}
