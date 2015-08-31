using System;

namespace WinPhone.MyShows.Models.Shows
{
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    //using WinPhone.Interfaces.Models.Shows;

    public class ShowInfo : BaseShow/*, IShowInfo*/
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("watching")]
        public long? Watching { get; set; }

        [JsonProperty("voted")]
        public long? Voted { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("kinopoiskId")]
        public int? KinopoiskId { get; set; }

        [JsonProperty("tvrageId")]
        public int? TvrageId { get; set; }

        [JsonProperty("imdbId")]
        public int? ImdbId { get; set; }

        [JsonProperty("started")]
        public DateTime Started { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("episodes")]
        public Dictionary<long, Episode> Episodes { get; set; }

        //public List<IEpisode> Episodes
        //{
        //    get
        //    {
        //        return this.episodes.Values.Cast<IEpisode>().ToList();
        //    }
        //    set
        //    {
        //        this.episodes = value.ToDictionary(k => k.Id, v => (Episode)v);
        //    }
        //}

        //[JsonProperty("episodes")]
        //private Dictionary<long, Episode> episodes { get; set; }

    }
}
