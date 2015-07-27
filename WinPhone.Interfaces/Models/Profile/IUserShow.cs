using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.Interfaces.Models.Profile
{
    using WinPhone.Interfaces.Models.Shows;

    public interface IUserShow : IBaseShow
    {
        long ShowId { get; set; }

        string WatchStatus { get; set; }

        int WatchedEpisodes { get; set; }
        
    }
}
