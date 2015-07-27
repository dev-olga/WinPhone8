using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.Interfaces.Models.Shows
{
    public interface IEpisode
    {
        long Id { get; set; }

        string Title { get; set; }

        //[JsonProperty("airDate")]
        // DateTime? AirDate { get; set; }
            
        string ShortName { get; set; }

        string TvRageLink { get; set; }

        string Image { get; set; }

        int SeasonNumber { get; set; }

        int EpisodeNumber { get; set; }

        int? ProductionNumber { get; set; }

        int? SequenceNumber { get; set; }
            
    }
}
