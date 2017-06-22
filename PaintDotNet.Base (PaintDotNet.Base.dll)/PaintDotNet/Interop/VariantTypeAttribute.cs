namespace PaintDotNet.Interop
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [Serializable]
    public sealed class VariantTypeAttribute : Attribute
    {
        public VariantTypeAttribute(params VarEnum[] variantTypes)
        {
            this.VariantTypes = variantTypes;
        }

        public VarEnum[] VariantTypes { get; set; }
    }
}

