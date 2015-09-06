namespace WinPhone.App.ViewModels.ShowDetails
{
    using System.Threading.Tasks;

    using WinPhone.MyShows.Models.Profile;
    using WinPhone.MyShows.Models.Shows;

    internal interface IShowDetailData
    {
        Task Load(long showId, ShowStatus status);
    }
}
