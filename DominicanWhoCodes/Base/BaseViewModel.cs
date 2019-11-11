using System;
using System.Collections;
using DominicanWhoCodes.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace DominicanWhoCodes.Base
{
    public class BaseViewModel : ReactiveObject, IRoutableViewModel
    {
        public RoutingState Router { get; protected set; }

        [Reactive]
        public string Title { get; set; }

        [Reactive]
        public bool IsBusy { get; set; }

        public BaseViewModel(IScreen hostScreen = null)
        {
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }

        public string UrlPathSegment { get; protected set; }

        public IScreen HostScreen { get; protected set; }

        public void NavigateToPage(IRoutableViewModel routableViewModel, bool cleanNavigationStack = false)
        {
            if (cleanNavigationStack)
            {
                HostScreen
                    .Router
                    .NavigateAndReset
                    .Execute(routableViewModel)
                    .Subscribe();
            }
            else
            {
                HostScreen
                    .Router
                    .Navigate
                    .Execute(routableViewModel)
                    .Subscribe();
            }
        }

        public void NavigateBack()
        {
            HostScreen
                .Router
                .NavigateBack
                .Execute()
                .Subscribe();
        }

        public void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
        {
            lock (collection)
            {
                accessMethod?.Invoke();
            }
        }
    }
}

