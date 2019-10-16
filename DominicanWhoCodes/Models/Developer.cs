using System;
using DominicanWhoCodes.Keys;
using Newtonsoft.Json;

namespace DominicanWhoCodes.Models
{
    public class Developer
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        [JsonProperty("image")]
        public string RelativeImageUrl { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }
        public string Webpage { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string Github { get; set; }

        public string AbsoluteImageUrl => $"{Constants.BaseUrl}{RelativeImageUrl}";
    }
}
