namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct CastOrRefHolder<T> : IObjectRefHolder<T>, IObjectRefHolder, IDisposable, IIsDisposed where T: class, IObjectRef
    {
        private T objectRefT;
        private bool needsDisposal;
        public bool HasRef =>
            (this.objectRefT > null);
        public T ObjectRef =>
            this.objectRefT;
        public bool IsDisposed =>
            (this.objectRefT == null);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal CastOrRefHolder(T objectRefT, bool needsDisposal)
        {
            this.needsDisposal = needsDisposal;
            this.objectRefT = Validate.IsNotNull<T>(objectRefT, "objectRefT");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            if (this.needsDisposal)
            {
                DisposableUtil.Free<T>(ref this.objectRefT);
            }
            else
            {
                this.objectRefT = default(T);
            }
        }

        IObjectRef IObjectRefHolder.ObjectRef =>
            this.ObjectRef;
    }
}

