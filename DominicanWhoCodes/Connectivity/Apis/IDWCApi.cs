using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DominicanWhoCodes.Keys;
using DominicanWhoCodes.Models;
using Refit;
using Xamarin.Forms;

namespace DominicanWhoCodes.Connectivity.Apis
{
    public interface IDWCApi
    {
        [Get("/dominicanwhocodes")]
        Task<IEnumerable<Developer>> GetDevelopers();

        [Get("/{picPath}")]
        Task<string> GetDeveloperPic(string picPath);
    }


}
