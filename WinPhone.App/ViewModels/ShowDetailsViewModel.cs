using System.Linq;
using System.Threading.Tasks;

namespace WinPhone.App.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using WinPhone.App.Common;
    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.App.Models.ShowDetails;
    using WinPhone.App.ViewModels.ShowDetails;

    internal class ShowDetailsViewModel : BaseViewModel, IShowDetailData, IDisposable
    {
        private UserShow userShow;

        private bool isLoading;

        private string title;

        private RelayCommand<int> updateEpisode;

        private enum OfflineDataKeys
        {
            UserShow
        }

        public ShowDetailsViewModel(IAuthorizationService authorizationService, IApiProvider apiProvider)
            : base(authorizationService, apiProvider)
        {    
            //this.updateEpisode = new RelayCommand<int>(
            //    id =>
            //        {
            //            this.ApiProvider.ProfileService.
            //        });
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (this.title != value)
                {
                    this.title = value;
                    this.NotifyPropertyChanged();
                }
            } 
        }

        public bool IsDataNotAvailable
        {
            get
            {
                return !this.IsLoading && this.UserShow == null;
            }
        }

        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }

            private set
            {
                if (this.isLoading != value)
                {
                    this.isLoading = value;
                    this.NotifyPropertyChanged();
                    this.NotifyPropertyChanged(() => this.IsDataNotAvailable);
                }
            }
        }

        public UserShow UserShow
        {
            get
            {
                return this.userShow;
            }
            set
            {
                if (this.userShow != value)
                {
                    this.userShow = value;
                    this.NotifyPropertyChanged();
                    this.NotifyPropertyChanged(() => this.IsDataNotAvailable);
                }
            }
        }

        private static IDictionary<string, object> GetStorageParameters(long id)
        {
            return new Dictionary<string, object> { { "id", id } };
        }

       // private static int toggle = 0;
        public async Task Load(ToNavigationParameter inputParameters)
        {
            this.Title = inputParameters.Title;
            var showId = inputParameters.ShowId;
            this.IsLoading = true;
            var mananger = OfflineProvider.GetOfflineManager();
            UserShowData data = null;
            
           // toggle++;
            if (/*toggle % 2 == 1 && */ InternetHelper.IsNetworkAvailable())
            {
                try
                {
                    var show = await this.ApiProvider.ShowsService.GetShowWithEpisodesAsync(showId);
                    var episodes =
                        (await
                         this.ApiProvider.ProfileService.GetWatchedEpisodesAsync(
                             this.AuthorizationService.User.AuthorizationToken,
                             showId)).Data;
                    data = new UserShowData()
                               {
                                   Show = show,
                                   Status = inputParameters.Status,
                                   Episodes = show.Episodes.Values.ToList(),
                                   WatchedEpisodes = episodes.Select(e => e.Id).ToList()
                               };
                }
                catch (Exception)
                {
                    //Todo handle
                }
            }
            else
            {
                data = await mananger.GetAsync<UserShowData>(OfflineDataKeys.UserShow, GetStorageParameters(showId));
            }

            this.UserShow = data != null ? new UserShow(this, data) : null;

            await this.SaveState();
            this.IsLoading = false;
        }

        public async Task SaveState()
        {
            if (this.UserShow == null)
            {
                return;
            }
            var data = new UserShowData()
            {
                Show = this.UserShow.Show,
                Status = this.UserShow.SelectedStatus,
                Episodes = this.UserShow.Episodes.Select(e => e.Episode).ToList(),
                WatchedEpisodes = this.UserShow.Episodes.Where(e => e.IsWatched).Select(e => e.Episode.Id).ToList()
            };
            var mananger = OfflineProvider.GetOfflineManager();
            await mananger.SaveAsync(OfflineDataKeys.UserShow, data, GetStorageParameters(this.UserShow.Show.Id));
        }

        public async void UpdateShowStatusAsync()
        {
            try
            {
                await
                    this.ApiProvider.ProfileService.UpdateShowStatusAsync(
                        this.AuthorizationService.User.AuthorizationToken,
                        this.UserShow.Show.Id,
                        this.UserShow.SelectedStatus);
            }
            catch (Exception)
            {
                // ToDO Handle
            }
        }

        public void Dispose()
        {
            
        }
    }
}
