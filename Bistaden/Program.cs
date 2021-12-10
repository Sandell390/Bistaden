using System;
using System.Threading;

namespace Bistaden
{
    class Program
    {
        static Beehive beehive = new Beehive(1000);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Thread printerThread = new Thread(Printer);
            printerThread.Name = "Printer";
            printerThread.Start();
        }

        static void Printer()
        {
            Console.Clear();
            Console.WriteLine($"Flower: {beehive.Flowers}");
            Console.WriteLine($"Honning Bottles: {beehive.HonningBottles}");

            Thread.Sleep(100);
        }
    }
}
