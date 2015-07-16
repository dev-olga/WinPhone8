using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.ViewModels.Main
{
    using WinPhone.App.Interfaces;

    public class MainViewModel : AuthorizedViewModel
    {
        public MainViewModel(IAuthorizationService authorizationService)
            : base(authorizationService)
        {
        }
    }
}
