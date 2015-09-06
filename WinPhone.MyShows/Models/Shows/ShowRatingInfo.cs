using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Models.Shows
{
    using Newtonsoft.Json;

    public class ShowRatingInfo : BaseShow
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("place")]
        public long Place { get; set; }

        [JsonProperty("watching")]
        public long Watching { get; set; }
    }
}
