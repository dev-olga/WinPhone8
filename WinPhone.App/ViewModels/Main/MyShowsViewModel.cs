using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Models.Main
{
    using System.Collections.ObjectModel;

    using GalaSoft.MvvmLight.Command;

    using WinPhone.App.Interfaces;
    using WinPhone.App.ViewModels;
    using WinPhone.MyShows.Models.Profile;

    internal class MyShowsViewModel : NotificationViewModel
    {
        #region Fields

        private readonly RelayCommand showsSelectionCommand;        

        private ObservableCollection<UserShow> selectedShows;

        private bool isShowSelectionEnabled;

        private ObservableCollection<UserShow> shows;


        #endregion

        public MyShowsViewModel()
        {
            this.showsSelectionCommand =
               new RelayCommand(() => this.IsShowSelectionEnabled = !this.IsShowSelectionEnabled);           
        }

        public RelayCommand ShowsSelectionCommand
        {
            get
            {
                return this.showsSelectionCommand;
            }
        }

        public ObservableCollection<UserShow> Shows
        {
            get
            {
                return this.shows ?? (this.shows = new ObservableCollection<UserShow>());
            }
            set
            {
                if (this.shows != value)
                {
                    this.shows = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public bool IsShowSelectionEnabled
        {
            get
            {
                return this.isShowSelectionEnabled;
            }
            set
            {
                if (this.isShowSelectionEnabled != value)
                {
                    this.isShowSelectionEnabled = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<UserShow> SelectedShows
        {
            get
            {
                return this.selectedShows ?? (this.selectedShows = new ObservableCollection<UserShow>());
            }
            set
            {
                if (this.selectedShows != value)
                {
                    this.selectedShows = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
    }
}
