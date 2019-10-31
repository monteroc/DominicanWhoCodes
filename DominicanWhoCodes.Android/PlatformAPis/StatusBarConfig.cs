using Android.App;
using Android.Views;
using DominicanWhoCodes.Droid.PlatformAPis;
using DominicanWhoCodes.PlatformApis;
using Plugin.CurrentActivity;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarConfig))]
namespace DominicanWhoCodes.Droid.PlatformAPis
{
    public class StatusBarConfig : IStatusBarConfig
    {
        public FormsAppCompatActivity Activity => CrossCurrentActivity.Current.Activity as FormsAppCompatActivity;

        public void EnableFloatingStatusBar()
        {
            Activity.Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            Activity.SetStatusBarColor(Android.Graphics.Color.Transparent);            
        }

        public void DisableFloatingStatusBar()
        {
            Activity.SetStatusBarColor(Android.Graphics.Color.White);            
        }
    }
}