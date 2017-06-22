namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IMetadataQueryReader : IImagingObject, IObjectRef, IDisposable, IIsDisposed, IEnumerable<string>, IEnumerable
    {
        object GetMetadataByName(string name);

        ImagingContainerFormat ContainerFormat { get; }

        string Location { get; }
    }
}

