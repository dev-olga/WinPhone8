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
        private string BaseUrl
        {
            get
            {
                // TODO: move to config
                return "http://api.myshows.ru";
            }
        }

        async protected Task<HttpResponseMessage> GetAsync(string url)
        {
            using (var client = new HttpClient() { BaseAddress = new Uri(this.BaseUrl) })
            {
                var message = new HttpRequestMessage(HttpMethod.Get, url);
                return await client.SendAsync(message);
            }
        }

        async protected Task<HttpResponseMessage> GetAsync(string url, string token)
        {
            using (var handler = new HttpClientHandler { UseCookies = true })
            {
                using (var client = new HttpClient(handler) { BaseAddress = new Uri(this.BaseUrl) })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, url);
                    message.Headers.Add("Cookie", token);
                    return await client.SendAsync(message);
                }
            }
        }
    }
}
