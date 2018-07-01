using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Sambaza
{
    /// <summary>
    /// Interaction logic for Ui_HostspotStart.xaml
    /// </summary>
    #region Ui_HostspotStart class 
    public partial class Ui_HostspotStart : Page
    {

        private static string log = string.Empty;

        public Ui_HostspotStart()
        {
            InitializeComponent();
            Hotspot_submit.IsEnabled = false;
            hotspot_password_textbox.IsEnabled = false;

            PopulateConnections();
            IsHotspotActive();
           
        }

        private void PopulateConnections()
        {
            ShareOption.Items.Clear();
            Hotspot h = new Hotspot();

            h.getconnections().ForEach(prop =>
            {
                Console.WriteLine("\n share (PopulateConnections) conn -" + prop);
                ShareOption.Items.Add("->" + prop);
            });

        }

        private void IsHotspotActive()
        {

            App_Hotspot_Details hotspotDetails = new App_Hotspot_Details();
            if (hotspotDetails.IsHotspotActive())
            {
                String Name = hotspotDetails.SsidName();

                hotspot_name_textbox.Text = Name;
                hotspot_name_textbox.IsEnabled = false;
                hotspot_password_textbox.Password.Insert(0, "**********");

                Hotspot_submit.IsEnabled = true;
                Hotspot_submit.Content = "Stop";
            }
           
        }
        /// <summary>
        /// submit button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Hotspot_submit_Click
        private void Hotspot_submit_Click(object sender, RoutedEventArgs e)
        {
            String hotspotname = hotspot_name_textbox.Text;
            String hotspotpassword = hotspot_password_textbox.Password.ToString();

            String shareOptionSelected = "Wi-Fi";//string.Empty;

           // PopulateConnections();

            var th = new Task(() =>
            {
                App_Hotspot ap = new App_Hotspot();
                App_Hotspot_Details apDetails = new App_Hotspot_Details();
                Boolean is_hotspot_on = apDetails.IsHotspotActive();
                if (!is_hotspot_on)
                {
                    
                    //Dispatcher.Invoke((Action)delegate
                    //{
                    //    if (ShareOption.SelectedItem.ToString() != null)
                    //    {
                    //        shareOptionSelected = ShareOption.SelectedItem.ToString();
                    //    }
                    //});
                    //share options
                    if (String.IsNullOrEmpty(shareOptionSelected))
                    {
                        Hotspot h = new Hotspot();

                        h.getconnections().ForEach(prop =>
                        {
                            // if(h.ToString().ToLower().Equals("wi-fi") || h.ToString().ToLower().Contains("wi"))
                            //  {
                            //shareOptionSelected = "Local Area Connection* 10";//prop;
                           // }
                        });
                    }

                    //start the hotspot
                    ap.Start(hotspotname,shareOptionSelected, hotspotpassword);
                    //start the servers 
                    StartServers();

                    is_hotspot_on = true;
                    Dispatcher.Invoke((Action)delegate
                    {
                        Hotspot_submit.Content = "stop";

                       
                    });
                }
                else
                {
                    ap.Stop();
                    is_hotspot_on = false;
                    Dispatcher.Invoke((Action)delegate
                    {
                        Hotspot_submit.Content = "start";

                        hotspot_name_textbox.Text = string.Empty;
                        hotspot_password_textbox.Password = string.Empty;
                        hotspot_name_textbox.IsEnabled = true;

                    });


                }
            });
            th.Start();
        }
        #endregion

        
        #region StartServers
        private void StartServers()
        {

            var http = new Task(() =>
            {
                HotSpotDetails details = new HotSpotDetails();
                String IpAddress = details.SelfIp;

                HttpServer httpServer = new HttpServer(IpAddress);
                httpServer.Start();

                Console.WriteLine("http server started {0}", IpAddress);
            });
            http.Start();

            var udp = new Task(() =>
            {

            });
            udp.Start();

        }
        #endregion

        /// <summary>
        /// hot spot name key up,
        /// ensure name is more than 4 characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region hotspot_name_textbox_KeyUp
        private void hotspot_name_textbox_KeyUp(object sender, KeyEventArgs e)
        {
            String hotspotname = hotspot_name_textbox.Text;
            if (hotspotname.Length >= 4)
            {
                hotspot_name_textbox_images.Source = new BitmapImage(new Uri(@"/Resources/Images/ic_check_black_24dp_1x.png", UriKind.Relative));
                hotspot_password_textbox.IsEnabled = true;
            }
            else
            {
                hotspot_name_textbox_images.Source = null;
                hotspot_password_textbox.IsEnabled = false;
            }


        }
        #endregion

        /// <summary>
        /// hot spot name key up,
        /// ensure name is more than 8 characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region hotspot_password_textbox_KeyUp
        private void hotspot_password_textbox_KeyUp(object sender, KeyEventArgs e)
        {
            String hotspotpassword = hotspot_password_textbox.Password.ToString();
            if (hotspotpassword.Length >= 8)
            {
                hotspot_password_textbox_images.Source = new BitmapImage(new Uri(@"/Resources/Images/ic_check_black_24dp_1x.png", UriKind.Relative));
                Hotspot_submit.IsEnabled = true;

            }
            else
            {
                hotspot_password_textbox_images.Source = null;
                Hotspot_submit.IsEnabled = false;

            }

        }
        #endregion


        //add log
        public static void Addlog(String msg)
        {
            log += msg;
            System.Console.WriteLine("Log message {0}",log);
        }


    }
    #endregion
}
