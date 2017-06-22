namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;

    internal abstract class DefaultValueComparer<T>
    {
        private static readonly DefaultValueComparer<T> instance;

        static DefaultValueComparer()
        {
            DefaultValueComparer<T>.instance = DefaultValueComparer<T>.Create();
        }

        protected DefaultValueComparer()
        {
        }

        public abstract bool AreAllDefaultValue(T[] array, int startIndex, int length);
        private static DefaultValueComparer<T> Create()
        {
            if (typeof(T).IsValueType)
            {
                return new IsStructNull<T>();
            }
            return new IsReferenceNull<T>();
        }

        public abstract bool IsDefaultValue(ref T value);

        public static DefaultValueComparer<T> Instance =>
            DefaultValueComparer<T>.instance;

        internal sealed class IsReferenceNull : DefaultValueComparer<T>
        {
            public override bool AreAllDefaultValue(T[] array, int startIndex, int length)
            {
                Validate.Begin().IsNotNull<T[]>(array, "array").Check().IsPositive(array.Length, "array.Length").IsNotNegative(startIndex, "startIndex").IsPositive(length, "length").Check().IsRangeValid(array.Length, startIndex, length, "array").Check();
                for (int i = startIndex; i < (startIndex + length); i++)
                {
                    if (array[i] != null)
                    {
                        return false;
                    }
                }
                return true;
            }

            public sealed override bool IsDefaultValue(ref T value) => 
                (((T) value) == null);
        }

        internal sealed class IsStructNull : DefaultValueComparer<T>
        {
            private static readonly EqualityComparer<T> comparer;
            private static T defaultValue;

            static IsStructNull()
            {
                DefaultValueComparer<T>.IsStructNull.comparer = EqualityComparer<T>.Default;
            }

            public override bool AreAllDefaultValue(T[] array, int startIndex, int length) => 
                ArrayUtil.AreAllZero<T>(array, startIndex, length);

            public sealed override bool IsDefaultValue(ref T value) => 
                DefaultValueComparer<T>.IsStructNull.comparer.Equals(value, DefaultValueComparer<T>.IsStructNull.defaultValue);
        }
    }
}

