﻿using System.Collections.Generic;

namespace WinPhone.App.Models.ShowDetails
{
    using System.Collections.ObjectModel;
    using System.Linq;

    using WinPhone.App.ViewModels;
    using WinPhone.MyShows.Models.Shows;

    public class UserShow : NotificationViewModel
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

        public Dictionary<int, List<UserEpisode>> Seasons
        {
            get
            {
                var seasons =
                    this.Episodes.GroupBy(e => e.Episode.SeasonNumber)
                        .OrderBy(s => s.Key)
                        .ToDictionary(s => s.Key, s => s.OrderBy(e => e.Episode.SequenceNumber).ToList());
                return seasons;
            }
        }

        public List<UserEpisode> Episodes
        {
            get
            {
                return this.episodes ?? new List<UserEpisode>();
            }
            set
            {
                if (this.episodes != value)
                {
                    this.episodes = value;
                    this.NotifyPropertyChanged();
                    this.NotifyPropertyChanged("Seasons");
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
                return new List<ShowStatus>
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
