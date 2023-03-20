using CommunityToolkit.WinUI.UI;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yugen.MotoGP.App.Services
{
    public static class ImageCacheService
    {
        static ImageCacheService()
        {
            ImageCache.Instance.CacheDuration = TimeSpan.FromHours(24);
        }

        public static async Task<BitmapImage> GetFromCacheAsync(Uri uri)
        {
            try
            {
                return await ImageCache.Instance.GetFromCacheAsync(uri);
            }
            catch 
            {
                return null;
            }

        }
    }
}
