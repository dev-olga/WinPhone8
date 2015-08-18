using System.Threading.Tasks;

namespace WinPhone.App.ViewModels.Main
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using WinPhone.App.Common;
    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.App.Models.Main;
    using WinPhone.MyShows.Models.Profile;
    using WinPhone.MyShows.Models.Shows;

    internal class MainViewModel : AuthorizedViewModel, IData
    {

        private readonly IApiProvider apiProvider;

        private readonly RelayCommand addShowCommand;

        //private readonly RelayCommand deleteShowsCommand;

        private readonly RelayCommand<PivotItems> selectPivotItemCommand;

        private ObservableCollection<ShowRatingInfo> suggestions;

        private string currentPivotItemName;

        private Profile profile;

        private MyShowsViewModel myShows;
             
        private PivotItems currentPivotItem;

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
            this.myShows = new MyShowsViewModel();

            this.addShowCommand = new RelayCommand(() => this.AddShow());
            this.selectPivotItemCommand = new RelayCommand<PivotItems>(
                item =>
                {
                    this.CurrentPivotItem = item;
                });

            //this.deleteShowsCommand = new RelayCommand(() => this.DeleteShows(), () => this.MyShows.IsShowSelectionEnabled && this.MyShows.SelectedShows.Any());
        }

        public string CurrentPivotItemName
        {
            get
            {
                return this.currentPivotItemName;
            }

            private set
            {
                if (this.currentPivotItemName != value.ToLower())
                {
                    this.currentPivotItemName = value.ToLower();
                    this.NotifyPropertyChanged();
                }
            }
        }

        public RelayCommand AddShowCommand
        {
            get
            {
                return this.addShowCommand;
            }
        }

        public RelayCommand<PivotItems> SelectPivotItemCommand
        {
            get
            {
                return this.selectPivotItemCommand;
            }
        }

        //public RelayCommand DeleteShowsCommand
        //{
        //    get
        //    {
        //        return this.deleteShowsCommand;
        //    }
        //}

        public PivotItems CurrentPivotItem
        {
            get
            {
                return this.currentPivotItem;
            }

            set
            {
                if (this.currentPivotItem != value)
                {
                    this.currentPivotItem = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public MyShowsViewModel MyShows
        {
            get
            {
                return this.myShows;
            }
        }

        public ObservableCollection<ShowRatingInfo> Suggestions
        {
            get
            {
                return this.suggestions;
            }
            private set
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
            private set
            {
                if (this.profile != value)
                {
                    this.profile = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        private async Task DeleteShows()
        {
            //this.ApiProvider.ShowsService.
        }

        private async Task AddShow()
        {
            //this.ApiProvider.ShowsService.
        }

        /// <summary>
        /// Loads view model data async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
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

            this.MyShows.Shows = new ObservableCollection<UserShow>(myShowsData);
            this.Profile = profileData;
            this.Suggestions = new ObservableCollection<ShowRatingInfo>(suggestionsData);
        }

        /// <summary>
        /// Saves view model data async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task SaveData()
        {
            var mananger = OfflineProvider.GetOfflineManager();
            await mananger.SaveAsync(OfflineDataKeys.MyShows, this.MyShows.Shows.ToList());
            await mananger.SaveAsync(OfflineDataKeys.Profile, this.Profile);
            await mananger.SaveAsync(OfflineDataKeys.Suggestions, this.Suggestions.ToList());
        }

    }
}
