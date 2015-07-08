using System.Threading.Tasks;

namespace WinPhone.App.Interfaces
{
    using WinPhone.App.Models;

    public interface IAuthorizationService
    {
        Task<bool> LogIn(Credentials credentials, bool remember = false);

        Task<bool> LogIn();

        void LogOut();
    }
}
