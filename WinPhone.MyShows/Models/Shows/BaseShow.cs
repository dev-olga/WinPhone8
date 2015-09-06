namespace WinPhone.MyShows.Models.Shows
{
    using Newtonsoft.Json;

    /// <summary>
    /// The base show.
    /// </summary>
    public class BaseShow
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("ruTitle")]
        public string RuTitle { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("rating")]
        public float Rating { get; set; }
        
    }
}
