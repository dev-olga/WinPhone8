using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.ViewModels.Login
{
    using WinPhone.App.Common;
    using WinPhone.App.Models;

    public class LoginViewModel
    {
        private RelayCommand authorizeCommand;

        //public LoginModel Login { get; set; }

        public LoginViewModel()
        {
            //this.Login = new LoginModel();
        }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool Remember { get; set; }

        public RelayCommand UpdateNameCommand
        {
            get
            {
                return this.authorizeCommand ?? (this.authorizeCommand = new RelayCommand(this.Authorize));
            }
        }

        private void Authorize()
        {
            
        }
    }
}
