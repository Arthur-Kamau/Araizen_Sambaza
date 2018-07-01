using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_System_Paths
    {
        String SystemApplicationDataStorage = String.Empty;
        #region path to system data storage
        public App_System_Paths()
        {
            // The folder for the roaming current user 
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Combine the base folder with your specific folder....
            string specificFolder = Path.Combine(folder, "Crypto");

            // CreateDirectory will check if folder exists and, if not, create it.
            // If folder exists then CreateDirectory will do nothing.
            Directory.CreateDirectory(specificFolder);

            SystemApplicationDataStorage = specificFolder;
        }
        #endregion

        #region path to Downloads  folder
        public string MyDownloads()
        {
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        }
        #endregion
        #region path to documents folder
        public string MyDocuments()
        {
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        }
        #endregion
        #region path to videos folder
        public string MyVideos()
        {
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            return Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        }
        #endregion


        #region Crypto Folder
        public string CryptoFolder()
        {
            String path = string.Concat(MyDocuments(), "\\Araizen_Crypto");
            bool exists = Directory.Exists(path);
            if (!exists)
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
        #endregion
        #region Crypto default Ghost Folder
        public string DefaultGhostFolder()
        {
            String path = System.IO.Path.Combine(MyVideos(), "/Araizen Crypto");
            bool exists = Directory.Exists(path);
            if (!exists)
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
        #endregion


        #region path to sql 
        public string Path_to_sql_File()
        {

            string path = string.Concat(SystemApplicationDataStorage, @"/Cryptodata.db3");
            Console.WriteLine("path to sql -->{0}", path);
            bool exist = File.Exists(path);
            if (!exist)
            {
                File.Create(path);
            }
            return path;

        }
        #endregion
        #region path to video thumbnails 
        public string Path_to_thumbanils()
        {

            string path = string.Concat(SystemApplicationDataStorage, @"/Thumbanils");
            Directory.CreateDirectory(path);
            return path;

        }
        #endregion
        #region path to history list
        public string PathToTransferLogs()
        {

            string path = string.Concat(SystemApplicationDataStorage, @"/History.json");
            Console.WriteLine("path to sql -->{0}", path);
            bool exist = File.Exists(path);
            if (!exist)
            {
                File.Create(path);
            }
            return path;

        }
        #endregion
        #region  path to App Error Logs
        public string PathToErrorLogs()
        {

            string path = string.Concat(SystemApplicationDataStorage, @"/error.json");
            Console.WriteLine("path to sql -->{0}", path);
            bool exist = File.Exists(path);
            if (!exist)
            {
                File.Create(path);
            }
            return path;

        }

        #endregion

        #region path to Randmon file 
        public string Path_to_RandomFile()
        {
            string path = string.Concat(SystemApplicationDataStorage, @"/random.txt");
            bool exist = File.Exists(path);
            if (!exist)
            {
                File.Create(path);
            }
            return path;

        }
        #endregion
        #region path to protect key txt 
        public string Path_to_ProtectKey()
        {

            string path = string.Concat(SystemApplicationDataStorage, @"/key.txt");
            bool exist = File.Exists(path);
            if (!exist)
            {
                File.Create(path);
            }
            return path;

        }
        #endregion

        #region path to DataItems json
        public string Path_to_DataItems()
        {
            string path = string.Concat(SystemApplicationDataStorage, @"/DataItem.json");
            bool exist = File.Exists(path);
            if (!exist)
            {
                File.Create(path);
            }
            return path;

        }
        #endregion


    }
}
