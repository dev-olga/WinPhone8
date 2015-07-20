using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.ViewModels.Main
{
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;

    using WinPhone.App.Interfaces;
    using WinPhone.App.Services.Profile;
    using WinPhone.MyShows.Models.Profile;
    using WinPhone.MyShows.Models.Shows;

    public class MainViewModel : AuthorizedViewModel, ILoadDataAsync
    {
        private ObservableCollection<UserShow> myShows;
 
        public MainViewModel(IAuthorizationService authorizationService)
            : base(authorizationService)
        {
        }

        public async Task LoadData()
        {
            var shows = await(new ProfileService()).GetUserShowsAsync(this.AuthorizationService.User.AuthorizationToken);
            this.MyShows = new ObservableCollection<UserShow>(shows);
        }

        public ObservableCollection<UserShow> MyShows
        {
            get
            {
                return this.myShows;
            }
            set
            {
                if (this.myShows != value)
                {
                    this.myShows = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
    }
}
