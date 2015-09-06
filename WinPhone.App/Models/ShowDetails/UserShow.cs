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
        //private int selectedStatus;

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

        //public int SelectedStatus
        //{
        //    get
        //    {
        //        return this.selectedStatus;
        //    }
        //    set
        //    {
        //        if (this.selectedStatus != value)
        //        {
        //            this.selectedStatus = value;
        //            this.NotifyPropertyChanged();
        //        }
        //    }
        //}

        //public KeyValuePair<ShowStatus, string> SelectedStatusItem
        //{
        //    get
        //    {
        //        return this.Statuses.FirstOrDefault(s=>s.Key == this.SelectedStatus);
        //    }
        //    set
        //    {
        //        var statusItem = this.Statuses.FirstOrDefault(s => s.Key == this.SelectedStatus);
        //        if (statusItem.Key != value.Key)
        //        {
        //            this.SelectedStatus = value.Key;
        //            this.NotifyPropertyChanged();
        //        }
        //    }
        //}

        //public List<KeyValuePair<ShowStatus, string>> Statuses
        //{
        //    get
        //    {
        //        return new List<KeyValuePair<ShowStatus, string>>()
        //                        {
        //                            new KeyValuePair<ShowStatus, string>(ShowStatus.None, "Choose status"),
        //                            new KeyValuePair<ShowStatus, string>(ShowStatus.Watching, "Watching"),
        //                            new KeyValuePair<ShowStatus, string>(ShowStatus.Later, "Later"),
        //                            new KeyValuePair<ShowStatus, string>(ShowStatus.Cancelled, "Cancelled"),
        //                            new KeyValuePair<ShowStatus, string>(ShowStatus.Remove, "Not watching")
        //                        };
        //    }
        //}

        public List<ShowStatus> Statuses
        {
            get
            {
                return new List<ShowStatus>()
                                {
                                    ShowStatus.Watching, 
                                    ShowStatus.Later, 
                                    ShowStatus.Cancelled,
                                    ShowStatus.Remove
                                };
            }
        } 

        //public List<int> Statuses
        //{
        //    get
        //    {
        //        return new List<int>()
        //                        {
        //                            (int)ShowStatus.Watching, 
        //                            (int)ShowStatus.Later, 
        //                            (int)ShowStatus.Remove, 
        //                            (int)ShowStatus.Cancelled
        //                        };
        //    }
        //} 
    }
}
