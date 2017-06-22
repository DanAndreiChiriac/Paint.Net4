namespace PaintDotNet
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class HandledEventHandlerExtensions
    {
        public static void Raise(this HandledEventHandler handler, object sender, HandledEventArgs e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public static void Raise(this HandledEventHandler handler, object sender, out bool handled, bool defaultHandledValue = false)
        {
            handled = defaultHandledValue;
            if (handler != null)
            {
                HandledEventArgs e = new HandledEventArgs(handled);
                handler(sender, e);
                handled = e.Handled;
            }
        }
    }
}

