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
            using (var stream =
                    await this.Storage.GetStorage().OpenStreamForReadAsync(this.GetKeyName(key)))
            {
                //using (var reader = new StreamReader(stream))
                //{
                //    var content = await reader.ReadToEndAsync();
                    
                //}
                return (T)serializer.ReadObject(stream);
            }
        }

        public async Task SaveAsync<T>(Enum key, T value)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using (
                var stream =
                    await
                    this.Storage.GetStorage()
                        .OpenStreamForWriteAsync(this.GetKeyName(key), CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, value);
            }
        }

        public void Clear()
        {
            
        }


        private string GetKeyName(Enum key)
        {
            return String.Format("{0}.{1}", key.GetType().FullName, key);
        }
    }
}
