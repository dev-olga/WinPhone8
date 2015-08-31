using System.Linq;

namespace WinPhone.App.Models.Main
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Threading.Tasks;

    using GalaSoft.MvvmLight.Command;

    using WinPhone.App.Interfaces;
    using WinPhone.App.ViewModels;
    using WinPhone.MyShows.Models.Profile;
    using WinPhone.MyShows.Models.Shows;

    using WinRTXamlToolkit.Tools;

    internal class MyShowsViewModel : NotificationViewModel, IDisposable
    {
        #region Fields

        private readonly RelayCommand showsSelectionCommand;

        private RelayCommand<IList<UserShow>> selectionChangedCommand;

        private ObservableCollection<UserShow> selectedShows = new ObservableCollection<UserShow>();

        private bool isShowSelectionEnabled;

        private ObservableCollection<UserShow> shows = new ObservableCollection<UserShow>();

        //private readonly RelayCommand deleteShowsCommand;

        protected readonly IApiProvider apiProvider;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MyShowsViewModel"/> class.
        /// </summary>
        /// <param name="apiProvider">
        /// The api provider.
        /// </param>
        public MyShowsViewModel(IApiProvider apiProvider)
        {
            this.apiProvider = apiProvider;
            this.showsSelectionCommand =
                new RelayCommand(() => this.IsShowSelectionEnabled = !this.IsShowSelectionEnabled);

            //this.deleteShowsCommand = new RelayCommand(
            //    this.DeleteShows,
            //    () => this.IsShowSelectionEnabled && this.SelectedShows.Any());

            this.SelectedShows.CollectionChanged += this.SelectedShowsCollectionChanged;
        }

        protected IApiProvider ApiProvider
        {
            get
            {
                return this.apiProvider;
            }
        }

        public RelayCommand ShowsSelectionCommand
        {
            get
            {
                return this.showsSelectionCommand;
            }
        }

        //public RelayCommand DeleteShowsCommand
        //{
        //    get
        //    {
        //        return this.deleteShowsCommand;
        //    }
        //}

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
                    //this.DeleteShowsCommand.RaiseCanExecuteChanged();
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

        private void SelectedShowsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //this.DeleteShowsCommand.RaiseCanExecuteChanged();
        }

        public void Dispose()
        {
            //this.SelectedShows.CollectionChanged -= SelectedShowsCollectionChanged;
        }

        //public async void DeleteShows()
        //{
        //    //this.SelectedShows.ForEach(selectedShow => this.Shows.Remove(selectedShow));
        //    var newCollection = new ObservableCollection<UserShow>(this.Shows.Where(s => !this.SelectedShows.Contains(s)));
        //    await Task.WhenAll(this.SelectedShows.Select(
        //        selectedShow =>
        //        this.ApiProvider.ProfileService.UpdateShowStatusAsync(selectedShow.ShowId, ShowStatus.Remove)));
        //    this.Shows = newCollection;
        //}
    }
}
