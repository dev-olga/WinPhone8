using System.Threading.Tasks;

namespace WinPhone.App.ViewModels.Main
{
    using System.Collections.ObjectModel;

    using WinPhone.App.Common;
    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.App.Services.Profile;
    using WinPhone.MyShows.Models.Profile;
    using WinPhone.MyShows.Models.Shows;

    internal class MainViewModel : AuthorizedViewModel, ILoadDataAsync
    {
        private ObservableCollection<UserShow> myShows;

        private ObservableCollection<ShowRatingInfo> suggestions;

        private Profile profile;

        private readonly IProfileService profileService;

        protected IProfileService ProfileService
        {
            get
            {
                return this.profileService;
            }
        }

        public MainViewModel(IAuthorizationService authorizationService, IProfileService profileService)
            : base(authorizationService)
        {
            this.profileService = profileService;
        }

        public async Task LoadData()
        {
            var shows = InternetHelper.IsNetworkAvailable() 
                ? await this.ProfileService.GetUserShowsAsync(this.AuthorizationService.User.AuthorizationToken)
                : await this.ProfileService.GetUserShowsOfflineAsync();
            this.MyShows = new ObservableCollection<UserShow>(shows);
        }

        public ObservableCollection<UserShow> MyShows
        {
            get
            {
                return this.myShows;
            }
            set
            {
                if (this.myShows != value)
                {
                    this.myShows = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<ShowRatingInfo> Suggestions
        {
            get
            {
                return this.suggestions;
            }
            set
            {
                if (this.suggestions != value)
                {
                    this.suggestions = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public Profile Profile
        {
            get
            {
                return this.profile;
            }
            set
            {
                if (this.profile != value)
                {
                    this.profile = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
    }
}
