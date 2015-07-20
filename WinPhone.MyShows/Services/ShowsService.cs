using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Services
{
    using System.Net;

    using WinPhone.MyShows.Models.Shows;

    public class ShowsService : BaseService
    {
        async public Task<List<ShowRatingInfo>> GetTopShowsAsync()
        {
            using (var response = await this.GetAsync(string.Format("/shows/top/all/")))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShowRatingInfo>>(json);
                    return result;
                }

                return null;
            }
        }

        async public Task<List<ShowInfo>> FindShowsAsync(string search)
        {
            using (var response = await this.GetAsync(string.Format("/shows/search/?q=" + search)))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, ShowInfo>>(json);
                    return result.Values.ToList();
                }

                return null;
            }
        }

        async public Task<ShowInfo> GetShowWithEpisodesAsync(long id)
        {
            using (var response = await this.GetAsync(string.Format("/shows/" + id)))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ShowInfo>(json);
                    return result;
                }

                return null;
            }
        }
    }
}
