using DominicanWhoCodes.iOS.PlatformApis;
using DominicanWhoCodes.PlatformApis;
using Xamarin.Forms.PlatformConfiguration;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarConfig))]
namespace DominicanWhoCodes.iOS.PlatformApis
{
    public class StatusBarConfig : IStatusBarConfig
    {

        public void EnableFloatingStatusBar()
        {
        }

        public void DisableFloatingStatusBar()
        {
        }
    }
}