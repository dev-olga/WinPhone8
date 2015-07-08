using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Models
{
    public class User
    {
        public string UserName
        {
            get; set; 
        }

        public bool IsLoggedIn { get; set; }
    }
}
