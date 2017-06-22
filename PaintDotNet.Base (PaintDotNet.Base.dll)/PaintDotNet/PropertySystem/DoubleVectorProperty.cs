namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using System;

    public sealed class DoubleVectorProperty : VectorProperty<double>
    {
        public DoubleVectorProperty(object name) : this(name, Pair.Create<double, double>(0.0, 0.0))
        {
        }

        private DoubleVectorProperty(DoubleVectorProperty cloneMe, DoubleVectorProperty sentinelNotUsed) : base(cloneMe, sentinelNotUsed)
        {
        }

        public DoubleVectorProperty(object name, Pair<double, double> defaultValues) : this(name, defaultValues, Pair.Create<double, double>(double.MinValue, double.MinValue), Pair.Create<double, double>(double.MaxValue, double.MaxValue))
        {
        }

        public DoubleVectorProperty(object name, Pair<double, double> defaultValues, Pair<double, double> minValues, Pair<double, double> maxValues) : this(name, defaultValues, minValues, maxValues, false)
        {
        }

        public DoubleVectorProperty(object name, Pair<double, double> defaultValues, Pair<double, double> minValues, Pair<double, double> maxValues, bool readOnly) : this(name, defaultValues, minValues, maxValues, readOnly, Property.DefaultValueValidationFailureResult)
        {
        }

        public DoubleVectorProperty(object name, Pair<double, double> defaultValues, Pair<double, double> minValues, Pair<double, double> maxValues, bool readOnly, ValueValidationFailureResult vvfResult) : base(name, defaultValues, minValues, maxValues, readOnly, vvfResult)
        {
        }

        public override Property Clone() => 
            new DoubleVectorProperty(this, this);
    }
}

