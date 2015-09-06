using System.Collections.Generic;

namespace WinPhone.App.Models.ShowDetails
{
    using System.Runtime.Serialization;

    using WinPhone.MyShows.Models.Shows;

    public class UserShowData
    {
        public ShowInfo Show { get; set; }

        public ShowStatus Status { get; set; }

        public List<Episode> Episodes { get; set; }

        public List<long> WatchedEpisodes { get; set; }
    }
}
