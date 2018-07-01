using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sambaza
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //start the windows service
            Console.WriteLine("Empty temp Images");
            App_System_Paths asps = new App_System_Paths();
            string[] files = Directory.GetFiles(asps.Path_to_thumbanils());
            foreach (var item in files)
            {
                Console.WriteLine("Deleting {0}", item);
                try
                {
                    File.Delete(item);
                }
                catch (Exception ef)
                {
                    Console.WriteLine("Error {0}", ef.Message);
                }

            }

            System.Windows.Application.Current.Shutdown();
        }
    }
}
