namespace PaintDotNet
{
    using System;
    using System.Collections.Concurrent;
    using System.Runtime.CompilerServices;

    public static class EnumUtil
    {
        public static object GetBoxed<T>(T value) where T: struct, IComparable, IFormattable, IConvertible
        {
            if (!value.GetType().IsEnum)
            {
                ExceptionUtil.ThrowArgumentException();
            }
            return BoxingHelper<T>.Get(value);
        }

        public static bool IsFlagDefined(Type enumType, object value)
        {
            if (!IsFlagsType(enumType))
            {
                throw new ArgumentException("enumType is not a [Flags] enumeration");
            }
            if (Enum.IsDefined(enumType, value))
            {
                return true;
            }
            Type underlyingType = Enum.GetUnderlyingType(enumType);
            if (underlyingType == typeof(int))
            {
                return IsFlagDefinedInt32(enumType, (int) value);
            }
            if (underlyingType != typeof(long))
            {
                throw new ArgumentException($"enumType's underlying type, {underlyingType.Name}, isn't supported");
            }
            return IsFlagDefinedInt64(enumType, (long) value);
        }

        private static bool IsFlagDefinedInt32(Type enumType, int value)
        {
            Array values = Enum.GetValues(enumType);
            int num = 0;
            for (int i = 0; i < values.Length; i++)
            {
                num |= (int) values.GetValue(i);
            }
            return ((value & num) > 0);
        }

        private static bool IsFlagDefinedInt64(Type enumType, long value)
        {
            Array values = Enum.GetValues(enumType);
            long num = 0L;
            for (int i = 0; i < values.Length; i++)
            {
                num |= (long) values.GetValue(i);
            }
            return ((value & num) > 0L);
        }

        public static bool IsFlagsType(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("enumType.IsEnum is false");
            }
            return (enumType.GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0);
        }

        private static class BoxingHelper<T>
        {
            private static readonly ConcurrentDictionary<T, object> boxes;

            static BoxingHelper()
            {
                EnumUtil.BoxingHelper<T>.boxes = new ConcurrentDictionary<T, object>();
            }

            public static object Get(T value) => 
                EnumUtil.BoxingHelper<T>.boxes.GetOrAdd(value, v => v);

            [Serializable, CompilerGenerated]
            private sealed class <>c
            {
                public static readonly EnumUtil.BoxingHelper<T>.<>c <>9;
                public static Func<T, object> <>9__1_0;

                static <>c()
                {
                    EnumUtil.BoxingHelper<T>.<>c.<>9 = new EnumUtil.BoxingHelper<T>.<>c();
                }

                internal object <Get>b__1_0(T v) => 
                    v;
            }
        }
    }
}

