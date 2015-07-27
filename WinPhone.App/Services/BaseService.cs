namespace WinPhone.App.Services
{
    using WinPhone.App.Common.Offline;

    internal abstract class BaseService
    {
        private readonly OfflineManager offlineManager;

        /// <summary>
        /// Gets the offline manager.
        /// </summary>
        protected OfflineManager OfflineManager
        {
            get
            {
                return this.offlineManager;
            }
        }

        protected BaseService(IStorage offlineStorage)
        {
            this.offlineManager = new OfflineManager(offlineStorage);
        }
    }
}
