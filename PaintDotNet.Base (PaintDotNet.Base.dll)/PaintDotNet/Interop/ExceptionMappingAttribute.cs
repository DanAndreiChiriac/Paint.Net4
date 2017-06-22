namespace PaintDotNet.Interop
{
    using System;
    using System.Runtime.CompilerServices;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
    public sealed class ExceptionMappingAttribute : Attribute
    {
        public ExceptionMappingAttribute(Type exceptionType)
        {
            this.ExceptionType = exceptionType;
        }

        public Type ExceptionType { get; private set; }
    }
}

