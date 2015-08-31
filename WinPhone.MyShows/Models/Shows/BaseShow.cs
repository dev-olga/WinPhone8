namespace WinPhone.MyShows.Models.Shows
{
    using Newtonsoft.Json;

    public class BaseShow
    {
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
