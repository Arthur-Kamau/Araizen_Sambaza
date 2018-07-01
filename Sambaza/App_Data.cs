using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_Data
    {

        #region App_Info
        class App_Info
        {

            public string App_Name { get; set; }
            public string App_User_Name { get; set; }
            public string App_Key { get; set; }
            public string App_version { get; set; }
            public string App_build { get; set; }
            public DateTime Install_DateTime { get; set; }
            public Boolean Is_AppLocked { get; set; }
            public Boolean Has_Lisence { get; set; }
            public Boolean Has_Registered { get; set; }
            public string Araizen_url { get; set; }
            public string Sambaza_url { get; set; }



            public App_Info() { }
            public App_Info(string app_key_str, string app_user_name_str, string App_version_str, string app_build_str, string app_name_str, DateTime install_datatime_str, Boolean has_lisence, Boolean has_registered, string araizen, string sambaza, Boolean is_applocked = false)
            {

                this.App_Key = app_key_str;
                this.App_Name = app_name_str;
                this.App_build = app_build_str;
                this.App_Name = App_version_str;
                #region if app_user_name_str is empty
                if (app_user_name_str.Length == 0 || app_user_name_str.Length > 2)
                {
                    app_user_name_str = App_System_Details.GetComputerName();
                    this.App_User_Name = app_user_name_str;
                }
                #endregion
                this.Install_DateTime = install_datatime_str;
                this.Is_AppLocked = is_applocked;
                this.Has_Lisence = has_lisence;
                this.Has_Registered = has_registered;
                this.Sambaza_url = sambaza;
                this.Araizen_url = araizen;
            }
        }
        #endregion
        #region App_IsLocked
        class App_IsLocked
        {

            public string App_Key { get; set; }
            public DateTime App_LockDate { get; set; }
            public Boolean Is_AppLocked { get; set; }
            public string App_LockedReason { get; set; }

        }
        #endregion
        #region App_User_Info
        class App_User_Info
        {
            public String Name { get; set; }
            public String User_Id { get; set; }

            public App_User_Info() { }
            public App_User_Info(String name, String User_Id)
            {
                this.Name = Name;
                this.User_Id = User_Id;
            }
        }

        #endregion

        #region App_Update_Details
        class App_Update_Details
        {
            public string App_key { get; set; }
            public string App_version { get; set; }
            public string App_build { get; set; }
            public string App_Update_Url { get; set; }

            public App_Update_Details() { }
            public App_Update_Details(String App_Key, String App_Version, String App_Build, String App_update_url)
            {
                this.App_key = App_Key;
                this.App_version = App_Version;
                this.App_build = App_Build;
                this.App_Update_Url = App_update_url;
            }

        }
        #endregion


        #region AppInstall_Details_Json
        class AppInstall_Details_Json
        {
            public string App_CommTitle_Install_Details { get; set; }
            public string App_Id_Install_Details { get; set; }
            public DateTime Install_Time_Install_Details { get; set; }
            public string Mac_Address_Install_Details { get; set; }
            public string Computer_Name_Install_Details { get; set; }

            public AppInstall_Details_Json() { }
            public AppInstall_Details_Json(string com_title, DateTime install_time, string app_id, string mac_address, string comp_name)
            {
                this.App_CommTitle_Install_Details = com_title;
                this.Install_Time_Install_Details = install_time;
                this.App_Id_Install_Details = app_id;
                this.Mac_Address_Install_Details = mac_address;
                this.Computer_Name_Install_Details = comp_name;
            }
        }
        #endregion
        #region User_data_Json
        class User_data_Json
        {
            ///initializer
            public User_data_Json() { }
            public User_data_Json(string user_name, string user_email, string user_computer_name, DateTime user_install_date_time, string app_key)
            {

                this.User_email = user_email;
                this.User_name = user_email;
                this.User_computer_name = user_computer_name;
                this.User_Install_date_time = user_install_date_time;
                this.App_key = app_key;

            }
            ///getter and setter
            public string User_name { get; set; }
            public DateTime User_Install_date_time { get; set; }
            public string User_computer_name { get; set; }
            public string User_email { get; set; }
            public string App_key { get; set; }
        }
        #endregion
        #region Purchase_data_Json
        class Purchase_data_Json
        {

            public string App_key { get; set; }
            public DateTime Purchase_time { get; set; }
            public string Purchase_key { get; set; }
            public int Purchase_lisence_period { get; set; }

            public Purchase_data_Json() { }
            public Purchase_data_Json(string app_key_param, DateTime purcase_date, string purchase_key, int purchase_lisence_period)
            {
                this.App_key = app_key_param;
                this.Purchase_time = purcase_date;
                this.Purchase_key = purchase_key;
                this.Purchase_lisence_period = purchase_lisence_period;
            }

            public override string ToString()
            {
                return string.Format("Purchase details -> \n {0},\n  ->{1} ,\n" +
                    "->{2} ,\n ->  {3}\n ", App_key, Purchase_time, Purchase_key, Purchase_lisence_period);
            }

        }
        #endregion


        #region TransferHistory
        class TransferHistory
        {
            public TransferHistory() { }
            public TransferHistory(string fileName, string transferClient, bool isSuccesfull, DateTime transferTime)
            {
                FileName = fileName;
                TransferClient = transferClient;
                IsSuccesfull = isSuccesfull;
                TransferTime = transferTime;
            }

            public String FileName { get; set; }
            public String TransferClient { get; set; }
            public Boolean IsSuccesfull { get; set; }
            public DateTime TransferTime { get; set; }


        }
        #endregion
    }
}
