using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Services
{
    using System.Net;

    using WinPhone.MyShows.Models.Shows;

    public class ShowsService : BaseService
    {
        async public Task<List<Show>> GetUserShowsAsync(string token)
        {
            using (var response = await this.GetAsync(string.Format("/profile/shows/"), token))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Show>>(json);
                    return result.Values.ToList();
                }

                return null;
            }
        }
    }
}
