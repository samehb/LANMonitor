using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Data.SQLite;

namespace LANMonitor
{
    public partial class LANMonitorForm : Form
    {
        Dictionary<string, int> InterfacesIndex = new Dictionary<string, int>();
        Dictionary<string, int> GVList = new Dictionary<string, int>();
        Dictionary<string, string> Hostnames = new Dictionary<string, string>();
        Dictionary<string, string> FirstSeenList = new Dictionary<string, string>();
        Dictionary<string, string> LastSeenList = new Dictionary<string, string>();
        Dictionary<string, string> Descriptions = new Dictionary<string, string>();
        Dictionary<string, string> IPAddresses = new Dictionary<string, string>();
        Dictionary<string, string> Vendors = new Dictionary<string, string>();

        string Connected = "";

        bool ClearDevices = false;

        string ExcludedList = "";
        string ColumnOrder = "";
        string InterfacesString = "";
        string SelectedInterfaceName;
        int ScanLimit = 254;
        int RefreshTime = 1;
        bool FirstRun = true;

        IEnumerable<KeyValuePair<string, string>> justconnected;
        IEnumerable<KeyValuePair<string, string>> justdisconnected;


        struct InterfaceInfo // Struct to hold interfaces information.
        {
            public IPAddress IP;
            public long BaseIP;
            public string MAC;
            public string DeviceName;
            public int InterfaceCapacity; // Note for later.
        }

        List<InterfaceInfo> Interfaces = new List<InterfaceInfo>();
        InterfaceInfo SelectedInterface = new InterfaceInfo();

        Dictionary<string, string> macc = null;

        public void SelectInterface() // Select network interface.
        {
            if (Interfaces.Count > 0) // If we find an interface continue. If that is not the case, skip scanning of devices and ask the user to connect an interface then restart.
            {
                if (InterfacesIndex.ContainsKey(SelectedInterfaceName)) // The next block is to determine if the interface (name) is available to us, if it is not continue to check for the default interface, and if that is not available simply get the first interface we find.
                    SelectedInterface = Interfaces[InterfacesIndex[SelectedInterfaceName]];
                else
                {
                    if (InterfacesIndex.ContainsKey("Local Area Connection"))
                    {
                        SelectedInterface = Interfaces[InterfacesIndex["Local Area Connection"]];
                        SelectedInterfaceName = "Local Area Connection";
                    }
                    else
                    {
                        SelectedInterface = Interfaces[0];
                        SelectedInterfaceName = InterfacesString.Split('|')[0];
                    }
                }
                LMStatusText.Text = "Scanning the devices for the first time, please wait.";
                RefreshDevicesTimer.Enabled = true;
            }
            else
                LMStatusText.Text = "Failed to acquire an active network interface, please enable at least one interface then restart the program.";
        }

        public void GetInterfaces() // Get all network interfaces available.
        {
            InterfaceInfo Interface = new InterfaceInfo();
            int counter = 0;
            IEnumerable<NetworkInterface> nics = (NetworkInterface.GetAllNetworkInterfaces().Where(network => (network.NetworkInterfaceType == NetworkInterfaceType.Ethernet || network.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) && network.OperationalStatus == OperationalStatus.Up));
            foreach (NetworkInterface ni in nics)
            {
                foreach (UnicastIPAddressInformation uipi in ni.GetIPProperties().UnicastAddresses)
                {
                    if (uipi.IPv4Mask != null && uipi.IPv4Mask.ToString() != "0.0.0.0")
                    {
                        if (!InterfacesIndex.ContainsKey(ni.Name))
                        {
                            InterfacesIndex.Add(ni.Name, counter);
                            Interface.IP = uipi.Address;
                            string[] NetmaskParts = uipi.IPv4Mask.ToString().Split('.');
                            string[] IPParts = uipi.Address.ToString().Split('.');
                            string StartIP = (int.Parse(IPParts[0]) & (int.Parse(NetmaskParts[0]))) + "." + (int.Parse(IPParts[1]) & (int.Parse(NetmaskParts[1]))) + "." + (int.Parse(IPParts[2]) & (int.Parse(NetmaskParts[2]))) + "." + (int.Parse(IPParts[3]) & (int.Parse(NetmaskParts[3])));
                            Interface.BaseIP = (long)BitConverter.ToInt32(IPAddress.Parse(StartIP).GetAddressBytes(), 0);
                            Interface.InterfaceCapacity = 254 - int.Parse(NetmaskParts[3]); // Later.
                            Interface.MAC = string.Join("-", (from z in ni.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());
                            Interface.DeviceName = Dns.GetHostName();

                            Interfaces.Add(Interface);
                            InterfacesString += ni.Name + "|" + uipi.Address + ";";
                            counter++;
                        }
                    }
                }
            }
            SelectInterface();
        }

        private delegate IPHostEntry GetHostEntryHandler(string ip);

        public string GetReverseDNS(string ip, int timeout) // Attempt to get the hostname from an IP address. Fastest approach.
        {
            try
            {
                GetHostEntryHandler callback = new GetHostEntryHandler(Dns.GetHostEntry);
                IAsyncResult result = callback.BeginInvoke(ip, null, null);
                if (result.AsyncWaitHandle.WaitOne(timeout, false))
                {
                    return callback.EndInvoke(result).HostName;
                }
                else
                {
                    return "Unknown";
                }
            }
            catch (Exception)
            {
                return "Unknown";
            }
        }

        
        public void UpdateSeenInformation() // Update last seen information.
        {
            string now = DateTime.Now.ToString("g");
            try
            {
                foreach (KeyValuePair<string, string> device in macc)
                {
                    LANDevicesList.Rows[GVList[device.Key]].Cells["LastSeen"].Value = LastSeenList[device.Key];
                }
                LANDevicesList.Rows[GVList[SelectedInterface.MAC]].Cells["LastSeen"].Value = now;
            }
            catch
            {

            }
        }

        public void UpdateIPs() // Refresh IP information.
        {
            int i = 0;
            foreach (DataGridViewRow row in LANDevicesList.Rows)
            {
                if (IPAddresses.ContainsKey(row.Cells["MAC"].Value.ToString()))
                {
                    LANDevicesList.Rows[GVList[row.Cells["MAC"].Value.ToString()]].Cells["IP"].Value = IPAddresses[row.Cells["MAC"].Value.ToString()];
                }
                i++;
            }
        }

        public void DisplayDevicesUpdates() // Display the devices after the first time (DisplayDevices) handling the updates.
        {
            string[] value;
            string connected = "Connected=";
            string disconnected = "Disconnected=";
            string btext = "";

            int counter = LANDevicesList.Rows.Count;

            try
            {
                foreach (KeyValuePair<string, string> device in justconnected)
                {
                    value = device.Value.Split(';');
                    if (GVList.ContainsKey(device.Key))
                        LANDevicesList.Rows[GVList[device.Key]].Cells["Status"].Value = "Online";
                    else
                    {
                        LANDevicesList.Rows.Add(value[0], value[1], value[2], FirstSeenList[device.Key], LastSeenList[device.Key], "", Vendors[value[2]], value[3], true);
                        GVList.Add(device.Key, counter);
                        Hostnames.Add(device.Key, value[1]);
                        counter++;
                    }
                    if (!ExcludedList.Contains(value[2] + ";"))
                        connected += "'" + (Descriptions[device.Key] != "" ? Descriptions[device.Key] : Hostnames[device.Key]) + "' ";
                }
                foreach (KeyValuePair<string, string> device in justdisconnected)
                {
                    value = device.Value.Split(';');
                    LANDevicesList.Rows[GVList[device.Key]].Cells["Status"].Value = "Offline";
                    if (!ExcludedList.Contains(value[2] + ";"))
                        disconnected += "'" + (Descriptions[device.Key] != "" ? Descriptions[device.Key] : Hostnames[device.Key]) + "' ";
                }
            }
            catch
            {

            }

            UpdateSeenInformation();


            UpdateIPs();

            if (connected.Trim() != "Connected=")
                btext = connected + Environment.NewLine;

            if (disconnected.Trim() != "Disconnected=")
                btext += disconnected + Environment.NewLine;

            if (btext != "")
                LANMonitorNotify.ShowBalloonTip(3000, "LANMonitor", btext, ToolTipIcon.Info);
        }

        public void DisplayDevices() // Display all devices available. This is called when you do not have any entries.
        {
            string[] value;
            string now = DateTime.Now.ToString("g");
            int counter = 0;
            foreach (KeyValuePair<string, string> device in macc)
            {
                value =  device.Value.Split(';');
                LANDevicesList.Rows.Add(value[0], value[1], value[2], FirstSeenList[device.Key], LastSeenList[device.Key], Descriptions[device.Key], Vendors[device.Key], value[3], !ExcludedList.Contains(value[2] + ";"));
                GVList.Add(device.Key, counter);
                Hostnames.Add(device.Key, value[1]);
                counter++;
            }

            LANDevicesList.Rows.Add(SelectedInterface.IP.ToString(), SelectedInterface.DeviceName, SelectedInterface.MAC, now, now, "My PC", GetVendor(SelectedInterface.MAC), "Online", false); // This segment is used to manually insert your computer as entry to the list. 
            GVList.Add(SelectedInterface.MAC, counter);
            Hostnames.Add(SelectedInterface.MAC, SelectedInterface.DeviceName);


            LANDevicesList.ClearSelection();
        }

        public string GetHost(string ip) // Acquire hostname from an IP address if possible.
        {
            try
            {
                string host = Dns.GetHostEntry(ip).HostName;
                return host;
            }
            catch
            {
                return "Unknown";
            }
        }

        void ResetVariables()
        {
            ClearDevices = false;
            FirstRun = true;
            macc = new Dictionary<string, string>();
            GVList = new Dictionary<string, int>();

            Hostnames = new Dictionary<string, string>();
            FirstSeenList = new Dictionary<string, string>();
            LastSeenList = new Dictionary<string, string>();
            Descriptions = new Dictionary<string, string>();

            ExcludedList = "";
        }

        public void MonitorNetwork() // This is the main method that is responsible for monitoring the network for changes.
        {
            Dictionary<string, string> macs = new Dictionary<string,string>();
            bool firstruncache = FirstRun && (macc.Count > 1);

            if (ClearDevices)
            {
                ResetVariables();
                BackgroundWorker.ReportProgress(2);
            }

            if (!FirstRun || (FirstRun && macc.Count < 1))
                macs = GetMACData();
            else
                macs = macc;

            if (FirstRun)
            {
                macc = new Dictionary<string, string>(macs);
                BackgroundWorker.ReportProgress(0);
                Thread.Sleep(100);
                FirstRun = false;
            }

            justconnected = macs.Except(macc);
            justdisconnected = macc.Except(macs);

            BackgroundWorker.ReportProgress(1);

            if (!firstruncache)
                macc = new Dictionary<string, string>(macs);
            else
                macc = new Dictionary<string, string>(justconnected.ToDictionary(x => x.Key, x => x.Value));
        }

        string GetMACs() // Get MAC addresses and their associated IPs by interating over the ARP cache.
        {
            MassPing(SelectedInterface.BaseIP);

            string macslist = "";

            Process process = new Process();
            process.StartInfo.FileName = "arp";
            process.StartInfo.Arguments = "-a";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            try
            {
                process.Start();

                using (StreamReader sr = process.StandardOutput)
                {
                    string SelectedInterfaceIP = SelectedInterface.IP.ToString();
                    string line = "";

                    while (line != null && (!line.Contains("Interface: " + SelectedInterfaceIP)))
                    {
                        line = sr.ReadLine();
                    }

                    sr.ReadLine();

                    line = sr.ReadLine();

                    while (line != null && line != "" && line.Contains("dynamic"))
                    {
                        string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        macslist += parts[1].Trim().ToUpper() + "," + parts[0].Trim() + ";";
                        line = sr.ReadLine();
                    }
                }
                process.WaitForExit();
            }
            catch
            {

            }

            return macslist;
        }

        public Dictionary<string, string> GetMACData() // Get and return the data associated with MACs.
        {
            Dictionary<string, string> macsdetails = new Dictionary<string, string>();

            string m = GetMACs().TrimEnd(';');
            if (m != "")
            {
                string[] macs = m.Split(';');
                Connected = "";
                foreach (string macstring in macs)
                {
                    string[] macvalues = macstring.Split(',');
                    string maca = macvalues[0];
                    string ip = macvalues[1];
                    string hostname;

                    if (Hostnames.ContainsKey(maca)) // Using Hostnames cache to skip calling host enquiry methods to save time making the hosts changes display faster
                        hostname = Hostnames[maca];
                    else
                    {
                        hostname = GetReverseDNS(ip, 1000); // If the Hostnames cache does not contain the host we need, we begin by calling GetReverseDNS which is a fast method for acquiring hostnames. Most of the time this method works and returns the hostnames but sometime it does not so we use the normal slower method instead. This is the best approach.
                        if (hostname == "Unknown")
                            hostname = GetHost(ip);
                    }

                    string time = DateTime.Now.ToString("g");

                    if (FirstSeenList.ContainsKey(maca))
                    {
                        if (LastSeenList.ContainsKey(maca))
                            LastSeenList[maca] = time;
                        else
                            LastSeenList.Add(maca, time);
                    }
                    else
                    {
                        FirstSeenList.Add(maca, time);
                        LastSeenList.Add(maca, time);
                    }

                    if (IPAddresses.ContainsKey(maca))
                        IPAddresses[maca] = ip;
                    else
                        IPAddresses.Add(maca, ip);

                    if (!Descriptions.ContainsKey(maca))
                        Descriptions.Add(maca, "");

                    if (!Vendors.ContainsKey(maca))
                        Vendors.Add(maca, GetVendor(maca));

                    if (!macsdetails.ContainsKey(maca))
                        macsdetails.Add(maca, ip + ";" + hostname + ";" + maca + ";Online");

                    Connected += "'" + ((Descriptions.ContainsKey(maca) && Descriptions[maca] != "") ? Descriptions[maca] : hostname) + "' ";
                }
            }

            return macsdetails;
        }

        private void MassPing(long baseiplong) // Async mass ping. This method is used to generate the ARP entries.
        {
            for (long i = 1; i < ScanLimit; i++)
            {
                Thread t = new Thread(() => { try { Ping p = new Ping(); p.Send(new IPAddress(i * 16777216 + baseiplong), 1000); } catch { } }); // 16777216 - 256*256*256
                t.Start();
            }
            Thread.Sleep(1000);
        }

        private void FlushARPCache() // Flush the ARP cache manually if we get inaccurate data.
        {
            Process process = new Process();
            process.StartInfo.FileName = "netsh";
            process.StartInfo.Arguments = "interface ip delete arpcache";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            try
            {
                process.Start();
                process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
            catch
            {

            }
        }

        private string GetVendor(string mac) // Get the inteface vendor by looking up the MAC address.
        {
            string vendor = "";
            SQLiteConnection sqlitedbc = new SQLiteConnection("Data Source=LANMonitor.db;Version=3;");
            sqlitedbc.Open();

            string sqlcmd = "select Vendor from macvendor where MAC='" + mac.Substring(0, 8) + "' limit 1";
            SQLiteCommand command = new SQLiteCommand(sqlcmd, sqlitedbc);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
                vendor = reader["Vendor"].ToString();

            sqlitedbc.Close();

            return vendor;
        }
    }
}
