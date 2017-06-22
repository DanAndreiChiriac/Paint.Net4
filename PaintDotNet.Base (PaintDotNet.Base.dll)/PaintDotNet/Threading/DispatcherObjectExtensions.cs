namespace PaintDotNet.Threading
{
    using System;
    using System.Runtime.CompilerServices;

    public static class DispatcherObjectExtensions
    {
        public static bool CheckAccess<TDispatcherObject>(this TDispatcherObject theObject) where TDispatcherObject: IDispatcherObject => 
            theObject.Dispatcher.CheckAccess();

        public static void VerifyAccess<TDispatcherObject>(this TDispatcherObject theObject) where TDispatcherObject: IDispatcherObject
        {
            theObject.Dispatcher.VerifyAccess();
        }
    }
}

