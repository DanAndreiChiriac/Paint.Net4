namespace PaintDotNet.Markup
{
    using System;
    using System.Globalization;

    internal static class TypeConverterHelper
    {
        private static readonly CultureInfo invariantEnglishUS = CultureInfo.ReadOnly(new CultureInfo("en-US", false));

        public static CultureInfo InvariantEnglishUS =>
            invariantEnglishUS;
    }
}

