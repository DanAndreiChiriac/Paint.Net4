namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class EnumExtensions
    {
        [Obsolete]
        public static string ToLongString(this Enum enumValue) => 
            $"{enumValue.GetType().FullName}.{enumValue.ToString("G")}";
    }
}

