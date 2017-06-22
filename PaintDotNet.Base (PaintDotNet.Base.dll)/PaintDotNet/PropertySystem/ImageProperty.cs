namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using System;

    public sealed class ImageProperty : Property<ImageResource>
    {
        public ImageProperty(object propertyName) : this(propertyName, null, false)
        {
        }

        private ImageProperty(ImageProperty cloneMe, ImageProperty sentinelNotUsed) : base(cloneMe, sentinelNotUsed)
        {
        }

        public ImageProperty(object propertyName, ImageResource image) : this(propertyName, image, false)
        {
        }

        public ImageProperty(object propertyName, ImageResource image, bool readOnly) : base(propertyName, image, readOnly, ValueValidationFailureResult.Ignore)
        {
        }

        public override Property Clone() => 
            new ImageProperty(this, this);

        protected override ImageResource OnClampNewValueT(ImageResource newValue) => 
            newValue;

        protected override bool ValidateNewValueT(ImageResource newValue) => 
            true;
    }
}

