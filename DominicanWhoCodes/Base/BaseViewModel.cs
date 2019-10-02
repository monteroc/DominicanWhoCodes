using System;
using ReactiveUI;
using Splat;

namespace DominicanWhoCodes.Base
{
    public class BaseViewModel : ReactiveObject, IRoutableViewModel
    {
        public RoutingState Router { get; protected set; }

        public BaseViewModel(IScreen hostScreen = null)
        {
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }

        public string UrlPathSegment
        {
            get;
            protected set;
        }

        public IScreen HostScreen
        {
            get;
            protected set;
        }


        public void NavigateToPage(IRoutableViewModel routableViewModel, bool cleanNavigationStack = false)
        {
            Router = new RoutingState();

            if (cleanNavigationStack)
            {
                Router
                    .NavigateAndReset
                    .Execute(routableViewModel)
                    .Subscribe();
            }
            else
            {
                Router
                    .Navigate
                    .Execute(routableViewModel)
                    .Subscribe();
            }
        }

        public void NavigateBak()
        {
            Router = new RoutingState();

            Router
                .NavigateBack
                .Execute()
                .Subscribe();
        }
    }
}

