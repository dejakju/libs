using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Kju
{
    public class ExecException : System.Exception
    {
        public ExecException() { }
        public ExecException(string message) : base(message) { }
        public ExecException(string message, System.Exception inner) : base(message, inner) { }
        protected ExecException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public static class Exec
    {
        public static Stopwatch Measure(Action a)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            a();
            stopwatch.Stop();
            return stopwatch;
        }

        public static void GetEnvArc()
        {
            IDictionary envarc = Environment.GetEnvironmentVariables();
            var counter = 0;
            envarc.Keys.Cast<string>().ToList().ForEach(key => {
                var val = envarc.Values.Cast<string>().ToArray();
                Console.WriteLine($"Key = {key} | Value = {val[counter++]}");
            });

            Console.WriteLine($"-----------------------------------------------");
            Console.WriteLine($"{envarc.Count} keys found");
        }

        public static string GetEnv(string name)
        {
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
            {
                string s = de.Key.ToString().ToUpper();
                if (s == name.ToUpper())
                    return (string)de.Value;
            }
            return string.Empty;
        }
    }

}