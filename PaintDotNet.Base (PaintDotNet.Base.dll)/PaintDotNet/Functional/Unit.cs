namespace PaintDotNet.Functional
{
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct Unit : IEquatable<Unit>
    {
        private static readonly object boxedInstance;
        public static object BoxedInstance =>
            boxedInstance;
        public override bool Equals(object obj) => 
            ((obj != null) && (obj is Unit));

        public bool Equals(Unit other) => 
            true;

        public override int GetHashCode() => 
            0;

        static Unit()
        {
            boxedInstance = new Unit();
        }
    }
}

