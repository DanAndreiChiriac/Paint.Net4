namespace PaintDotNet.ObjectModel
{
    using PaintDotNet.ComponentModel;
    using System;

    public interface IResourceCache
    {
        IObjectRef GetCachedOrCreateResource(IResourceSource resourceSource, Type interfaceType);
        IObjectRef TryGetCachedResource(IResourceSource resourceSource, Type interfaceType);

        bool SupportsResourceCaching { get; }
    }
}

