using System;
namespace LoginSample.Data
{
    public interface INetworkConnection
    {
        bool IsConnected { get; set; }
        void CheckNetworkConnection();
        
    }
}
