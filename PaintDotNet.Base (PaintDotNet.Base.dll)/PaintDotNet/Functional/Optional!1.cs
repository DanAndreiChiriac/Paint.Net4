namespace PaintDotNet.Functional
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Optional<T> : IEquatable<Optional<T>>
    {
        private static readonly Type type;
        private static readonly bool isRefType;
        private static readonly bool isNullableType;
        private static readonly EqualityComparer<T> comparer;
        private static readonly DefaultValueComparer<T> nullValueComparer;
        private T value;
        private readonly bool hasValue;
        static Optional()
        {
            Optional<T>.type = typeof(T);
            Optional<T>.isRefType = !Optional<T>.type.IsValueType;
            Optional<T>.isNullableType = Optional<T>.type.IsNullableType();
            Optional<T>.comparer = EqualityComparer<T>.Default;
            Optional<T>.nullValueComparer = Optional<T>.isNullableType ? DefaultValueComparer<T>.Instance : null;
        }

        public static Optional<T> Null =>
            new Optional<T>();
        public T Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (!this.hasValue)
                {
                    ExceptionUtil.ThrowInvalidOperationException();
                }
                return this.value;
            }
        }
        public bool HasValue =>
            this.hasValue;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Optional(T value)
        {
            this.value = value;
            this.hasValue = !Optional<T>.IsNullValue(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Optional<T>(T value) => 
            new Optional<T>(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator T(Optional<T> value) => 
            value.Value;

        public static implicit operator Optional<T>(PaintDotNet.Functional.Null @null) => 
            Optional<T>.Null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override unsafe bool Equals(object obj) => 
            EquatableUtil.Equals<Optional<T>, object>(*((Optional<T>*) this), obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Optional<T> other) => 
            ((this.hasValue == other.hasValue) && Optional<T>.comparer.Equals(this.value, other.value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Optional<T> value1, Optional<T> value2) => 
            value1.Equals(value2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Optional<T> value1, Optional<T> value2) => 
            !(value1 == value2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            if (!this.hasValue)
            {
                return 0;
            }
            return Optional<T>.comparer.GetHashCode(this.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetValueOrDefault() => 
            this.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetValueOrDefault(T defaultValue)
        {
            if (!this.hasValue)
            {
                return defaultValue;
            }
            return this.value;
        }

        public override string ToString()
        {
            if (!this.hasValue)
            {
                return string.Empty;
            }
            return this.value.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNullValue(T value)
        {
            if (Optional<T>.isRefType && (value == null))
            {
                return true;
            }
            if (!Optional<T>.isNullableType)
            {
                return false;
            }
            return Optional<T>.nullValueComparer.IsDefaultValue(ref value);
        }
    }
}

