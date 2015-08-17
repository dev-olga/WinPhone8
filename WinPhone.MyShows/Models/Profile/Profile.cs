namespace WinPhone.MyShows.Models.Profile
{
    using Newtonsoft.Json;

    public class Profile
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("avatar")]
        public string AvatarUrl { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("stats")]
        public Statistic Statistic { get; set; }
    }
}
