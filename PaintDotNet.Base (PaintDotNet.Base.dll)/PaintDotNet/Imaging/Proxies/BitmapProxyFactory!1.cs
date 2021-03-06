﻿namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    internal sealed class BitmapProxyFactory<TPixel> : ObjectRefProxyFactory where TPixel: struct, INaturalPixelInfo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            new BitmapProxy<TPixel>((IBitmap<TPixel>) objectRef, proxyOptions);
    }
}

