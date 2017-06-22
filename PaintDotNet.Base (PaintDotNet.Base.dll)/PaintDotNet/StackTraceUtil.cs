namespace PaintDotNet
{
    using System;
    using System.Diagnostics;

    public static class StackTraceUtil
    {
        public static StackTrace Capture() => 
            new StackTrace2();

        private sealed class StackTrace2 : StackTrace
        {
            private string[] callStack;

            public StackTrace2()
            {
                this.callStack = this.GetLines();
            }
        }
    }
}

