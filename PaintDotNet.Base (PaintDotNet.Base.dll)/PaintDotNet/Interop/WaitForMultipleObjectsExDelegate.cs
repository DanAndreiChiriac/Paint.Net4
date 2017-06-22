namespace PaintDotNet.Interop
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate int WaitForMultipleObjectsExDelegate(IntPtr[] handles, bool waitAll, int millisecondsTimeout, bool alertable);
}

