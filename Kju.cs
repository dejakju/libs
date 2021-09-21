using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Kju
{
    public class CoreException : System.Exception
    {
        public CoreException() { }
        public CoreException(string message) : base(message) { }
        public CoreException(string message, System.Exception inner) : base(message, inner) { }
        protected CoreException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public static class Core
    {
        public static IEnumerable<T> FilterBy<T>(this IEnumerable<T> items, Func<T, bool> f)
        {
            foreach (var item in items)
            {
                if (f(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> ThenFilterBy<T>(this IEnumerable<T> items, Func<T, bool> f)
        {
            foreach (var item in items)
            {
                if (f(item))
                {
                    yield return item;
                }
            }
        }
        public static Stopwatch Measure(this Action a)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            a();
            stopwatch.Stop();
            return stopwatch;
        }


        // Console output only !!!
        public static void MeasureRuntime(this Action a, string name)
        {
            Stopwatch stopwatch = new Stopwatch();
            System.Console.WriteLine($"----------------------------------------------------------------------------");
            System.Console.WriteLine($"MEASURING '{name}' ...");
            System.Console.WriteLine($"+ ...");
            stopwatch.Start();
            a();
            stopwatch.Stop();
            System.Console.WriteLine($"... +");
            System.Console.WriteLine($"MEASURED '{name}' EXECUTION TIME = {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed} s)");
            System.Console.WriteLine($"----------------------------------------------------------------------------");
        }

        // !!! This belongs in a separate class (as it deals with the filesystem) !!!
        public static IEnumerable<T> Examine<T>(this IEnumerable<T> items, Func<T, bool> f)
        {
            string[] drives = Environment.GetLogicalDrives();
            foreach (var drive in drives)
            {
                System.Console.WriteLine($"{drive}");

                foreach (var item in items)
                {
                    if (f(item))
                    {
                        yield return item;
                    }
                }

            }

        }
    }
}
