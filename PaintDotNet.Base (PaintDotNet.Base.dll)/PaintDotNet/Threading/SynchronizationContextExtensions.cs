namespace PaintDotNet.Threading
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public static class SynchronizationContextExtensions
    {
        public static void Post(this SynchronizationContext syncContext, Action action)
        {
            Validate.IsNotNull<Action>(action, "action");
            syncContext.Post(_ => action(), null);
        }

        public static void Post(this SynchronizationContext syncContext, SendOrPostCallback callback)
        {
            Validate.IsNotNull<SendOrPostCallback>(callback, "callback");
            syncContext.Post(callback, null);
        }

        public static void Post<T>(this SynchronizationContext syncContext, Action<T> action, T value)
        {
            Validate.IsNotNull<Action<T>>(action, "action");
            object state = value;
            syncContext.Post(context => action((T) context), state);
        }

        public static void Send(this SynchronizationContext syncContext, Action action)
        {
            Validate.IsNotNull<Action>(action, "action");
            syncContext.Send(_ => action(), null);
        }

        public static void Send(this SynchronizationContext syncContext, SendOrPostCallback callback)
        {
            Validate.IsNotNull<SendOrPostCallback>(callback, "callback");
            syncContext.Send(callback, null);
        }

        public static void Send<T>(this SynchronizationContext syncContext, Action<T> action, T value)
        {
            Validate.IsNotNull<Action<T>>(action, "action");
            object state = value;
            syncContext.Send(context => action((T) context), state);
        }
    }
}

