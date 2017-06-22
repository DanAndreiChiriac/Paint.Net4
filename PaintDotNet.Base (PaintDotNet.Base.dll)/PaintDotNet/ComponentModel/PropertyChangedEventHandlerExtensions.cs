namespace PaintDotNet.ComponentModel
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public static class PropertyChangedEventHandlerExtensions
    {
        public static void Raise(this PropertyChangedEventHandler handler, object sender, PropertyChangedEventArgs e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public static void Raise(this PropertyChangedEventHandler handler, object sender, string propertyName)
        {
            if (handler != null)
            {
                handler(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

