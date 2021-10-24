using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace libs
{
    class Run
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{DOS.GetEnv("username")}@{DOS.GetEnv("computername")} running on {DOS.GetEnv("processor_identifier")} (OS: {DOS.GetEnv("os")})");
            Console.ResetColor();

            try
            {
                DirectoryInfo di =  DOS.CreateDir("bin\\debug\\net5.0\\libs.exe");
            }
            catch (DOSException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.ToString()}");
                Console.ResetColor();
            }


            // Dictionary<int, ulong> m = new Dictionary<int, ulong>();
            // for (int i = 0; i < 80; i++)
            // {
            //     Console.WriteLine($"The #{i}-th fib number is = {Math.NthFibonacci(i, m)}");
            // }


        }

    }
}
