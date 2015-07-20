using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Models.Profile
{
    using Newtonsoft.Json;

    using WinPhone.MyShows.Models.Shows;

    public class UserShow : BaseShow
    {
        [JsonProperty("showId")]
        public long ShowId { get; set; }

        [JsonProperty("watchStatus")]
        public string WatchStatus { get; set; }

        [JsonProperty("watchedEpisodes")]
        public int WatchedEpisodes { get; set; }
        
    }
}
