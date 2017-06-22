namespace PaintDotNet.Diagnostics
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class StopwatchExtensions
    {
        public static TimeSpan GetTimeSpan(this Stopwatch stopwatch) => 
            TimeSpan.FromTicks(stopwatch.ElapsedTicks);
    }
}

