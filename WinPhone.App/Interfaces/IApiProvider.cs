using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Interfaces
{
    using WinPhone.MyShows.Services;

    internal interface IApiProvider
    {
        ProfileService ProfileService { get; }

        ShowsService ShowsService { get; }

        WinPhone.MyShows.Services.AuthorizationService AuthorizationService { get; }
    }
}
