using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DominicanWhoCodes.Helpers;
using DominicanWhoCodes.Keys;
using DominicanWhoCodes.Models;
using Refit;
using Xamarin.Forms;

namespace DominicanWhoCodes.Connectivity.Apis
{
    [Url(Constants.BaseApiUrl)]
    public interface IDWCApi
    {
        //The GET param is empty because we are using a temporary API Url dirict to the json file.
        [Get("")]
        Task<IEnumerable<Developer>> GetDevelopers();
    }


}
