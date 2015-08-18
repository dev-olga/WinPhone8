using System.Linq;

namespace WinPhone.App.Models.Main
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using GalaSoft.MvvmLight.Command;

    using WinPhone.App.ViewModels;
    using WinPhone.MyShows.Models.Profile;

    internal class MyShowsViewModel : NotificationViewModel
    {
        #region Fields

        private readonly RelayCommand showsSelectionCommand;

        private RelayCommand<IList<UserShow>> selectionChangedCommand;

        private ObservableCollection<UserShow> selectedShows = new ObservableCollection<UserShow>();

        private bool isShowSelectionEnabled;

        private ObservableCollection<UserShow> shows = new ObservableCollection<UserShow>();

        private readonly RelayCommand deleteShowsCommand;
        #endregion

        public MyShowsViewModel()
        {
            this.showsSelectionCommand =
                new RelayCommand(() => this.IsShowSelectionEnabled = !this.IsShowSelectionEnabled);

            this.deleteShowsCommand = new RelayCommand(
                () => { var tmp = this.SelectedShows; },
                () => this.IsShowSelectionEnabled && this.SelectedShows.Any());
            this.SelectedShows.CollectionChanged += delegate { this.DeleteShowsCommand.RaiseCanExecuteChanged(); };
        }

        public RelayCommand ShowsSelectionCommand
        {
            get
            {
                return this.showsSelectionCommand;
            }
        }

        public RelayCommand DeleteShowsCommand
        {
            get
            {
                return this.deleteShowsCommand;
            }
        }

        public ObservableCollection<UserShow> Shows
        {
            get
            {
                return this.shows;
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
                    this.DeleteShowsCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public ObservableCollection<UserShow> SelectedShows
        {
            get
            {
                return this.selectedShows;
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
