using System;
using System.Reactive;
using DominicanWhoCodes.Base;
using DominicanWhoCodes.Connectivity.Apis;
using DominicanWhoCodes.Models;
using DominicanWhoCodes.PlatformApis;
using DominicanWhoCodes.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DominicanWhoCodes.Modules.Developers.ViewModels
{
    public class DeveloperDetailsViewModel : BaseViewModel
    {
        private readonly IStatusBarConfig _statusBarConfig;
        private readonly IEssentialsService _essentialsService;

        [Reactive]
        public Developer Developer { get; set; }

        public ReactiveCommand<string, Unit> NavigateToSocialUrlCommand { get; set; }

        public ReactiveCommand<Unit, Unit> BackButtonCommand { get; set; }

        public DeveloperDetailsViewModel(Developer developer, IStatusBarConfig statusBarConfig, IEssentialsService essentialsService = null)
        {
            Developer = developer;
            _statusBarConfig = statusBarConfig;
            _essentialsService = essentialsService ?? Locator.Current.GetService<IEssentialsService>();
            
            Load();
            RegisterCommands();
        }
        
        private void Load()
        {
            _statusBarConfig.EnableFloatingStatusBar();
        }

        private void RegisterCommands()
        {
            BackButtonCommand = ReactiveCommand.Create(NavigateBack);
            NavigateToSocialUrlCommand = ReactiveCommand.Create<string>(async (x) => await _essentialsService.OpenBrowserAsync(new Uri(x)));
        }
    }
}

