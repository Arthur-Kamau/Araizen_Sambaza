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
using System.Windows.Shapes;

namespace Sambaza
{
    /// <summary>
    /// Interaction logic for Ui_Start_Hotspot_Required_Dialog.xaml
    /// </summary>
    public partial class Ui_Start_Hotspot_Required_Dialog : Window
    {
        public Ui_Start_Hotspot_Required_Dialog()
        {
            InitializeComponent();
        }

        private void Start_Hotspot_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
