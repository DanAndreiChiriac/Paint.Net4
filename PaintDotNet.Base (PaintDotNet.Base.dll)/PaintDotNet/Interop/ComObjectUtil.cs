namespace PaintDotNet.Interop
{
    using System;
    using System.Runtime.InteropServices;

    public static class ComObjectUtil
    {
        public static int AddRef(IntPtr pObject, out IntPtr pObjectRef)
        {
            pObjectRef = pObject;
            return Marshal.AddRef(pObject);
        }

        public static int Release(ref IntPtr pObject)
        {
            int num;
            try
            {
                if (pObject != IntPtr.Zero)
                {
                    return Marshal.Release(pObject);
                }
                num = 0;
            }
            finally
            {
                pObject = IntPtr.Zero;
            }
            return num;
        }
    }
}

