using System;
using System.Threading.Tasks;
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

           
            // Views and ViewModels
            Locator.CurrentMutable.Register(() => new DevelopersPage(), typeof(IViewFor<DevelopersViewModel>));
        }

        public Page CreateMainPage()
        {
            NavigateToMainPage();

            return new ReactiveUI.XamForms.RoutedViewHost();
        }

        public void NavigateToMainPage()
        {
            Router = new RoutingState();

            Router
                .NavigateAndReset
                .Execute(new DevelopersViewModel())
                .Subscribe();
        }

    }
}
