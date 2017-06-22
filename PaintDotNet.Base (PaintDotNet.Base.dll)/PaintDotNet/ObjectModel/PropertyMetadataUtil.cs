namespace PaintDotNet.ObjectModel
{
    using System;
    using System.Windows;

    public static class PropertyMetadataUtil
    {
        private static readonly PropertyMetadata nullInstance = new PropertyMetadata(null);

        public static PropertyMetadata Null =>
            nullInstance;
    }
}

