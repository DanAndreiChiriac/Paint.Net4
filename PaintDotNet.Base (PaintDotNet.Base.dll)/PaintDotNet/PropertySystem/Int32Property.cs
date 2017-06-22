namespace PaintDotNet.PropertySystem
{
    using System;

    public sealed class Int32Property : ScalarProperty<int>
    {
        public Int32Property(object name) : this(name, 0)
        {
        }

        private Int32Property(Int32Property copyMe, Int32Property sentinelNotUsed) : base(copyMe, sentinelNotUsed)
        {
        }

        public Int32Property(object name, int defaultValue) : this(name, defaultValue, -2147483648, 0x7fffffff)
        {
        }

        public Int32Property(object name, int defaultValue, int minValue, int maxValue) : this(name, defaultValue, minValue, maxValue, false)
        {
        }

        public Int32Property(object name, int defaultValue, int minValue, int maxValue, bool readOnly) : this(name, defaultValue, minValue, maxValue, readOnly, Property.DefaultValueValidationFailureResult)
        {
        }

        public Int32Property(object name, int defaultValue, int minValue, int maxValue, bool readOnly, ValueValidationFailureResult vvfResult) : base(name, defaultValue, minValue, maxValue, readOnly, vvfResult)
        {
        }

        public override Property Clone() => 
            new Int32Property(this, this);

        protected override int OnCoerceValueT(object newValue)
        {
            if (newValue is double)
            {
                return (int) ((double) newValue);
            }
            if (newValue is float)
            {
                return (int) ((float) newValue);
            }
            return base.OnCoerceValueT(newValue);
        }
    }
}

