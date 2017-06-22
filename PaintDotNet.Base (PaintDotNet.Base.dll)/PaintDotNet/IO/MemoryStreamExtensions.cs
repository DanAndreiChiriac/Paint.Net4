namespace PaintDotNet.IO
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;

    public static class MemoryStreamExtensions
    {
        public static byte[] ToArrayEx(this MemoryStream memoryStream)
        {
            if (memoryStream.Length == 0)
            {
                return Array.Empty<byte>();
            }
            return memoryStream.ToArray();
        }
    }
}

