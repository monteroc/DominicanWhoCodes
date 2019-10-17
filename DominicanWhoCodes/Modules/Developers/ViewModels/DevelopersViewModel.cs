using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DominicanWhoCodes.Base;
using DominicanWhoCodes.Connectivity.Apis;
using DominicanWhoCodes.Models;
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

        [Reactive]
        public ObservableCollection<Developer> Developers { get; set; }

        public DevelopersViewModel(IApiService apiService)
        {
            _apiService = apiService;
           
            LoadData();
        }

        public async void LoadData()
        {
            Title = "DominicanWho.Codes";

            var data = await _apiService.DWCApi.GetDevelopers();          
            Developers =new ObservableCollection<Developer>(data);
        }
    }
}

