using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_Json_DataItems
    {
        #region create app data item json file
        public void CreateJsonDataItemsFile()
        {
            //Stream stream = File.Open(asps.Path_to_user_data_xml(), FileMode.Create);
            //check if file is not exist
            App_System_Paths asps = new App_System_Paths();
            bool exists = File.Exists(asps.Path_to_DataItems());
            Console.WriteLine("\n\n\n ------->exist result {0}", exists);
            if (!exists)
            {
                File.Create(asps.Path_to_DataItems());
                Console.WriteLine("File not exist creaate file Path_to_app_data_items");
                //Stream stream = File.Open(asps.Path_to_auth_data_xml(), FileMode.Create);
                //stream.Close();
            }

        }
        #endregion

        #region get app data item json file contents
        public List<DataItem> GetDataItemsContents()
        {
            App_System_Paths asps = new App_System_Paths();
            string json_str = App_File.Get_data_from_file(asps.Path_to_DataItems());
            Console.WriteLine(" GetDataItemsContents --------->{0}", json_str);
            List<DataItem> items = JsonConvert.DeserializeObject<List<DataItem>>(json_str);

            return items;
        }
        #endregion
        #region save app data items into json file 
        public void SaveDataItemsContents(List<DataItem> data)
        {
            App_System_Paths asps = new App_System_Paths();

            string json_str = JsonConvert.SerializeObject(data);
            Console.WriteLine("\n SaveDataItemsContents --------->{0}", json_str);
            App_File.Save_data_to_file(asps.Path_to_DataItems(), json_str);
        }
        #endregion
    }

    class DataItem
    {
        public DataItem(string file_Name, string file_Path, string file_EncryptionType, bool file_IsGhost, bool file_IsNameRandomized, string file_RandomizedName)
        {
            File_Name = file_Name;
            File_Path = file_Path;
            File_EncryptionType = file_EncryptionType;
            File_IsGhost = file_IsGhost;
            File_IsNameRandomized = file_IsNameRandomized;
            File_RandomizedName = file_RandomizedName;
        }

        public string File_Name { get; set; }
        public string File_Path { get; set; }
        public string File_EncryptionType { get; set; }
        public Boolean File_IsGhost { get; set; }
        public Boolean File_IsNameRandomized { get; set; }
        public string File_RandomizedName { get; set; }



    }
}
