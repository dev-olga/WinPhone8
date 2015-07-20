using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Models.Profile
{
    using Newtonsoft.Json;

    public class Statistic
    {
        [JsonProperty("watchedHours")]
        public double WatchedHours { get; set; }

        [JsonProperty("remainingHours")]
        public double RemainingHours { get; set; }

        [JsonProperty("watchedEpisodes")]
        public int WatchedEpisodes { get; set; }

        [JsonProperty("remainingEpisodes")]
        public int RemainingEpisodes { get; set; }

        [JsonProperty("totalEpisodes")]
        public int TotalEpisodes { get; set; }

        [JsonProperty("totalDays")]
        public double TotalDays { get; set; }

        [JsonProperty("totalHours")]
        public double TotalHours { get; set; }

        [JsonProperty("remainingDays")]
        public double RemainingDays { get; set; }

        [JsonProperty("watchedDays")]
        public double WatchedDays { get; set; }
    }
}
