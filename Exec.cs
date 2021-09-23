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

    }

}