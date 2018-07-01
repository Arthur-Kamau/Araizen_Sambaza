using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sambaza
{
    /// <summary>
    /// Server for interacting with other araizen samabaza application
    /// /// Interaction logic for Ui_HostspotConnect.xaml
    /// use local ip as domain name
    /// run servers on 
    ///         * http server on 1800
    ///         * udp server on 1801
    ///         * tcp server on 1802
    /// 
    /// </summary>
    #region App_Server
    class App_Server
    {

    }
    #endregion
  

  

    /// <summary>
    /// the http server class
    ///   responsible for letting user stream a movie as though online
    ///   other users on the network download the  app
    /// </summary>
    #region clas http
    class HttpServer
    {

        public static HttpListener listener = new HttpListener();
        int port = 1800;
       // int port = 8080;
        String MyIp;
        Socket serverSocket = null;
        int backlog = 4;
        List<Socket> client = new List<Socket>();
        byte[] Buffer = new byte[1024];


        public HttpServer(String IpAddress)
        {
            this.MyIp = IpAddress;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }


        //start http server
        public void Start()
        {
            if (string.IsNullOrEmpty(MyIp))
            {
                App_Hotspot_Details Hotspot_Detals = new App_Hotspot_Details();
                HotSpotDetails details = Hotspot_Detals.Self_mac_Ip();
                MyIp = details.SelfIp;

            }

            System.Console.WriteLine("http://localhost:{0}/", port);
            System.Console.WriteLine("http://{0}:{1}/", MyIp, port);

            String Localformart = String.Format("http://localhost:{0}/", port);
            String Gloabalformart = String.Format("http://{0}:{1}/", MyIp, port);

            //add prefix
            listener.Prefixes.Add(Localformart);
            listener.Prefixes.Add(Gloabalformart);

            if (listener.IsListening)
            { listener.Stop(); }

            listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous; 

            listener.Start();

            if (listener.IsListening)
            { Console.WriteLine("Http serever listening"); }
            else { Console.WriteLine("Http serever not listening ?"); }

            int requestCounter = 0;

            while (listener.IsListening)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerResponse response = context.Response;

                    requestCounter++;
                    Console.WriteLine("Request counter {0}", requestCounter);
                    //webpage requested by browser
                    String WebPage = Directory.GetCurrentDirectory() + context.Request.Url.LocalPath; //+ "webpage\\"; // String.Empty;

                    Console.WriteLine("Path to wbpage = {0} \n",WebPage);
                    if (string.IsNullOrEmpty(WebPage))
                    {
                        WebPage = "index.html";
                    }

                   // TextReader tr = new StreamReader(WebPage);
                    FileStream tr = new FileStream(WebPage,FileMode.Open,FileAccess.ReadWrite);
                    // String message = tr.ReadToEnd();

                 //   String message;
                    byte data;

                    using(BinaryReader rds=new BinaryReader(tr))
                    {
                        var message = rds.ReadBytes(Convert.ToInt32(tr.Length));
                        //transform into byte array
                       // byte[] buffer = Encoding.UTF8.GetBytes(message);

                        //set up the message lent
                        response.ContentLength64 = message.Length;
                        //create a stream to send the message
                        Stream st = response.OutputStream;
                        st.Write(message, 0, message.Length);
                        //close the connection
                        context.Response.Close();
                    }
                    //using (StreamReader rd = new StreamReader(tr))
                    //{
                    //    var message = rd.ReadToEnd();


                    //    //transform into byte array
                    //    byte[] buffer = Encoding.UTF8.GetBytes(message);

                    //    //set up the message lent
                    //    response.ContentLength64 = buffer.Length;
                    //    //create a stream to send the message
                    //    Stream st = response.OutputStream;
                    //    st.Write(buffer, 0, buffer.Length);
                    //    //close the connection
                    //    context.Response.Close();
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in Http server is listening");
                }
            }


            //test code
            serverSocket.Bind(new IPEndPoint(IPAddress.Any,port));
            serverSocket.Listen(backlog);
            Accept();


        }
        public void Accept()
        {
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);

        }

        private void AcceptCallback(IAsyncResult ar)
        {
            Ui_HostspotStart.Addlog("Message ");
          Socket Aclient =  serverSocket.EndAccept(ar);
            client.Add(Aclient);
            Aclient.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None,new AsyncCallback(ReceiveCallBack),Aclient);
            Accept();
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            Socket Aclient = (Socket)ar.AsyncState;
            int size = Aclient.EndReceive(ar);
            Byte[] ReceiveBytes = new byte[size];
            Array.Copy(Buffer, ReceiveBytes, size);
            String data = Encoding.ASCII.GetString(ReceiveBytes);
            Ui_HostspotStart.Addlog(data);

            String Response = "<h1>Helo from server</h1>";
            Byte[] resbytes = Encoding.ASCII.GetBytes(Response);
            Aclient.BeginSend(resbytes, 0, resbytes.Length, SocketFlags.None, new AsyncCallback(SendCallBack), Aclient);


        }

        private void SendCallBack(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            client.Shutdown(SocketShutdown.Send);
          
        }

        public void Stop()
        {
            if (listener.IsListening)
            { listener.Stop(); }
        }


    }
    #endregion

    /// <summary>
    /// 
    /// udp server allow 
    /// streaming in inbuilt media player
    /// send /receive meta data
    /// 
    /// </summary>
    #region class udp server
    class UdpServer
    {
        private const int port = 1801;

        /// <summary>
        /// start broadasting and receiving
        /// </summary>
        #region Start
        public void Start()
        {
            var broadcast = new Task(() =>
            {
                while (true)
                {
                    StartBroadcasting();
                    Thread.Sleep(15000);
                }
            });
            var receiver  = new Task(() =>
            {
                while (true)
                {
                    StartReceiver();
                    Thread.Sleep(15000);
                }
            });

            Console.WriteLine("udp started broadcasting ");
        }
        #endregion 

        /// <summary>
        /// Broadcast data :
        ///     1)list of connected client
        ///     2)public items
        ///     3)
        /// </summary>
        #region StartBroadcasting
        private void StartBroadcasting()
        {
            
            //udp send status
            string udpstr = "";
            App_Hotspot_Details HotspotDetails = new App_Hotspot_Details();
            List<HotspotGuest> HotspotList = HotspotDetails.Mac_Ip_connected_devices();

            foreach (var item in HotspotList)
            {
                UdpClient udpClient = new UdpClient();
                udpClient.Connect(item.GuestIp, port);
                Byte[] senddata = Encoding.ASCII.GetBytes(udpstr);
                udpClient.Send(senddata, senddata.Length);
            }
        }
        #endregion

        /// <summary>
        /// Receive from other clients:
        ///     1)list of connected client
        ///     2)public items
        ///     3)
        /// </summary>
        #region StartReceiver
        private void StartReceiver()
        {

        }
        #endregion
    }
    #endregion

    /// <summary>
    /// tcp server 
    /// responsible for sending the file 
    /// 
    /// </summary>
    #region tcp server
    class TcpServer
    {

    }
    #endregion



}
