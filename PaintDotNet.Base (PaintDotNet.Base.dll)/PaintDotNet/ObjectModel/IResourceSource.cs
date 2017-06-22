namespace PaintDotNet.ObjectModel
{
    using PaintDotNet.ComponentModel;
    using System;

    public interface IResourceSource
    {
        IObjectRef CreateResource(IServiceProvider services);

        bool IsResource { get; }

        PaintDotNet.ObjectModel.ResourceID ResourceID { get; }

        long Version { get; }
    }
}

