using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace GenericGames.Helpers;

public class ConnectionHelper
{
    public static string GetIpAddress()
    {
        string returnAddress = String.Empty;

        // Get a list of all network interfaces (usually one per network card, dialup, and VPN connection)
        NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface network in networkInterfaces)
        {
            // Read the IP configuration for each network
            IPInterfaceProperties properties = network.GetIPProperties();

            if (network.OperationalStatus == OperationalStatus.Up &&
                   !network.Description.ToLower().Contains("virtual") &&
                   !network.Description.ToLower().Contains("pseudo"))
            {
                // Each network interface may have multiple IP addresses
                foreach (IPAddressInformation address in properties.UnicastAddresses)
                {
                    // We're only interested in IPv4 addresses for now
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                    {
                        continue;
                    }

                    // Ignore loopback addresses (e.g., 127.0.0.1)
                    if (IPAddress.IsLoopback(address.Address))
                    {
                        continue;
                    }

                    returnAddress = address.Address.ToString();
                }
            }
        }

        return returnAddress;
    }
}
