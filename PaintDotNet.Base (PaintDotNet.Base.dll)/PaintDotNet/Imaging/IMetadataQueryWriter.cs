namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IMetadataQueryWriter : IMetadataQueryReader, IImagingObject, IObjectRef, IDisposable, IIsDisposed, IEnumerable<string>, IEnumerable
    {
        void RemoveMetadataByName(string name);
        void SetMetadataByName(string name, object value);
    }
}

