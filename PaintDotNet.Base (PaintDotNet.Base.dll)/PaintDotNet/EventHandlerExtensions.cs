namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class EventHandlerExtensions
    {
        public static void Raise(this EventHandler handler, object sender)
        {
            handler.Raise(sender, EventArgs.Empty);
        }

        public static void Raise(this EventHandler handler, object sender, EventArgs e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public static void Raise<TEventArgs>(this EventHandler<TEventArgs> handler, object sender, TEventArgs e) where TEventArgs: EventArgs
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public static void RaisePooled<TDerivedArgs, TValue1>(this EventHandler<TDerivedArgs> handler, object sender, TValue1 value1) where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1>, new()
        {
            if (handler != null)
            {
                TDerivedArgs e = PooledEventArgs<TDerivedArgs, TValue1>.Get(value1);
                try
                {
                    handler(sender, e);
                }
                finally
                {
                    e.Return();
                }
            }
        }

        public static void RaisePooled<TDerivedArgs, TValue1, TValue2>(this EventHandler<TDerivedArgs> handler, object sender, TValue1 value1, TValue2 value2) where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1, TValue2>, new()
        {
            if (handler != null)
            {
                TDerivedArgs e = PooledEventArgs<TDerivedArgs, TValue1, TValue2>.Get(value1, value2);
                try
                {
                    handler(sender, e);
                }
                finally
                {
                    e.Return();
                }
            }
        }

        public static void RaisePooled<TDerivedArgs, TValue1, TValue2, TValue3>(this EventHandler<TDerivedArgs> handler, object sender, TValue1 value1, TValue2 value2, TValue3 value3) where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3>, new()
        {
            if (handler != null)
            {
                TDerivedArgs e = PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3>.Get(value1, value2, value3);
                try
                {
                    handler(sender, e);
                }
                finally
                {
                    e.Return();
                }
            }
        }

        public static void RaisePooled<TDerivedArgs, TValue1, TValue2, TValue3, TValue4>(this EventHandler<TDerivedArgs> handler, object sender, TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4) where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3, TValue4>, new()
        {
            if (handler != null)
            {
                TDerivedArgs e = PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3, TValue4>.Get(value1, value2, value3, value4);
                try
                {
                    handler(sender, e);
                }
                finally
                {
                    e.Return();
                }
            }
        }

        public static void RaisePooled<TDerivedArgs, TValue1, TValue2, TValue3, TValue4, TValue5>(this EventHandler<TDerivedArgs> handler, object sender, TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5) where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3, TValue4, TValue5>, new()
        {
            if (handler != null)
            {
                TDerivedArgs e = PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3, TValue4, TValue5>.Get(value1, value2, value3, value4, value5);
                try
                {
                    handler(sender, e);
                }
                finally
                {
                    e.Return();
                }
            }
        }
    }
}

