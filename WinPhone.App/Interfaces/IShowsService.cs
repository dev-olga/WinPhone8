using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Interfaces
{
    //using WinPhone.Interfaces.Models.Shows;
    using WinPhone.MyShows.Models.Shows;

    internal interface IShowsService
    {
        Task<List<ShowRatingInfo>> GetTopShowsAsync();

        Task<ShowInfo> GetShowWithEpisodesAsync(long id);

        //Task<List<ShowRatingInfo>> GetTopShowsOfflineAsync();

        //Task SaveTopShowsOfflineAsync();

        //Task SaveShowWithEpisodesOfflineAsync(long id);

        Task<List<ShowInfo>> FindShowsAsync(string search);

    }
}
