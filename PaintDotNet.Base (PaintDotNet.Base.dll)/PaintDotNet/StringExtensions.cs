namespace PaintDotNet
{
    using PaintDotNet.Collections;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class StringExtensions
    {
        public static bool IsInterned(this string s) => 
            (string.IsInterned(s) > null);

        public static bool IsNullOrEmpty(this string s) => 
            string.IsNullOrEmpty(s);

        public static string Join(this IEnumerable<string> strings, string separator) => 
            string.Join(separator, strings.ToArrayEx<string>());

        public static string ValueOrDefault(this string s, string nullPlaceholder = "<null>")
        {
            Validate.IsNotNull<string>(nullPlaceholder, "nullPlaceholder");
            return (s ?? nullPlaceholder);
        }
    }
}

