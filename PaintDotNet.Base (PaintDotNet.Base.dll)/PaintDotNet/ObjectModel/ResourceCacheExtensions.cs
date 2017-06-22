namespace PaintDotNet.ObjectModel
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ResourceCacheExtensions
    {
        public static TResource GetCachedOrCreateResource<TResource>(this IResourceCache resourceCache, IResourceSource<TResource> resourceSource) where TResource: class, IObjectRef => 
            ((TResource) resourceCache.GetCachedOrCreateResource(resourceSource, typeof(TResource)));

        public static TResource SafeGetCachedOrCreateResource<TResource>(this IResourceCache resourceCache, IResourceSource<TResource> resourceSource) where TResource: class, IObjectRef
        {
            if (resourceSource == null)
            {
                return default(TResource);
            }
            return (TResource) resourceCache.GetCachedOrCreateResource(resourceSource, typeof(TResource));
        }
    }
}

