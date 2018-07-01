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
    /// Interaction logic for Ui_HostspotOptions.xaml
    /// </summary>
    public partial class Ui_HostspotOptions : Page
    {
        public Ui_HostspotOptions()
        {
            InitializeComponent();
            HotSpotOptionsContent.Source = new Uri("Ui_HostspotStart.xaml", UriKind.RelativeOrAbsolute);
            StartHotspot.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void StartHotspot_Click(object sender, RoutedEventArgs e)
        {
           ConnectHotspot.Background = new SolidColorBrush(Colors.Transparent);
            ConnectHotspot.BorderBrush = new SolidColorBrush(Colors.Transparent);

            StartHotspot.Background = new SolidColorBrush(Colors.LightGray);
            StartHotspot.BorderBrush = new SolidColorBrush(Colors.Transparent);

            HotSpotOptionsContent.Source = new Uri("Ui_HostspotStart.xaml", UriKind.RelativeOrAbsolute);

        }

        private void ConnectHotspot_Click(object sender, RoutedEventArgs e)
        {
            StartHotspot.Background = new SolidColorBrush(Colors.Transparent);
            StartHotspot.BorderBrush = new SolidColorBrush(Colors.Transparent);

            ConnectHotspot.Background = new SolidColorBrush(Colors.LightGray);
            ConnectHotspot.BorderBrush = new SolidColorBrush(Colors.Transparent);

            HotSpotOptionsContent.Source = new Uri("Ui_HostspotConnect.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
