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
using MahApps.Metro.Controls;

namespace Sambaza
{
    /// <summary>
    /// Interaction logic for Ui_ApplicationError.xaml
    /// </summary>
    public partial class Ui_ApplicationError : MetroWindow// Window
    {
        public Ui_ApplicationError()
        {
            InitializeComponent();
        }
        public Ui_ApplicationError(String e)
        {
            InitializeComponent();
            ErrorLog.Text = e;
        }
        public Ui_ApplicationError(Exception e)
        {
            InitializeComponent();
            ErrorLog.Text = e.ToString();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
