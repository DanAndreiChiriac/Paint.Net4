namespace PaintDotNet
{
    using PaintDotNet.Collections;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public static class TypeUtil
    {
        private const BindingFlags getAllFieldsBindingFlags = (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        private static readonly ConcurrentDictionary<Type, FieldInfo[]> typeFieldInfosCache = new ConcurrentDictionary<Type, FieldInfo[]>();
        private static readonly Func<Type, FieldInfo[]> typeFieldInfosCacheValueFactory = new Func<Type, FieldInfo[]>(<>c.<>9.<.cctor>b__7_0);

        public static IEnumerable<FieldInfo> EnumerateAllFields(Type type)
        {
            if (type.BaseType == null)
            {
                return Array.Empty<FieldInfo>();
            }
            return type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Concat<FieldInfo>(EnumerateAllFields(type.BaseType));
        }

        public static IReadOnlyList<FieldInfo> GetAllFields(Type type) => 
            typeFieldInfosCache.GetOrAdd(type, typeFieldInfosCacheValueFactory);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValueType<T>() => 
            IsValueTypeHelper<T>.Value;

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly TypeUtil.<>c <>9 = new TypeUtil.<>c();

            internal FieldInfo[] <.cctor>b__7_0(Type t) => 
                TypeUtil.EnumerateAllFields(t).ToArrayEx<FieldInfo>();
        }

        private static class IsValueTypeHelper<T>
        {
            public static readonly bool Value;

            static IsValueTypeHelper()
            {
                TypeUtil.IsValueTypeHelper<T>.Value = typeof(T).IsValueType;
            }
        }
    }
}

