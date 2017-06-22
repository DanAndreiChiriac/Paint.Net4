namespace PaintDotNet.PropertySystem
{
    using System;

    public sealed class StaticListChoiceProperty : Property<object>
    {
        private readonly object[] valueChoices;

        private StaticListChoiceProperty(StaticListChoiceProperty cloneMe, StaticListChoiceProperty sentinelNotUsed) : base(cloneMe, sentinelNotUsed)
        {
            this.valueChoices = (object[]) cloneMe.valueChoices.Clone();
        }

        public StaticListChoiceProperty(object name, object[] valueChoices) : this(name, valueChoices, 0)
        {
        }

        public StaticListChoiceProperty(object name, object[] valueChoices, int defaultChoiceIndex) : this(name, valueChoices, defaultChoiceIndex, false)
        {
        }

        public StaticListChoiceProperty(object name, object[] valueChoices, int defaultChoiceIndex, bool readOnly) : this(name, valueChoices, defaultChoiceIndex, readOnly, Property.DefaultValueValidationFailureResult)
        {
        }

        public StaticListChoiceProperty(object name, object[] valueChoices, int defaultChoiceIndex, bool readOnly, ValueValidationFailureResult vvfResult) : base(name, valueChoices[defaultChoiceIndex], readOnly, vvfResult)
        {
            if ((defaultChoiceIndex < 0) || (defaultChoiceIndex >= valueChoices.Length))
            {
                throw new ArgumentOutOfRangeException("defaultChoiceIndex", "must be in the range [0, valueChoices.Length) (actual value: " + defaultChoiceIndex.ToString() + ")");
            }
            this.valueChoices = (object[]) valueChoices.Clone();
        }

        public override Property Clone() => 
            new StaticListChoiceProperty(this, this);

        public static StaticListChoiceProperty CreateForEnum<TEnum>(object name, TEnum defaultValue, bool readOnly) where TEnum: struct => 
            CreateForEnum(typeof(TEnum), name, defaultValue, readOnly);

        public static StaticListChoiceProperty CreateForEnum(Type enumType, object name, object defaultValue, bool readOnly)
        {
            if (enumType.GetCustomAttributes(typeof(FlagsAttribute), true).Length != 0)
            {
                throw new ArgumentOutOfRangeException("Enums with [Flags] are not currently supported");
            }
            Array values = Enum.GetValues(enumType);
            int index = Array.IndexOf(values, defaultValue);
            if (index == -1)
            {
                throw new ArgumentOutOfRangeException($"defaultValue ({defaultValue.ToString()}) is not a valid enum value for {enumType.FullName}");
            }
            object[] array = new object[values.Length];
            values.CopyTo(array, 0);
            return new StaticListChoiceProperty(name, array, index, readOnly);
        }

        protected override object OnClampNewValueT(object newValue)
        {
            object defaultValue = newValue;
            if (Array.IndexOf<object>(this.valueChoices, newValue) == -1)
            {
                defaultValue = base.DefaultValue;
            }
            return defaultValue;
        }

        protected override bool ValidateNewValueT(object newValue) => 
            (Array.IndexOf<object>(this.valueChoices, newValue) != -1);

        public object[] ValueChoices =>
            ((object[]) this.valueChoices.Clone());
    }
}

