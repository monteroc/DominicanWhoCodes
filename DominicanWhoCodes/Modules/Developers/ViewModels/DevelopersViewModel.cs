using System;
using System.Collections;
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
using DynamicData.Binding;
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
        public Developer SelectedDeveloper { get; set; }

        public ObservableCollection<Developer> Developers { get; } = new ObservableCollection<Developer>();

        public DevelopersViewModel(IApiService apiService, IStatusBarConfig statusBarConfig)
        {
            _apiService = apiService;
            _statusBarConfig = statusBarConfig;

            SetCollectionThreadSafe(Developers);

            LoadData();
            RegisterEvents();
        }

        private void SetCollectionThreadSafe<T>(ObservableCollection<T> collection) => BindingBase.EnableCollectionSynchronization(collection, null, ObservableCollectionCallback);

        public async void LoadData()
        {
            Title = AppConstant.AppName;

            IsBusy = true;

            await GetDevelopersAsync();

            IsBusy = false;
        }

        private void RegisterEvents()
        {
            this.WhenAnyValue(x => x.SelectedDeveloper)
                .Where(x => x != null)
                .Subscribe(NavigateToDeveloperDetailPage);
        }

        private async Task GetDevelopersAsync()
        {
            var _developers = LoadDevelopersAsync().ConfigureAwait(true);

            await foreach (var dev in _developers)
            {
                InsertIntoCollection(Developers, dev);
            }
        }

        private void NavigateToDeveloperDetailPage(Developer developer) => NavigateToPage(new DeveloperDetailsViewModel(developer, _statusBarConfig));

        private void InsertIntoCollection<T>(in ObservableCollection<T> collection, in T modelToInsert) => collection.Add(modelToInsert);

        private async IAsyncEnumerable<Developer> LoadDevelopersAsync()
        {
            var data = await _apiService.DWCApi.GetDevelopers().ConfigureAwait(false);

            var index = 0;
            var _count = data.Count();

            while (data.Any() && _count > 0)
            {
                yield return data.ElementAt(index);
                index++;
                _count--;
            }
        }

        public void UpdateStatusbar() => _statusBarConfig.DisableFloatingStatusBar();
    }
}