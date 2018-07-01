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
using System.Windows.Shapes;
using MahApps.Metro.Controls;


namespace Sambaza
{
    /// <summary>
    /// Interaction logic for Ui_EnableWlan.xaml
    /// </summary>
    public partial class Ui_EnableWlan : MetroWindow//Window
    {
        public Ui_EnableWlan()
        {
            InitializeComponent();

            Proceed.IsEnabled = false;
            var th = new Task(() =>
            {
                while (true)
                {
                    App_Hotspot_Details state = new App_Hotspot_Details();
                    bool  result = state.IsWifiActive();
                    if (result)
                    {
                      //  System.Windows.Threading.Dispatcher.Invoke((Action)delegate
                     //   {

                        //    Proceed.IsEnabled = false;
                         //   Ui_MainWindow p = new Ui_MainWindow();
                         //   p.Show();
                          //  this.Close();
                      ///  });
                      

                    }
                    Thread.Sleep(1000);
                }
            });
            th.Start();
            
        }
        private void Proceed_Click(object sender, RoutedEventArgs e)
        {
           
            Ui_MainWindow p = new Ui_MainWindow();
            p.Show();
           

        }
    }
}
