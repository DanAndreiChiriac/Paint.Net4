namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class MetadataQueryWriterProxy : ObjectRefProxy<IMetadataQueryWriter>, IMetadataQueryWriter, IMetadataQueryReader, IImagingObject, IObjectRef, IDisposable, IIsDisposed, IEnumerable<string>, IEnumerable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MetadataQueryWriterProxy(IMetadataQueryWriter objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerator<string> GetEnumerator() => 
            base.innerRefT.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetMetadataByName(string name) => 
            base.innerRefT.GetMetadataByName(name);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual IEnumerator OnExplicitIEnumerableGetEnumerator() => 
            base.innerRefT.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemoveMetadataByName(string name)
        {
            base.innerRefT.RemoveMetadataByName(name);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetMetadataByName(string name, object value)
        {
            base.innerRefT.SetMetadataByName(name, value);
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.OnExplicitIEnumerableGetEnumerator();

        public ImagingContainerFormat ContainerFormat =>
            base.innerRefT.ContainerFormat;

        public string Location =>
            base.innerRefT.Location;
    }
}

