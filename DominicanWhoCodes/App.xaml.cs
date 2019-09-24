using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DominicanWhoCodes
{
    public partial class App : Application
    {
        AppBootstrapper bootstrapper;
        public App()
        {
            InitializeComponent();           
        }

        protected override  void OnStart()
        {
            bootstrapper = new AppBootstrapper();

            MainPage = bootstrapper.CreateMainPage();
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
