namespace PaintDotNet.Diagnostics
{
    using PaintDotNet;
    using System;

    public sealed class FloatIsClampedValidator : IValidator<float>
    {
        private float maxValue;
        private float minValue;

        public FloatIsClampedValidator(float minValue, float maxValue)
        {
            if (minValue > maxValue)
            {
                ExceptionUtil.ThrowArgumentException("minValue must be less than or equal to maxValue", "minValue");
            }
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public bool Check(float value) => 
            FloatUtil.IsClamped(value, this.minValue, this.maxValue);

        public Exception CreateException(float value, string valueName, Exception innerException) => 
            new ArgumentOutOfRangeException($"value({value.ToString()}):{typeof(float).Name} is not within the range [{this.minValue.ToString()}, {this.maxValue.ToString()}]", innerException);
    }
}

