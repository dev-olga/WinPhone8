using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinPhone.Interfaces.Services
{
    using WinPhone.Interfaces.Models.Profile;

    public interface IProfileService
    {
        Task<List<IUserShow>> GetUserShowsAsync(string token);

        Task<IProfile> GetProfileAsync(string login);
    }
}
