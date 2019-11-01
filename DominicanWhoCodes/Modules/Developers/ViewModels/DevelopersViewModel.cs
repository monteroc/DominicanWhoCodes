using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using DominicanWhoCodes.Base;
using DominicanWhoCodes.Config;
using DominicanWhoCodes.Connectivity.Apis;
using DominicanWhoCodes.Models;
using DominicanWhoCodes.PlatformApis;
using DominicanWhoCodes.Services;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using Xamarin.Forms;

namespace DominicanWhoCodes.Modules.Developers.ViewModels
{
    public class DevelopersViewModel : BaseViewModel
    {
        private readonly IApiService _apiService;
        private readonly IStatusBarConfig _statusBarConfig;

        [Reactive]
        public ObservableCollection<Developer> Developers { get; set; }

        [Reactive]
        public Developer SelectedDeveloper { get; set; }

        public DevelopersViewModel(IApiService apiService, IStatusBarConfig statusBarConfig)
        {
            _apiService = apiService;
            _statusBarConfig = statusBarConfig;
            
            LoadData();
            RegisterEvents();
        }

        public async void LoadData()
        {
            Title = AppConstant.AppName;

            var data = await _apiService.DWCApi.GetDevelopers();
            Developers = new ObservableCollection<Developer>(data);
        }

        private void RegisterEvents()
        {
            this.WhenAnyValue(x => x.SelectedDeveloper)
                .Where(x => x != null)
                .Subscribe(NavigateToDeveloperDetailPage);
        }

        public void UpdateStatusbar()=> _statusBarConfig.DisableFloatingStatusBar();     

        private void NavigateToDeveloperDetailPage(Developer developer) => NavigateToPage(new DeveloperDetailsViewModel(developer, _statusBarConfig));
    }
}