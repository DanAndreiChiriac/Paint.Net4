namespace PaintDotNet.ObjectModel
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;

    [StructLayout(LayoutKind.Sequential)]
    public struct ResourceID : IEquatable<ResourceID>
    {
        private const long invalidValue = 0L;
        private static long previousValue;
        private readonly long value;
        public static ResourceID Invalid =>
            new ResourceID(0L);
        static ResourceID()
        {
        }

        public static bool operator ==(ResourceID x, ResourceID y) => 
            x.Equals(y);

        public static bool operator !=(ResourceID x, ResourceID y) => 
            !x.Equals(y);

        internal bool IsValid =>
            (this.value > 0L);
        public static ResourceID Generate()
        {
            long num1 = Interlocked.Increment(ref previousValue);
            if (num1 == 0)
            {
                ExceptionUtil.ThrowInternalErrorException();
            }
            return new ResourceID(num1);
        }

        private ResourceID(long value)
        {
            this.value = value;
        }

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ResourceID, object>(this, obj);

        public bool Equals(ResourceID other) => 
            (this.value == other.value);

        public override int GetHashCode() => 
            this.value.GetHashCode();

        public override string ToString() => 
            ("[@" + this.value.ToString() + "]");
    }
}

