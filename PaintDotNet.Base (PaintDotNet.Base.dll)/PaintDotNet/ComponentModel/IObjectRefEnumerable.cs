namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using PaintDotNet.Interop;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [NativeInterfaceID("00000100-0000-0000-c000-000000000046")]
    public interface IObjectRefEnumerable : IObjectRef, IDisposable, IIsDisposed, IEnumerable<IObjectRef>, IEnumerable
    {
    }
}

