namespace PaintDotNet.Interop
{
    using System;
    using System.Runtime.CompilerServices;

    [AttributeUsage(AttributeTargets.Interface, AllowMultiple=false, Inherited=true)]
    public sealed class NativeInterfaceIDAttribute : Attribute
    {
        public NativeInterfaceIDAttribute(string guid)
        {
            this.Guid = new System.Guid(guid);
        }

        public System.Guid Guid { get; private set; }
    }
}

