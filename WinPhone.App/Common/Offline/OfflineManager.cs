using System;

namespace WinPhone.App.Common.Offline
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    using Windows.Storage;


    internal class OfflineManager
    {
        private readonly IStorage storage;

        private IStorage Storage
        {
            get
            {
                return this.storage;
            }
        }

        public OfflineManager(IStorage storage)
        {
            this.storage = storage;
        }

        public async Task<T> GetAsync<T>(Enum key, IDictionary<string, object> parameters = null)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var storageFolder = await this.Storage.GetStorageFolderAsync();
            using (var stream =
                    await storageFolder.OpenStreamForReadAsync(this.GetKeyName(key, parameters)))
            {
                try
                {
                    return (T)serializer.ReadObject(stream);
                }
                catch (Exception ex)
                {
                    return default(T);
                }
            }
        }

        public async Task SaveAsync<T>(Enum key, T value, IDictionary<string, object> parameters = null)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var storageFolder = await this.Storage.GetStorageFolderAsync();
            using (
                var stream =
                    await storageFolder.OpenStreamForWriteAsync(this.GetKeyName(key, parameters), CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, value);
            }
        }

        public async void Clear()
        {
            var storageFolder = await this.Storage.GetStorageFolderAsync();
            await storageFolder.DeleteAsync();
        }


        private string GetKeyName(Enum key, IDictionary<string, object> parameters = null)
        {
            var hash = this.GetKeyHash(parameters);
            return string.Format("{0}.{1}&{2}", key.GetType().FullName, key, hash);
        }

        private string GetKeyHash(IDictionary<string, object> parameters)
        {
            var sb = new StringBuilder();

            if (parameters != null && parameters.Any())
            {
                var mergedParams = parameters.Where(kvp => !string.IsNullOrEmpty(kvp.Key))
                                             .Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value))
                                             .ToArray();
                sb.AppendFormat("[{0}]", string.Join(";", mergedParams));
            }

            return sb.ToString();
        }
    }
}
