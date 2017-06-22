namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class BitmapEncoderProxy : ObjectRefProxy<IBitmapEncoder>, IBitmapEncoder, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitmapEncoderProxy(IBitmapEncoder objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Commit()
        {
            base.innerRefT.Commit();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapFrameEncode CreateNewFrame(IEnumerable<KeyValuePair<string, object>> encoderOptions) => 
            base.innerRefT.CreateNewFrame(encoderOptions);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dictionary<string, object> GetFrameEncoderOptions() => 
            base.innerRefT.GetFrameEncoderOptions();

        public IEnumerable<IColorContext> ColorContexts
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.ColorContexts = value;
            }
        }

        public ImagingContainerFormat ContainerFormat =>
            base.innerRefT.ContainerFormat;

        public IBitmapEncoderInfo EncoderInfo =>
            base.innerRefT.EncoderInfo;

        public IMetadataQueryWriter MetadataQueryWriter =>
            base.innerRefT.MetadataQueryWriter;

        public IPalette Palette
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Palette = value;
            }
        }

        public IBitmapSource Preview
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Preview = value;
            }
        }

        public IBitmapSource Thumbnail
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Thumbnail = value;
            }
        }
    }
}

