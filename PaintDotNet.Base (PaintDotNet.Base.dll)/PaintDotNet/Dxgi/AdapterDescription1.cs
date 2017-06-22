namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct AdapterDescription1
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        private string description;
        private uint vendorID;
        private uint deviceID;
        private uint subSysID;
        private uint revision;
        private UIntPtr dedicatedVideoMemory;
        private UIntPtr dedicatedSystemMemory;
        private UIntPtr sharedSystemMemory;
        private long adapterLuid;
        private AdapterFlags flags;
        public AdapterDescription1(string description, uint vendorID, uint deviceID, uint subSystemID, uint revision, UIntPtr dedicatedVideoMemory, UIntPtr dedicatedSystemMemory, UIntPtr sharedSystemMemory, long adapterLuid, AdapterFlags flags)
        {
            Validate.IsNotNull<string>(description, "description");
            if (description.Length >= 0x80)
            {
                ExceptionUtil.ThrowArgumentException("description.Length must be less than 128", "description");
            }
            this.description = description;
            this.vendorID = vendorID;
            this.deviceID = deviceID;
            this.subSysID = subSystemID;
            this.revision = revision;
            this.dedicatedVideoMemory = dedicatedVideoMemory;
            this.dedicatedSystemMemory = dedicatedSystemMemory;
            this.sharedSystemMemory = sharedSystemMemory;
            this.adapterLuid = adapterLuid;
            this.flags = flags;
        }

        public string Description =>
            this.description;
        public uint VendorID =>
            this.vendorID;
        public uint DeviceID =>
            this.deviceID;
        public uint SubSystemID =>
            this.subSysID;
        public uint Revision =>
            this.revision;
        public long DedicatedVideoMemory =>
            ((long) this.dedicatedVideoMemory.ToUInt64());
        public long DedicatedSystemMemory =>
            ((long) this.dedicatedSystemMemory.ToUInt64());
        public long SharedSystemMemory =>
            ((long) this.sharedSystemMemory.ToUInt64());
        public long AdapterLuid =>
            this.adapterLuid;
        public AdapterFlags Flags =>
            this.flags;
    }
}

