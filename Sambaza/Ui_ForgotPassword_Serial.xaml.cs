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

namespace Sambaza
{
    /// <summary>
    /// Interaction logic for Ui_ForgotPassword_Serial.xaml
    /// </summary>
    public partial class Ui_ForgotPassword_Serial : Window
    {
        public Ui_ForgotPassword_Serial()
        {
            InitializeComponent();
            var th = new Task(() =>
            {
                while (true)
                {
                    var IsThereInterent = App_System_Wifi.CheckForInternetConnection();
                    Dispatcher.Invoke((Action)delegate
                    {
                        if (IsThereInterent)
                        {
                            Submit.IsEnabled = true;
                            InternetStatus.Content = "There Is Internet";

                        }
                        else
                        {
                            Submit.IsEnabled = false;
                            InternetStatus.Content = " No Internet";
                        }
                    });
                    Thread.Sleep(1500);
                }
            });
            th.Start();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            String serialstr = Serial.Text;
            App_System_Communication ac = new App_System_Communication();
            var isOk = ac.ConfirmForgotPasswordSerialIsGenuine(serialstr);

            if (isOk)
            {
                //open change pass

                Ui_ForgotPasswod_ChangePasskey recovery = new Ui_ForgotPasswod_ChangePasskey();
                recovery.Show();
                this.Close();
            }
            else
            {
                //update status
                IsSuccessful.Content = "Unsucessful please try again.";
            }
        }

    }
}
