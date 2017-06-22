namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IStringEnumerable : IObjectRef, IDisposable, IIsDisposed, IEnumerable<string>, IEnumerable
    {
    }
}

