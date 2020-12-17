using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ModelLib;

namespace UDPSender
{
    class UDPSender
    {
        public void Start()
        {
            UdpClient client = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 11001);

            Measurement m1 = new Measurement();
            Random rnd = new Random();

            m1.Id = rnd.Next(1, 10);
            m1.Pressure = rnd.Next(1, 100);
            m1.Humidity = rnd.Next(1, 100);
            m1.Temperature = rnd.Next(1, 100);
            m1.Timestamp = default;

            string sendStr = m1.ToString();
            Console.WriteLine(sendStr);

            Byte[] Buffer = Encoding.UTF8.GetBytes(sendStr.ToCharArray());
            client.Send(Buffer, Buffer.Length, endPoint);

            ////receiving the return message
            //Byte[] rebuffer = client.Receive(ref endPoint);

            //string receiveData = Encoding.UTF8.GetString(rebuffer);

            //Console.WriteLine(receiveData);
        }
    }
}
