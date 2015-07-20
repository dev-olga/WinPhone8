namespace WinPhone.App.Services.Profile
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WinPhone.App.Common;
    using WinPhone.App.Common.Offline;
    using WinPhone.MyShows.Models.Profile;

    public class ProfileService
    {
        private MyShows.Services.ProfileService apiService;

        private OfflineManager offlineManager;

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
                return this.offlineManager ?? (this.offlineManager = new OfflineManager(typeof(ProfileService).FullName));
            }
        }

        public async Task<List<UserShow>> GetUserShowsAsync(string token)
        {
            List<UserShow> shows;
            if (InternetHelper.IsNetworkAvailable())
            {
                shows = await this.ApiService.GetUserShowsAsync(token);
               // this.OfflineManager.Save(OfflineDataKeys.Shows.ToString(), shows);
            }
            else
            {
                shows = this.OfflineManager.Get<List<UserShow>>(OfflineDataKeys.Shows.ToString());
            }
            
            return shows;
        }
    }
}
