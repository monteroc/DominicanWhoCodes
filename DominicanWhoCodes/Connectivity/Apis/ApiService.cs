using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DominicanWhoCodes.Helpers;
using DominicanWhoCodes.Keys;
using DominicanWhoCodes.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace DominicanWhoCodes.Connectivity.Apis
{
    public class ApiService : IApiService
    {
        private readonly string _apiBaseAddress;
        private readonly HttpClient _client;

        public IDWCApi DWCApi { get; set; }
        public ApiService()
        {
            _apiBaseAddress = GetUrl();

            _client = _client ?? new HttpClient()
            {
                BaseAddress = new Uri(_apiBaseAddress),
                Timeout = TimeSpan.FromSeconds(20)
            };

            DWCApi = RestService.For<IDWCApi>(_client, new RefitSettings
            {
                ContentSerializer = new JsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            });
        }
        private string GetUrl()
        {
            var urlAttribute = (UrlAttribute)Attribute.GetCustomAttribute(typeof(IDWCApi), typeof(UrlAttribute));

            return urlAttribute.Url;
        }
    }
}
