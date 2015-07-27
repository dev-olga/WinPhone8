using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Common.Offline
{
    internal static class OfflineProvider
    {
        /// <summary>
        /// The offline manager.
        /// </summary>
        private static OfflineManager offlineManager;

        /// <summary>
        /// The default offline manager.
        /// </summary>
        private static readonly OfflineManager DefaultOfflineManager = new OfflineManager(new LocalStorage());

        /// <summary>
        /// The set offline manager.
        /// </summary>
        /// <param name="offlineManager">
        /// The offline manager.
        /// </param>
        public static void SetOfflineManager(OfflineManager offlineManager)
        {
            OfflineProvider.offlineManager = offlineManager;
        }

        public static OfflineManager GetOfflineManager()
        {
            return OfflineProvider.offlineManager ?? DefaultOfflineManager;
        }
    }
}
