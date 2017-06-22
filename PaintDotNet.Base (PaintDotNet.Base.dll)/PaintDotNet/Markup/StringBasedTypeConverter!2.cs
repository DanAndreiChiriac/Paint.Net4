namespace PaintDotNet.Markup
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    internal class StringBasedTypeConverter<T, TParser> : TypeConverter where T: IFormattable where TParser: IParseString<T>, new()
    {
        private TParser parser;

        public StringBasedTypeConverter()
        {
            this.parser = Activator.CreateInstance<TParser>();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (!(sourceType == typeof(string)))
            {
                return base.CanConvertFrom(context, sourceType);
            }
            return true;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (!(destinationType == typeof(string)))
            {
                return base.CanConvertTo(context, destinationType);
            }
            return true;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
            {
                throw base.GetConvertFromException(value);
            }
            string source = value as string;
            if (source != null)
            {
                return this.parser.Parse(source, culture);
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if ((destinationType == typeof(string)) && (value is T))
            {
                T local = (T) value;
                return local.ToString(null, culture);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        protected TParser Parser =>
            this.parser;
    }
}

