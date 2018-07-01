using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_History
    {

        #region get app data item json file contents
        public List<HistoryItem> GetHistoryItemsContents()
        {
            App_System_Paths asps = new App_System_Paths();
            string json_str = App_File.Get_data_from_file(asps.PathToTransferLogs());
            Console.WriteLine(" GetHistoryItemsContents --------->{0}", json_str);
            List<HistoryItem> items = JsonConvert.DeserializeObject<List<HistoryItem>>(json_str);

            return items;
        }
        #endregion

        #region save history items to file
        public void SaveHistoryItemsContents(List<HistoryItem> data)
        {
            App_System_Paths asps = new App_System_Paths();

            string json_str = JsonConvert.SerializeObject(data);
            Console.WriteLine("\n SaveDataItemsContents --------->{0}", json_str);
            App_File.Save_data_to_file(asps.PathToTransferLogs(), json_str);
        }
        #endregion
    }
    class HistoryItem
    {
        public DateTime TransferTime { get; set; }
        public Boolean IsTransferSuccessfull { get; set; }
        public String TransferItemName { get; set; }
        public String TransferClient { get; set; }
    }
}
