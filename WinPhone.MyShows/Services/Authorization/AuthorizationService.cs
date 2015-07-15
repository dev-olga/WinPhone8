using System.Threading.Tasks;

namespace WinPhone.MyShows.Services
{
    using System.Net;

    using WinPhone.MyShows.Helpers;
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
        /// The response.
        /// </returns>
        async public Task<AuthorizationResponse> AuthorizeAsync(string login, string password)
        {
            var response = await this.ReadAsync(string.Format("{0}/profile/login?login={1}&password={2}", this.BaseUrl, login, MD5Helper.GetMd5Hash(password)));
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return AuthorizationResponse.OK;
                case HttpStatusCode.Forbidden:
                    return AuthorizationResponse.InvalidCredentials;
                case HttpStatusCode.NotFound:
                    return AuthorizationResponse.EmptyCredentials;
                default:
                    return AuthorizationResponse.Unknown;
            }
        }

    }
}
