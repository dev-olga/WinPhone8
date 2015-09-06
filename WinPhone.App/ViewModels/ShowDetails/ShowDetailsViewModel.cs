using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.ViewModels.ShowDetails
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    using WinPhone.App.Common;
    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.App.Models.ShowDetails;
    using WinPhone.MyShows.Models.Profile;
    using WinPhone.MyShows.Models.Shows;

    using UserShow = WinPhone.MyShows.Models.Profile.UserShow;

    internal class ShowDetailsViewModel : BaseViewModel, IShowDetailData
    {
        private Models.ShowDetails.UserShow userShow;

        private bool isLoading;

        private enum OfflineDataKeys
        {
            UserShow
        }

        public ShowDetailsViewModel(IAuthorizationService authorizationService, IApiProvider apiProvider)
            : base(authorizationService, apiProvider)
        {
            //this.IsLoading = true;            
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
        public Models.ShowDetails.UserShow UserShow
        {
            get
            {
                return this.userShow ?? (this.userShow = new Models.ShowDetails.UserShow());
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
            await OfflineProvider.GetOfflineManager().SaveAsync(OfflineDataKeys.UserShow, this.UserShow);
        }

        public async Task Load(long showId)
        {
            this.IsLoading = true;
            var mananger = OfflineProvider.GetOfflineManager();
            Models.ShowDetails.UserShow model;
            if (InternetHelper.IsNetworkAvailable())
            {
                var show = await this.ApiProvider.ShowsService.GetShowWithEpisodesAsync(showId);
                var episodes =
                    (await
                     this.ApiProvider.ProfileService.GetWatchedEpisodesAsync(
                         this.AuthorizationService.User.AuthorizationToken,
                         showId)).Data;
                model = new Models.ShowDetails.UserShow();
                model.Show = show;
                model.Episodes =
                    new ObservableCollection<UserEpisode>(
                        show.Episodes.Values.Select(
                            episode =>
                            new UserEpisode { Episode = episode, IsWatched = episodes.Any(e => e.Id == episode.Id) }));

                await mananger.SaveAsync(OfflineDataKeys.UserShow, model);
            }
            else
            {
                model = await mananger.GetAsync<Models.ShowDetails.UserShow>(OfflineDataKeys.UserShow);
            }

            this.UserShow = model;
            this.UserShow.PropertyChanged += this.PropertyChangedEventHandler;
            this.IsLoading = false;
        }

        public async Task Load(UserShow show)
        {
            await this.Load(show.Id);
            this.UserShow.SelectedStatus = show.Status;
        }
    }
}
