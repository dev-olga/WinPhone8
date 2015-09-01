using WinPhone.App.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WinPhone.App.Views
{
    using WinPhone.App.ViewModels;
    using WinPhone.App.ViewModels.ShowDetails;
    using WinPhone.MyShows.Models.Profile;
    using WinPhone.MyShows.Models.Shows;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShowDetailsPage : BasePage
    {

        public ShowDetailsPage() : base()
        {
            NavigationCacheMode = NavigationCacheMode.Disabled;
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.DataContext is IShowDetailData)
            {
                if (e.Parameter as ShowRatingInfo != null)
                {
                    await(this.DataContext as IShowDetailData).Load((e.Parameter as ShowRatingInfo).Id);
                }
                else if (e.Parameter as UserShow != null)
                {
                    await(this.DataContext as IShowDetailData).Load(e.Parameter as UserShow);
                }
            }
        }
    }
}
