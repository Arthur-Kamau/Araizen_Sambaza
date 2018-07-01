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
    /// Interaction logic for Ui_Login.xaml
    /// </summary>
    public partial class Ui_Login : Window
    {

        App_Random ar = new App_Random();
        private Boolean isGhostSelected = false;
        int attempts = 0;
        String MasterPass = String.Empty;
        String GhostPass = String.Empty;

        public Ui_Login()
        {
            InitializeComponent();
            MasterPass = Sambaza.Properties.Settings.Default.PassKey;
            GhostPass = Sambaza.Properties.Settings.Default.GhostPassKey;

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //check if master pass key
            App_Protect_Hash hash = new App_Protect_Hash();

            if (hash.Sha1Hash(passkey.Password.ToString()).Equals(MasterPass))
            {
                /**
                 * Do some decrypting and some mergining
                 */
                Console.WriteLine("passkey true");
                ar.InsertToRandom_Master_Pass('T', 20);


                //close this stage
                isGhostSelected = false;

                // Ui_AppStart p = new Ui_AppStart();
                Ui_MainWindow p = new Ui_MainWindow();
                p.Show();
                this.Close();
            }
            else
            {
                //check if ghost passkey


                if (hash.Sha1Hash(passkey.Password.ToString()).Equals(GhostPass))
                {

                    Console.WriteLine("passkey ghost true");

                    ar.InsertToRandom_Master_Pass('T', 20);

                    //close this stage
                    isGhostSelected = true;


                    //Ui_AppStart p = new Ui_AppStart();
                    Ui_MainWindow p = new Ui_MainWindow();
                    p.Show();
                    this.Close();
                }
                else
                {
                    if (attempts == 3 || attempts > 3)
                    {
                        //kill the app
                        Console.WriteLine("Attempt {0}", attempts);
                        System.Windows.Application.Current.Shutdown();
                        // Environment.Exit(0);

                    }
                    Status.Content = "Error Wrong passkey";
                    attempts++;
                }

            }
        }

        public Boolean IsGhost()
        {
            return isGhostSelected;
        }

        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {

            Console.WriteLine("ForgotPassword_Click");
            Ui_ForgotPassword mfe = new Ui_ForgotPassword();
            mfe.Show();

            this.Close();
        }


    }
}