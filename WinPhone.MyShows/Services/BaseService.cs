namespace WinPhone.MyShows.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class BaseService
    {
        /// <summary>
        /// Gets the base url.
        /// </summary>
        protected string BaseUrl
        {
            get
            {
                // TODO: move to config
                return "http://api.myshows.ru";
            }
        }

        async protected Task<string> Read(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(new Uri(url));
            return await response.Content.ReadAsStringAsync();
        }
    }
}
