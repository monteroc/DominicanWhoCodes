using System;
using System.Threading.Tasks;
using DominicanWhoCodes.Connectivity.Apis;
using DominicanWhoCodes.Modules.Developers.ViewModels;
using DominicanWhoCodes.Modules.Developers.Views;
using DominicanWhoCodes.PlatformApis;
using DominicanWhoCodes.Services;
using ReactiveUI;
using Refit;
using Splat;
using Xamarin.Forms;

namespace DominicanWhoCodes
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public RoutingState Router { get; protected set; }

        public AppBootstrapper()
        {
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            // IScreen 
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

            //Services
            Locator.CurrentMutable.RegisterLazySingleton(() => new ApiService(), typeof(IApiService));
            Locator.CurrentMutable.RegisterLazySingleton(() => new EssentialsService(), typeof(IEssentialsService));

            // Views and ViewModels
            Locator.CurrentMutable.Register(() => new DevelopersPage(), typeof(IViewFor<DevelopersViewModel>));
            Locator.CurrentMutable.Register(() => new DeveloperDetailsPage(), typeof(IViewFor<DeveloperDetailsViewModel>));
        }

        public Page CreateMainPage()
        {
            var apiService = Locator.Current.GetService<IApiService>();
            var statusBarConfig = DependencyService.Get<IStatusBarConfig>();

            NavigateToMainPage(apiService,statusBarConfig);

            return new ReactiveUI.XamForms.RoutedViewHost();
        }

        public void NavigateToMainPage(IApiService apiService, IStatusBarConfig statusBarConfig)
        {
            Router = new RoutingState();

            Router
                .NavigateAndReset
                .Execute(new DevelopersViewModel(apiService, statusBarConfig))
                .Subscribe();
        }

    }
}
