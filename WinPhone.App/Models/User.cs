using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Models
{
    public class User
    {
        public User(string userName)
        {
            this.UserName = userName;
        }

        public string UserName
        {
            get; private set; 
        }

        public string AuthorizationToken
        {
            get;
            set;
        }
    }
}
