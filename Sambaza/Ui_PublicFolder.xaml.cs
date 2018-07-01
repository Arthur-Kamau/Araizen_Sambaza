using System;
using System.Collections.Generic;
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

namespace Sambaza
{
    /// <summary>
    /// Interaction logic for Ui_PublicFolder.xaml
    /// </summary>
    public partial class Ui_PublicFolder : Page//Window
    {
        List<string> item_list = new List<string>();
        List<String> GhostItemsList = new List<string>();

        App_System_Communication ac = new App_System_Communication();
        App_System_Paths path = new App_System_Paths();

        public Ui_PublicFolder()
        {
            LoadGhostItemsFromJson();
            InitializeComponent();
            Populate_public_contents();
            SendInstallDetails();

        }
        #region snd install details
        private void SendInstallDetails()
        {
            //from the thread spawn multiple low priority threads 
            bool HasAppSentDetails = false;
            var th = new Task(() =>
            {
                while (true)
                {
                    var IsThereInterent = App_System_Wifi.CheckForInternetConnection();
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        if (IsThereInterent)
                        {
                            Console.WriteLine("There Is Internet");
                            if (!HasAppSentDetails)
                            {
                                Console.WriteLine("Sending install details ...............");

                                /***/
                                ac.Send_Install_Details();
                                /***/
                                bool isAppGenuine = ac.Request_If_App_IsGenuine();

                                if (!isAppGenuine)
                                {
                                    //app is not genuine
                                    // AppIsNotGenuineUpdate();
                                }
                                //String result = App_System_Communication.Check_New_Version();
                                //if (result != null || result != string.Empty)
                                //{
                                //    Main_NewVersion mn = new Main_NewVersion(result);
                                //    mn.ShowDialog();
                                //}

                                ac.UpdateAppId();
                                HasAppSentDetails = true;

                            }//else ignore 
                        }
                        else
                        {
                            Console.WriteLine(" No Internet");
                        }
                    });
                    Thread.Sleep(5500);
                }
            });
            th.Start();

        }
        #endregion
        #region Populate_public_contents()
        private void Populate_public_contents()
        {


            //select folder
            // String path_to_documents = path.MyDocuments();
            string sambaza_folder = path.MyDownloads(); //string.Concat(path_to_documents, "\\Araizen_Crypto");

           //File.Create(sambaza_folder);
            bool exists = Directory.Exists(sambaza_folder);
            if (!exists)
            {
                Directory.CreateDirectory(sambaza_folder);
            }

            String[] sambaza_folder_contents = Directory.GetFiles(sambaza_folder);
            if (sambaza_folder_contents.Count() == 0)
            {

                content_infomation.Content = "Downloads folder is empty";
                Console.WriteLine("Folde item empty");
            }
            else
            {
                content_infomation.Opacity = 0;
                int counter = 0;
                foreach (string file_item in sambaza_folder_contents)
                {
                    Console.WriteLine("Folde item : {0}", file_item);

                    String owner = App_System_Details.GetComputerName();
                    long length = new System.IO.FileInfo(file_item).Length;
                    String ext = System.IO.Path.GetExtension(file_item);
                    String name_without_ext = System.IO.Path.GetFileNameWithoutExtension(file_item);

                    Add_items_to_ui(name: name_without_ext, owner: owner, type: ext, size: length, file_path: file_item, counterInt: counter);
                    item_list.Add(file_item);
                    counter++;
                }

            }
        }
        #endregion

        #region add folder items to ui  -->Add_items_to_ui(String name,String owner,String type,long size)
        private void Add_items_to_ui(String name, String owner, String type, long size, string file_path, int counterInt)
        {
            App_System_Paths asps = new App_System_Paths();

            StackPanel item_grid = new StackPanel();
            StackPanel image_and_comment = new StackPanel();
            StackPanel comments = new StackPanel();

            StackPanel item_details = new StackPanel();
            StackPanel item_details_description = new StackPanel();
            StackPanel download_stream = new StackPanel();



            //who is hosting the content
            Label item_parent_label = new Label
            {
                Content = owner
            };
            //name of the content
            Label item_name_label = new Label
            {
                Content = string.Concat("Name \t", name)
            };
            //size
            Label item_size_label = new Label
            {
                Content = string.Concat("Size ", Format_length(size))
            };
            //type -> word video music document
            Label item_type_label = new Label();

            FileInfo nf = new FileInfo(file_path);
            if (nf.Attributes.Equals("Directory"))
            {
                type = "Folder";
            }

            item_type_label.Content = string.Concat("\t\t\t Type \t", type);
            // item_details.HorizontalAlignment = 

            ComboBox commandcombo = new ComboBox();
            commandcombo.Width = 120;
            commandcombo.Name = "DownloadStream" + counterInt;
            ComboBoxItem download_combo = new ComboBoxItem();
            download_combo.Content = "Download";
            download_combo.Name = "Download" + counterInt;
            ComboBoxItem stream_combo = new ComboBoxItem();
            stream_combo.Content = "Stream";
            stream_combo.Name = "streamItem" + counterInt;


          //  commandcombo.DropDownClosed += GhostItemsChange;

            commandcombo.Items.Add(download_combo);
            commandcombo.Items.Add(stream_combo);
            download_stream.Children.Add(commandcombo);
           // download_stream.Children.Add(download_button);

     
            //ContainerOfIsGhost.Children.Add(IsGhostTrueLabel);


            //if video
            Button stream_button = new Button();
            stream_button.Content = "Stream";
            //all documents
            Button download_button = new Button();
            download_button.Content = "Download";

            //like it or not 
            Button comment_button = new Button();
            Button thumbs_up_button = new Button();
            Button thumbs_down_button = new Button();

            Image item_image = new Image();
            // item_image.Height = 70;
            // item_image.Width = 80;

            //Image comment_image = new Image();
            //Image thumbs_up_image = new Image();
            //Image thumbs_down_image = new Image();



            item_grid.Orientation = Orientation.Horizontal;
            item_grid.Width = public_contents.Width;
            item_grid.Height = 100;

            image_and_comment.Orientation = Orientation.Vertical;
            //comments.Orientation = Orientation.Horizontal;

            item_image.Width = 100; item_image.Height = 100;


            comment_button.Height = 25; comment_button.Width = 25;
            thumbs_up_button.Height = 25; thumbs_up_button.Width = 25;
            thumbs_down_button.Height = 25; thumbs_down_button.Width = 25;

            comments.Height = 30; comments.Width = 90;
            //comment_image.Width = 20; comment_image.Height = 20;
            //thumbs_up_image.Width = 20; thumbs_up_image.Height = 20;
            //thumbs_down_image.Width = 20; thumbs_up_image.Height = 20;


            comment_button.FindResource(ToolBar.ButtonStyleKey);
            comment_button.BorderThickness = new Thickness(0, 0, 0, 0);
            //  comment_button.Background = new SolidColorBrush(Colors.White);
            //comment_button.Content = comment_image;

            thumbs_down_button.FindResource(ToolBar.ButtonStyleKey);
            thumbs_down_button.BorderThickness = new Thickness(0, 0, 0, 0);
            //thumbs_down_button.Content = thumbs_down_image;

            thumbs_up_button.FindResource(ToolBar.ButtonStyleKey);
            thumbs_up_button.BorderThickness = new Thickness(0, 0, 0, 0);
            //thumbs_up_button.Content = thumbs_up_image;

            comments.Children.Add(comment_button);
            comments.Children.Add(thumbs_up_button);
            comments.Children.Add(thumbs_down_button);

            image_and_comment.Children.Add(item_image);
            // image_and_comment.Children.Add(comments);

            //item details
            item_details.Width = 500;
            item_details.Height = 100;
            item_details.Children.Add(item_name_label);
            item_details.Children.Add(item_parent_label);

            item_details_description.Orientation = Orientation.Horizontal;
            item_details_description.Children.Add(item_size_label);
            item_details_description.Children.Add(item_type_label);

            //add item_details_description into item_details
            item_details.Children.Add(item_details_description);

            download_stream.Orientation = Orientation.Vertical;




           
            List<string> video_ext = new List<string>() { ".mp4", ".mov", ".wmv", ".avi", ".flv" };
            List<string> image_ext = new List<string>() { ".png", ".jpeg", ".gif", ".bmp", ".tiff", ".psd", ".webp" };
            List<string> music_ext = new List<string>() { ".mp3", ".ogg", ".aac", ".atrac", ".aiff", ".wma", ".vorbis", ".opus" };
            List<string> wordDocument_ext = new List<string>() { ".doc", ".docx", ".dotx", ".rtf", ".dot" };
            List<string> textFile_ext = new List<string>() { ".txt", ".log" };
            List<string> webFile_ext = new List<string>() { ".html", ".htm" };

            //video_ext.InsertRange(video_ext.Count, new string[] { ".mp4", ".mov", ".wmv", ".avi", ".flv" });
            //image_ext.InsertRange(video_ext.Count, new string[] { ".png", ".jpeg", ".gif", ".bmp", ".tiff", ".psd", ".webp" });
            //wordDocument_ext.InsertRange(video_ext.Count, new string[] { ".doc", ".docx", ".dotx", ".rtf", ".dot", });
            //textFile_ext.InsertRange(video_ext.Count, new string[] { ".txt", ".log" });
            //webFile_ext.InsertRange(video_ext.Count, new string[] { ".html", ".htm" });
            //music_ext.InsertRange(video_ext.Count, new string[] { ".mp3", ".ogg", ".aac", ".atrac", ".aiff", ".wma", ".vorbis", ".opus" });


            FileAttributes attr = File.GetAttributes(file_path);
            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {

                item_image.Source = new BitmapImage(new Uri(@"/Resources/images/folder_icon.jpg", UriKind.Relative));

            }

            if (video_ext.Contains(type.ToLower()))
            {
                String[] crypto_Temp_Images_folder = Directory.GetFiles(asps.Path_to_thumbanils());
                foreach (var item in crypto_Temp_Images_folder)
                {
                    string image_name = System.IO.Path.GetFileNameWithoutExtension(item);
                    Console.WriteLine("Image name {0} and file name ={1}", item, name);
                    if (image_name.Equals(name))
                    {
                        try
                        {

                        }
                        catch (Exception e) { }
                        item_image.Source = new BitmapImage(new Uri(item));

                    }
                }
            }
            else if (wordDocument_ext.Contains(type.ToLower()))
            {

                item_image.Source = new BitmapImage(new Uri(@"/Resources/images/WinWordLogoSmall.scale-140.png", UriKind.Relative));


            }

            else if (type.ToLower().Equals(".pdf"))
            {


                item_image.Source = new BitmapImage(new Uri(@"/Resources/images/pdf.png", UriKind.Relative));


            }
            else if (type.ToLower().Equals(".xml"))
            {
                //String resourceDir = asps.Curr_Resources_Dir();
                //System.Uri resourceImageUri = new System.Uri(System.IO.Path.Combine(resourceDir, "images/file.jpg"));

                //Console.WriteLine("->Resource Dir ={0} \n resource image uri ={1}", asps.Curr_Resources_Dir(), resourceImageUri);

                item_image.Source = new BitmapImage(new Uri(@"/Resources/images/file.jpg", UriKind.Relative));

            }

            else if (music_ext.Contains(type.ToLower()))
            {

                item_image.Source = new BitmapImage(new Uri(@"/Resources/images/mp3.png", UriKind.Relative));

            }
            else if (image_ext.Contains(type.ToLower()))
            {

                System.Uri resourceImageUri = new System.Uri(file_path);

                item_image.Source = new BitmapImage();
            }
            else
            {

                item_image.Source = new BitmapImage(new Uri(@"/Resources/images/files.png", UriKind.Relative));

            }





            //comment_image.Source = new BitmapImage(new Uri(@"C:\Users\Arthur-Kamau\source\repos\sambaza-desktop-ui\sambaza-desktop-ui\resources\ic_comment_black_24dp.png"));
            //thumbs_down_image.Source = new BitmapImage(new Uri(@"C:\Users\Arthur-Kamau\source\repos\sambaza-desktop-ui\sambaza-desktop-ui\resources\ic_thumb_down_black_24dp_1x.png"));

            //thumbs_up_image.Source = new BitmapImage(new Uri(@"C:\Users\Arthur-Kamau\source\repos\sambaza-desktop-ui\sambaza-desktop-ui\resources\ic_thumb_up_black_24dp_1x.png"));



            item_grid.Children.Add(image_and_comment);
            item_grid.Children.Add(item_details);
            item_grid.Children.Add(download_stream);

            item_grid.Margin = new Thickness(0, 10, 0, 0);


            public_contents.Children.Add(item_grid);


            /**
             * set selcetced item in combiobox
             */

        }
        #endregion

        private void LoadGhostItemsFromJson()
        {
            App_Json_DataItems json_dataitem = new App_Json_DataItems();
            List<DataItem> ghostlist = json_dataitem.GetDataItemsContents();
            if (ghostlist == null || ghostlist.Count == 0)
            {
                Console.WriteLine("GhostItemsList item is null or empty");
            }
            else
            {
                foreach (DataItem itemInList in ghostlist)
                {
                    GhostItemsList.Add(itemInList.File_Name);
                    Console.WriteLine("\n\n\t->GhostItemsList item containe {0}", itemInList.File_Name);
                }
            }
        }


        #region IsGhostTrueCheckBox_Click
        private void IsGhostTrueCheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkItem = (CheckBox)sender;
            String TheWholeName = checkItem.Name;
            String integerItem = TheWholeName.Substring(TheWholeName.LastIndexOf("x") + 1);

            /**
             * add to ghost
             */


            if (checkItem.IsChecked == true)
            {
                checkItem.Content = "Ghost Item";
                Console.WriteLine("Ghost item is checked for int number ={0} \n and is checked = true", integerItem);
                /**
                  *  add to json file
                  */
                AddGhostItem(integerItem: integerItem);
            }
            else
            {
                checkItem.Content = "Not Ghost Item";
                Console.WriteLine("Ghost item is checked for int number ={0} \n and is checked = false", integerItem);
                /**
                 * remove from json file
                 */
                RemoveGhostItem(integerItem: integerItem);
            }
        }
        #endregion

        #region add ghost item
        private void AddGhostItem(String integerItem)
        {
            int getItem = Int32.Parse(integerItem);

            String ItemPathFromList = item_list[getItem];

            Console.WriteLine("Ghost item selected");

            Console.WriteLine("------------> Item selected {0}", ItemPathFromList);

            App_Random rands = new App_Random();
            String RandomNameSelected = rands.RandomItemName(10);

            // public DataItem(string file_Name, string file_Path, string file_EncryptionType, bool file_IsGhost, bool file_IsNameRandomized, string file_RandomizedName)


            String FileItemNamePar = System.IO.Path.GetFileName(ItemPathFromList);
            String FileItemPathPar = System.IO.Path.GetDirectoryName(ItemPathFromList);
            String fileEncryptionTypePar = "Default";
            Boolean FileGhostItemPar = true;
            Boolean IsRandomizeNamePar = true;
            String RandomizedNamePar = RandomNameSelected;

            DataItem Dataitem = new DataItem(
                file_Name: FileItemNamePar,
                file_Path: FileItemPathPar,
                file_EncryptionType: fileEncryptionTypePar,
                file_IsGhost: FileGhostItemPar,
                file_IsNameRandomized: IsRandomizeNamePar,
                file_RandomizedName: RandomizedNamePar
                );
            App_Json_DataItems ajd = new App_Json_DataItems();

            List<DataItem> GhostItemsInJson = ajd.GetDataItemsContents();

            if (GhostItemsInJson == null)
            {
                List<DataItem> NewItems = new List<DataItem>
                {
                    Dataitem
                };

                ajd.SaveDataItemsContents(NewItems);
                Console.WriteLine("new item list");
            }
            else
            {

                List<String> names = new List<string>();
                //get all th names from json
                for (int i = 0; i < GhostItemsInJson.Count; i++)
                {
                    names.Add(GhostItemsInJson[i].File_Name);
                }
                //check if any names match the names selected
                if (names.Contains(Dataitem.File_Name))
                {
                    //ignore if there is  a match
                    Console.WriteLine("Contains name {0}", Dataitem.File_Name);
                }
                else
                {
                    //if no match add
                    GhostItemsInJson.Add(Dataitem);
                }
                ajd.SaveDataItemsContents(GhostItemsInJson);
                Console.WriteLine("-------- old item list");
            }
        }
        #endregion
        #region remove item from ghost items
        private void RemoveGhostItem(String integerItem)
        {

            int getItem = Int32.Parse(integerItem);

            String ItemPathFromList = item_list[getItem];

            Console.WriteLine("Not Ghost item selected");

            App_Json_DataItems ajd = new App_Json_DataItems();

            List<DataItem> GhostItemsInJson = ajd.GetDataItemsContents();

            for (int i = 0; i < GhostItemsInJson.Count(); i++)
            {
                if (GhostItemsInJson[i].File_Name.Equals(System.IO.Path.GetFileName(ItemPathFromList)))
                {

                    Console.WriteLine(" \n\n Removing item name {0} ", GhostItemsInJson[i].File_Name);
                    GhostItemsInJson.Remove(GhostItemsInJson[i]);
                }
            }


            ajd.SaveDataItemsContents(GhostItemsInJson);
        }

        #endregion



        private string Format_length(long len)
        {
            string[] sizes = { "b", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            String result = string.Format("{0:0.##} {1}", len, sizes[order]);
            Console.WriteLine("-->{0}", result);
            return result;
        }

        private void HomePanel_Drop(object sender, DragEventArgs e)
        {
            Console.WriteLine("Drop  Home Panel");
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var item in files)
            {
                Console.WriteLine(" home panel Item Dropped {0} \n", item);
            }
        }

        private void Search_Words_KeyUp(object sender, KeyEventArgs e)
        {
            String WordToSearch = Search_Words.Text;
            if (WordToSearch == null || WordToSearch.Length == 0)
            {
                item_list.Clear();
                LoadCryptoFolderContents();
            }
            else
            {
                if (item_list.Count > 0)
                {
                    int counter = 0;
                    App_System_Paths asps = new App_System_Paths();
                    String path_to_documents = asps.MyDocuments();
                    string sambaza_folder = string.Concat(path_to_documents, "\\Araizen_Crypto");

                    String[] sambaza_folder_contents = Directory.GetFiles(sambaza_folder);
                    foreach (var file_item in sambaza_folder_contents)//item_list)
                    {
                        if (System.IO.Path.GetFileName(file_item).Contains(WordToSearch))
                        {
                            public_contents.Children.Clear();
                            content_infomation.Opacity = 0;
                            Console.WriteLine("Folde item : {0}", file_item);

                            String owner = App_System_Details.GetComputerName();
                            long length = new System.IO.FileInfo(file_item).Length;
                            String ext = System.IO.Path.GetExtension(file_item);
                            String name_without_ext = System.IO.Path.GetFileNameWithoutExtension(file_item);

                            Add_items_to_ui(name: name_without_ext, owner: owner, type: ext, size: length, file_path: file_item, counterInt: counter);
                            counter++;
                        }
                        else
                        {
                            public_contents.Children.Clear();
                            content_infomation.Opacity = 1;
                            content_infomation.Content = "No Files match The Input Character(s)";
                            Console.WriteLine("Does not contain letter {0} in word {1}", WordToSearch, System.IO.Path.GetFileName(file_item));
                        }

                    }
                }
                else if (item_list.Count == 0 || item_list.Count < 0)
                {
                    Console.WriteLine("Itemlist empt {0}", item_list.Count);
                    item_list.Clear();
                    LoadCryptoFolderContents();
                }
            }
        }
        private void Search_Words_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void Search_Words_LostFocus(object sender, RoutedEventArgs e)
        {
            item_list.Clear();
            LoadCryptoFolderContents();
        }

        private void LoadCryptoFolderContents()
        {
            item_list.Clear();
            App_System_Paths asps = new App_System_Paths();
            String path_to_documents = asps.MyDocuments();
            string sambaza_folder = string.Concat(path_to_documents, "\\Araizen_Crypto");

            String[] sambaza_folder_contents = Directory.GetFiles(sambaza_folder);
            if (sambaza_folder_contents.Count() == 0)
            {

                content_infomation.Content = "Crypto folder in your downloads folder is empty";
                Console.WriteLine("Folde item empty");
            }
            else
            {
                content_infomation.Opacity = 0;
                int counter = 0;

                foreach (string file_item in sambaza_folder_contents)
                {
                    Console.WriteLine("Folde item : {0}", file_item);

                    String owner = App_System_Details.GetComputerName();
                    long length = new System.IO.FileInfo(file_item).Length;
                    String ext = System.IO.Path.GetExtension(file_item);
                    String name_without_ext = System.IO.Path.GetFileNameWithoutExtension(file_item);

                    Add_items_to_ui(name: name_without_ext, owner: owner, type: ext, size: length, file_path: file_item, counterInt: counter);
                    item_list.Add(file_item);
                    counter++;
                }

            }
        }


    }
}
