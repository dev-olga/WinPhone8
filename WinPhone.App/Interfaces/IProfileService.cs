using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinPhone.App.Interfaces
{
    using WinPhone.MyShows.Models.Profile;

    internal interface IProfileService
    {
        Task<List<UserShow>> GetShowsAsync(string token);

        //Task<List<UserShow>> GetShowsOfflineAsync();

        //Task SaveUserShowsOfflineAsync(List<UserShow> shows);

        Task<Profile> GetProfileAsync(string login);

        //Task<Profile> GetProfileOfflineAsync();

        //Task SaveUserProfileOfflineAsync(Profile profile);
    }
}
