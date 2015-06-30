using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Services
{
    using System.Net.Http;

    using WinPhone.MyShows.Services.Authorization;

    public class AuthorizationService : BaseService
    {
        /// <summary>
        /// Authorizes user.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The token.
        /// </returns>
        async public Task<AuthorizationResponse> Authorize(string login, string password)
        {
            var response = await this.Read(string.Format("{0}/profile/login?login={1}&password={2}", this.BaseUrl, login, password));
            return new AuthorizationResponse { Token = response };
        }

    }
}
