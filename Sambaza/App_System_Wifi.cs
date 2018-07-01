using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_System_Wifi
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("https://google.com/"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public static void Open_in_browser(String url)
        {
            System.Diagnostics.Process.Start(url);
        }
    }
}
