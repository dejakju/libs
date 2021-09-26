using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Kju
{
    class Run
    {

        static void Main(string[] args)
        {
            Console.WriteLine($"{DOS.GetEnv("username")}@{DOS.GetEnv("computername")} running on {DOS.GetEnv("processor_identifier")} (OS: {DOS.GetEnv("os")})");



            SingleLL<string> ll = new SingleLL<string>();
            ll.setIdentifier("StringNode");

            Console.WriteLine($"Length of {ll.getIdentifier()}: {ll.length()} nodes");

            ll.add(1, "Hooray");
            ll.add(1, "Second");
            ll.add(1, "Hooray");
            ll.add(1, "Hooray");
            ll.add(1, "Hooray");

            Console.WriteLine($"Length of {ll.getIdentifier()}: {ll.length()} nodes");

            List<string> nodes = ll.listAll();
            foreach (var node in nodes)
            {
                Console.WriteLine($"{node}");
            }


            // Console.WriteLine($"{}");
            // Console.WriteLine($"{}");
            // Console.WriteLine($"{}");
            // Console.WriteLine($"{}");
            // Console.WriteLine($"{}");
            // Console.WriteLine($"{}");


            // string[] drives = Environment.GetLogicalDrives();
            // foreach (var drive in drives)
            // {
            //     Console.WriteLine($"{drive}");
            // }

            // Dictionary<int, ulong> m = new Dictionary<int, ulong>();
            // for (int i = 0; i < 80; i++)
            // {
            //     Console.WriteLine($"The #{i}-th fib number is = {Math.NthFibonacci(i, m)}");
            // }


            // Game myGame = new Game();
            // myGame.Start();



        }

    }
}
