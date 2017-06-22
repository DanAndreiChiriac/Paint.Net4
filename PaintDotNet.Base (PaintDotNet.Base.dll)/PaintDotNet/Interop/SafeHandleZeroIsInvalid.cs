namespace PaintDotNet.Interop
{
    using System;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Permissions;

    [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode=true), SecurityPermission(SecurityAction.Demand, UnmanagedCode=true)]
    public abstract class SafeHandleZeroIsInvalid : SafeHandle
    {
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected SafeHandleZeroIsInvalid(bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
        }

        public sealed override bool IsInvalid =>
            (base.handle == IntPtr.Zero);
    }
}

