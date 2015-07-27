using System;

namespace WinPhone.App.Common.Offline
{
    using System.IO;
    using System.Runtime.Serialization;
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

        public async Task<T> GetAsync<T>(Enum key)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var storageFolder = await this.Storage.GetStorageFolderAsync();
            using (var stream =
                    await storageFolder.OpenStreamForReadAsync(this.GetKeyName(key)))
            {
                return (T)serializer.ReadObject(stream);
            }
        }

        public async Task SaveAsync<T>(Enum key, T value)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var storageFolder = await this.Storage.GetStorageFolderAsync();
            using (
                var stream =
                    await storageFolder.OpenStreamForWriteAsync(this.GetKeyName(key), CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, value);
            }
        }

        public async void Clear()
        {
            var storageFolder = await this.Storage.GetStorageFolderAsync();
            await storageFolder.DeleteAsync();
        }


        private string GetKeyName(Enum key)
        {
            return string.Format("{0}.{1}", key.GetType().FullName, key);
        }
    }
}
