namespace WinPhone.App.Common.Offline
{
    using Windows.Storage;

    internal class LocalStorage : IStorage
    {
        public StorageFolder GetStorage()
        {
            return ApplicationData.Current.LocalFolder;
        }
    }
}
