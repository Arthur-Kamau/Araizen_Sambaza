using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_System_Details
    {
        public static string DotNetVersion()
        {
            return System.Environment.Version.ToString();
        }
        public static string OsVersion()
        {
            return System.Environment.OSVersion.ToString();
        }

        public static string GetComputerName()
        {
            return System.Environment.MachineName;
        }

        public static string GetNetBiosName()
        {
            //Retrieve the NetBIOS name. 
            string result = System.Environment.MachineName;

            //Display the results to the console window.
            Console.WriteLine("NetBIOS Name = {0}", result);
            return result;
        }
        public static Boolean GetInternetActive()
        {
            Boolean available = NetworkInterface.GetIsNetworkAvailable();


            return available;
        }
        public static string GetMacAddress()
        {
            String mac = String.Empty;

            mac = (from nic in NetworkInterface.GetAllNetworkInterfaces() select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
            return mac;
        }
        public static string GetMacAddress_1()
        {
            NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();
            string smac = string.Empty;

            foreach (NetworkInterface adapter in nic)
            {
                if (smac == string.Empty)
                {
                    smac = adapter.GetPhysicalAddress().ToString();
                }
            }
            return smac;
        }
    }
}
