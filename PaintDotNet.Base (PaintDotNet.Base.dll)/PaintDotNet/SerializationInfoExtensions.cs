namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;

    public static class SerializationInfoExtensions
    {
        public static bool ContainsEntry(this SerializationInfo info, string name) => 
            info.TryGetEntry(name).HasValue;

        public static T GetValue<T>(this SerializationInfo info, string name) => 
            ((T) info.GetValue(name, typeof(T)));

        public static SerializationEntry? TryGetEntry(this SerializationInfo info, string name)
        {
            SerializationInfoEnumerator enumerator = info.GetEnumerator();
            while (enumerator.MoveNext())
            {
                SerializationEntry current = enumerator.Current;
                if (string.Equals(current.Name, name, StringComparison.InvariantCulture))
                {
                    return new SerializationEntry?(current);
                }
            }
            return null;
        }

        public static bool TryGetValue<T>(this SerializationInfo info, string name, out T value)
        {
            if (info.ContainsEntry(name))
            {
                value = info.GetValue<T>(name);
                return true;
            }
            value = default(T);
            return false;
        }
    }
}

