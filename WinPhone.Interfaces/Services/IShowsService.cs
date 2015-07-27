using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.Interfaces.Services
{
    using WinPhone.Interfaces.Models.Shows;

    public interface IShowsService
    {
        Task<List<IShowRatingInfo>> GetTopShowsAsync();

        Task<IShowInfo> GetShowWithEpisodesAsync(long id);

        Task<List<IShowInfo>> FindShowsAsync(string search);

    }
}
