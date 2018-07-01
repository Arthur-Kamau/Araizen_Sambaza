using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_Xml
    {
        #region Save_xml_settings_data_to_file()
        public void Save_xml_settings_data_to_file(string Settings_Send_AnonymousData, String PlatformTypePar, DateTime ChangeTime, string Setting_System_Resources)
        {
            App_System_Paths asps = new App_System_Paths();
            //"kamau","email","comp name",DateTime.Now,key
            AppSettings_Details user = new AppSettings_Details(Settings_Send_AnonymousData_par: Settings_Send_AnonymousData, PlatFormType: PlatformTypePar, App_SettingsChange_Time_par: ChangeTime, Setting_System_Resources_par: Setting_System_Resources);
            Stream stream = File.Open(asps.Path_to_settings_data_xml(), FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, user);
            stream.Close();
            //confirm data is save 
            //just printing to screen
            user = null;
            stream = File.Open(asps.Path_to_settings_data_xml(), FileMode.Open);
            bf = new BinaryFormatter();
            user = (AppSettings_Details)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine("install data->\n" + user.ToString());
        }
        #endregion
        #region Save_xml_auth_data_to_file()
        public void Save_xml_auth_data_to_file(string Name, DateTime install_time, string email, string pass_par)
        {
            //AppInstall_Details installdetails = Get_xml_install_data_from_file();
            App_System_Paths asps = new App_System_Paths();
            //"kamau","email","comp name",DateTime.Now,key
            string Appkey = App_Json.get_app_key();

            AppAuth_Details user = new AppAuth_Details(app_id: Appkey/**installdetails.App_Id_Install_Details**/, email: email, name: Name, install_time: install_time, mac_addr: App_System_Details.GetMacAddress(), pass: pass_par);

            //save in son file
            App_Json aj = new App_Json();
            //if json is empty
            if (new FileInfo(asps.Path_to_auth_data_json()).Length == 0)
            {
                aj.Save_json_auth_data_to_file(user);
            }

            try
            {
                Stream stream = File.Open(asps.Path_to_auth_data_xml(), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                // stream = null;
                Console.WriteLine("\n\n path to auth file {0} \n --> Writing objectr {1}", asps.Path_to_auth_data_xml(), user.ToString());

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, user);
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("error Save_xml_auth_data_to_file in app_xaml \n e= {0}\n\n", e);
            }

        }
        #endregion
        #region Save_xml_Ghostauth_data_to_file()
        public void Save_xml_GhostAuth_data_to_file(Boolean Is_AppGhost_Active, DateTime AppGhost_ChangeTime, Boolean AppGhost_RandomizeNames, Boolean AppGhostTrackUsage, string mac_addr, string AppGhostFilePath, string app_ghost)
        {

            App_Protect_Hash hash = new App_Protect_Hash();
            //public AppGhostAuth_Details(Boolean Is_AppGhost_Active_Par, DateTime AppGhost_ChangeTime_Par, Boolean AppGhost_RandomizeNames_Par, Boolean AppGhostTrackUsage_Par, string mac_addr,String GhostPasskey)
            App_System_Paths asps = new App_System_Paths();

            AppGhostAuth_Details user = new AppGhostAuth_Details(Is_AppGhost_Active_Par: Is_AppGhost_Active, AppGhost_ChangeTime_Par: AppGhost_ChangeTime, AppGhost_RandomizeNames_Par: AppGhost_RandomizeNames, AppGhostTrackUsage_Par: AppGhostTrackUsage, mac_addr: mac_addr, GhostPasskey: hash.Sha1Hash(app_ghost), AppGhostFilePathPar: AppGhostFilePath);
            Stream stream = File.Open(asps.Path_to_Ghostauth_data_xml(), FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, user);
            stream.Close();
            //confirm data is save 
            //just printing to screen
            user = null;
            stream = File.Open(asps.Path_to_Ghostauth_data_xml(), FileMode.Open);
            bf = new BinaryFormatter();
            user = (AppGhostAuth_Details)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine("install data->\n" + user.ToString());
        }
        #endregion
        #region Save_xml_install_data_to_file()
        public void Save_xml_install_data_to_file(DateTime install_time, string app_id, string mac_address, string comp_name, string com_title = "Crypto")
        {


            App_System_Paths asps = new App_System_Paths();
            //"kamau","email","comp name",DateTime.Now,key
            AppInstall_Details user = new AppInstall_Details(com_title: com_title, install_time: install_time, app_id: app_id, mac_address: mac_address, comp_name: comp_name);
            Stream stream = File.Open(asps.Path_to_install_data_xml(), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

            Console.WriteLine("Install details \n install time:{0} , \n from object \n  mac add : {1}", install_time, user.Mac_Address_Install_Details);

            BinaryFormatter bf = new BinaryFormatter();
            Console.WriteLine("serializing \n {0}", user.ToString());
            bf.Serialize(stream, user);
            stream.Close();

            //confirm data is save
            //just printing to screen
            user = null; bf = null;
            Stream stream1 = File.Open(asps.Path_to_install_data_xml(), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            bf = new BinaryFormatter();
            user = (AppInstall_Details)bf.Deserialize(stream1);
            stream1.Close();
            Console.WriteLine("install data from file->\n" + user.ToString());
        }
        #endregion
        #region Save_xml_user_data_to_file
        public void Save_xml_user_data_to_file(string name, string email, string comp_name, DateTime install_time, String app_key)
        {

            //"kamau","email","comp name",DateTime.Now,key
            User_data user = new User_data(name, email, comp_name, install_time, app_key);
            App_System_Paths asps = new App_System_Paths();

            Stream stream = File.Open(asps.Path_to_user_data_xml(), FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, user);
            stream.Close();
            //confirm data is save 
            //just printing to screen
            user = null;
            stream = File.Open(asps.Path_to_user_data_xml(), FileMode.Open);
            bf = new BinaryFormatter();
            user = (User_data)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine("user data->\n" + user.ToString());
        }
        #endregion
        #region Save_xml_purchase_data_to_file //multiple parameters
        public void Save_xml_purchase_data_to_file(string app_key, DateTime purchase_time, string purchase_key, int lisence_preiod)
        {
            App_System_Paths asps = new App_System_Paths();
            //App_key Purchase_time  Purchase_key  Purchase_lisence_period
            Purchase_data pd = new Purchase_data(app_key, purchase_time, purchase_key, lisence_preiod);
            Stream stream = File.Open(asps.Path_to_purchase_data_xml(), FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, pd);
            stream.Close();
            //confirm data is save 
            //just printing to screen
            pd = null;
            stream = File.Open(asps.Path_to_purchase_data_xml(), FileMode.Open);
            bf = new BinaryFormatter();
            pd = (Purchase_data)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine("\n\nuser data->\n" + pd.ToString());
        }
        #endregion
        #region Save dummy purxchase data if null 
        public void SaveDummyPurchaseDataIfFileEmpty()
        {
            String key = App_Json.get_app_key();
            DateTime installtime = App_Json.get_install_time();
            try
            {
                App_System_Paths asps = new App_System_Paths();

                //  Stream stream = File.Open(asps.Path_to_purchase_data_xml(), FileMode.Create);

                BinaryFormatter bf = new BinaryFormatter();

                Stream stream = File.Open(asps.Path_to_purchase_data_xml(), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

                if (stream.Length == 0)
                {
                    Console.WriteLine("Insert default data");
                    //public    void Save_xml_purchase_data_to_file(string app_key, DateTime purchase_time, string purchase_key, int lisence_preiod)


                    Save_xml_purchase_data_to_file(app_key: key, purchase_time: installtime, purchase_key: "-", lisence_preiod: 0);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error in xml save purchase data");
            }

            Purchase_data pd = new Purchase_data(app_key_param: key, purcase_date: installtime, purchase_key: "-", purchase_lisence_period: 0);
            App_Json aj = new App_Json();
            //  aj.Save_json_purchase_data_to_file(pd);

        }
        #endregion



        #region  Get_xml_settings_data_from_file()
        public AppSettings_Details Get_xml_settings_data_from_file()
        {
            App_System_Paths asps = new App_System_Paths();

            BinaryFormatter bf = new BinaryFormatter();

            Stream stream = File.Open(asps.Path_to_settings_data_xml(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            AppSettings_Details settings_details = (AppSettings_Details)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine("install data->\n" + settings_details.ToString());

            return settings_details;
        }

        #endregion
        #region CreateSettingsDataFile
        public void CreateSettingsDataFile()
        {
            //Stream stream = File.Open(asps.Path_to_settings_data_xml(), FileMode.Create);
            App_System_Paths asps = new App_System_Paths();
            bool exists = File.Exists(asps.Path_to_settings_data_xml());
            Console.WriteLine("\n\n\n ------->exist result {0}", exists);
            if (!exists)
            {
                File.Create(asps.Path_to_settings_data_xml());
                Console.WriteLine("File not exist creaate file -- Path_to_settings_data_xml");
                //Stream stream = File.Open(asps.Path_to_auth_data_xml(), FileMode.Create);
                //stream.Close();
            }
        }
        #endregion
        #region  Get_xml_auth_data_from_file()
        public AppAuth_Details Get_xml_auth_data_from_file()
        {
            //CreateAuthFileIfNecessary();
            AppAuth_Details Install_details = null;
            try
            {
                App_System_Paths asps = new App_System_Paths();

                BinaryFormatter bf = new BinaryFormatter();

                Stream stream = File.Open(asps.Path_to_auth_data_xml(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);


                Install_details = (AppAuth_Details)bf.Deserialize(stream);
                stream.Close();

                Console.WriteLine("install data->\n" + Install_details.ToString());
                return Install_details;
            }
            catch (IOException)
            {
                Console.WriteLine("Error ioexception");
            }

            if (Install_details == null)
            {
                Console.WriteLine("Ïnstall details from xml is null get from json");
                App_Json a = new App_Json();
                Install_details = a.GetAppAuthDetails();
            }
            return Install_details;

        }
        #endregion
        #region CreateAuthFile
        public void CreateAuthFile()
        {
            //check if file is not exist
            App_System_Paths asps = new App_System_Paths();
            bool exists = File.Exists(asps.Path_to_auth_data_xml());
            Console.WriteLine("\n\n\n ------->exist result {0}", exists);
            if (!exists)
            {
                File.Create(asps.Path_to_auth_data_xml());
                Console.WriteLine("File not exist creaate file");
                //Stream stream = File.Open(asps.Path_to_auth_data_xml(), FileMode.Create);
                //stream.Close();
            }
        }
        #endregion
        #region  Get_xml_Ghostauth_data_from_file()
        public AppGhostAuth_Details Get_xml_Ghostauth_data_from_file()
        {
            App_System_Paths asps = new App_System_Paths();


            BinaryFormatter bf = new BinaryFormatter();

            Stream stream = File.Open(asps.Path_to_Ghostauth_data_xml(), FileMode.Open);

            AppGhostAuth_Details Ghost_details = (AppGhostAuth_Details)bf.Deserialize(stream);

            stream.Close();
            Console.WriteLine("install data->\n" + Ghost_details.ToString());

            return Ghost_details;
        }

        #endregion
        #region CreateGhostAuthFile
        public void CreateGhostAuthFile()
        {
            //check if file is not exist
            App_System_Paths asps = new App_System_Paths();
            bool exists = File.Exists(asps.Path_to_Ghostauth_data_xml());
            Console.WriteLine("\n\n\n ------->exist result {0}", exists);
            if (!exists)
            {
                File.Create(asps.Path_to_Ghostauth_data_xml());
                Console.WriteLine("File not exist creaate file");
                //Stream stream = File.Open(asps.Path_to_auth_data_xml(), FileMode.Create);
                //stream.Close();
            }
        }
        #endregion
        #region  Get_xml_install_data_from_file()
        public AppInstall_Details Get_xml_install_data_from_file()
        {
            AppInstall_Details Install_details = null;

            App_System_Paths asps = new App_System_Paths();

            try
            {

                BinaryFormatter bf = new BinaryFormatter();

                Stream stream = File.Open(asps.Path_to_install_data_xml(), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

                Install_details = (AppInstall_Details)bf.Deserialize(stream);
                stream.Close();
                Console.WriteLine("install data->\n" + Install_details.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Get_xml_install_data_from_file \n {0}", e);
            }
            if (Install_details == null)
            {
                App_Json json = new App_Json();
                Install_details = json.GetAppInstallDetails();
            }
            return Install_details;
        }
        #endregion
        #region CreateInstallDataiFile
        public void CreateInstallDataFile()
        {
            //Stream stream = File.Open(asps.Path_to_settings_data_xml(), FileMode.Create);
            App_System_Paths asps = new App_System_Paths();
            bool exists = File.Exists(asps.Path_to_install_data_xml());
            Console.WriteLine("\n\n\n ------->exist result {0}", exists);
            if (!exists)
            {
                File.Create(asps.Path_to_install_data_xml());
                Console.WriteLine("File not exist creaate file -- Path_to_settings_data_xml");
                //Stream stream = File.Open(asps.Path_to_auth_data_xml(), FileMode.Create);
                //stream.Close();
            }
        }
        #endregion
        #region  Get_xml_user_data_to_file()
        public User_data Get_xml_user_data_to_file()
        {

            App_System_Paths asps = new App_System_Paths();

            BinaryFormatter bf = new BinaryFormatter();

            Stream stream = File.Open(asps.Path_to_user_data_xml(), FileMode.Open);

            User_data User_details = (User_data)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine("user data->\n" + User_details.ToString());

            return User_details;
        }

        #endregion
        #region CreateUserDataFile
        public void CreateUserDataFile()
        {
            //Stream stream = File.Open(asps.Path_to_user_data_xml(), FileMode.Create);
            //check if file is not exist
            App_System_Paths asps = new App_System_Paths();
            bool exists = File.Exists(asps.Path_to_user_data_xml());
            Console.WriteLine("\n\n\n ------->exist result {0}", exists);
            if (!exists)
            {
                File.Create(asps.Path_to_user_data_xml());
                Console.WriteLine("File not exist creaate file Path_to_user_data_xml");
                //Stream stream = File.Open(asps.Path_to_auth_data_xml(), FileMode.Create);
                //stream.Close();
            }
        }
        #endregion
        #region  Get_xml_purchase_data_to_file()
        public Purchase_data Get_xml_purchase_data_from_file()
        {
            Purchase_data Purchase_details = null;
            try
            {

                App_System_Paths asps = new App_System_Paths();

                //  Stream stream = File.Open(asps.Path_to_purchase_data_xml(), FileMode.Create);

                BinaryFormatter bf = new BinaryFormatter();

                Stream stream = File.Open(asps.Path_to_purchase_data_xml(), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

                if (stream.Length == 0)
                {
                    SaveDummyPurchaseDataIfFileEmpty();
                }

                Purchase_details = (Purchase_data)bf.Deserialize(stream);
                stream.Close();
                Console.WriteLine("Purchase data->\n" + Purchase_details.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Ërror in app xml purchase data");

            }

            if (Purchase_details == null)
            {
                App_Json aj = new App_Json();

            }

            return Purchase_details;
        }
        #endregion
        #region CreatePurchaseDataFile
        public void CreatePurchaseDataFile()
        {
            //check if file is not exist
            App_System_Paths asps = new App_System_Paths();
            bool exists = File.Exists(asps.Path_to_purchase_data_xml());
            Console.WriteLine("\n\n\n ------->exist result {0}", exists);
            if (!exists)
            {
                File.Create(asps.Path_to_purchase_data_xml());
                Console.WriteLine("File not exist creaate file");
                //Stream stream = File.Open(asps.Path_to_auth_data_xml(), FileMode.Create);
                //stream.Close();
            }
        }
        #endregion

    }

    #region App Settings_Details object body
    [Serializable()]
    class AppSettings_Details : ISerializable
    {
        public string App_Setting_System_Resources { get; set; }
        public string App_Settings_Send_AnonymousData { get; set; }
        public string App_Settings_PlatformType { get; set; }
        public DateTime App_SettingsChange_Time { get; set; }

        public AppSettings_Details() { }
        public AppSettings_Details(string Settings_Send_AnonymousData_par, String PlatFormType, DateTime App_SettingsChange_Time_par, string Setting_System_Resources_par)
        {
            this.App_Setting_System_Resources = Setting_System_Resources_par;
            this.App_Settings_Send_AnonymousData = Settings_Send_AnonymousData_par;
            this.App_SettingsChange_Time = App_SettingsChange_Time_par;
            this.App_Settings_PlatformType = PlatFormType;


        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("App_Settings_Send_AnonymousData", App_Settings_Send_AnonymousData);
            info.AddValue("App_Setting_System_Resources", App_Setting_System_Resources);
            info.AddValue("App_SettingsChange_Time", App_SettingsChange_Time);
            info.AddValue("App_Settings_PlatformType", App_Settings_PlatformType);

        }

        public AppSettings_Details(SerializationInfo info, StreamingContext context)
        {

            App_Settings_Send_AnonymousData = (string)info.GetValue("App_Settings_Send_AnonymousData", typeof(string));
            App_Setting_System_Resources = (string)info.GetValue("App_Setting_System_Resources", typeof(string));
            App_Settings_PlatformType = (string)info.GetValue("App_Settings_PlatformType", typeof(string));
            App_SettingsChange_Time = (DateTime)info.GetValue("App_SettingsChange_Time", typeof(DateTime));

        }

        public override string ToString()
        {
            return string.Format("App settings details \n App_Settings_Send_AnonymousData {0},\n App_Setting_System_Resources {1},\n " +
                "App_SettingsChange_Time {2}",
               App_Settings_Send_AnonymousData, App_Setting_System_Resources, App_SettingsChange_Time

                );

        }
    }
    #endregion
    #region App Auth_Details object body
    [Serializable()]
    class AppAuth_Details : ISerializable
    {
        public string App_User_Email { get; set; }
        public string App_User_Name { get; set; }
        public string App_User_Pass { get; set; }
        public DateTime App_User_Install_Time { get; set; }
        public string App_User_App_Id { get; set; }
        public string Mac_Address_Install_Details { get; set; }

        public AppAuth_Details() { }
        public AppAuth_Details(string email, DateTime install_time, string app_id, string name, string mac_addr, string pass)
        {
            this.App_User_App_Id = app_id;
            this.App_User_Email = email;
            this.App_User_Name = name;
            this.App_User_Install_Time = install_time;
            this.Mac_Address_Install_Details = mac_addr;
            this.App_User_Pass = pass;

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("App_User_App_Id", App_User_App_Id);
            info.AddValue("App_User_Email", App_User_Email);
            info.AddValue("App_User_Name", App_User_Name);
            info.AddValue("App_User_Pass", App_User_Pass);
            info.AddValue("App_User_Install_Time", App_User_Install_Time);
            info.AddValue("Mac_Address_Install_Details", Mac_Address_Install_Details);
        }

        public AppAuth_Details(SerializationInfo info, StreamingContext context)
        {

            App_User_App_Id = (string)info.GetValue("App_User_App_Id", typeof(string));
            App_User_Email = (string)info.GetValue("App_User_Email", typeof(string));
            App_User_Name = (string)info.GetValue("App_User_Name", typeof(string));
            App_User_Pass = (string)info.GetValue("App_User_Pass", typeof(string));
            App_User_Install_Time = (DateTime)info.GetValue("App_User_Install_Time", typeof(DateTime));
            Mac_Address_Install_Details = (string)info.GetValue("Mac_Address_Install_Details", typeof(string));

        }

        public override string ToString()
        {
            return string.Format("App install details  \n App id {0},\n email {1},\n name {2}, install time  {3},\n mac add {4}\n pass ky {5}",
               App_User_App_Id, App_User_Email, App_User_Name,
                App_User_Install_Time, Mac_Address_Install_Details,
                App_User_Pass
                );

        }
    }
    #endregion
    #region App GhostAuth_Details object body
    [Serializable()]
    class AppGhostAuth_Details : ISerializable
    {
        public Boolean Is_AppGhost_Active { get; set; }
        public Boolean AppGhost_RandomizeNames { get; set; }
        public DateTime AppGhost_ChangeTime { get; set; }
        public Boolean AppGhostTrackUsage { get; set; }
        public string AppGhostFilePath { get; set; }
        public string Mac_Address_Install_Details { get; set; }
        public string GhostAuthentificationKey { get; set; }

        public AppGhostAuth_Details() { }
        public AppGhostAuth_Details(Boolean Is_AppGhost_Active_Par, DateTime AppGhost_ChangeTime_Par, Boolean AppGhost_RandomizeNames_Par, Boolean AppGhostTrackUsage_Par, string mac_addr, String GhostPasskey, String AppGhostFilePathPar)
        {
            this.Is_AppGhost_Active = Is_AppGhost_Active_Par;
            this.AppGhost_RandomizeNames = AppGhost_RandomizeNames_Par;
            this.AppGhost_ChangeTime = AppGhost_ChangeTime_Par;
            this.AppGhostTrackUsage = AppGhostTrackUsage_Par;
            this.Mac_Address_Install_Details = mac_addr;
            this.GhostAuthentificationKey = GhostPasskey;
            this.AppGhostFilePath = AppGhostFilePathPar;


        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("Is_AppGhost_Active", Is_AppGhost_Active);
            info.AddValue("AppGhost_RandomizeNames", AppGhost_RandomizeNames);
            info.AddValue("AppGhost_ChangeTime", AppGhost_ChangeTime);
            info.AddValue("AppGhostTrackUsage", AppGhostTrackUsage);
            info.AddValue("Mac_Address_Install_Details", Mac_Address_Install_Details);
            info.AddValue("GhostAuthentificationKey", GhostAuthentificationKey);
            info.AddValue("AppGhostFilePath", AppGhostFilePath);
        }

        public AppGhostAuth_Details(SerializationInfo info, StreamingContext context)
        {

            Is_AppGhost_Active = (Boolean)info.GetValue("Is_AppGhost_Active", typeof(Boolean));
            AppGhost_RandomizeNames = (Boolean)info.GetValue("AppGhost_RandomizeNames", typeof(Boolean));
            AppGhostTrackUsage = (Boolean)info.GetValue("AppGhostTrackUsage", typeof(Boolean));
            AppGhost_ChangeTime = (DateTime)info.GetValue("AppGhost_ChangeTime", typeof(DateTime));
            Mac_Address_Install_Details = (string)info.GetValue("Mac_Address_Install_Details", typeof(string));
            GhostAuthentificationKey = (string)info.GetValue("GhostAuthentificationKey", typeof(string));
            AppGhostFilePath = (string)info.GetValue("AppGhostFilePath", typeof(string));

        }

        public override string ToString()
        {
            return string.Format(" AppGhostAuth_Details  \n Is Ghost Active {0},\n Randomize names {1},\n Track Ghost {2}, Last Change  {3},mac add {4}",
               Is_AppGhost_Active, AppGhost_RandomizeNames, AppGhostTrackUsage,
                AppGhost_ChangeTime, Mac_Address_Install_Details

                );

        }
    }
    #endregion
    #region AppInstall_Details object body
    [Serializable()]
    class AppInstall_Details : ISerializable
    {
        public string App_CommTitle_Install_Details { get; set; }
        public string App_Id_Install_Details { get; set; }
        public DateTime Install_Time_Install_Details { get; set; }
        public string Mac_Address_Install_Details { get; set; }
        public string Computer_Name_Install_Details { get; set; }

        public AppInstall_Details() { }
        public AppInstall_Details(string com_title, DateTime install_time, string app_id, string mac_address, string comp_name)
        {
            this.App_CommTitle_Install_Details = com_title;
            this.Install_Time_Install_Details = install_time;
            this.App_Id_Install_Details = app_id;
            this.Mac_Address_Install_Details = mac_address;
            this.Computer_Name_Install_Details = comp_name;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("App_CommTitle_Install_Details", App_CommTitle_Install_Details);
            info.AddValue("App_Id_Install_Details", App_Id_Install_Details);
            info.AddValue("Install_Time_Install_Details", Install_Time_Install_Details);
            info.AddValue("Mac_Address_Install_Details", Mac_Address_Install_Details);
            info.AddValue("Computer_Name_Install_Details", Computer_Name_Install_Details);
        }

        public AppInstall_Details(SerializationInfo info, StreamingContext context)
        {

            App_CommTitle_Install_Details = (string)info.GetValue("App_CommTitle_Install_Details", typeof(string));
            Install_Time_Install_Details = (DateTime)info.GetValue("Install_Time_Install_Details", typeof(DateTime));
            App_Id_Install_Details = (string)info.GetValue("App_Id_Install_Details", typeof(string));
            Mac_Address_Install_Details = (string)info.GetValue("Mac_Address_Install_Details", typeof(string));
            Computer_Name_Install_Details = (string)info.GetValue("Computer_Name_Install_Details", typeof(string));

        }

        public override string ToString()
        {
            return string.Format("App install details \n communication title {0},\n app key {1},\n install time {2}, comp mac addersss  {3},comp name {4}",
                App_CommTitle_Install_Details, App_Id_Install_Details, Install_Time_Install_Details,
                Mac_Address_Install_Details, Computer_Name_Install_Details

                );

        }
    }
    #endregion
    #region User_data object body
    [Serializable()]
    class User_data : ISerializable
    {
        ///initializer
        public User_data() { }
        public User_data(string user_name, string user_email, string user_computer_name, DateTime user_install_date_time, string app_key)
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", User_name);
            info.AddValue("Email", User_email);
            info.AddValue("Install_Time", User_Install_date_time);
            info.AddValue("Computer_Name", User_computer_name);
            info.AddValue("App_key", App_key);

        }

        public User_data(SerializationInfo info, StreamingContext context)
        {

            User_name = (string)info.GetValue("Name", typeof(string));
            User_email = (string)info.GetValue("Email", typeof(string));
            User_computer_name = (string)info.GetValue("Computer_Name", typeof(string));
            User_Install_date_time = (DateTime)info.GetValue("Install_Time", typeof(DateTime));
            App_key = (string)info.GetValue("App_key", typeof(string));


        }
        public override string ToString()
        {
            return string.Format("User name ->{0},\n User email ->{1} ,\n" +
                "computer  name ->{2} ,\n install time {3}\n ,app_key {4}", User_name, User_email, User_computer_name, User_Install_date_time, App_key);
        }

    }
    #endregion
    #region Purchase_data object body
    [Serializable()]
    class Purchase_data : ISerializable
    {

        public string App_key { get; set; }
        public DateTime Purchase_time { get; set; }
        public string Purchase_key { get; set; }
        public int Purchase_lisence_period { get; set; }

        public Purchase_data() { }
        public Purchase_data(string app_key_param, DateTime purcase_date, string purchase_key, int purchase_lisence_period)
        {
            this.App_key = app_key_param;
            this.Purchase_time = purcase_date;
            this.Purchase_key = purchase_key;
            this.Purchase_lisence_period = purchase_lisence_period;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("App_key", App_key);
            info.AddValue("Purchase_time", Purchase_time);
            info.AddValue("Purchase_key", Purchase_key);
            info.AddValue("Purchase_lisence_period", Purchase_lisence_period);
        }
        public Purchase_data(SerializationInfo info, StreamingContext context)
        {

            App_key = (string)info.GetValue("App_key", typeof(string));
            Purchase_time = (DateTime)info.GetValue("Purchase_time", typeof(DateTime));
            Purchase_key = (string)info.GetValue("Purchase_key", typeof(string));
            Purchase_lisence_period = (int)info.GetValue("Purchase_lisence_period", typeof(int));

        }
        public override string ToString()
        {
            return string.Format("Purchase details -> \n {0},\n  ->{1} ,\n" +
                "->{2} ,\n ->  {3}\n ", App_key, Purchase_time, Purchase_key, Purchase_lisence_period);
        }

    }
    #endregion

}

