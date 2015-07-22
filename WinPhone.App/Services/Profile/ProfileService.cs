namespace WinPhone.App.Services.Profile
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.MyShows.Models.Profile;

    internal class ProfileService : IProfileService
    {
        private MyShows.Services.ProfileService apiService;

        private readonly OfflineManager offlineManager;

        private enum OfflineDataKeys
        {
            Profile,
            Shows
        }

        protected MyShows.Services.ProfileService ApiService
        {
            get
            {
                return this.apiService ?? (this.apiService = new MyShows.Services.ProfileService());
            }
        }

        private OfflineManager OfflineManager
        {
            get
            {
                return this.offlineManager;
            }
        }

        public ProfileService(IStorage offlineStorage)
        {
            this.offlineManager = new OfflineManager(offlineStorage);
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
        public async Task<List<UserShow>> GetUserShowsAsync(string token)
        {
            return await this.ApiService.GetUserShowsAsync(token);
        }

        /// <summary>
        /// Gets user's shows from local storage async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<UserShow>> GetUserShowsOfflineAsync()
        {
            return await this.OfflineManager.GetAsync<List<UserShow>>(OfflineDataKeys.Shows);
        }

        /// <summary>
        /// Saves user shows into the local storage async.
        /// </summary>
        /// <param name="shows">
        /// The list of shows.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task SaveUserShowsOfflineAsync(List<UserShow> shows)
        {
            await this.OfflineManager.SaveAsync(OfflineDataKeys.Shows, shows);
        }
    }
}
