using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Models.Profile
{
    using Newtonsoft.Json;

    using WinPhone.MyShows.Attributes;
    using WinPhone.MyShows.Helpers;
    using WinPhone.MyShows.Models.Shows;

    public class UserShow : BaseShow
    {
        [JsonProperty("showId")]
        public override long Id { get; set; }

        [JsonProperty("watchStatus")]
        public string WatchStatus { get; set; }

        public ShowStatus Status
        {
            get
            {
                return Enum.GetValues(typeof(ShowStatus))
                    .Cast<ShowStatus>()
                    .FirstOrDefault(status => status.GetAttribute<DisplayAttribute>().Name == this.WatchStatus);
            }
        }

        [JsonProperty("watchedEpisodes")]
        public int WatchedEpisodes { get; set; }
        
    }
}
