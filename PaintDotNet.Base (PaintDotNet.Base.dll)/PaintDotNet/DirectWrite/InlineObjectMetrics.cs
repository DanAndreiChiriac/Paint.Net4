namespace PaintDotNet.DirectWrite
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct InlineObjectMetrics
    {
        private float width;
        private float height;
        private float baseline;
        private uint supportsSideways;
        public float Width
        {
            get => 
                this.width;
            set
            {
                this.width = value;
            }
        }
        public float Height
        {
            get => 
                this.height;
            set
            {
                this.height = value;
            }
        }
        public float Baseline
        {
            get => 
                this.baseline;
            set
            {
                this.baseline = value;
            }
        }
        public uint SupportsSideways
        {
            get => 
                this.supportsSideways;
            set
            {
                this.supportsSideways = value;
            }
        }
        public InlineObjectMetrics(float width, float height, float baseline, uint supportsSideways)
        {
            this.width = width;
            this.height = height;
            this.baseline = baseline;
            this.supportsSideways = supportsSideways;
        }
    }
}

