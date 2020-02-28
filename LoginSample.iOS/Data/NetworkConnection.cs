using System;
using CoreFoundation;
using LoginSample.Data;
using LoginSample.iOS.Data;
using SystemConfiguration;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]
namespace LoginSample.iOS.Data
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            InternetStatus();
        }

        public bool InternetStatus()
        {
            NetworkReachabilityFlags flags;
            bool defaultNetworkAvailable = IsNetworkAvailable(out flags);
            if (defaultNetworkAvailable && (flags & NetworkReachabilityFlags.IsDirect) != 0)
            {
                return false;
            }
            else if (flags == 0)
            {
                return false;
            }
            return true;
        }

        private event EventHandler ReachabilityChanged;
        private void onChange(NetworkReachabilityFlags flags)
        {
            var h = ReachabilityChanged;
            if (h != null)
            {
                h(null, EventArgs.Empty);
            }
        }

        private NetworkReachability defaultNetworkReachability;
        public bool IsNetworkAvailable(out NetworkReachabilityFlags flags)
        {
            if (defaultNetworkReachability == null)
            {
                defaultNetworkReachability = new NetworkReachability(new System.Net.IPAddress(0));
                defaultNetworkReachability.SetNotification(onChange);
                defaultNetworkReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
            }
            if (!defaultNetworkReachability.TryGetFlags(out flags))
            {
                return false;
            }
            return ISReachableWithoutRequiringConnection(flags);
        }

        private bool ISReachableWithoutRequiringConnection(NetworkReachabilityFlags flags)
        {
            bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;
            bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

            if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
            {
                noConnectionRequired = true;
            }
            return isReachable && noConnectionRequired;
        }
    }
}
