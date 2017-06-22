namespace PaintDotNet.Collections
{
    using PaintDotNet.Functional;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct CastDoubleToFloatFunc : IFunc<double, float>
    {
        public float Invoke(double arg1) => 
            ((float) arg1);
    }
}

