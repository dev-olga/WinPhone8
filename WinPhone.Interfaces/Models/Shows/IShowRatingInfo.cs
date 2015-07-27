using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.Interfaces.Models.Shows
{

    public interface IShowRatingInfo : IBaseShow
    {
        long Id { get; set; }

        int Year { get; set; }

        long Place { get; set; }

        long Watching { get; set; }
    }
}
