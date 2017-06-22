namespace PaintDotNet
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class StackTraceExtensions
    {
        private static readonly string[] lineSplitStrings = new string[] { "\r\n" };

        public static string[] GetLines(this StackTrace stackTrace) => 
            stackTrace.ToString().Split(lineSplitStrings, StringSplitOptions.RemoveEmptyEntries);
    }
}

