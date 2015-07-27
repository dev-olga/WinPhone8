
namespace WinPhone.App.Interfaces
{
    using System.Threading.Tasks;

    using WinPhone.App.Models;

    internal interface IAuthorizationService
    {
        Task<bool> LogInAsync(Credentials credentials, bool remember = false);

        Task<bool> LogInAsync();

        void LogOut();

        bool IsLoggedIn { get; }

        User User { get; }
    }
}
