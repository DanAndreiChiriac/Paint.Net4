namespace PaintDotNet
{
    using System;
    using System.Collections.Generic;

    public static class BoxPolicy
    {
        public sealed class Boolean : IBoxPolicy<bool>
        {
            private static readonly BoxPolicy.Boolean instance = new BoxPolicy.Boolean();

            private Boolean()
            {
            }

            public object BoxValue(bool value) => 
                BooleanUtil.GetBoxed(value);

            public static BoxPolicy.Boolean Instance =>
                instance;
        }

        public sealed class Default<TValue> : IBoxPolicy<TValue>
        {
            private static readonly BoxPolicy.Default<TValue> instance;

            static Default()
            {
                BoxPolicy.Default<TValue>.instance = new BoxPolicy.Default<TValue>();
            }

            private Default()
            {
            }

            public object BoxValue(TValue value) => 
                value;

            public static BoxPolicy.Default<TValue> Instance =>
                BoxPolicy.Default<TValue>.instance;
        }

        public sealed class Double : IBoxPolicy<double>
        {
            private static readonly BoxPolicy.Double instance = new BoxPolicy.Double();

            private Double()
            {
            }

            public object BoxValue(double value) => 
                DoubleUtil.GetBoxed(value);

            public static BoxPolicy.Double Instance =>
                instance;
        }

        public sealed class Enum<TEnum> : IBoxPolicy<TEnum>
        {
            private static readonly SortedList<TEnum, object> boxCache;
            private static readonly object boxCacheSync;
            private static readonly BoxPolicy.Enum<TEnum> instance;

            static Enum()
            {
                BoxPolicy.Enum<TEnum>.instance = new BoxPolicy.Enum<TEnum>();
                BoxPolicy.Enum<TEnum>.boxCacheSync = new object();
                BoxPolicy.Enum<TEnum>.boxCache = new SortedList<TEnum, object>();
            }

            private Enum()
            {
            }

            public object BoxValue(TEnum value) => 
                BoxPolicy.Enum<TEnum>.GetCachedBoxValue(value);

            private static object GetCachedBoxValue(TEnum value)
            {
                object boxCacheSync = BoxPolicy.Enum<TEnum>.boxCacheSync;
                lock (boxCacheSync)
                {
                    object obj3;
                    if (!BoxPolicy.Enum<TEnum>.boxCache.TryGetValue(value, out obj3))
                    {
                        obj3 = value;
                        BoxPolicy.Enum<TEnum>.boxCache[value] = obj3;
                    }
                    return obj3;
                }
            }

            public static BoxPolicy.Enum<TEnum> Instance =>
                BoxPolicy.Enum<TEnum>.instance;
        }

        public sealed class Int32 : IBoxPolicy<int>
        {
            private static readonly BoxPolicy.Int32 instance = new BoxPolicy.Int32();

            private Int32()
            {
            }

            public object BoxValue(int value) => 
                Int32Util.GetBoxed(value);

            public static BoxPolicy.Int32 Instance =>
                instance;
        }

        public sealed class Int64 : IBoxPolicy<long>
        {
            private static readonly BoxPolicy.Int64 instance = new BoxPolicy.Int64();

            private Int64()
            {
            }

            public object BoxValue(long value) => 
                Int64Util.GetBoxed(value);

            public static BoxPolicy.Int64 Instance =>
                instance;
        }
    }
}

