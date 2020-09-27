using System;
using System.Net;
using System.Net.Sockets;

namespace NMapNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TcpClient tcp = new TcpClient();
            IPAddress addr = IPAddress.Parse("69.59.196.211");
            IPHostEntry entry = Dns.GetHostEntry(addr);
            Console.WriteLine(entry.HostName); // Prints "stackoverflow.com"
        }
    }
}
