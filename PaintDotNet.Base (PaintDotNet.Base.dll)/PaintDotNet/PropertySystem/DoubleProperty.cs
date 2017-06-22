namespace PaintDotNet.PropertySystem
{
    using System;

    public sealed class DoubleProperty : ScalarProperty<double>
    {
        public DoubleProperty(object name) : this(name, 0.0)
        {
        }

        private DoubleProperty(DoubleProperty copyMe, DoubleProperty sentinelNotUsed) : base(copyMe, sentinelNotUsed)
        {
        }

        public DoubleProperty(object name, double defaultValue) : this(name, defaultValue, double.MinValue, double.MaxValue)
        {
        }

        public DoubleProperty(object name, double defaultValue, double minValue, double maxValue) : this(name, defaultValue, minValue, maxValue, false)
        {
        }

        public DoubleProperty(object name, double defaultValue, double minValue, double maxValue, bool readOnly) : this(name, defaultValue, minValue, maxValue, readOnly, Property.DefaultValueValidationFailureResult)
        {
        }

        public DoubleProperty(object name, double defaultValue, double minValue, double maxValue, bool readOnly, ValueValidationFailureResult vvfResult) : base(name, defaultValue, minValue, maxValue, readOnly, vvfResult)
        {
        }

        public override Property Clone() => 
            new DoubleProperty(this, this);
    }
}

