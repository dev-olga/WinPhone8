namespace WinPhone.App.Services.Profile
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.Interfaces.Models.Profile;
    using WinPhone.MyShows.Models.Profile;

    internal class ProfileService : IProfileService 
    {
        private MyShows.Services.ProfileService apiService;       

        //private enum OfflineDataKeys
        //{
        //    Profile,
        //    Shows
        //}

        /// <summary>
        /// Gets the api service.
        /// </summary>
        private MyShows.Services.ProfileService ApiService
        {
            get
            {
                return this.apiService ?? (this.apiService = new MyShows.Services.ProfileService());
            }
        } 

        /// <summary>
        /// Gets user's shows async.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<UserShow>> GetShowsAsync(string token)
        {
            return await this.ApiService.GetUserShowsAsync(token);
        }

        ///// <summary>
        ///// Gets user's shows from local storage async.
        ///// </summary>
        ///// <returns>
        ///// The <see cref="Task"/>.
        ///// </returns>
        //public async Task<List<UserShow>> GetShowsOfflineAsync()
        //{
        //    return await this.OfflineManager.GetAsync<List<UserShow>>(OfflineDataKeys.Shows);
        //}

        ///// <summary>
        ///// Saves user shows into the local storage async.
        ///// </summary>
        ///// <param name="shows">
        ///// The list of shows.
        ///// </param>
        ///// <returns>
        ///// The <see cref="Task"/>.
        ///// </returns>
        //public async Task SaveUserShowsOfflineAsync(List<UserShow> shows)
        //{
        //    await this.OfflineManager.SaveAsync(OfflineDataKeys.Shows, shows);
        //}

        public async Task<Profile> GetProfileAsync(string login)
        {
            return await this.ApiService.GetProfileAsync(login);
        }

        //public async Task<Profile> GetProfileOfflineAsync()
        //{
        //    return await this.OfflineManager.GetAsync<Profile>(OfflineDataKeys.Profile);
        //}

        //public async Task SaveUserProfileOfflineAsync(Profile profile)
        //{
        //    await this.OfflineManager.SaveAsync(OfflineDataKeys.Profile, profile);
        //}
    }
}
