using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GithubService.Models
{
    [Serializable]
    public class GithubCardModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("avatar_url")]
        public string Avatar_url { get; set; }
        [JsonProperty("isbookmarked")]
        public bool Isbookmarked { get; set; }
    }
}