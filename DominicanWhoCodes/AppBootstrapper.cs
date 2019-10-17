using System;
using System.Threading.Tasks;
using DominicanWhoCodes.Connectivity.Apis;
using DominicanWhoCodes.Modules.Developers.ViewModels;
using DominicanWhoCodes.Modules.Developers.Views;
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
           
            // Views and ViewModels
            Locator.CurrentMutable.Register(() => new DevelopersPage(), typeof(IViewFor<DevelopersViewModel>));
        }

        public Page CreateMainPage()
        {
            var apiService = Locator.Current.GetService<IApiService>();

            NavigateToMainPage(apiService);

            return new ReactiveUI.XamForms.RoutedViewHost();
        }

        public void NavigateToMainPage(IApiService apiService = null)
        {
            Router = new RoutingState();

            Router
                .NavigateAndReset
                .Execute(new DevelopersViewModel(apiService))
                .Subscribe();
        }

    }
}
