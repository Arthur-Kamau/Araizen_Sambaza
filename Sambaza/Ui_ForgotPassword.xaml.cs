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
    /// Interaction logic for Ui_ForgotPassword.xaml
    /// </summary>
    public partial class Ui_ForgotPassword : Window
    {
        App_System_Communication coms = new App_System_Communication();
        App_Protect_String ProtectString = new App_Protect_String();

        public Ui_ForgotPassword()
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


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

           Ui_Login ml = new Ui_Login();
            ml.Show();
            this.Close();

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            String UserEmail = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.UserEmail);

            String emailstr = Email.Text;


            if (UserEmail.Equals(emailstr))
            {
                Boolean IsEmailGenuine = EnsureGenuineEmail(emailstr);
                if (IsEmailGenuine)
                {

                    Ui_ForgotPassword_Serial emailSerial = new Ui_ForgotPassword_Serial();
                    emailSerial.Show();
                    this.Close();
                }
                else
                {
                    IsSuccessful.Content = "Not Successsfull try again";

                }
            }
            else
            {
                IsSuccessful.Content = "Your local email Has to match Araizen portal email";

            }

        }

        private bool EnsureGenuineEmail(String email)
        {
            App_System_Communication ac = new App_System_Communication();
            String IsKey = ac.CreateForgotPasswordSerial(email);

            Console.WriteLine(" \n got response from server = {0}", IsKey);
            if (IsKey == null || IsKey == string.Empty)
            {
                coms.Send_Install_Details();
                return false;
            }
            else if (IsKey == "err")
            {

                coms.Send_Install_Details();
                return false;
            }
            else
            {
                return true;
            }


        }
    }
}