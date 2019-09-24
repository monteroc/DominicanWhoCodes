using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominicanWhoCodes.Connectivity.Apis;
using DominicanWhoCodes.Keys;
using DominicanWhoCodes.Models;
using Refit;
using Xamarin.Forms;

namespace DominicanWhoCodes
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            var data = await GetDevelopers();
        }

        async Task<IEnumerable<Developer>> GetDevelopers()
        {
            var _dwcApi = RestService.For<IDWCApi>(Constants.BaseApiUrl);

            return await _dwcApi.GetDevelopers();
        }
    }
}
