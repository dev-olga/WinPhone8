using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Models.Shows
{
    public class ProfileResponse
    {
        public ProfileResponseCode Code { get; set; }
    }

    public class ProfileResponse<T> : ProfileResponse
    {
        public T Data { get; set; }
    }
}
