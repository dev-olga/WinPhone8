using System.Collections.Generic;

namespace WinPhone.App.Models.ShowDetails
{
    using WinPhone.App.ViewModels;
    using WinPhone.MyShows.Models.Shows;

    internal class UserShow : NotificationViewModel
    {
        private ShowInfo show;

        private List<UserEpisode> episodes;

        private ShowStatus selectedStatus;

        public ShowInfo Show
        {
            get
            {
                return this.show;
            }
            set
            {
                if (this.show != value)
                {
                    this.show = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public List<UserEpisode> Episodes
        {
            get
            {
                return this.episodes;
            }
            set
            {
                if (this.episodes != value)
                {
                    this.episodes = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public ShowStatus SelectedStatus
        {
            get
            {
                return this.selectedStatus;
            }
            set
            {
                if (this.selectedStatus != value)
                {
                    this.selectedStatus = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public List<KeyValuePair<ShowStatus, string>> Statuses
        {
            get
            {
                return new List<KeyValuePair<ShowStatus, string>>()
                                {
                                    new KeyValuePair<ShowStatus, string>(ShowStatus.Watching, "Watching"),
                                    new KeyValuePair<ShowStatus, string>(ShowStatus.Later, "Maybe"),
                                    new KeyValuePair<ShowStatus, string>(ShowStatus.Remove, "Will not watch"),
                                    new KeyValuePair<ShowStatus, string>(ShowStatus.Cancelled, "Not watching")
                                };
            }
        } 
    }
}
