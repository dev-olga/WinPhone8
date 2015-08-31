namespace WinPhone.App.ViewModels.ShowDetails
{
    using System.Threading.Tasks;

    using WinPhone.MyShows.Models.Profile;

    internal interface IShowDetailData
    {
        Task Load(long showId);

        Task Load(UserShow show);
    }
}
