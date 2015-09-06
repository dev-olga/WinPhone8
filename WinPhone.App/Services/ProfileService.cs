using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Services
{
    using WinPhone.App.Interfaces;
    using WinPhone.App.Models;
    using WinPhone.MyShows.Models.Shows;

    internal class ProfileService
    {
        private readonly IApiProvider apiProvider;

        private readonly User user;

        protected User User
        {
            get
            {
                return this.user;
            }
        }

        protected IApiProvider ApiProvider
        {
            get
            {
                return this.apiProvider;
            }
        }

        public ProfileService(IApiProvider apiProvider, User user)
        {
            this.apiProvider = apiProvider;
            this.user = user;
        }

        public async Task<ProfileResponse> UpdateShowStatusAsync(long showId, ShowStatus status)
        {
            await this.ApiProvider.ProfileService.UpdateShowStatusAsync(this.User.AuthorizationToken, showId, status);
        }
    }
}
