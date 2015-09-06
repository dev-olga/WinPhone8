using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Tests.MyShows.Services
{
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

    using WinPhone.MyShows.Services;

    [TestClass]
    public class ShowsServiceTests
    {
        [TestMethod]
        public void GetUserShowsTests()
        {
            var service = new AuthorizationService();
            var task = service.AuthorizeAsync("_nuit", "test");
            task.Wait();
            var res = task.Result;

            var task1 = (new ProfileService()).GetUserShowsAsync(res.Token);
            //"PHPSESSID=s8lh2auubkmudcof44nthajhg1; SiteUser[login]=_nuit; SiteUser[password]=06e2268df7b5378019053acbe0c33021"
            task1.Wait();
            var res1 = task1.Result;
        }

        [TestMethod]
        public void GetWatchedEpisodesTests()
        {
            var service = new AuthorizationService();
            var task = service.AuthorizeAsync("_nuit", "test");
            task.Wait();
            var res = task.Result;

            var task1 = (new ProfileService()).GetWatchedEpisodesAsync(res.Token, 113);
            //"PHPSESSID=s8lh2auubkmudcof44nthajhg1; SiteUser[login]=_nuit; SiteUser[password]=06e2268df7b5378019053acbe0c33021"
            task1.Wait();
            var res1 = task1.Result;
        }
        

        [TestMethod]
        public void GetTopShowsTests()
        {

            var task1 = (new ShowsService()).GetTopShowsAsync();
            task1.Wait();
            var res1 = task1.Result;
        }
        
         [TestMethod]
        public void FindShowsAsyncTests()
        {

            var task1 = (new ShowsService()).FindShowsAsync("theory");
            task1.Wait();
            var res1 = task1.Result;
        }

         [TestMethod]
         public void GetShowWithEpisodesTests()
         {

             var task1 = (new ShowsService()).GetShowWithEpisodesAsync(113);
             task1.Wait();
             var res1 = task1.Result;
         }
        
    }
}
