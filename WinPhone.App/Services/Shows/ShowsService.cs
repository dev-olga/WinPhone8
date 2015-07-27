using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Services.Shows
{
    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.Interfaces.Models.Shows;
    using WinPhone.MyShows.Models.Shows;

    internal class ShowsService : IShowsService
    {
        private MyShows.Services.ShowsService apiService;

        private MyShows.Services.ShowsService ApiService
        {
            get
            {
                return this.apiService ?? (this.apiService = new MyShows.Services.ShowsService());
            }
        }

        public async Task<List<ShowRatingInfo>> GetTopShowsAsync()
        {
            return await this.ApiService.GetTopShowsAsync();
        }

        public Task<ShowInfo> GetShowWithEpisodesAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShowInfo>> FindShowsAsync(string search)
        {
            throw new NotImplementedException();
        }
    }
}
