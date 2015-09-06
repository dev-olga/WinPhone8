using System.Collections.Generic;

namespace WinPhone.App.Models.ShowDetails
{
    using System.Collections.ObjectModel;
    using System.Linq;

    using WinPhone.App.ViewModels;
    using WinPhone.MyShows.Models.Shows;

    public class UserShow : NotificationViewModel
    {
        private ShowInfo show;

        private ObservableCollection<UserEpisode> episodes;

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

        public ObservableCollection<UserEpisode> Episodes
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

        public List<ShowStatus> Statuses
        {
            get
            {
                return new List<ShowStatus>()
                                {
                                    ShowStatus.Watching, 
                                    ShowStatus.Later, 
                                    ShowStatus.Remove, 
                                    ShowStatus.Cancelled
                                };
            }
        } 
    }
}
