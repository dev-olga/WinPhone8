using System.Threading.Tasks;

namespace WinPhone.MyShows.Services
{
    using System.Linq;
    using System.Net;

    using WinPhone.MyShows.Helpers;
    using WinPhone.MyShows.Models.Authorization;

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
        public async Task<AuthorizationResponse> AuthorizeAsync(string login, string password)
        {
            using (var response =
                    await
                    this.GetAsync(
                        string.Format("/profile/login?login={0}&password={1}", login, MD5Helper.GetMd5Hash(password))))
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        {
                            var token = response.Headers.ToList().FirstOrDefault(h => h.Key == "Set-Cookie");
                            return new AuthorizationResponse
                                       {
                                           Code = AuthorizationCode.OK,
                                           Token =
                                               token.Value != null && token.Value.Any()
                                                   ? token.Value.First()
                                                   : string.Empty
                                       };
                        }

                    case HttpStatusCode.Forbidden:
                        return new AuthorizationResponse { Code = AuthorizationCode.InvalidCredentials };
                    case HttpStatusCode.NotFound:
                        return new AuthorizationResponse { Code = AuthorizationCode.EmptyCredentials };
                    default:
                        return new AuthorizationResponse { Code = AuthorizationCode.Unknown };
                }
            }
        }
    }
}
