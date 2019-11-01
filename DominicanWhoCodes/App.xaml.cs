using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace DominicanWhoCodes
{
    public partial class App : Xamarin.Forms.Application
    {
        AppBootstrapper bootstrapper;
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            bootstrapper = new AppBootstrapper();

            var mainPage = (Xamarin.Forms.NavigationPage)bootstrapper.CreateMainPage();

            MainPage = mainPage;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
