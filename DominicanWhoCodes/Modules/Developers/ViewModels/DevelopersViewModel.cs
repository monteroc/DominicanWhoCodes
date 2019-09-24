using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DominicanWhoCodes.Base;
using DominicanWhoCodes.Connectivity.Apis;
using ReactiveUI;
using Splat;
using Xamarin.Forms;

namespace DominicanWhoCodes.Modules.Developers.ViewModels
{
    public class DevelopersViewModel : BaseViewModel
    {
        private readonly IApiService _apiService;

        private string _welcomeText;
        public string WelcomeText
        {
            get => _welcomeText;
            set => this.RaiseAndSetIfChanged(ref _welcomeText, value);
        }

        public DevelopersViewModel(IApiService apiService)
        {
            _apiService = apiService;

            DisplayDominicanDevelopersCount();
        }

        public async void DisplayDominicanDevelopersCount()
        {
            var data = await _apiService.DWCApi.GetDevelopers();

            WelcomeText = $"We have {data?.Count()} developers registered.";
        }
    }
}

