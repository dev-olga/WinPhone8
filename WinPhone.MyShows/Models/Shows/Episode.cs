using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Models.Shows
{
    using Newtonsoft.Json;

    //using WinPhone.Interfaces.Models.Shows;

    public class Episode /*: IEpisode*/
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        //[JsonProperty("airDate")]
        //public DateTime? AirDate { get; set; }
            
        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("tvrageLink")]
        public string TvRageLink { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("seasonNumber")]
        public int SeasonNumber { get; set; }

        [JsonProperty("episodeNumber")]
        public int EpisodeNumber { get; set; }

        [JsonProperty("productionNumber")]
        public string ProductionNumber { get; set; }

        [JsonProperty("sequenceNumber")]
        public int? SequenceNumber { get; set; }
            
    }
}
