using System;

namespace UDPReciever
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPReciever worker = new UDPReciever();
            worker.Start();
            Console.ReadLine();
        }
    }
}
