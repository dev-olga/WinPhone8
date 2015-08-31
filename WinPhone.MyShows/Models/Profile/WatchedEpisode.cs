using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Models.Profile
{
    using Newtonsoft.Json;

    public class WatchedEpisode
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("watchDate")]
        public string WatchDate { get; set; }

        [JsonProperty("rating")]
        public double? Rating { get; set; }
    }
}
