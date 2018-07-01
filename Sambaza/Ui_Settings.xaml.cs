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
    /// Interaction logic for Ui_Settings.xaml
    /// </summary>
    public partial class Ui_Settings : Page
    {
        String SendDataStr = String.Empty;
        String PlatformTypeStr = String.Empty;
        String SystemResourcesStr = String.Empty;

        App_Protect_String ProtectString = new App_Protect_String();
        public Ui_Settings()
        {
            InitializeComponent();

            //get setting
            SendDataStr = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.Send_AnonymousData);
            PlatformTypeStr = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.PlatformType);
            SystemResourcesStr = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.System_Resources);

            Boolean LoginOnStartUpBool= Sambaza.Properties.Settings.Default.LoginOnStart;

            //initial value for login/or not on start up
            if (LoginOnStartUpBool)
            { LoginOnStartUp.SelectedIndex = 0;}
            else {
                LoginOnStartUp.SelectedIndex = 1;
            }

            if (string.IsNullOrEmpty(SendDataStr))
            { SendDataOption.SelectedIndex = 0; }
            else
            {
                if (SendDataStr == "SendData")
                { SendDataOption.SelectedIndex = 0; }
                else { SendDataOption.SelectedIndex = 1; }
            }


            if (string.IsNullOrEmpty(PlatformTypeStr))
            { PlatformOption.SelectedIndex = 0; }
            else
            {
                if (PlatformTypeStr == "PlatformStable")
                { PlatformOption.SelectedIndex = 0; }
                else { PlatformOption.SelectedIndex = 1; }
            }

            if (string.IsNullOrEmpty(SystemResourcesStr))
            { SystemResources.SelectedIndex = 0; }
            else
            {
                if (SystemResourcesStr == "Optimal")
                { SystemResources.SelectedIndex = 0; }
                else { SystemResources.SelectedIndex = 1; }
            }

        }
        
        private void EmailChange_Click(object sender, RoutedEventArgs e)
        {
            Ui_ChangeEmail em = new Ui_ChangeEmail();
            em.ShowDialog();
        }

        private void PasswordChange_Click(object sender, RoutedEventArgs e)
        {
            Ui_ChangePassword cp = new Ui_ChangePassword();
            cp.ShowDialog();

        }

        private void SendDataOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = SendDataOption.SelectedIndex;
            String SendDataOptionSelected = String.Empty;
            if (index == 0) { SendDataOptionSelected = "SendData"; }
            else { SendDataOptionSelected = "DoNotSendData"; }

            Sambaza.Properties.Settings.Default.Send_AnonymousData = ProtectString.EncryptString(SendDataOptionSelected);

            Sambaza.Properties.Settings.Default.Save();
        }

        private void PlatformOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = PlatformOption.SelectedIndex;
            String PlatformOptionSelected = String.Empty;
            if (index == 0) { PlatformOptionSelected = "PlatformStable"; }
            else { PlatformOptionSelected = "PlatformUnsatble"; }

            Sambaza.Properties.Settings.Default.PlatformType = ProtectString.EncryptString(PlatformOptionSelected);
            Sambaza.Properties.Settings.Default.Save();

        }

        private void SystemResources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            int index = SystemResources.SelectedIndex;
            String SystemResourcesOptionSelected = String.Empty;
            if (index == 0) { SystemResourcesOptionSelected = "Optimal"; }
            else { SystemResourcesOptionSelected = "Minimal"; }

            Sambaza.Properties.Settings.Default.System_Resources = ProtectString.EncryptString(SystemResourcesOptionSelected);
            Sambaza.Properties.Settings.Default.Save();
        }

        private void LoginOnStartUp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = LoginOnStartUp.SelectedIndex;
            Boolean LoginOnStartUpBool ;
            if (index == 0) { LoginOnStartUpBool = true; }
            else { LoginOnStartUpBool = false; }

            Sambaza.Properties.Settings.Default.LoginOnStart = LoginOnStartUpBool;
            Sambaza.Properties.Settings.Default.Save();
        }
    }
}
