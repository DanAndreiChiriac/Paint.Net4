namespace PaintDotNet.PropertySystem
{
    using PaintDotNet.Diagnostics;
    using System;

    public sealed class StringProperty : Property<string>
    {
        private readonly int maxLength;

        public StringProperty(object name) : this(name, string.Empty)
        {
        }

        private StringProperty(StringProperty cloneMe, StringProperty sentinelNotUsed) : base(cloneMe, sentinelNotUsed)
        {
            this.maxLength = cloneMe.maxLength;
        }

        public StringProperty(object name, string defaultValue) : this(name, defaultValue, MaxMaxLength)
        {
        }

        public StringProperty(object name, string defaultValue, int maxLength) : this(name, defaultValue, maxLength, false)
        {
        }

        public StringProperty(object name, string defaultValue, int maxLength, bool readOnly) : this(name, defaultValue, maxLength, readOnly, Property.DefaultValueValidationFailureResult)
        {
        }

        public StringProperty(object name, string defaultValue, int maxLength, bool readOnly, ValueValidationFailureResult vvfResult) : base(name, defaultValue, readOnly, vvfResult)
        {
            Validate.IsNotNull<string>(defaultValue, "defaultValue");
            if ((maxLength < 0) || (maxLength > MaxMaxLength))
            {
                throw new ArgumentOutOfRangeException($"maxLength was {maxLength} but it must be greater than 0, and less than StringProperty.MaxMaxLength");
            }
            this.maxLength = maxLength;
        }

        public override Property Clone() => 
            new StringProperty(this, this);

        protected override string OnClampNewValueT(string newValue)
        {
            string str = newValue;
            if (str.Length > this.MaxLength)
            {
                str = str.Substring(this.MaxLength);
            }
            return str;
        }

        protected override string PropertyValueToStringT(string value) => 
            value;

        protected override bool ValidateNewValueT(string newValue) => 
            (newValue.Length <= this.maxLength);

        public int MaxLength =>
            this.maxLength;

        public static int MaxMaxLength =>
            0x7fff;
    }
}

