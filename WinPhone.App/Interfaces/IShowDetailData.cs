namespace WinPhone.App.ViewModels.ShowDetails
{
    using System.Threading.Tasks;

    using WinPhone.App.Models.ShowDetails;

    internal interface IShowDetailData
    {
        Task Load(ToNavigationParameter inputParameters);

        Task SaveState();
    }
}
