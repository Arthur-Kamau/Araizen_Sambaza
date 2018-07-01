using NETCONLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sambaza
{
    /// <summary>
    /// class for getting wifi details
    /// such as
    ///    1)my ip
    ///    2)hotspot name
    ///    3)is hotspot running
    /// </summary>
    #region App_Hotspot_Details
    class App_Hotspot_Details
    {
        App_Console console = new App_Console();
        List<String> mac_address_list = new List<string>();
        List<HotspotGuest> mac_ip_address_list = new List<HotspotGuest>();

        /// <summary>
        ///    method to get list of mac address of connected devices.
        /// </summary>
        /// <returns> List<String>  of mac address </returns>
        #region Mac_connected_devices()
        public List<String> Mac_connected_devices()
        {
            String output = Console_command("netsh", "wlan show hosted");
            // Console.WriteLine("1------>{0}", output);
            mac_address_list = GetMacAddr(output);
            foreach (string item in mac_address_list)
            {
                Console.WriteLine("mac list item-number  = {0}", item);
            }
            return mac_address_list;
        }
        #endregion

        /// <summary>
        ///  method to get HotspotGuest details from mac Address of connected devices
        ///  HotspotGuest => ip,mac,name
        /// </summary>
        /// <returns> List<HotspotGuest></returns>
        #region  Mac_Ip_connected_devices()
        public List<HotspotGuest> Mac_Ip_connected_devices()
        {

            if (mac_address_list.Count == 0 || mac_address_list == null)
            {
                String output_ = Console_command("netsh", "wlan show hosted");
                //  Console.WriteLine("1------>{0}", output_);
                mac_address_list = GetMacAddr(output_);

            }
            String output = Console_command("arp", "-a");
            // Console.WriteLine("2------>{0}", output);
            foreach (string macs in mac_address_list)
            {
                string item_ip = GetIp(output, macs.Replace(":", "-"));

                HotspotGuest awgd = new HotspotGuest
                {
                    ComputerName = "",
                    GuestIp = item_ip,
                    MacAddress = macs

                };
                Console.WriteLine("The ip is {0} and sub string= mac address is {1}--", awgd.GuestIp, awgd.MacAddress);
                mac_ip_address_list.Add(awgd);
            }

            return mac_ip_address_list;
        }
        #endregion

        /// <summary>
        /// method to get the number of  connected devices
        /// </summary>
        /// <returns> integer</returns>
        #region NumberOfClientsConnected()
        public int NumberOfClientsConnected()
        {
            int number = 0;
            if (mac_address_list.Count == 0 || mac_address_list == null)
            {
                String output_ = Console_command("netsh", "wlan show hosted");
                Console.WriteLine("1------>{0}", output_);
                mac_address_list = GetMacAddr(output_);

            }
            number = mac_address_list.Count();
            return number;
        }
        #endregion

        /// <summary>
        /// method to get HotSpotDetails
        ///  HotSpotDetails = > name ,ip, computername
        /// </summary>
        /// <returns>HotSpotDetails</returns>
        #region Self_mac_Ip()
        public HotSpotDetails Self_mac_Ip()
        {

            string host_name = Dns.GetHostName();
            string ip = string.Empty;
            var host = Dns.GetHostEntry(host_name);
            foreach (var ip_ in host.AddressList)
            {
                if (ip_.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = ip_.ToString();
                }
            }


            Console.WriteLine("-->my host name is {0} and my ip is {1} ", host_name, ip);
            HotSpotDetails s = new HotSpotDetails();
            s.SelfIp = ip;
            s.MacAddress = App_System_Details.GetMacAddress();
            s.ComputerName = host_name;
            return s;
        }
        #endregion

        /// <summary>
        /// method to check if hot spot is on
        /// 
        /// </summary>
        /// <returns> boolean </returns>
        #region IsHotspotActive
        public Boolean IsHotspotActive()
        {
            App_Console console = new App_Console();

            String output = console.UserConsole("netsh", "wlan show hosted");
            string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (line.Contains("Status"))
                {
                    string the_status_ = line.Substring(line.LastIndexOf(":") + 1);
                    string the_status = the_status_.Replace(" ", string.Empty);
                    Console.WriteLine("Wifi satus {0}", the_status_);
                    //Console.WriteLine("Wifi satus {0}", the_status);
                    if (the_status.Contains("Started"))
                    {
                        string ssid_name = SsidName();
                        Console.WriteLine("ssid name = {0}", ssid_name);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        #endregion


        /// <summary>
        /// method to check if wifi  is on or off
        /// 
        /// </summary>
        /// <returns> boolean </returns>
        #region IsWifiActive
        public Boolean IsWifiActive()
        {
            App_Console console = new App_Console();

            String output = console.UserConsole("netsh", "wlan show interface");
            string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (line.Contains("Hosted network status"))
                {
                    string the_status_ = line.Substring(line.LastIndexOf(":") + 1);
                    string the_status = the_status_.Replace(" ", string.Empty);
                   
                    if (the_status.Contains("Not started") || the_status.Equals("Not started"))
                    {
                       
          
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        #endregion

        /// <summary>
        /// get the name of the hotspot
        /// </summary>
        /// <returns></returns>
        #region SsidName()
        public string SsidName()
        {
            App_Console console = new App_Console();
            String output = console.UserConsole("netsh", "wlan show hosted");
            string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (line.Contains("SSID"))
                {
                    string the_name_ = line.Substring(line.LastIndexOf(":") + 1);
                    string the_name = the_name_.Replace(" ", string.Empty);
                    return the_name;
                }
            }
            return "";
        }
        #endregion


        /// <summary>
        /// method to run console command and get the output
        /// </summary>
        /// <param name="command"></param>
        /// <param name="args"></param>
        /// <returns> string </returns>
        #region  Console_command
        private string Console_command(string command, string args)
        {
            string output = string.Empty;

            ProcessStartInfo processStartInfo = new ProcessStartInfo(command, args);
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;

            processStartInfo.CreateNoWindow = true;

            Process proc = new Process
            {
                StartInfo = processStartInfo
            };

            proc.Start();

            output = proc.StandardOutput.ReadToEnd();


            return output;
        }
        #endregion

        /// <summary>
        /// get mac address from console output
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        #region  GetMacAddr(string output)
        private List<string> GetMacAddr(string output)
        {
            //split_string.Substring(0, split_string.LastIndexOf(uptoword));

            string mac = string.Empty;
            List<string> mac_ad = new List<string>();

            string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (line.Contains("Authenticated")) //"Number of clients"))
                {

                    mac = line.Substring(0, line.LastIndexOf("Authenticated"));
                    mac_ad.Add(mac.Replace(" ", string.Empty));
                }
            }
            return mac_ad;

        }
        #endregion

        /// <summary>
        /// method to getip from macaddress and ip
        /// </summary>
        /// <param name="output"></param>
        /// <param name="mac"></param>
        /// <returns>string</returns>
        #region GetIp(String output, String mac)
        private string  GetIp(String output, String mac)
        {
            // string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //or
            string ip = string.Empty;
            string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (line.Contains(mac))
                {
                    Console.WriteLine("1 line = {0}", line);
                    ip = line.Substring(0, line.LastIndexOf(mac));
                }
            }
            return ip;
        }
        #endregion
    }
    #endregion


    /// <summary>
    /// Interaction logic for starting - stoping hotspot 
    /// </summary>
    #region App Hotspot 
    class App_Hotspot
    {
       // private const string V = "Wi-Fi";
        Hotspot h = null;

        #region constructor
        public App_Hotspot()
        {
            h = new Hotspot();
        }
        #endregion

        #region Start 
        public void Start(string ssid , string shareOption , string key = "12345678")
        {
            //if (string.IsNullOrEmpty(shareOption))
            //{
            //    shareOption = V;
            //}

            Console.WriteLine("Start wifi name {0} and key {1} with share option {2}",ssid,key,shareOption);
            h.create(ssid, key);
            h.start();
           //h.shareinternet("Ethernet", shareOption, true);
           h.shareinternet( shareOption, shareOption, true);
            

            Console.WriteLine(h.Message);

          

        }
        #endregion
        #region Share options 
        public List<String> ShareOptions()
        {
            List<String> options = new List<string>();

            Console.WriteLine("-----------------------------------------------------------");
            h.getconnections().ForEach(prop =>
            {
                Console.WriteLine("conn -" + prop);
                options.Add(prop);
            });
            Console.WriteLine("-----------------------------------------------------------");

            return options;
        }
        #endregion
        #region Stop hot spot
        public void Stop()
        {
            h.stop();
            //h.getconnections().ForEach((conprop) =>
            //{
            //    //(conprop)
            //    Console.WriteLine("conn -" + conprop);
            //});

        }
        #endregion

        #region Share internet
        public void ShareInternet()
        {
            //h.shareinternet("Ethernet", "Wi-Fi", true);
            h.shareinternet("Local Area Connection* 10", "Local Area Connection* 10", true);
        }
        #endregion

        #region Stop internet
        public void StopInternet()
        {
            //h.shareinternet("Ethernet", "Wi-Fi", false);
            h.shareinternet("Local Area Connection* 10", "Local Area Connection* 10", false);
        }
        #endregion
    }

    #endregion


   

    /// <summary>
    /// Implimentation of App hotspot  
    /// its verbose the reason for abstraction
    /// </summary>
    #region Hotspot
    class Hotspot
    {
        private string message = "";
        private dynamic netsharingmanager = null;
        private dynamic everyConnection = null;
        private bool hasnetsharingmanager = false;

        ProcessStartInfo ps = null;
        #region Constructor
        public Hotspot()
        {
            Init();
        }
        #endregion

        /// <summary>
        /// start console and check if sharing is possiblie and if on
        /// </summary>
        #region
        private void Init()
        {
            ps = new ProcessStartInfo("cmd.exe");
            ps.UseShellExecute = false;
            ps.RedirectStandardOutput = true;
            ps.CreateNoWindow = true;
            ps.FileName = "netsh";


            //sharing 
            netsharingmanager = Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.HNetShare.1"));
            if (netsharingmanager == null)
            {
                this.message = "HNetCfg.HNetShare.1 was not found \n";
                hasnetsharingmanager = true;

            }
            else
            {
                hasnetsharingmanager = false;

            }

            if (netsharingmanager.SharingInstalled == false)
            {
                this.message = "Sharing on this platform is not available \n";
                hasnetsharingmanager = false;
            }
            else
            {
                hasnetsharingmanager = true;
            }

            if (hasnetsharingmanager)
            {
                everyConnection = netsharingmanager.EnumEveryConnection;

            }

        }
        #endregion

        #region getConnections
        public List<string> getconnections()
        {
            dynamic thisConnection= null;
            dynamic connectionprop = null;

            everyConnection = netsharingmanager.EnumEveryConnection;


            List<string> connections = new List<string>();


            foreach (dynamic connection in everyConnection)
            {
                thisConnection= netsharingmanager.INetSharingConfigurationForINetConnection(connection);
                // connectionprop = everyconnection.NetConnectionProps(connection);
                connectionprop = /*everyconnection*/ netsharingmanager.NetConnectionProps(connection);
                connections.Add(connectionprop.Name);
            }
            return connections;
        }
        #endregion

        #region  shareinternet
        public void shareinternet(string pubconnectionname, string priconnectionname, bool isenabled)
        {
            bool hascon = false;
            dynamic thisConnection= null;
            dynamic connectionprop = null;

            if (everyConnection == null)
            {
                everyConnection = netsharingmanager.EnumEveryConnection;
            }
            try
            {
                foreach (dynamic connection in everyConnection)
                {
                    thisConnection= netsharingmanager.INetSharingConfigurationForINetConnection(connection);
                    connectionprop = netsharingmanager.NetConnectionProps(connection);

                    Console.WriteLine("connectionprop name = {0} and pubconnectionname = {1}", connectionprop.name, pubconnectionname);
                    if (connectionprop.name == pubconnectionname) //public connection
                    {
                        hascon = true;
                        this.message = string.Format("Setting ICS Public  {0} on connection: {1}\n", isenabled, pubconnectionname);
                        Console.WriteLine("Setting ICS Public  {0} on connection: {1}\n", isenabled, pubconnectionname);
                        if (isenabled)
                        {
                            thisConnection.EnableSharing(0);
                        }
                        else
                        {
                            thisConnection.DisableSharing();
                        }
                    }
                    if (connectionprop.Name == priconnectionname) //private connection
                    {
                        hascon = true;
                        this.message = string.Format("Setting ICS Private  {0} on connection: {1}\n", isenabled, pubconnectionname);
                        Console.WriteLine("Setting ICS Private  {0} on connection: {1}\n", isenabled, pubconnectionname);
                        if (isenabled)
                        {
                             thisConnection.EnableSharing(1);

                        }
                        else
                        {
                            thisConnection.DisableSharing();
                        }
                    }
                    if (!hascon)
                    {
                        this.message += "no connection found";
                        Console.WriteLine("no connection found");
                    }
                }
            }catch(Exception e)
            {
                //   Dispatcher.Invoke((Action)delegate
                //   {
                //   Ui_ApplicationError er = new Ui_ApplicationError(e);
                //   er.Show();
                //   });
                Console.WriteLine("Hey an err in hotspot {0}",e);

            }
        }
        #endregion

        #region start Hotspot
        public void start()
        {
            ps.Arguments = "wlan start hosted network";
            Execute(ps);
        }
        #endregion

        #region Create hot spot
        public void create(string ssid_par, string key_par)
        {
            ps.Arguments = string.Format("wlan set hostednetwork mode=allow ssid={0} key={1}", ssid_par, key_par);
            Execute(ps);
        }
        #endregion

        #region Stop hotspot
        public void stop()
        {
            ps.Arguments = "wlan stop hosted network";
            Execute(ps);
        }
        #endregion

        #region Execute command
        private void Execute(ProcessStartInfo ps)
        {
            bool isExecuted = false;
            try
            {
                using (Process p = Process.Start(ps))
                {
                    message += p.StandardOutput.ReadToEnd() + "\n";
                    p.WaitForExit();
                    isExecuted = true;
                }
            }
            catch (Exception e)
            {
                message = "errorr -- >";
                message += e.Message;
                isExecuted = false;

            }

        }
        #endregion

        /// <summary>
        /// getter and setter for console  commands
        /// </summary>
        #region Message
        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }

        }
        #endregion
    }
    #endregion

    /// <summary>
    /// class HotspotGuest
    /// for gip,mac,name
    /// </summary>
    #region  HotspotGuest
    class HotspotGuest
    {
        public String GuestIp { get; set; }
        public String MacAddress { get; set; }
        public String ComputerName { get; set; }

    }
    #endregion

    /// <summary>
    /// class to get name,strength,protected
    /// </summary>
    #region  NetworkDetails
    class NetworkDetails
    {
        public String Protected { get; set; }
       // public String MacAddress { get; set; }
        public String Name { get; set; }
        public String Strength { get; set; }
    }
    #endregion

    /// <summary>
    /// class HotSpotDetails
    /// for ip,mac,name
    /// </summary>
    #region HotSpotDetails
    class HotSpotDetails
    {
        public String SelfIp { get; set; }
        public String MacAddress { get; set; }
        public String ComputerName { get; set; }
    }
    #endregion
}
