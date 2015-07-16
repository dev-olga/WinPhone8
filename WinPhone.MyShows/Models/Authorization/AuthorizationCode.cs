using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Models.Authorization
{
    public enum AuthorizationCode
    {
        OK = 1,
        InvalidCredentials,
        EmptyCredentials,
        Unknown
    }
}
