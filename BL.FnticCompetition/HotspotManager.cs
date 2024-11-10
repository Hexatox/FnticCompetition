using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace BL.FnticCompetition
{
    public class HotspotManager
    {
        // Method to start a hotspot
        public void StartHotspot(string ssid, string password)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                StartHotspotWindows(ssid, password);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                StartHotspotLinux(ssid, password);
            }
            else
            {
                throw new PlatformNotSupportedException("This script currently supports only Windows and Linux.");
            }
        }

        // Method to list connected devices' MAC addresses
        public string[] GetConnectedDevices()
        {
            string command = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "arp -a" : "ip neigh show";
            string output = ExecuteCommand(command);

            // Use regex to extract MAC addresses
            var macAddresses = Regex.Matches(output, @"[0-9A-Fa-f]{2}([-:][0-9A-Fa-f]{2}){5}");
            string[] macArray = new string[macAddresses.Count];

            for (int i = 0; i < macAddresses.Count; i++)
            {
                macArray[i] = macAddresses[i].Value;
            }

            return macArray;
        }

        private void StartHotspotWindows(string ssid, string password)
        {
            ExecuteCommand($"netsh wlan set hostednetwork mode=allow ssid={ssid} key={password}");
            ExecuteCommand("netsh wlan start hostednetwork");
        }

        private void StartHotspotLinux(string ssid, string password)
        {
            ExecuteCommand($"nmcli dev wifi hotspot ifname wlp4s0 ssid {ssid} password {password}");
        }

        private string ExecuteCommand(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/bash";
            
            process.StartInfo.Arguments = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) 
                                          ? "/C " + command 
                                          : "-c \"" + command + "\"";
            
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }
    }
}
