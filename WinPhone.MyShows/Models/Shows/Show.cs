namespace WinPhone.MyShows.Models.Shows
{
    using Newtonsoft.Json;

    public class Show
    {
        [JsonProperty("showId")]
        public long ShowId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("watchStatus")]
        public string WatchStatus { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
