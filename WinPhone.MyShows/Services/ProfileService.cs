using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Services
{
    using System.Net;

    using WinPhone.MyShows.Models.Profile;

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
        public async Task<Profile> GetProfileAsync(string login)
        {
            var response = await this.GetAsync(string.Format("/profile/" + login));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Profile>(json);
                return result;
            }

            return null;
        }

        public async Task<Profile> GetUserProfileAsync(string token)
        {
            var response = await this.GetAsync(string.Format("/profile/"), token);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Profile>(json);
                return result;
            }

            return null;
        }

        /// <summary>
        /// Gets user's shows async.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The list of <see cref="UserShow"/>.
        /// </returns>
        public async Task<List<UserShow>> GetUserShowsAsync(string token)
        {
            using (var response = await this.GetAsync(string.Format("/profile/shows/"), token))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, UserShow>>(json);
                    return result.Values.ToList();
                }

                return null;
            }
        }
    }
}
