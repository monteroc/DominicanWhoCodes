using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DominicanWhoCodes.Services
{
    public class EssentialsService:IEssentialsService
    {
        public async Task OpenBrowserAsync(Uri uri)
        {
           await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}
