using System.Collections.Generic;
using System.Linq;
using Yugen.MotoGP.App.Models.Calendar;

namespace Yugen.MotoGP.App.Helpers
{
    public static class AssetsHelper
    {
        //private static Dictionary<double, string> _scaleQualityMap;
        //private static string[] qualityMap = { "@1x", "@2x", "@3x", "@4x" };

        /// <summary>
        /// DisplayInformation is no longer supported in WinUI 3 desktop
        /// (https://github.com/microsoft/microsoft-ui-xaml/issues/4228)
        /// Until we find a way to determinate the DPI in WinUI3, we'll
        /// just return the best quality found.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDpiAwareAssetPath(IList<Asset> asset, string type)
        {
            type = type.ToLowerInvariant();
            var typeFiltered = asset
                .Where(x => x.Type.ToLowerInvariant() == type)
                .ToArray();

            if (typeFiltered.Length > 0)
            {
                return typeFiltered[typeFiltered.Length - 1].Path;
            }
            return "https://www.logolynx.com/images/logolynx/e5/e52be09dec76f183a1e48b11752d4122.png";

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