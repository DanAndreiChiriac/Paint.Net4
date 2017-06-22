namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal static class ListSourceExtension
    {
        public static VerifyVersionScope<T> UseVersionScope<T>(this IListSource<T> source) => 
            new VerifyVersionScope<T>(source);

        [StructLayout(LayoutKind.Sequential)]
        public struct VerifyVersionScope<T> : IDisposable
        {
            private IListSource<T> source;
            private int version;
            internal VerifyVersionScope(IListSource<T> source)
            {
                Validate.IsNotNull<IListSource<T>>(source, "source");
                this.source = source;
                this.version = this.source.Version;
            }

            public void Dispose()
            {
                if (this.source != null)
                {
                    try
                    {
                        if (this.source.Version != this.version)
                        {
                            ExceptionUtil.ThrowInvalidOperationException("The collection changed during the operation");
                        }
                    }
                    finally
                    {
                        this.source = null;
                        this.version = 0;
                    }
                }
            }
        }
    }
}

