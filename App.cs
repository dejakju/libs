﻿using System;
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





        }

    }
}
