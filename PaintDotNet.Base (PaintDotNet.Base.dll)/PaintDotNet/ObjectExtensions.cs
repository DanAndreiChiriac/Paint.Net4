namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ObjectExtensions
    {
        public static bool IsNullReference<T>(this T obj) where T: class => 
            (obj == null);

        public static bool ReferenceEquals<T>(this T first, T second) where T: class => 
            (first == second);

        public static int SizeOf<T>(this T obj) where T: struct => 
            ObjectUtil.SizeOf<T>();
    }
}

