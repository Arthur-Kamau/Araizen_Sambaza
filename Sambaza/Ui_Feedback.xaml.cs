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
    /// Interaction logic for Ui_Feedback.xaml
    /// </summary>
    public partial class Ui_Feedback : Window
    {
        String emailstr;

        public Ui_Feedback()
        {
            InitializeComponent();

            App_Protect_String ProtectString = new App_Protect_String();

            emailstr = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.UserEmail);

            Now.Content = DateTime.Now;

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


            this.Close();

            // String emailstr = EmailField.Text;

            DateTime SendTime = DateTime.Now;
            String feedBack = TextFeedbackContents.Text;

            App_System_Communication asc = new App_System_Communication();
            asc.SendFedback(feedbacktext: feedBack, sendtime: SendTime);

        }
    }
}
