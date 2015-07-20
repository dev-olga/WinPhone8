namespace WinPhone.App.Services.Offline
{
    using Windows.Storage;

    internal class OfflineStorage
    {
        public ApplicationDataContainer GetContainer(string key)
        {
            return ApplicationData.Current.LocalSettings.CreateContainer(key, ApplicationDataCreateDisposition.Always);
        }
    }
}
