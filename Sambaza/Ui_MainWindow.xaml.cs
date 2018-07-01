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
using MahApps.Metro.Controls;

namespace Sambaza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Ui_MainWindow : MetroWindow //Window
    {
        public Ui_MainWindow()
        {
            InitializeComponent();
            content_container.Source = new Uri("Ui_Menu.xaml", UriKind.RelativeOrAbsolute);

        }
        private void Quick_Menu_button_Click(object sender, RoutedEventArgs e)
        {
            content_container.Source = new Uri("Ui_Menu.xaml", UriKind.RelativeOrAbsolute);

        }

        private void Home_button_Click(object sender, RoutedEventArgs e)
        {
            content_container.Source = new Uri("Ui_Home.xaml", UriKind.RelativeOrAbsolute);

        }

        private void Main_Hotspot_Option_Connect_button_Click(object sender, RoutedEventArgs e)
        {
            content_container.Source = new Uri("Ui_HostspotOptions.xaml", UriKind.RelativeOrAbsolute);

        }

        
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            content_container.Source = new Uri("Ui_Transfer.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Public_button_Click(object sender, RoutedEventArgs e)
        {
            content_container.Source = new Uri("Ui_PublicFolder.xaml", UriKind.RelativeOrAbsolute);

        }
        private void Transfer_History_Option_Click(object sender, RoutedEventArgs e)
        {
            content_container.Source = new Uri("Ui_TransferHistory.xaml", UriKind.RelativeOrAbsolute);

        }



        //private void Transfer_button_Click(object sender, RoutedEventArgs e)
        //{
        //    content_container.Source = new Uri("Main_Transfer.xaml", UriKind.RelativeOrAbsolute);

        //}
        private void User_Map_button_Click(object sender, RoutedEventArgs e)
        {
            content_container.Source = new Uri("Ui_Users_Map.xaml", UriKind.RelativeOrAbsolute);

        }


        private void Settings_button_Click(object sender, RoutedEventArgs e)
        {
            content_container.Source = new Uri("Ui_Settings.xaml", UriKind.RelativeOrAbsolute);

        }

        //window closing check if server is running and move it to the services
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Console.WriteLine("Main Window closing");
            
            Ui_Stop x = new Ui_Stop();
            x.Show();
            //this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //check local data if logged in
            Ui_AccountOption m = new Ui_AccountOption();
            m.ShowDialog();
        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            Ui_Feedback mf = new Ui_Feedback();
            mf.ShowDialog();
        }

       
    }
}