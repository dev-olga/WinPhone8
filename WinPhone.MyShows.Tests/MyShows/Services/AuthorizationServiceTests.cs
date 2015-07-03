using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Tests.MyShows.Services
{
    using System.Xml;

    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

    using WinPhone.MyShows.Services;

    [TestClass]
    public class AuthorizationServiceTests
    {
        [TestMethod]
        public void AuthorizeTests()
        {
            var service = new AuthorizationService();
            var task = service.Authorize("_nuit", "test");
            task.Wait();
            var res = task.Result;
        }
    }
}
