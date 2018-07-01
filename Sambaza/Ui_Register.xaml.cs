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
    /// Interaction logic for Ui_Register.xaml
    /// </summary>
    /// 
    public partial class Ui_Register : Window
    {

        App_Random ar = new App_Random();
        App_Protect_String ProtectString = new App_Protect_String();

        public Ui_Register()
        {
            InitializeComponent();

            //populate random text file
            // ar.PopulateRandomFile();

            //get random text 
            //get specifc  length key and save ite to master key file


        }

        bool IsPasswordValid(String pass)
        {
            if (pass.Length > 4)
            {
                return true;
            }
            return false;
        }
        bool IsNameValid(String name)
        {
            if (name.Length > 2)
            {
                return true;
            }
            return false;
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            ar.InsertToRandom_Master_Pass('T', 20);

            String emailstr = email.Text;
            String namestr = name.Text;

            String passwordstr = mypassword.Password.ToString();
            String passwordConfStr = mypasswordconfirm.Password.ToString();
            if (emailstr.Length == 0 || namestr.Length == 0 || passwordstr.Length == 0 || passwordConfStr.Length == 0)
            {
                Status.Content = "Please Fill all the fields";

            }
            else
            {
                if (!IsValidEmail(email.Text))
                { Status.Content = "Input correct email"; }
                else
                {
                    if (!IsNameValid(name.Text))
                    { Status.Content = "Input name with correct Length"; }
                    else
                    {
                        if (!IsPasswordValid(mypassword.Password.ToString()))
                        { Status.Content = "Input password with correct Length"; }
                        else
                        {

                            if (passwordstr.Equals(passwordConfStr))
                            {
                                App_Protect_Hash hash = new App_Protect_Hash();
                                App_System_Paths path = new App_System_Paths();
                                App_Random random = new App_Random();

                                Sambaza.Properties.Settings.Default.UserEmail = ProtectString.EncryptString(emailstr);
                                Sambaza.Properties.Settings.Default.AppKey = ProtectString.EncryptString(random.RandomItemName(15));
                                Sambaza.Properties.Settings.Default.PassKey = hash.Sha1Hash(passwordstr);
                                Sambaza.Properties.Settings.Default.GhostPassKey = hash.Sha1Hash("123456789");
                                Sambaza.Properties.Settings.Default.MacAddress = ProtectString.EncryptString(App_System_Details.GetMacAddress());
                                Sambaza.Properties.Settings.Default.InstallTime = ProtectString.EncryptString(DateTime.Now.ToString());



                               // Sambaza.Properties.Settings.Default.GhostPath = ProtectString.EncryptString(path.DefaultGhostFolder());
                                Sambaza.Properties.Settings.Default.IsUserRegistered = ProtectString.EncryptString("true");
                                Sambaza.Properties.Settings.Default.EncryptionKey = ProtectString.EncryptString(random.RandomItemName(25));



                                Console.WriteLine("<---- \n\n  EncryptionKey = > {0}  \n IsUserRegistered => {1} \n\n " +
                                    " ----->", Sambaza.Properties.Settings.Default.EncryptionKey,
                                    Sambaza.Properties.Settings.Default.IsUserRegistered
                                    // Sambaza.Properties.Settings.Default.GhostPath
                                    );

                                Sambaza.Properties.Settings.Default.Save();
                                //open home

                               // Boolean isGhostSelected = false;

                                //   AppStart p = new AppStart(isGhostSelected);
                                Ui_MainWindow p = new Ui_MainWindow();
                                p.Show();
                                this.Hide();

                            }
                            else
                            {
                                Status.Content = "Your password and confirm password do not match";
                                e.Handled = true;
                            }
                        }
                    }
                }
            }


        }

        private void email_KeyUp(object sender, KeyEventArgs e)
        {
            String emailstr = email.Text;
            var res = IsValidEmail(emailstr);
            if (res)
            {
                Status.Content = "Email Ok";

                //String resourceDir = asps.Curr_Resources_Dir();
                //System.Uri resourceImageUri = new System.Uri(System.IO.Path.Combine(resourceDir, "images/ic_check_black_24dp_1x.png"));

                //Console.WriteLine("->Resource Dir ={0} \n resource image uri ={1}", asps.Curr_Resources_Dir(), resourceImageUri);

                IsemailOk.Source = new BitmapImage(new Uri(@"/Resources/images/ic_check_black_24dp_1x.png", UriKind.Relative));

            }
            else { IsemailOk.Source = null; }
        }

        private void name_KeyUp(object sender, KeyEventArgs e)
        {
            String namestr = name.Text;
            var res = IsNameValid(namestr);
            if (res)
            {
                //Status.Content = "Name ok";
                //String resourceDir = asps.Curr_Resources_Dir();
                //System.Uri resourceImageUri = new System.Uri(System.IO.Path.Combine(resourceDir, "images/ic_check_black_24dp_1x.png"));

                //Console.WriteLine("->Resource Dir ={0} \n resource image uri ={1}", asps.Curr_Resources_Dir(), resourceImageUri);

                //IsNameOk.Source  = new BitmapImage(new Uri("pack://application:,,,/AssemblyName;component/Resources/ic_check_black_24dp_1x.png"));
                IsNameOk.Source = new BitmapImage(new Uri(@"Resources/images/ic_check_black_24dp_1x.png", UriKind.Relative));

            }
            else { IsNameOk.Source = null; }
        }

        private void password_KeyUp(object sender, KeyEventArgs e)
        {
            String pass = mypassword.Password.ToString();
            if (IsPasswordValid(pass))
            {
                Status.Content = "Password ok";
                //this
                //var src = new Uri(@"Sambaza;component/image/ic_check_black_24dp_1x.png");
                //or
                IspasswordOk.Source = new BitmapImage(new Uri(@"/Resources/images/ic_check_black_24dp_1x.png", UriKind.Relative));


            }
            else { IspasswordOk.Source = null; }
        }

        private void mypasswordconfirm_KeyUp(object sender, KeyEventArgs e)
        {
            if (mypassword.Password.ToString().Equals(mypasswordconfirm.Password.ToString()))
            {
                Status.Content = "Password and Confirm Password match";

                //String resourceDir = asps.Curr_Resources_Dir();
                //System.Uri resourceImageUri = new System.Uri(System.IO.Path.Combine(resourceDir, "images/ic_check_black_24dp_1x.png"));

                //  Console.WriteLine("->Resource Dir ={0} \n resource image uri ={1}", asps.Curr_Resources_Dir(), resourceImageUri);

                IsConfirmPasswordOk.Source = new BitmapImage(new Uri(@"/Resources/images/ic_check_black_24dp_1x.png", UriKind.Relative));

            }
            else { IsConfirmPasswordOk.Source = null; }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}