using NativeWifi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SimpleWifi;
using System.Diagnostics;

namespace Sambaza
{
 
    public partial class Ui_HostspotConnect : Page
    {
        List<NetworkDetails> available_wifi = new List<NetworkDetails>();
        List<AccessPoint> aps = null;
        App_Console Console = new App_Console();
        private static Wifi wifi;

        #region constructor
        public Ui_HostspotConnect()
        {
            InitializeComponent();

            wifi = new Wifi();
            //get the list of wifis
            try { aps = wifi.GetAccessPoints(); }
            catch(Exception e) {
                System.Console.WriteLine("Connect to hotspot Error {0}",e);
                ErrorItem.Content = "Error in wlan disconnected";
            } 

            //is the nework settings active
            if (IsNetworkActive())
            {
                //is the computer connected to a network
                var network = GetHotspotNameConnectedTo();
                if (string.IsNullOrEmpty(network))
                {
                    //no netwrk show available networks and enable user to connect
                    AvailableWifiConnections();
                }
                else
                {
                    //user is connected to a network
                    ErrorItem.Content = "Connected to " + network;

                    //set combobox item to networks name
                    ComboBoxItem  NetworkItem = new ComboBoxItem();
                    NetworkItem.Content = network;
                   // NetworkItem.Name = network;                
                    wifi_name_combobox.Items.Add(NetworkItem);
                    wifi_name_combobox.SelectedIndex = 0;

                    //show the stringth
                    List<AccessPoint> aps = wifi.GetAccessPoints();
                    foreach (AccessPoint ap in aps)
                    {
                        if (ap.Name.Equals(network)) {
                            WifiStrength.Content = string.Format("Strength : {0} %",ap.SignalStrength);
                         }
                    }
                    //make the password items to invisble
                    hotspot_password_label.Opacity = 0;
                    wifi_password_textbox.Opacity = 0;
                    Protection.Opacity = 0;
                    //set button content to disconnect
                    HotSpot_Connect.Content = "Disconnect";

                }
                
            }
            else
            {
                ErrorItem.Content = "Please activate wifi in your comouter";
            }
        }
        #endregion

        #region connect to  hotspot and servers
        private void HotSpot_Connect_Click(object sender, RoutedEventArgs e)
        {
            var network = GetHotspotNameConnectedTo();

            //no wifi so its connect
            if (string.IsNullOrEmpty(network))
            {
                AccessPoint selected = null;

                string nameItem = wifi_name_combobox.SelectedItem.ToString();

                foreach (AccessPoint ap in aps)
                {
                    if (ap.Name.Equals(nameItem))
                    {
                        selected = ap;
                    }
                }

                AuthRequest authrequest = new AuthRequest(selected);

                authrequest.Password = wifi_password_textbox.Password.ToString();

                bool status = selected.Connect(authrequest);

                System.Console.WriteLine("Connection status {0}", status);
                if (status)
                {
                    System.Console.WriteLine("Connected ..........");
                    ErrorItem.Content = "Connceted to " + nameItem;

                    //make the password items to invisble
                    hotspot_password_label.Opacity = 0;
                    wifi_password_textbox.Opacity = 0;
                    Protection.Opacity = 0;
                    //set button content to disconnect
                    HotSpot_Connect.Content = "Disconnect";

                }
                else
                {
                    System.Console.WriteLine("Not connected");
                    ErrorItem.Content = "Error Connecting to " + nameItem;
                }
            }
            //connected to wifi so its disconnect
            else 
            {
                if (wifi.ConnectionStatus == WifiStatus.Connected)
                {
                    wifi.Disconnect();
                   
                }
                ErrorItem.Content = ("Disconnected");

                //empty the  available wifi combobox and insert the list of available networks
                 wifi_name_combobox.Items.Clear();

                //populate with list of availble wifi
                //show the stringth
                List<AccessPoint> aps = wifi.GetAccessPoints();
                foreach (AccessPoint ap in aps)
                {
                    if (ap.Name.Equals(network))
                    {
                        AvailableWifiConnections();
                    }
                }

                //update ui show the password details and fields
                hotspot_password_label.Opacity = 1;
                wifi_password_textbox.Opacity = 1;
                Protection.Opacity = 1;
                //set button content to disconnect
                HotSpot_Connect.Content = "Connect";
            }

           
        }
        #endregion


        #region AvailableWifiConnections()
        private void AvailableWifiConnections()
        {
            WlanClient client = new WlanClient();

            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)

            {

                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);

                foreach (Wlan.WlanAvailableNetwork network in networks)

                {

                    Wlan.Dot11Ssid ssid = network.dot11Ssid;

                    string networkName = Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);

                    NetworkDetails wifi_dt = new NetworkDetails();
                    wifi_dt.Name = networkName;
                    wifi_dt.Protected = network.dot11DefaultCipherAlgorithm.ToString();
                    wifi_dt.Strength = string.Concat(network.wlanSignalQuality, "%");

                    System.Console.WriteLine("wifi name = {0} , protection = {1} , strength = {2}", networkName, network.dot11DefaultCipherAlgorithm.ToString(), string.Concat(network.wlanSignalQuality, "--%"));
                    available_wifi.Add(wifi_dt);
                }

            }

            //add to ui
            if (available_wifi.Count == 0)
            {
                wifi_name_combobox.Items.Add("No Networks Detected");
            }
            else
            {
                foreach (var av in available_wifi)
                {
                    wifi_name_combobox.Items.Add(av.Name);
                }
            }
        }
        #endregion

        #region IsNetworkActive()
        private Boolean IsNetworkActive()
        {
            String output = Console.UserConsole("netsh", "wlan show hosted");
            String result = Get_If_Wifi_Is_On_Or_Off(output: output, status: "Status");
           // Console.WriteLine("Result of Hosted Network Status {0}", result);

            if (result.Contains("Not available"))
            {
                //err turned off
                return false;
            }
            else
            {
                //ok
                return true;
            }

        }
        #endregion



        /// <summary>
        /// slit string by new line the console output
        /// </summary>
        /// <param name="output"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        #region Get_If_Wifi_Is_On_Or_Off
        private string Get_If_Wifi_Is_On_Or_Off(String output, String status = "Status")
        {
            // string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //or
            string available_or_not = string.Empty;
            string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (line.Contains("Status"))
                {
                   // Console.WriteLine("status line = {0}", line);
                    available_or_not = line.Substring(line.LastIndexOf(status));
                }
            }
            return available_or_not;
        }
        #endregion

        /// <summary>
        /// Combo box populated by network name
        /// detect selected item change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region wifi_name_combobox_SelectionChanged
        private void wifi_name_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = wifi_name_combobox.SelectedIndex;
            string nameValue = wifi_name_combobox.SelectedValue.ToString();
            string nameItem = wifi_name_combobox.SelectedItem.ToString();

            System.Console.WriteLine("You selected index {0}  the selectedValue = {1} the selected item = {2}", index, nameValue, nameItem);
            foreach(var item  in available_wifi)
            {
                System.Console.WriteLine("Item {0}", item.Name);

                if (item.Name.Equals(nameValue))
                {
                    WifiStrength.Content =  string.Format(" Strength  : {0} ",item.Strength);
                    Protection.Content = string.Format(" Protection  : {0} ", item.Protected);

                }
            }
        }
        #endregion

        #region GetHotspotNameConnectedTo
        private string GetHotspotNameConnectedTo()
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName  = "netsh.exe",
                    Arguments = "wlan show interfaces",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true

                }
            };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            var line = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).
                        FirstOrDefault(l => l.Contains("SSID") && !l.Contains("BSSID"));

            if (string.IsNullOrEmpty(line))
            {
                return string.Empty;
            }
            var ssid = line.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].TrimStart();
            return ssid;
        }
        #endregion
    }



}
