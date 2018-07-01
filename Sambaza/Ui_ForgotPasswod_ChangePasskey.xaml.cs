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
    /// Interaction logic for Ui_ForgotPasswod_ChangePasskey.xaml
    /// </summary>
    public partial class Ui_ForgotPasswod_ChangePasskey : Window
    {
        App_System_Paths asps = new App_System_Paths();

        public Ui_ForgotPasswod_ChangePasskey()
        {
            InitializeComponent();
            Submit.IsEnabled = false;

        }
        #region submit click save new passwod
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            String newPasskey = Passkey.Password.ToString();
            String newPasskeyConfirm = PasskeyConfirm.Password.ToString();
            //remember to has it
            App_Protect_Hash hash = new App_Protect_Hash();


            Sambaza.Properties.Settings.Default.PassKey = hash.Sha1Hash(newPasskey);
            Sambaza.Properties.Settings.Default.Save();

            //Ui_AppStart st = new Ui_AppStart();
            Ui_MainWindow st = new Ui_MainWindow();
            st.Show();
            this.Close();

        }
        #endregion

        #region Confirm passkey key up
        private void PasskeyConfirm_KeyUp(object sender, KeyEventArgs e)
        {
            String newPasskey = Passkey.Password.ToString();
            String newPasskeyConfirm = PasskeyConfirm.Password.ToString();

            if (newPasskey.Equals(newPasskeyConfirm))
            {

                IsConfirmPasskeyOk.Source = new BitmapImage(new Uri(@"/Resources/images/ic_check_black_24dp_1x.png", UriKind.Relative));

                Submit.IsEnabled = true;
            }
            else { IsConfirmPasskeyOk.Source = null; }

        }
        #endregion
        #region Passkey key up
        private void Passkey_KeyUp(object sender, KeyEventArgs e)
        {
            String pass = Passkey.Password.ToString();
            if (IsPasswordValid(pass))
            {
                Status.Content = "Password ok";

                IsPasskeyOk.Source = new BitmapImage(new Uri(@"/Resources/images/ic_check_black_24dp_1x.png", UriKind.Relative));

            }
            else { IsPasskeyOk.Source = null; }
        }
        #endregion
        #region check password length
        bool IsPasswordValid(String pass)
        {
            if (pass.Length > 4)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
