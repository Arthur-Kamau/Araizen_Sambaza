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
    /// Interaction logic for Ui_Stop.xaml
    /// </summary>
    public partial class Ui_Stop : Window
    {
        public Ui_Stop()
        {
            InitializeComponent();

            var ThreadAppInfo = new Thread(ShutdownTasks);
            ThreadAppInfo.Priority = ThreadPriority.BelowNormal;
            ThreadAppInfo.IsBackground = true;
            ThreadAppInfo.Start();
        }
        private void ShutdownTasks()
        {
            Dispatcher.Invoke((Action)delegate
            {
                System.Windows.Application.Current.Shutdown();
            });
        }
    }
}
