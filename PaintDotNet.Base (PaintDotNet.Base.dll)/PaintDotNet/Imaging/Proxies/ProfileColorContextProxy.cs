namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class ProfileColorContextProxy : ObjectRefProxy<IProfileColorContext>, IProfileColorContext, IColorContext, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ProfileColorContextProxy(IProfileColorContext objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] GetProfileBytes() => 
            base.innerRefT.GetProfileBytes();

        public ColorContextType Type =>
            base.innerRefT.Type;
    }
}

