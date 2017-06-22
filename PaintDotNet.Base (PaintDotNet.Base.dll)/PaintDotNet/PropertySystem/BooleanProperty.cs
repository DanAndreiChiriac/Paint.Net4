namespace PaintDotNet.PropertySystem
{
    using System;

    public class BooleanProperty : ScalarProperty<bool>
    {
        public BooleanProperty(object name) : this(name, false)
        {
        }

        private BooleanProperty(BooleanProperty copyMe, BooleanProperty sentinelNotUsed) : base(copyMe, sentinelNotUsed)
        {
        }

        public BooleanProperty(object name, bool defaultValue) : this(name, defaultValue, false)
        {
        }

        public BooleanProperty(object name, bool defaultValue, bool readOnly) : this(name, defaultValue, readOnly, Property.DefaultValueValidationFailureResult)
        {
        }

        public BooleanProperty(object name, bool defaultValue, bool readOnly, ValueValidationFailureResult vvfResult) : base(name, defaultValue, false, true, readOnly, vvfResult)
        {
        }

        public override Property Clone() => 
            new BooleanProperty(this, this);
    }
}

