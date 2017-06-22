namespace PaintDotNet.PropertySystem
{
    using System;

    public abstract class ScalarProperty<T> : Property<T> where T: struct, IComparable<T>
    {
        private T maxValue;
        private T minValue;

        internal ScalarProperty(ScalarProperty<T> copyMe, ScalarProperty<T> sentinelNotUsed) : base(copyMe, sentinelNotUsed)
        {
            this.minValue = copyMe.minValue;
            this.maxValue = copyMe.maxValue;
        }

        internal ScalarProperty(object name, T defaultValue, T minValue, T maxValue) : this(name, defaultValue, minValue, maxValue, false)
        {
        }

        internal ScalarProperty(object name, T defaultValue, T minValue, T maxValue, bool readOnly) : this(name, defaultValue, minValue, maxValue, readOnly, Property.DefaultValueValidationFailureResult)
        {
        }

        internal ScalarProperty(object name, T defaultValue, T minValue, T maxValue, bool readOnly, ValueValidationFailureResult vvfResult) : base(name, defaultValue, readOnly, vvfResult)
        {
            if (ScalarProperty<T>.IsLessThan(maxValue, minValue))
            {
                throw new ArgumentOutOfRangeException("maxValue < minValue");
            }
            if (ScalarProperty<T>.IsLessThan(defaultValue, minValue))
            {
                throw new ArgumentOutOfRangeException("defaultValue < minValue");
            }
            if (ScalarProperty<T>.IsGreaterThan(defaultValue, maxValue))
            {
                throw new ArgumentOutOfRangeException("defaultValue > maxValue");
            }
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public static T Clamp(T value, T min, T max)
        {
            T local = value;
            if (ScalarProperty<T>.IsGreaterThan(min, max))
            {
                throw new ArgumentOutOfRangeException("min must be less than or equal to max");
            }
            if (ScalarProperty<T>.IsGreaterThan(value, max))
            {
                local = max;
            }
            if (ScalarProperty<T>.IsLessThan(value, min))
            {
                local = min;
            }
            return local;
        }

        public T ClampPotentialValue(T newValue) => 
            ScalarProperty<T>.Clamp(newValue, this.minValue, this.maxValue);

        public bool IsEqualTo(ScalarProperty<T> rhs) => 
            ScalarProperty<T>.IsEqualTo((ScalarProperty<T>) this, rhs);

        public static bool IsEqualTo(ScalarProperty<T> lhs, ScalarProperty<T> rhs) => 
            ScalarProperty<T>.IsEqualTo(lhs.Value, rhs.Value);

        public static bool IsEqualTo(T lhs, T rhs) => 
            (lhs.CompareTo(rhs) == 0);

        public bool IsGreaterThan(ScalarProperty<T> rhs) => 
            ScalarProperty<T>.IsGreaterThan((ScalarProperty<T>) this, rhs);

        public static bool IsGreaterThan(ScalarProperty<T> lhs, ScalarProperty<T> rhs) => 
            ScalarProperty<T>.IsGreaterThan(lhs.Value, rhs.Value);

        public static bool IsGreaterThan(T lhs, T rhs) => 
            (lhs.CompareTo(rhs) > 0);

        public bool IsLessThan(ScalarProperty<T> rhs) => 
            ScalarProperty<T>.IsLessThan((ScalarProperty<T>) this, rhs);

        public static bool IsLessThan(ScalarProperty<T> lhs, ScalarProperty<T> rhs) => 
            ScalarProperty<T>.IsLessThan(lhs.Value, rhs.Value);

        public static bool IsLessThan(T lhs, T rhs) => 
            (lhs.CompareTo(rhs) < 0);

        protected override T OnClampNewValueT(T newValue) => 
            this.ClampPotentialValue(newValue);

        protected override bool ValidateNewValueT(T newValue)
        {
            if (ScalarProperty<T>.IsLessThan(newValue, this.minValue))
            {
                return false;
            }
            if (ScalarProperty<T>.IsGreaterThan(newValue, this.maxValue))
            {
                return false;
            }
            return base.ValidateNewValueT(newValue);
        }

        public T MaxValue =>
            this.maxValue;

        public T MinValue =>
            this.minValue;
    }
}

