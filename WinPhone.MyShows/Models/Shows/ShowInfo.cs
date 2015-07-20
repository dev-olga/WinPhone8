using System;

namespace WinPhone.MyShows.Models.Shows
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class ShowInfo : BaseShow
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("watching")]
        public long? Watching { get; set; }

        [JsonProperty("voted")]
        public long? Voted { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("kinopoiskId")]
        public int? KinopoiskId { get; set; }

        [JsonProperty("tvrageId")]
        public int? TvrageId { get; set; }

        [JsonProperty("imdbId")]
        public int? ImdbId { get; set; }

        [JsonProperty("started")]
        public DateTime Started { get; set; }

        [JsonProperty("episodes")]
        public Dictionary<long, Episode> Episodes { get; set; }
    }
}
