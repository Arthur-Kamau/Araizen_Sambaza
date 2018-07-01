using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_Random
    {

        // static int length = 10;
        static char[] item = new char[10];
        static char[] pass = new char[4];


        static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*0123456789abcdefghijklmnopqryz";
        static string numbs = "1234567890";
        App_System_Paths sp = new App_System_Paths();
        String RandomFilePath = String.Empty;
        String PassProtect = String.Empty;

        public App_Random()
        {
            RandomFilePath = sp.Path_to_RandomFile();
            PassProtect = sp.Path_to_ProtectKey();
        }

        public string Generate_app_key()
        {
            Random rand = new Random();

            for (int i = 0; i < item.Length; i++)
            {
                item[i] = chars[rand.Next(chars.Length)];
            }
            return new string(item);
        }

        public string Generate_app_pin()
        {

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                pass[i] = numbs[rand.Next(chars.Length)];
            }
            return new string(pass);
        }

        public string Generate_random_number(int min, int max)
        {
            System.Random rand = new Random();
            string num = Convert.ToString(rand.Next(min, max));
            return num;
        }


        public string RandomItemName(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*0123456789abcdefghijklmnopqryz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void CreateRandomTextFile_And_MasterPassFile()
        {

            bool exist_RandomFile = File.Exists(RandomFilePath);
            bool exist_MasterPassFile = File.Exists(PassProtect);

            if (!exist_RandomFile)
            {
                using (File.Create(RandomFilePath)) ;
                PopulateRandomFile();
            }
            if (!exist_MasterPassFile) { using (File.Create(PassProtect)) ; }


        }
        public void PopulateRandomFile()
        {
            //CreateRandomTextFile_And_MasterPassFile();

            App_System_Paths sp = new App_System_Paths();

            string txt;
            using (StreamReader sr = new StreamReader(RandomFilePath))
            {

                txt = sr.ReadToEnd();
                sr.Close();
            }
            if (txt == null || txt.Length == 0)
            {
                using (StreamWriter sw = new StreamWriter(RandomFilePath))
                {
                    StringBuilder randomdata = new StringBuilder();
                    for (int i = 1; i <= 20; i++)
                    {
                        randomdata.Append(RandomItemName(25));

                    }
                    Console.WriteLine("----------->Appending {0}", randomdata);
                    sw.Write(randomdata);
                    sw.Close();
                }
            }
            else
            {
                Console.WriteLine("Text not empty do not write");
            }
        }
        public void InsertToRandom_Master_Pass(Char item, int Length)
        {
            App_System_Paths sp = new App_System_Paths();
            StringBuilder str = new StringBuilder();
            string pass = string.Empty;

            try
            {
                // Create an instance of StreamReader to read from a file.  
                // The using statement also closes the StreamReader.  
                using (StreamReader sr = new StreamReader(PassProtect))
                {
                    // string line;

                    // Read and display lines from the file until  
                    // the end of the file is reached.  
                    //while ((line = sr.Read()) != null)
                    //{
                    // Console.WriteLine(line);

                    str.Append(sr.ReadToEnd());

                    //}
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong. 
                Console.WriteLine("The file could not be read: {0}", e);
            }

            if (str.ToString().Contains(item))
            {
                pass = str.ToString().Substring(str.ToString().IndexOf(item), Length);
            }
            else
            {
                pass = "kkk"; //str.ToString().Substring(0, Length);
            }

            Console.WriteLine("The file contains {0}", str);

            /***
             * write pass to file
             */
            using (StreamWriter sw = new StreamWriter(PassProtect))
            {
                sw.Write(pass);
                sw.Close();
            }

        }
    }
}