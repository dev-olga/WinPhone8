using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Models.ShowDetails
{
    using WinPhone.App.ViewModels;
    using WinPhone.MyShows.Models.Shows;

    public class UserEpisode : NotificationViewModel
    {
        private Episode episode;

        private bool isWatched;

        public Episode Episode
        {
            get
            {
                return this.episode;
            }
            set
            {
                if (this.episode != value)
                {
                    this.episode = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public bool IsWatched
        {
            get
            {
                return this.isWatched;
            }
            set
            {
                if (this.isWatched != value)
                {
                    this.isWatched = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
    }
}
