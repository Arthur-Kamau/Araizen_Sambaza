using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_System_Communication
    {


        private const string ok = "ok";
        private const string err = "err";

        String AppKey = String.Empty;
        String Mac = String.Empty;
        String ComputerName = String.Empty;
        String email = String.Empty;
        String name = String.Empty;
        String AppVersion = String.Empty;
        String AppBuild = String.Empty;
        String InstallTime = String.Empty;
        String PurchaseKey = String.Empty;
        int PurchasePeriod;

        public App_System_Communication()
        {
            App_Protect_String ProtectString = new App_Protect_String();

            AppKey = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.AppKey);
            Mac = ProtectString.DecryptString(App_System_Details.GetMacAddress());
            ComputerName = ProtectString.DecryptString(App_System_Details.GetComputerName());

            email = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.UserEmail);
            name = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.UserName);
            AppVersion = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.AppBuild);
            AppVersion = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.AppVersion);
            InstallTime = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.InstallTime);
            PurchaseKey = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.PurchaseKey);
            PurchaseKey = ProtectString.DecryptString(Sambaza.Properties.Settings.Default.PurchaseKey);
            PurchasePeriod = Convert.ToInt32(ProtectString.DecryptString(Convert.ToString(Sambaza.Properties.Settings.Default.PurchasePeriod)));

        }

        #region send feedback
        public void SendFedback(String feedbacktext, DateTime sendtime)
        {
            string Htmlresult = null;

            string url = "http://localhost:81/araizen/Crypto/Feeddback.php?";//https//www.araizen.spartial.org/sambaza/getForgotPasswordSerial.php";

            //message title // app key // install time //computer mac address // computer name
            string parameters = string.Format("App_Key={0}&email={1}&sendtime={2}&feedbacktext={3}", AppKey, email, sendtime, feedbacktext);

            using (WebClient wc = new WebClient())
            {
                try
                {
                    Htmlresult = wc.DownloadString(String.Concat(url, parameters));
                    Console.WriteLine(Htmlresult);
                }
                catch (Exception x) { Console.WriteLine("Errror in comms {0}", x); }
            }
            //got a response from te server
            if (Htmlresult != null)
            {
                Console.WriteLine("App got response");

                //alert user success 
                //return ok;

            }
            else //did not get responcse from server
            {
                Console.WriteLine("App did not get response");
                // return "err";

            }
        }
        #endregion

        #region create forgost serial key
        public string CreateForgotPasswordSerial(String email)
        {
            string Htmlresult = null;

            string url = "http://localhost:81/araizen/Crypto/ForgotPassword_EmailConfirmation.php?"; //"https//www.araizen.spartial.org/sambaza/getForgotPasswordSerial.php";

            //message title // app key // install time //computer mac address // computer name
            string parameters = string.Format("App_Key={0}&email={1}", AppKey, email);

            using (WebClient wc = new WebClient())
            {
                try
                {
                    Htmlresult = wc.DownloadString(String.Concat(url, parameters));
                    Console.WriteLine(Htmlresult);
                }
                catch (Exception x) { Console.WriteLine("Errror in comms {0}", x); }
            }
            //got a response from te server
            if (Htmlresult != null)
            {
                //get objects from the response
                Console.WriteLine("App  response = {0}", Htmlresult);
                //alert user success 
                return ok;

            }
            else //did not get responcse from server
            {
                Console.WriteLine("App did not get response");
                return "err";

            }
        }
        #endregion

        #region create forgost serial key
        public Boolean ConfirmForgotPasswordSerialIsGenuine(String serial)
        {
            string Htmlresult = null;

            string url = "http://localhost:81/araizen/Crypto/ForgotPassword_SerialConfirmation.php?";//"https//www.araizen.spartial.org/sambaza/getForgotPasswordSerial.php";



            //message title // app key // install time //computer mac address // computer name
            string parameters = string.Format("App_Key={0}&email={1}&App_ForgotPasswordSerial={2}", AppKey, email, serial);

            using (WebClient wc = new WebClient())
            {

                try
                {
                    Htmlresult = wc.DownloadString(String.Concat(url, parameters));
                    Console.WriteLine(Htmlresult);
                }
                catch (Exception x) { Console.WriteLine("Errror in comms {0}", x); }
            }
            //got a response from te server
            if (Htmlresult != null)
            {

                if (Htmlresult == "err" || Htmlresult == "")
                {
                    Console.WriteLine("Result is err or empty");
                    return false;
                }
                //alert user success 
                Console.WriteLine("Result is {0}", Htmlresult);
                return true;

            }
            else //did not get responcse from server
            {
                Console.WriteLine("App did not get response");
                return false;

            }
        }
        #endregion

        #region Check New version()
        public string Check_New_Version()
        {
            string Htmlresult = null;

            string url = "http://www.araizen.com/Crypto/comms/NewVersion.php?";

            //message title // app key // install time //computer mac address // computer name
            string parameters = string.Format("App_Key={0}&App_Version={1}&App_Build={2}",
                AppKey, AppVersion, AppBuild);

            using (WebClient wc = new WebClient())
            {
                try
                {
                    Htmlresult = wc.DownloadString(String.Concat(url, parameters));
                    Console.WriteLine(Htmlresult);
                }
                catch (Exception x) { Console.WriteLine("Errror in comms {0}", x); }
            }
            //got a response from te server
            if (Htmlresult != null)
            {


                //alert user success 
                return Htmlresult;

            }
            else //did not get responcse from server
            {
                Console.WriteLine("App did not get response");
                return "";

            }
        }
        #endregion

        #region update app id 
        public void UpdateAppId()
        {
            string Htmlresult = null;

            string url = "http://www.araizen.com/Crypto/comms/InstallDetails.php?";

            //message title // app key // install time //computer mac address // computer name
            string parameters = string.Format("Email={0}&App_Key={1}&Computer_Mac_Address={2}",
                 email, AppKey, Mac);

            using (WebClient wc = new WebClient())
            {
                try
                {
                    Htmlresult = wc.DownloadString(String.Concat(url, parameters));
                    Console.WriteLine(Htmlresult);
                }
                catch (Exception x) { Console.WriteLine("Errror in comms {0}", x); }
            }
            //got a response from te server
            if (Htmlresult != null)
            {
                //result is ok or err
                if (Htmlresult.Equals("ok"))
                {
                    Console.WriteLine("ok response from server");
                    // return ok;
                }
                else if (Htmlresult.Equals("block"))
                {
                    //block the application

                    Console.WriteLine("err response from server");
                    //return "err";
                }
                else
                {
                    Console.WriteLine("\n unknown response from Send_Install_Details \n result=>{0} ", Htmlresult);
                    // return "err";
                }
            }
            else //did not get responcse from server
            {
                Console.WriteLine("App did not get response");
                //return "err";
            }
        }
        #endregion

        #region Send_Install_Details()
        public string Send_Install_Details()
        {
            Console.WriteLine("\n\n\n Send_Install_Details \n\n ");

            string Htmlresult = null;

            string url = "http://www.araizen.com/Crypto/comms/InstallDetails.php?";

            //message title // app key // install time //computer mac address // computer name
            string parameters = string.Format("Email={0}&Name={1}&App_Key={2}&Install_Time={3}&Computer_Mac_Address={4}&Computer_Name={5}",
                                                 email, name, AppKey, InstallTime, Mac, ComputerName
                );

            using (WebClient wc = new WebClient())
            {

                try
                {
                    Htmlresult = wc.DownloadString(String.Concat(url, parameters));
                    Console.WriteLine(Htmlresult);
                }
                catch (Exception x) { Console.WriteLine("Errror in comms {0}", x); }
            }
            //got a response from te server
            if (Htmlresult != null)
            {
                //result is ok or err
                if (Htmlresult.Equals("ok"))
                {
                    Console.WriteLine("ok response from server");
                    return ok;
                }
                else if (Htmlresult.Equals("block"))
                {
                    //block the application

                    Console.WriteLine("err response from server");
                    return "err";
                }
                else
                {
                    Console.WriteLine("\n unknown response from Send_Install_Details \n result=>{0} ", Htmlresult);
                    Console.WriteLine(Htmlresult);
                    return "err";
                }
            }
            else //did not get responcse from server
            {
                Console.WriteLine("App did not get response");
                return "err";
            }
        }
        #endregion


        #region Send_user_Details()
        public string Send_User_Details()
        {
            string Htmlresult = null;

            string url = "http://www.araizen.com/Crypto/comms/installdata.php";

            //message title // app key // install time //computer mac address // computer name
            string parameters = string.Format("App_Key={0}&Install_Time={1},Computer_Mac_Address={2},Computer_Name ={3}",
               AppKey, InstallTime, Mac, ComputerName
                );

            using (WebClient wc = new WebClient())
            {
                try
                {
                    Htmlresult = wc.DownloadString(String.Concat(url, parameters));
                    Console.WriteLine(Htmlresult);
                }
                catch (Exception x) { Console.WriteLine("Errror in comms {0}", x); }
            }
            //got a response from te server
            if (Htmlresult != null)
            {
                //result is ok or err
                if (Htmlresult.Equals("ok") || Htmlresult.Equals("okay") || Htmlresult.Equals("true"))
                {
                    Console.WriteLine("ok response from server");
                    return ok;
                }
                else if (Htmlresult.Equals("err"))
                {
                    Console.WriteLine("err response from server");
                    return "err";
                }
                else
                {
                    Console.WriteLine("unknown response");
                    return "err";
                }
            }
            else //did not get responcse from server
            {
                Console.WriteLine("App did not get response");
                return "err";
            }
        }
        #endregion


        #region Get_Purchase_Details()
        public string Get_Purchase_Details(String purchaseKey)
        {
            string Htmlresult = null;

            string url = "http://www.araizen.com/Crypto/comms/GetPurchaseDetails.php?";

            // app key // install time //computer mac address // computer name
            string parameters = string.Format("App_Key={0}&Email={1}&purchasekey={2}",
                AppKey, email, purchaseKey
                );

            using (WebClient wc = new WebClient())
            {
                try
                {
                    Htmlresult = wc.DownloadString(String.Concat(url, parameters));
                    Console.WriteLine(Htmlresult);
                }
                catch (Exception x) { Console.WriteLine("Errror in comms {0}", x); }
            }
            //got a response from te server
            if (Htmlresult != null)
            {
                return Htmlresult;



            }
            else //did not get responcse from server
            {
                Console.WriteLine("App did not get response");
                return "err";

            }
        }
        #endregion


        #region AuthentifyPurchaseKey
        public bool AuthentifyPurchaseKey(String PurchaseKey)
        {
            string Htmlresult = null;

            string url = "http://localhost:81/araizen/Crypto/ConfirmPurchaseKey.php?";//https//www.araizen.spartial.org/sambaza/getForgotPasswordSerial.php";

            // app key // install time //computer mac address // computer name
            string parameters = string.Format("App_Key={0}&Email={1}&purchasekey={2}",
                AppKey, email, PurchaseKey);

            using (WebClient wc = new WebClient())
            {
                try
                {
                    Htmlresult = wc.DownloadString(String.Concat(url, parameters));
                    Console.WriteLine(Htmlresult);
                }
                catch (Exception x) { Console.WriteLine("Errror in comms {0}", x); }
            }
            //got a response from te server
            if (Htmlresult != null)
            {
                Console.WriteLine("App got response");

                //alert user success 
                //return ok;
                if (Htmlresult.Equals("ok") || Htmlresult.Equals("true"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else //did not get responcse from server
            {
                Console.WriteLine("App did not get response");
                // return "err";
                return false;

            }
        }
        #endregion


        #region BlockDuplication
        public Boolean IsAppGenuine()
        {
            string Htmlresult = null;

            string url = "http://localhost:81/araizen/Crypto/GetPurchaseDetails.php?";//"https//www.araizen.spartial.org/sambaza/clients/get_client_details.php";

            //message title // app key // install time //computer mac address // computer name
            string parameters = string.Format("App_Key={0}&Email={1}&Computer_Mac_Address={2}",
                AppKey, email, ComputerName
                );

            using (WebClient wc = new WebClient())
            {
                try
                {
                    Htmlresult = wc.DownloadString(String.Concat(url, parameters));
                    Console.WriteLine(Htmlresult);
                }
                catch (Exception x) { Console.WriteLine("Errror in comms {0}", x); }
            }
            //got a response from te server
            if (Htmlresult != null)
            {
                if (Htmlresult.ToLower().Equals("ok"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else //did not get responcse from server
            {
                Console.WriteLine("App did not get response");
                return false;

            }

        }
        #endregion


        #region Request_If_App_IsGenuine()
        public Boolean Request_If_App_IsGenuine()
        {

            string Htmlresult = null;

            string url = ""; //"https//www.araizen.spartial.org/sambaza/authentify/is_app_genuine.php";

            //message title // app key // install time //computer mac address // computer name
            string parameters = string.Format("App_Key={0}&Computer_Mac_Address={1}&Purchase_Key={2}&period={3}",

                AppKey, Mac, PurchaseKey, PurchasePeriod
                );

            using (WebClient wc = new WebClient())
            {
                try
                {
                    Htmlresult = wc.DownloadString(String.Concat(url, parameters));
                    Console.WriteLine(Htmlresult);
                }
                catch (Exception x) { Console.WriteLine("Errror in comms {0}", x); }
            }
            //got a response from te server
            if (Htmlresult != null)
            {
                //result is ok or err
                if (Htmlresult.Equals("ok") || Htmlresult.Equals("true") || Htmlresult.Equals("okay"))
                {
                    Console.WriteLine("ok response from server");
                    return true;
                }

                else if (Htmlresult.Equals("err"))
                {
                    Console.WriteLine("err response from server --app not genuine");
                    return true;
                }
                else
                {
                    Console.WriteLine("unknown response");
                    return false;
                }
            }
            else //did not get responcse from server
            {
                Console.WriteLine("App did not get response");
                return false;
            }
        }
        #endregion

    }
}
