using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Common
{
    using System.Net.NetworkInformation;

    using Windows.Networking.Connectivity;

    public static class InternetHelper
    {
        public static bool IsNetworkAvailable()
        {
            var isConnected = NetworkInterface.GetIsNetworkAvailable();
            
            if (isConnected)
            {
                var connection = NetworkInformation.GetInternetConnectionProfile().GetNetworkConnectivityLevel();
                if (connection == NetworkConnectivityLevel.None || connection == NetworkConnectivityLevel.LocalAccess)
                {
                    isConnected = false;
                }
            }

            return isConnected;
        }
    }
}
