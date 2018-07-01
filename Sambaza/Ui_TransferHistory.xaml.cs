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
using System.Windows.Shapes;

namespace Sambaza
{
    /// <summary>
    /// Interaction logic for Ui_TransferHistory.xaml
    /// </summary>
    public partial class Ui_TransferHistory : Page// Window
    {
        App_History history = new App_History();
        List<HistoryItem> historyList = new List<HistoryItem>();

        public Ui_TransferHistory()
        {
            InitializeComponent();
            historyList = history.GetHistoryItemsContents();

            PopulateHistoryItems();
        }
        #region populate list with data base data
        private void PopulateHistoryItems()
        {
            if (historyList == null || historyList.Count == 0)
            {
                header.Opacity = 1;
                header.Content = "No history items to display";
            }
            else
            {

                int counter = 0;
                foreach (HistoryItem item in historyList)
                {
                    StackPanel parentContainer = new StackPanel();
                    StackPanel transferCleientAndDelete = new StackPanel();


                    Label ItemName = new Label();
                    Label TransferClient = new Label();
                    Label TransferTime = new Label();
                    Button RemoteItem = new Button();

                    ItemName.Content = "Item Name: " + item.TransferItemName;
                    TransferTime.Content = "Time  : " + item.TransferTime;
                    TransferClient.Content = "Client  : " + item.TransferClient;

                    RemoteItem.Name = item.TransferItemName + "#" + counter;
                    RemoteItem.Click += RemoveItem_Click;


                    parentContainer.Orientation = Orientation.Vertical;
                    transferCleientAndDelete.Orientation = Orientation.Horizontal;

                    transferCleientAndDelete.Children.Add(TransferClient);
                    transferCleientAndDelete.Children.Add(RemoteItem);

                    parentContainer.Children.Add(ItemName);
                    parentContainer.Children.Add(TransferTime);
                    parentContainer.Children.Add(transferCleientAndDelete);

                    HistoryContents.Children.Add(parentContainer);

                    counter++;
                }
            }


        }
        #endregion
        #region RemoveItem_Click
        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {

            Button checkItem = (Button)sender;
            String TheWholeName = checkItem.Name;
            String integerItem = TheWholeName.Substring(TheWholeName.LastIndexOf("#") + 1);
            int RemoveIndex = Convert.ToInt32(integerItem);
            Console.WriteLine("Remove at index {0}",RemoveIndex);

            historyList.RemoveAt(RemoveIndex);

            HistoryContents.Children.Clear();
            //save the 
            history.SaveHistoryItemsContents(historyList);


        }
        #endregion
        #region populate list with list 
        private void RedisplayList()
        {
            if (historyList == null || historyList.Count == 0)
            {
                header.Opacity = 1;
                header.Content = "No history items to display";
            }

            int counter = 0;
            foreach (HistoryItem item in historyList)
            {
                StackPanel parentContainer = new StackPanel();
                StackPanel transferCleientAndDelete = new StackPanel();


                Label ItemName = new Label();
                Label TransferClient = new Label();
                Label TransferTime = new Label();
                Button RemoteItem = new Button();

                ItemName.Content = "Item Name: " + item.TransferItemName;
                TransferTime.Content = "Time  : " + item.TransferTime;
                TransferClient.Content = "Client  : " + item.TransferClient;

                RemoteItem.Name = item.TransferItemName + "#" + counter;
                RemoteItem.Click += RemoveItem_Click;


                parentContainer.Orientation = Orientation.Vertical;
                transferCleientAndDelete.Orientation = Orientation.Horizontal;

                transferCleientAndDelete.Children.Add(TransferClient);
                transferCleientAndDelete.Children.Add(RemoteItem);

                parentContainer.Children.Add(ItemName);
                parentContainer.Children.Add(TransferTime);
                parentContainer.Children.Add(transferCleientAndDelete);

                HistoryContents.Children.Add(parentContainer);

                counter++;
            }

        }
        #endregion

        #region Clear the entire list
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            List<HistoryItem> historyList_ = null;
            history.SaveHistoryItemsContents(historyList_);
        }
        #endregion
    }
}
