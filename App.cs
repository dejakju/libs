using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace libs
{
    class App
    {

        static void Main(string[] args)
        {
            try
            {
                Test.Run_Fibonacci_Test();
            }
            catch (DOSException e)
            {
                DOS.WriteLine("Aborted. Code = " + e.Message);
            }
        }

    }
}
