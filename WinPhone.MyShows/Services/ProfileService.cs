using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Services
{
    using System.Net;

    using WinPhone.MyShows.Models.Profile;
    using WinPhone.MyShows.Models.Shows;

    public class ProfileService : BaseService
    {
        /// <summary>
        /// Gets profile data  async.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <returns>
        /// The <see cref="Profile"/>.
        /// </returns>
        public async Task<ProfileResponse<Profile>> GetProfileAsync(string login)
        {
            var result = new ProfileResponse<Profile>();
            var response = await this.GetAsync("/profile/" + login);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Profile>(json);
                        result.Code = ProfileResponseCode.OK;
                        result.Data = data;
                        break;
                    }
                case HttpStatusCode.Unauthorized:
                    {
                        result.Code = ProfileResponseCode.AuthorizationRequired;
                        break;
                    }
                default:
                    {
                        result.Code = ProfileResponseCode.Unknown;
                        break;
                    }
            }
            return result;
        }

        //public async Task<Profile> GetUserProfileAsync(string token)
        //{
        //    var response = await this.GetAsync(string.Format("/profile/"), token);

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        var json = await response.Content.ReadAsStringAsync();
        //        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Profile>(json);
        //        return result;
        //    }

        //    return null;
        //}

        /// <summary>
        /// Gets user's shows async.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The list of <see cref="UserShow"/>.
        /// </returns>
        public async Task<ProfileResponse<List<UserShow>>> GetUserShowsAsync(string token)
        {
            var result = new ProfileResponse<List<UserShow>>();
            using (var response = await this.GetAsync(string.Format("/profile/shows/"), token))
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        {
                            var json = await response.Content.ReadAsStringAsync();
                            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, UserShow>>(json);
                            result.Code = ProfileResponseCode.OK;
                            result.Data = data.Values.ToList();
                            break;
                        }
                    case HttpStatusCode.Unauthorized:
                        {
                            result.Code = ProfileResponseCode.AuthorizationRequired;
                            break;
                        }
                    default:
                        {
                            result.Code = ProfileResponseCode.Unknown;
                            break;
                        }
                }

                return result;
            }
        }

        public async Task<ProfileResponse> UpdateShowStatusAsync(long id, ShowStatus status)
        {
            var result = new ProfileResponse();
            using (var response = await this.GetAsync("/profile/shows/" + id + "/" + status.ToString().ToLower()))
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        {
                            result.Code = ProfileResponseCode.OK;
                            break;
                        }
                    case HttpStatusCode.Unauthorized:
                        {
                            result.Code = ProfileResponseCode.AuthorizationRequired;
                            break;
                        }
                    case HttpStatusCode.NotFound:
                        {
                            result.Code = ProfileResponseCode.NotFound;
                            break;
                        }
                    default:
                        {
                            result.Code = ProfileResponseCode.Unknown;
                            break;
                        }
                }

                return result;
            }
        }
    }
}
