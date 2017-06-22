namespace PaintDotNet
{
    using System;

    public static class PooledEventArgs
    {
        public static TDerivedArgs Get<TDerivedArgs, TValue1>(TValue1 value1) where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1>, new() => 
            PooledEventArgs<TDerivedArgs, TValue1>.Get(value1);

        public static TDerivedArgs Get<TDerivedArgs, TValue1, TValue2>(TValue1 value1, TValue2 value2) where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1, TValue2>, new() => 
            PooledEventArgs<TDerivedArgs, TValue1, TValue2>.Get(value1, value2);

        public static TDerivedArgs Get<TDerivedArgs, TValue1, TValue2, TValue3>(TValue1 value1, TValue2 value2, TValue3 value3) where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3>, new() => 
            PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3>.Get(value1, value2, value3);

        public static TDerivedArgs Get<TDerivedArgs, TValue1, TValue2, TValue3, TValue4>(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4) where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3, TValue4>, new() => 
            PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3, TValue4>.Get(value1, value2, value3, value4);

        public static TDerivedArgs Get<TDerivedArgs, TValue1, TValue2, TValue3, TValue4, TValue5>(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5) where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3, TValue4, TValue5>, new() => 
            PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3, TValue4, TValue5>.Get(value1, value2, value3, value4, value5);
    }
}

