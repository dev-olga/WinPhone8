using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Models.ShowDetails
{
    using WinPhone.MyShows.Models.Shows;

    public class ToNavigationParameter
    {
        public long ShowId { get; set; }
        public ShowStatus Status { get; set; }
    }
}
