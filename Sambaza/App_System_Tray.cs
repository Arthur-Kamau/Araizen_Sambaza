using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sambaza
{
    class App_System_Tray
    {
        public static void ShowInfoSystemIconServerStarted()
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Resources/images/img-.ico")).Stream;
            notifyIcon.Icon = new System.Drawing.Icon(iconStream);
            notifyIcon.Text = string.Format("Araizen Sambaza Server has Started.");
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(5000, "Success Loading", "Araizen Crypto has successfully loaded", ToolTipIcon.Info);
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }

        public static void ShowInfoSystemIconServerStopped()
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Resources/images/img-.ico")).Stream;
            notifyIcon.Icon = new System.Drawing.Icon(iconStream);
            notifyIcon.Text = string.Format("Araizen Sambaza Server has stopped.");
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(5000, "Success Loading", "Araizen Crypto has successfully loaded", ToolTipIcon.Info);
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }
    }
}
