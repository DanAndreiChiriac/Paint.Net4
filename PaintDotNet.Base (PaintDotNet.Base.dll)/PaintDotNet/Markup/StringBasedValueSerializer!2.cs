namespace PaintDotNet.Markup
{
    using System;
    using System.Windows.Markup;

    internal class StringBasedValueSerializer<T, TParser> : ValueSerializer where T: IFormattable where TParser: IParseString<T>, new()
    {
        private TParser parser;

        public StringBasedValueSerializer()
        {
            this.parser = Activator.CreateInstance<TParser>();
        }

        public override bool CanConvertFromString(string value, IValueSerializerContext context) => 
            true;

        public override bool CanConvertToString(object value, IValueSerializerContext context) => 
            (value is T);

        public override object ConvertFromString(string value, IValueSerializerContext context)
        {
            if (value != null)
            {
                return this.parser.Parse(value, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);
            }
            return base.ConvertFromString(value, context);
        }

        public override string ConvertToString(object value, IValueSerializerContext context)
        {
            if (value is T)
            {
                T local = (T) value;
                return local.ToString(null, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);
            }
            return base.ConvertToString(value, context);
        }

        protected TParser Parser =>
            this.parser;
    }
}

