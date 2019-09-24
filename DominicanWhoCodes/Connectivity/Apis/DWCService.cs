using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DominicanWhoCodes.Keys;
using DominicanWhoCodes.Models;
using Refit;

namespace DominicanWhoCodes.Connectivity.Apis
{
    public class DWCService : IDWCApi
    {
        public async Task<string> GetDeveloperPic(string picPath)
        {
            var _dwcApi = RestService.For<IDWCApi>(Constants.BaseUrl);

            return await _dwcApi.GetDeveloperPic(picPath);
        }

        public async Task<IEnumerable<Developer>> GetDevelopers()
        {
            var _dwcApi = RestService.For<IDWCApi>(Constants.BaseApiUrl);

            return await _dwcApi.GetDevelopers();
        }
    }
}
