using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_ErrorLogs
    {
        #region get app data item json file contents
        public List<ErrorItem> GetErrorItemsContents()
        {
            App_System_Paths asps = new App_System_Paths();
            string json_str = App_File.Get_data_from_file(asps.PathToErrorLogs());
            Console.WriteLine(" GetErrorItemsContents --------->{0}", json_str);
            List<ErrorItem> items = JsonConvert.DeserializeObject<List<ErrorItem>>(json_str);

            return items;
        }
        #endregion

        #region save app data items into json file 
        public void SaveErrorItemsContents(List<ErrorItem> data)
        {
            App_System_Paths asps = new App_System_Paths();

            string json_str = JsonConvert.SerializeObject(data);
            Console.WriteLine("\n SaveDataItemsContents --------->{0}", json_str);
            App_File.Save_data_to_file(asps.PathToErrorLogs(), json_str);
        }
        #endregion
    }
    class ErrorItem
    {
        public DateTime ErrorTime { get; set; }
        public String Error { get; set; }
    }
}
