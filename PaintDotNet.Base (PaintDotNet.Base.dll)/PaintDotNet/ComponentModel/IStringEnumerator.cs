namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IStringEnumerator : IObjectRef, IDisposable, IIsDisposed, IEnumerator<string>, IEnumerator, ICloneable
    {
    }
}

