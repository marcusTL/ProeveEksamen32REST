using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPReciever
{
    class UDPReciever
    {
        public void Start()
        {
            UdpClient client = new UdpClient(11001);

            Byte[] buffer;

            while (true)
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
                buffer = client.Receive(ref endPoint);

                string receiveData = Encoding.UTF8.GetString(buffer);


                Console.WriteLine($"IP: {endPoint.Address}, Port: {endPoint.Port}");

                Console.WriteLine("Message recieved: " + receiveData);
            }
        }
    }
}
