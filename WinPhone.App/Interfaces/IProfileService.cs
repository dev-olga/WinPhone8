using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinPhone.App.Interfaces
{
    using WinPhone.MyShows.Models.Profile;

    internal interface IProfileService
    {
        Task<List<UserShow>> GetUserShowsAsync(string token);

        Task<List<UserShow>> GetUserShowsOfflineAsync();

        Task SaveUserShowsOfflineAsync(List<UserShow> shows);
    }
}
