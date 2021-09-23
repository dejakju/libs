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
