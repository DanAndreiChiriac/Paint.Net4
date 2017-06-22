namespace PaintDotNet.PropertySystem
{
    using System;

    public sealed class DoubleVector3Property : Vector3Property<double>
    {
        public DoubleVector3Property(object name) : this(name, Tuple.Create<double, double, double>(0.0, 0.0, 0.0))
        {
        }

        private DoubleVector3Property(DoubleVector3Property cloneMe, DoubleVector3Property sentinelNotUsed) : base(cloneMe, sentinelNotUsed)
        {
        }

        public DoubleVector3Property(object name, Tuple<double, double, double> defaultValues) : this(name, defaultValues, Tuple.Create<double, double, double>(double.MinValue, double.MinValue, double.MinValue), Tuple.Create<double, double, double>(double.MaxValue, double.MaxValue, double.MaxValue))
        {
        }

        public DoubleVector3Property(object name, Tuple<double, double, double> defaultValues, Tuple<double, double, double> minValues, Tuple<double, double, double> maxValues) : this(name, defaultValues, minValues, maxValues, false)
        {
        }

        public DoubleVector3Property(object name, Tuple<double, double, double> defaultValues, Tuple<double, double, double> minValues, Tuple<double, double, double> maxValues, bool readOnly) : this(name, defaultValues, minValues, maxValues, readOnly, Property.DefaultValueValidationFailureResult)
        {
        }

        public DoubleVector3Property(object name, Tuple<double, double, double> defaultValues, Tuple<double, double, double> minValues, Tuple<double, double, double> maxValues, bool readOnly, ValueValidationFailureResult vvfResult) : base(name, defaultValues, minValues, maxValues, readOnly, vvfResult)
        {
        }

        public override Property Clone() => 
            new DoubleVector3Property(this, this);
    }
}

