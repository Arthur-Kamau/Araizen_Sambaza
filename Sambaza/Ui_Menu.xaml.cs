using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Sambaza
{
    /// <summary>
    /// Interaction logic for Ui_Menu.xaml
    /// </summary>
    public partial class Ui_Menu : Page
    {
        public Ui_Menu()
        {
            InitializeComponent();
            SetUpData();


        }
        private void SetUpData()
        {
            is_active_internet_connection.Content = "Checking ...";

            var th = new Task(() =>
            {
                while (true)
                {
                    var IsThereInterent = App_System_Wifi.CheckForInternetConnection();
                    Dispatcher.Invoke((Action)delegate
                    {
                        if (IsThereInterent)
                        {
                            is_active_internet_connection.Content = "There Is Internet";
                        }
                        else
                        {
                            is_active_internet_connection.Content = " No Internet";
                        }
                    });
                    Thread.Sleep(2000);
                }
            });
            th.Start();

            Crypto_Oerations.Content = "Okay";
            dot_net_platform.Content = App_System_Details.DotNetVersion();
            os_version.Content = App_System_Details.OsVersion();

            App_System_Paths asps = new App_System_Paths();
            path_to_public_folder.Content = asps.CryptoFolder();

            String AppBuildStr = Sambaza.Properties.Settings.Default.AppBuild;
            String AppVarsionStr = Sambaza.Properties.Settings.Default.AppVersion;

            App_Build.Content = AppBuildStr;
            App_Version.Content = AppVarsionStr;


        }

        private void Main_Quick_Menu_Drop(object sender, DragEventArgs e)
        {
            Console.WriteLine("Main window drop");
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (var item in files)
                {
                    Console.WriteLine(" main Item Dropped {0} \n", item);
                }
                // Assuming you have one file that you care about, pass it off to whatever
                // handling code you have defined.
                //HandleFileOpen(files[0]);
            }
        }
    }
}

