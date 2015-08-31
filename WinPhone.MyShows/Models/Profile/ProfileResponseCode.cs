using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Models.Shows
{
    public enum ProfileResponseCode
    {
        OK = 1,
        AuthorizationRequired,
        NotFound,
        InvalidParameters,
        Unknown
    }
}
