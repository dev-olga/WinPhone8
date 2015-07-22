using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Common.Offline
{
    using Windows.Storage;

    public interface IStorage
    {
        StorageFolder GetStorage();
    }
}
