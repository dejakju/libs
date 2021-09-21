using System;
using System.Collections;
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


            Console.WriteLine(Exec.GetEnv("computername"));
            Console.WriteLine(Exec.GetEnv("username"));



        }

    }
}
