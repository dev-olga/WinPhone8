using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace WinPhone.App.Views
{
    using System.Collections.ObjectModel;

    using WinPhone.App;
    using WinPhone.App.Common;
    using WinPhone.App.Services;
    using WinPhone.App.ViewModels;
    using WinPhone.App.ViewModels.Main;
    using WinPhone.MyShows.Models.Profile;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : BasePage
    {
        //private NavigationHelper navigationHelper;

        public MainPage() : base()
        {
            this.InitializeComponent();
        }

    }
}
