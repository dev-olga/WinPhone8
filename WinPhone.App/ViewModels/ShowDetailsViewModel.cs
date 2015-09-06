using System.Linq;
using System.Threading.Tasks;

namespace WinPhone.App.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    using WinPhone.App.Common;
    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.App.Models.ShowDetails;
    using WinPhone.App.ViewModels.ShowDetails;
    using WinPhone.MyShows.Models.Shows;

    internal class ShowDetailsViewModel : BaseViewModel, IShowDetailData, IDisposable
    {
        private UserShow userShow;

        private bool isLoading;

        private enum OfflineDataKeys
        {
            UserShow
        }

        public ShowDetailsViewModel(IAuthorizationService authorizationService, IApiProvider apiProvider)
            : base(authorizationService, apiProvider)
        {    
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
                }
            }
        }

        public UserShow UserShow
        {
            get
            {
                return this.userShow ?? (this.userShow = new UserShow());
            }
            set
            {
                if (this.userShow != value)
                {
                    this.userShow = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        private async void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            await OfflineProvider.GetOfflineManager().SaveAsync(
                OfflineDataKeys.UserShow, 
                this.UserShow,
                GetStorageParameters(this.UserShow.Show.Id)
                );
        }

        private static IDictionary<string, object> GetStorageParameters(long id)
        {
            return new Dictionary<string, object> { { "id", id } };
        }

        public async Task Load(long showId, ShowStatus status)
        {
            this.IsLoading = true;
            var mananger = OfflineProvider.GetOfflineManager();
            UserShow model;
            if (InternetHelper.IsNetworkAvailable())
            {
                var show = await this.ApiProvider.ShowsService.GetShowWithEpisodesAsync(showId);
                var episodes =
                    (await
                     this.ApiProvider.ProfileService.GetWatchedEpisodesAsync(
                         this.AuthorizationService.User.AuthorizationToken,
                         showId)).Data;
                model = new UserShow();
                model.Show = show;
                model.Episodes =
                        show.Episodes.Values.Select(
                            episode =>
                            new UserEpisode
                                {
                                    Episode = episode, 
                                    IsWatched = episodes.Any(e => e.Id == episode.Id)
                                }).ToList();

                await mananger.SaveAsync(OfflineDataKeys.UserShow, model, GetStorageParameters(showId));
            }
            else
            {
                model = await mananger.GetAsync<UserShow>(OfflineDataKeys.UserShow, GetStorageParameters(showId));
            }

            this.UserShow = model;
            this.UserShow.SelectedStatus = status;
            this.UserShow.PropertyChanged += this.PropertyChangedEventHandler;
            this.IsLoading = false;
        }

        public void Dispose()
        {
            this.UserShow.PropertyChanged -= this.PropertyChangedEventHandler;
        }
    }
}
