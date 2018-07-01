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
    /// Interaction logic for Ui_Trial_End_Warning.xaml
    /// </summary>
    public partial class Ui_Trial_End_Warning : Window
    {
        public Ui_Trial_End_Warning()
        {
            InitializeComponent();
        }

        private void Okay_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Ui_Login ml = new Ui_Login();
            ml.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Close();
            Ui_Login ml = new Ui_Login();
            ml.Show();
        }
    }
}
