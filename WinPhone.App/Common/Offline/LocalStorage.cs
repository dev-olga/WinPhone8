namespace WinPhone.App.Common.Offline
{
    using System;
    using System.Threading.Tasks;

    using Windows.Storage;

    using WinRTXamlToolkit.IO.Extensions;

    internal class LocalStorage : IStorage
    {
        private static readonly string FolderName = "OfflineData";

        public async Task<StorageFolder> GetStorageFolderAsync()
        {
            var folder = ApplicationData.Current.LocalFolder;
            if (!await folder.ContainsFolderAsync(FolderName))
            {
                return await ApplicationData.Current.LocalFolder.CreateFolderAsync(FolderName);
            }
            return await ApplicationData.Current.LocalFolder.GetFolderAsync(FolderName);
        }
    }
}
