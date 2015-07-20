using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Common.Offline
{
    using Windows.Storage;

    using WinPhone.App.Services.Offline;

    internal class OfflineManager
    {
        private readonly ApplicationDataContainer offlineContainer;

        private ApplicationDataContainer OfflineContainer
        {
            get
            {
                return this.offlineContainer;
            }
        }

        public OfflineManager(string storageKey)
        {
            this.offlineContainer = new OfflineStorage().GetContainer(storageKey);
        }

        public T Get<T>(string key)
        {
            return this.OfflineContainer.Values.ContainsKey(key) ? (T)this.OfflineContainer.Values[key] : default(T);
        }

        public void Save<T>(string key, T value)
        {
            this.OfflineContainer.Values[key] = value;
        }
    }
}
