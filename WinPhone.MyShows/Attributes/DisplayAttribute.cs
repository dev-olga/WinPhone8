using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.MyShows.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class DisplayAttribute : Attribute
    {
        public string Name { get; private set; }

        public DisplayAttribute(string name)
        {
            this.Name = name;
        }
    }
}
