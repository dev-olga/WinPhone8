namespace WinPhone.App.Common.Offline
{
    using System;
    using System.Threading.Tasks;

    using Windows.Storage;

    internal class LocalStorage : IStorage
    {
        public async Task<StorageFolder> GetStorageFolderAsync()
        {
            return await ApplicationData.Current.LocalFolder.GetFolderAsync("OfflineData");
        }
    }
}
