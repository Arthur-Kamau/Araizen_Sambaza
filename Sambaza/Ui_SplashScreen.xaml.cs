using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Threading;

namespace Sambaza
{
    /// <summary>
    /// Interaction logic for Ui_SplashScreen.xaml
    /// </summary>
    public partial class Ui_SplashScreen : Window
    {


        DispatcherTimer dt = new DispatcherTimer();
        DispatcherTimer prog = new DispatcherTimer();


        Ui_Login logIn = new Ui_Login();

        Boolean isAppregistered;
        Boolean ApphasLicence;
        Boolean LoginOnStart = true;

        Double TrialDaysRemaining = 0.0;
        App_Protect_String ProtectString = new App_Protect_String();


        public Ui_SplashScreen()
        {

            String registeredData = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.IsUserRegistered);
            String LicenceData = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.IsAppLicenced);

            LoginOnStart = Convert.ToBoolean(ProtectString.DecryptString(Convert.ToString(Sambaza.Properties.Settings.Default.LoginOnStart)));

            Console.WriteLine("from app is registered {0} is licenced {1}", registeredData, LicenceData);
            if (string.IsNullOrEmpty(registeredData)) { isAppregistered = false; }
            else
            {
                if (registeredData.Equals("false"))
                {
                    isAppregistered = false;
                }
                else
                {
                    isAppregistered = true;
                }
            }
            if (string.IsNullOrEmpty(LicenceData)) { ApphasLicence = false; }
            else
            {
                if (LicenceData.Equals("false"))
                {
                    ApphasLicence = false;
                }
                else
                {
                    ApphasLicence = true;
                }
            }
            Console.WriteLine("from app is registered {0} is licenced {1}", isAppregistered, ApphasLicence);



            var ThreadAppUser = new Thread(CreatFilesIfNeccessary);
            ThreadAppUser.IsBackground = true;
            ThreadAppUser.Priority = ThreadPriority.Highest;
            ThreadAppUser.Start();


            InitializeComponent();



            //show splash scree for some time
            dt.Tick += new EventHandler(SplashTimer);
            dt.Interval = new TimeSpan(0, 0, 12);
            dt.Start();


            //set progress bar

            prog.Tick += new EventHandler(ProgressTimer);
            prog.Interval = new TimeSpan(0, 0, 1);
            prog.Start();

            ThreadAppUser.Join();
        }

        private void CreatFilesIfNeccessary()
        {
            //create the files




        }


        private void SplashTimer(object sender, EventArgs e)
        {

            //when timer ends
            //is there another instance
            Process x = Process.GetCurrentProcess();

            foreach (Process x2 in Process.GetProcesses())
            {
                if (x2.ProcessName == x.ProcessName)
                {
                    if (x.Id != x2.Id)
                    {
                        Ui_SingleInstance msi = new Ui_SingleInstance();
                        msi.ShowDialog();

                        System.Windows.Application.Current.Shutdown();
                    }
                }
            }

            //check if user has licence
            if (ApphasLicence)
            {
                if (IsLicenceStillValid())
                {
                    if (TrialDaysRemaining < 5)
                    {
                        Close_Stop_Timer();
                        this.Close();
                        Ui_Trial_End_Warning mtw = new Ui_Trial_End_Warning();
                        mtw.Show();
                    }
                    else
                    {
                        Close_Stop_Timer();
                        this.Close();

                        //check if user requested to be logged in
                        if (LoginOnStart)
                        {
                            Ui_Login ml = new Ui_Login();
                            ml.Show();
                        }
                        else
                        {
                            Ui_MainWindow main = new Ui_MainWindow();
                            main.Show();
                        }

                    }
                }
                else
                {
                    Close_Stop_Timer();
                    this.Close();
                    Ui_Purchase mp = new Ui_Purchase();
                    mp.Show();

                }

            }
            else //user is under trial
            {
                if (isAppregistered)
                {
                    Close_Stop_Timer();
                    this.Close();
                    if (LoginOnStart)
                    {
                        Ui_Login ml = new Ui_Login();
                        ml.Show();
                    }
                    else
                    {
                        Ui_MainWindow main = new Ui_MainWindow();
                        main.Show();
                    }
                   
                }
                else
                {
                    Close_Stop_Timer();
                    this.Close();
                    Ui_Register reg = new Ui_Register();
                    reg.Show();
                }
            }


        }


        private void FileWatcherThread()
        {
            System.IO.DirectoryInfo curr = new DirectoryInfo(".");
            String path_to_folder = curr.ToString() + "\\App_Config"; //for all the files

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path_to_folder;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {

            //copy file to appdata back app 
            //use is file ready in App_file to check if file is ready


        }


        private void Close_Stop_Timer() { dt.Stop(); this.Close(); }
        private int incriments = 0;
        private void ProgressTimer(object sender, EventArgs e)
        {
            incriments++;
            progress_bar.Value = incriments;
            Console.WriteLine(" value -{0}", incriments);
            if (incriments.Equals(10) || incriments == 10 || incriments > 10)
            {
                prog.Stop();
            }
        }



        private Boolean IsLicenceStillValid()
        {
            String InstallTimeStr = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.InstallTime);

            DateTime InstallTime = DateTime.Parse(InstallTimeStr);
            DateTime EndOfTrialPeriodDate = InstallTime.AddDays(30.0);

            TimeSpan days_timespan = EndOfTrialPeriodDate.Subtract(DateTime.Now);
            TrialDaysRemaining = days_timespan.Days;

            //end of period
            if (TrialDaysRemaining < 0 || TrialDaysRemaining > 30 || TrialDaysRemaining == 0)
            {

                return false;

            }
            //the last day or //if less or equal to 10 days remaining
            else
            {
                return true;

            }


        }


    }
}