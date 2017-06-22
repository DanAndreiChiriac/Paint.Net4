namespace PaintDotNet.Diagnostics
{
    using PaintDotNet;
    using System;

    public sealed class DoubleIsClampedValidator : IValidator<double>
    {
        private double maxValue;
        private double minValue;

        public DoubleIsClampedValidator(double minValue, double maxValue)
        {
            if (minValue > maxValue)
            {
                ExceptionUtil.ThrowArgumentException("minValue must be less than or equal to maxValue", "minValue");
            }
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public bool Check(double value) => 
            DoubleUtil.IsClamped(value, this.minValue, this.maxValue);

        public Exception CreateException(double value, string valueName, Exception innerException) => 
            new ArgumentOutOfRangeException($"value({value.ToString()}):{typeof(double).Name} is not within the range [{this.minValue.ToString()}, {this.maxValue.ToString()}]", innerException);
    }
}

