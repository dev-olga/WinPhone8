using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.Interfaces.Models.Profile
{
    public interface IStatistic
    {
        double WatchedHours { get; set; }

        double RemainingHours { get; set; }

        int WatchedEpisodes { get; set; }

        int RemainingEpisodes { get; set; }

        int TotalEpisodes { get; set; }

        double TotalDays { get; set; }

        double TotalHours { get; set; }

        double RemainingDays { get; set; }

        double WatchedDays { get; set; }
    }
}
