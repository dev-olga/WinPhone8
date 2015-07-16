using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Services
{
    public class ProfileService : BaseService
    {
        async public Task<object> GetProfileAsync(string login)
        {
            var response = await this.GetAsync(string.Format("/profile/" + login));
            return response;
        }
    }
}
