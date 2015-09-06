using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WinPhone.App.Views
{
    using System.Threading.Tasks;

    using WinPhone.App.Common;
    using WinPhone.App.Models.ShowDetails;
    using WinPhone.App.ViewModels.ShowDetails;

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
            if (this.DataContext is IShowDetailData && e.Parameter as ToNavigationParameter != null)
            {
                var param = e.Parameter as ToNavigationParameter;
                await (this.DataContext as IShowDetailData).Load(param);
            }
        }
    }
}
