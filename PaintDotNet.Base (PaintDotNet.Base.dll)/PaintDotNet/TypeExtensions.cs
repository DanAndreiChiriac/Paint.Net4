namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class TypeExtensions
    {
        public static TAttribute[] GetCustomAttributes<TAttribute>(this Type type, bool inherit) where TAttribute: Attribute => 
            ((TAttribute[]) type.GetCustomAttributes(typeof(TAttribute), inherit));

        public static bool IsAssignableFrom<T>(this Type type) => 
            type.IsAssignableFrom(typeof(T));

        public static bool IsNullableType(this Type type) => 
            ((type.IsValueType && type.IsGenericType) && (type.GetGenericTypeDefinition() == typeof(Nullable<>)));

        public static bool IsObsolete(this Type type, bool inherit) => 
            (type.GetCustomAttributes(typeof(ObsoleteAttribute), inherit).Length > 0);
    }
}

