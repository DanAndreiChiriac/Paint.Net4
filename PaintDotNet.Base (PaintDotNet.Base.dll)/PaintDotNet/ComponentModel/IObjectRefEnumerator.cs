namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IObjectRefEnumerator : IObjectRef, IDisposable, IIsDisposed, IEnumerator<IObjectRef>, IEnumerator, ICloneable
    {
    }
}

