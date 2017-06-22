namespace PaintDotNet.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct EmptyEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
    {
        public T Current
        {
            get
            {
                throw new InvalidOperationException();
            }
        }
        public void Dispose()
        {
        }

        object IEnumerator.Current =>
            this.Current;
        public bool MoveNext() => 
            false;

        public void Reset()
        {
        }
    }
}

