using System.Threading.Tasks;

namespace WinPhone.App.ViewModels.Main
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;

    using WinPhone.App.Common;
    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.App.Models.Main;
    using WinPhone.MyShows.Models.Profile;
    using WinPhone.MyShows.Models.Shows;

    internal class MainViewModel : AuthorizedViewModel, IDisposable
    {

        private readonly IApiProvider apiProvider;

        private readonly RelayCommand addShowCommand;

        private readonly RelayCommand<PivotItems> selectPivotItemCommand;

        private ObservableCollection<ShowRatingInfo> suggestions;

        private Profile profile;

        private MyShowsViewModel myShows;
             
        private PivotItems currentPivotItem;

        private bool processing;

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
        /// <param name="apiProvider">
        /// The api Provider.
        /// </param>
        public MainViewModel(IAuthorizationService authorizationService, IApiProvider apiProvider)
            : base(authorizationService)
        {
            this.apiProvider = apiProvider;
            this.myShows = new MyShowsViewModel(apiProvider);
            this.MyShows.SelectedShows.CollectionChanged += this.ShowsCollectionChanged;

            this.addShowCommand = new RelayCommand(() => this.AddShow());
            this.selectPivotItemCommand = new RelayCommand<PivotItems>(
                item =>
                {
                    this.CurrentPivotItem = item;
                    this.Processing = true;
                    switch (CurrentPivotItem)
                    {
                        case PivotItems.MyProfile:
                            {
                                this.LoadProfileAsync();
                                break;
                            }
                        case PivotItems.MyShows:
                            {
                                this.LoadMyShowsAsync();
                                break;
                            }
                        case PivotItems.Suggestions:
                            {
                                this.LoadSuggestionsAsync();
                                break;
                            }
                    }
                    this.Processing = false;
                });            
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

        public bool Processing
        {
            get
            {
                return this.processing;
            }
            set
            {
                if (this.processing != value)
                {
                    this.processing = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

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

        private async Task AddShow()
        {
            //this.ApiProvider.ShowsService.
        }

        private async void LoadProfileAsync()
        {
            Profile profileData;
            var mananger = OfflineProvider.GetOfflineManager();
            if (InternetHelper.IsNetworkAvailable())
            {
                profileData = (await this.ApiProvider.ProfileService.GetProfileAsync(this.AuthorizationService.User.UserName)).Data;
                await mananger.SaveAsync(OfflineDataKeys.Profile, profileData);
            }
            else
            {
                profileData = await mananger.GetAsync<Profile>(OfflineDataKeys.Profile);
            }

            this.Profile = profileData;
        }

        private async void LoadSuggestionsAsync()
        {
            var mananger = OfflineProvider.GetOfflineManager();
            List<ShowRatingInfo> suggestionsData;
            if (InternetHelper.IsNetworkAvailable())
            {
                suggestionsData = await this.ApiProvider.ShowsService.GetTopShowsAsync();
                suggestionsData = suggestionsData.OrderBy(s => s.Place).Take(8).ToList();
                await mananger.SaveAsync(OfflineDataKeys.Suggestions, suggestionsData);
            }
            else
            {
                suggestionsData = await mananger.GetAsync<List<ShowRatingInfo>>(OfflineDataKeys.Suggestions);
            }

            this.Suggestions = new ObservableCollection<ShowRatingInfo>(suggestionsData);
        }

        private async void LoadMyShowsAsync()
        {
            var mananger = OfflineProvider.GetOfflineManager();
            List<UserShow> myShowsData;
            if (InternetHelper.IsNetworkAvailable())
            {
                myShowsData = (await this.ApiProvider.ProfileService.GetUserShowsAsync(this.AuthorizationService.User.AuthorizationToken)).Data;
                await mananger.SaveAsync(OfflineDataKeys.MyShows, myShowsData);
            }
            else
            {
                myShowsData = await mananger.GetAsync<List<UserShow>>(OfflineDataKeys.MyShows);
            }

            this.MyShows.Shows = new ObservableCollection<UserShow>(myShowsData);            
        }

        private async void SaveMyShowsAsync()
        {
            var mananger = OfflineProvider.GetOfflineManager();
            await mananger.SaveAsync(OfflineDataKeys.MyShows, this.MyShows.Shows.ToList());
        }
        
        private void ShowsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.SaveMyShowsAsync();
        }

        /// <summary>
        /// Disposes view model.
        /// </summary>
        public void Dispose()
        {
            this.MyShows.Shows.CollectionChanged -= this.ShowsCollectionChanged;
            this.MyShows.Dispose();
        }
    }
}
