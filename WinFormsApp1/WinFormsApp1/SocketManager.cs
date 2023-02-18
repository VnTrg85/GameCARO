using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class SocketManager
    {
        #region Client

        Socket Client;

        public bool Connect()
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP), PORT);
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                Client.Connect(ipe);
                return true;
            }
            catch
            {
                return false;
            }
        }
        

        #endregion

        #region Server
        Socket Server;
        public void CreateServer()
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP), PORT);
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server.Bind(ipe);
            Server.Listen(10);
            Thread acceptClient = new Thread(() =>
            {
                Client = Server.Accept();
            });
            acceptClient.IsBackground =true;
            acceptClient.Start();
        }
        #endregion



        #region Both

        public string IP = "123.4.5.6";
        int PORT = 9999;
        int BUFFER = 1024;

        public Socket Client1 { get => Client; set => Client=value; }

        public bool Send(object data)
        {
            byte[] dataSend = SerializeData(data);

            return sendData(Client,dataSend);

        }

        public object Receive()
        {
            byte[] receData = new byte[BUFFER];
            bool isOk = recieveData(Client, receData);
            return DeserializeData(receData);         
        }
        

        public bool recieveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }

        public bool sendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }


        //Nen mot doi tuong object thanh mang byte[]
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }

        /// <summary>
        /// Giải nén mảng byte[] thành đối tượng object
        /// </summary>
        /// <param name="theByteArray"></param>
        /// <returns></returns>
        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        /// <summary>
        /// Lấy ra IP V4 của card mạng đang dùng
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }


        #endregion
    }
}
