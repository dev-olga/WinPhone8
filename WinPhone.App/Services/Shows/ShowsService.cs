using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Services.Shows
{
    public class ShowsService
    {
        private MyShows.Services.ShowsService apiService;

        protected MyShows.Services.ShowsService ApiService
        {
            get
            {
                return this.apiService ?? (this.apiService = new MyShows.Services.ShowsService());
            }
        }

        //public async Task<Profile> GetProfileAsync(string login)
        //{

        //}

    }
}
