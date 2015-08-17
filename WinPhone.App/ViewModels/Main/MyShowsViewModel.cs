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
        //private readonly IApiProvider apiProvider;

        private readonly RelayCommand showsSelectionCommand;

        //private readonly RelayCommand deleteShowsCommand;

        private ObservableCollection<UserShow> selectedShows;

        private bool isShowSelectionEnabled;

        private ObservableCollection<UserShow> shows;
        #endregion

        public MyShowsViewModel(/*IApiProvider apiProvider*/)
        {
           // this.apiProvider = apiProvider;
            this.showsSelectionCommand =
               new RelayCommand(() => this.IsShowSelectionEnabled = !this.IsShowSelectionEnabled);
           // this.deleteShowsCommand = new RelayCommand(() => this.DeleteShows());
        }

        //protected IApiProvider ApiProvider
        //{
        //    get
        //    {
        //        return this.apiProvider;
        //    }
        //}

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


        public async Task DeleteShows()
        {
            //this.ApiProvider.ShowsService.
        }
    }
}
