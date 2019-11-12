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
        private IEnumerable<Developer> _developersContainer;

        public ObservableCollection<Developer> Developers { get; } = new ObservableCollection<Developer>();

        [Reactive]
        public Developer SelectedDeveloper { get; set; }

        [Reactive]
        public string SearchText { get; set; }

        public DevelopersViewModel(IApiService apiService, IStatusBarConfig statusBarConfig)
        {
            _apiService = apiService;
            _statusBarConfig = statusBarConfig;

            SetCollectionThreadSafe(Developers);

            LoadData();
            RegisterEvents();
        }

        private void SetCollectionThreadSafe<T>(ObservableCollection<T> collection) => BindingBase.EnableCollectionSynchronization(collection, null, ObservableCollectionCallback);

        public  void LoadData()
        {
            Title = AppConstant.AppName;

            IsBusy = true;

            GetDevelopersAsync().ConfigureAwait(false);

            IsBusy = false;
        }

        private void RegisterEvents()
        {
            this.WhenAnyValue(x => x.SelectedDeveloper)
                .Where(x => x != null)
                .Subscribe(NavigateToDeveloperDetailPage);

            this.WhenAnyValue(x => x.SearchText)
                            .Subscribe(FilterDeveloper);
        }

        private async Task GetDevelopersAsync()
        {
            var _developers = LoadDevelopersAsync().ConfigureAwait(false);

            await foreach (var dev in _developers)
            {
                InsertIntoCollection(Developers, dev);
            }
        }

        private async IAsyncEnumerable<Developer> LoadDevelopersAsync()
        {
            var data = await _apiService.DWCApi.GetDevelopers();

            var index = 0;
            var _count = data.Count();

            _developersContainer = data;
            while (data.Any() && _count > 0)
            {
                yield return data.ElementAt(index);
                index++;
                _count--;
            }
        }

        private void FilterDeveloper(string name)
        {
            var _data = _developersContainer;
            var showAll = string.IsNullOrWhiteSpace(name);

            if (_data != null)
            {
                Developers.Clear();
                var _filteredList = _data.Where(x => showAll || x.Name.ToLower().Contains(name.ToLower()));

                foreach (var dev in _filteredList)
                {
                    InsertIntoCollection(Developers, dev);
                }
            }
        }

        private void NavigateToDeveloperDetailPage(Developer developer) => NavigateToPage(new DeveloperDetailsViewModel(developer, _statusBarConfig));

        private void InsertIntoCollection<T>(in ObservableCollection<T> collection, in T modelToInsert) => collection.Add(modelToInsert);

        public void UpdateStatusbar() => _statusBarConfig.DisableFloatingStatusBar();
    }
}
