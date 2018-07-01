using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_File
    {

        public static void Save_data_to_file(string path, string data)
        {
            //  C: \Users\Arthur - Kamau\source\repos\sambaza - desktop - ui\sambaza - desktop - ui\bin\Debug\App_Config\
            //if file does not exist create it
            //create dir container if not exist

            CreateFileIfNotExist(path, data);
            SaveToFile(path, data);

        }
        private static void CreateFileIfNotExist(string path, string data)
        {
            System.IO.DirectoryInfo curr = new DirectoryInfo(".");
            String path_to_folder = curr.ToString() + "\\App_Config";
            if (File.Exists(path_to_folder)) { Console.WriteLine("File exists = {0}", path_to_folder); } else { Directory.CreateDirectory(path_to_folder); }

            //create file if not exist
            if (File.Exists(path))
            {
                Console.WriteLine("File exists = {0}", path);
            }
            else
            {
                Console.WriteLine("create file in path = {0}", path);
                var the_file = File.Create(@path);
                the_file.Close();
            }
        }
        private static void SaveToFile(string path, string data)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    Console.WriteLine("writing to file");
                    //encrypt the data


                    sw.WriteLine(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("erro saving {0} \n\n error {1}", path, e);
            }
        }
        public static string Get_data_from_file(string file_path)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.  
                // The using statement also closes the StreamReader.  
                using (StreamReader sr = new StreamReader(file_path))
                {
                    string line;
                    string str = string.Empty;
                    // Read and display lines from the file until  
                    // the end of the file is reached.  
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        str += line;
                    }
                    Console.WriteLine("-------->{0}", str);
                    return str;
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong. 
                Console.WriteLine("The file could not be read:");

                Console.WriteLine(e.Message);
            }
            return "";
        }

        //back up  is file ready
        public static bool IsFileReady(String filename)
        {
            //if the file can be opened  for exclusive access  it means the file is no longer locked by another process
            try
            {
                using (FileStream inputstreasm = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    if (inputstreasm.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception {0}", e);
                return false;
            }
        }

    }
}
