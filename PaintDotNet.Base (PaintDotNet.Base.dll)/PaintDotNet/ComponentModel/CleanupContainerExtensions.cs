namespace PaintDotNet.ComponentModel
{
    using System;
    using System.Runtime.CompilerServices;

    public static class CleanupContainerExtensions
    {
        public static void AddCleanupRef(this ICleanupContainer container, IObjectRef objectRef)
        {
            container.AddCleanupObject(objectRef.CreateRef());
        }
    }
}

