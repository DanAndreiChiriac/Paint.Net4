namespace PaintDotNet.Diagnostics
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    public static class Profiling
    {
        [Conditional("DEBUG")]
        public static void Enter()
        {
        }

        [Conditional("DEBUG")]
        public static void Enter(string message)
        {
        }

        [Conditional("DEBUG")]
        private static void Enter2(string message)
        {
        }

        [Conditional("DEBUG")]
        public static void Leave()
        {
        }

        [Conditional("DEBUG")]
        public static void Ping()
        {
        }

        [Conditional("DEBUG")]
        public static void Ping(string message)
        {
        }

        [Conditional("DEBUG")]
        public static void Ping(string message, int callerCount)
        {
        }

        [Conditional("DEBUG")]
        public static void PingFormat(string messageFormat, params object[] args)
        {
        }

        public static EnterScope UseEnter() => 
            EnterScope.Create();

        public static EnterScope UseEnter(string message) => 
            EnterScope.Create();

        private static void WriteLine(string message)
        {
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EnterScope : IDisposable
        {
            private bool isEntered;
            internal static Profiling.EnterScope Create() => 
                new Profiling.EnterScope(true);

            private EnterScope(bool isEntered)
            {
                this.isEntered = isEntered;
            }

            public void Dispose()
            {
                if (this.isEntered)
                {
                    this.isEntered = false;
                }
            }
        }
    }
}

