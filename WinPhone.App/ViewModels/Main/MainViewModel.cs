using System.Threading.Tasks;

namespace WinPhone.App.ViewModels.Main
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using WinPhone.App.Common;
    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.MyShows.Models.Profile;
    using WinPhone.MyShows.Models.Shows;

    internal class MainViewModel : AuthorizedViewModel, IData
    {
        private ObservableCollection<UserShow> myShows;

        private ObservableCollection<ShowRatingInfo> suggestions;

        private Profile profile;

        private readonly IApiProvider apiProvider;

        private enum OfflineDataKeys
        {
            Profile,
            MyShows,
            Suggestions
        }

        protected IApiProvider ApiProvider
        {
            get
            {
                return this.apiProvider;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="authorizationService">
        /// The authorization service.
        /// </param>
        public MainViewModel(IAuthorizationService authorizationService, IApiProvider apiProvider)
            : base(authorizationService)
        {
            this.apiProvider = apiProvider;
        }

        public async Task LoadData()
        {
            List<UserShow> myShowsData;
            Profile profileData;
            List<ShowRatingInfo> suggestionsData;
            if (InternetHelper.IsNetworkAvailable())
            {
                myShowsData = await this.ApiProvider.ProfileService.GetUserShowsAsync(this.AuthorizationService.User.AuthorizationToken);
                profileData = await this.ApiProvider.ProfileService.GetProfileAsync(this.AuthorizationService.User.UserName);
                suggestionsData = await this.ApiProvider.ShowsService.GetTopShowsAsync();
                suggestionsData = suggestionsData.OrderBy(s => s.Place).Take(8).ToList();
            }
            else
            {
                var mananger = OfflineProvider.GetOfflineManager();
                myShowsData = await mananger.GetAsync<List<UserShow>>(OfflineDataKeys.MyShows);
                profileData = await mananger.GetAsync<Profile>(OfflineDataKeys.Profile);
                suggestionsData = await mananger.GetAsync<List<ShowRatingInfo>>(OfflineDataKeys.Suggestions);
            }

            this.MyShows = new ObservableCollection<UserShow>(myShowsData);
            this.Profile = profileData;
            this.Suggestions = new ObservableCollection<ShowRatingInfo>(suggestionsData);
        }

        public async Task SaveData()
        {
            var mananger = OfflineProvider.GetOfflineManager();
            await mananger.SaveAsync(OfflineDataKeys.MyShows, this.MyShows.ToList());
            await mananger.SaveAsync(OfflineDataKeys.Profile, this.Profile);
            await mananger.SaveAsync(OfflineDataKeys.Suggestions, this.Suggestions.ToList());
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
