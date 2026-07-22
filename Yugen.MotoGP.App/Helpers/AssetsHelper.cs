using System.Collections.Generic;
using System.Linq;
using Yugen.MotoGP.App.Models.Event;

namespace Yugen.MotoGP.App.Helpers;

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
    public static string GetDpiAwareAssetPath(IList<AssetDto> asset, AssetType type)
    {
        var path = "https://www.motociclismo.es/uploads/s1/13/79/68/14/motogp-logo-white.jpeg";

        var typeFiltered = asset
            .Where(x => string.Equals(x.Type, type.ToString(), System.StringComparison.InvariantCultureIgnoreCase))
            .ToArray();

        if (typeFiltered.Length == 1)
        {
            path = typeFiltered[0].Path;
        }

        if (typeFiltered.Length > 1)
        {
            //var _displayInformation = DisplayInformation.GetForCurrentView();
            //var dpi = (int)_displayInformation.RawPixelsPerViewPixel;
            //while (dpi > typeFiltered.Length)
            //{
            //    dpi--;
            //}
            path = typeFiltered.FirstOrDefault(x => x.Quality == "@2x")?.Path ?? path;
        }

        return path;
    }
}