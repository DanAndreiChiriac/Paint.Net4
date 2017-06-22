namespace PaintDotNet.PropertySystem
{
    using System;

    internal sealed class ObjectProperty : Property<object>
    {
        public ObjectProperty(object propertyName) : this(propertyName, null, false)
        {
        }

        private ObjectProperty(ObjectProperty cloneMe, ObjectProperty sentinelNotUsed) : base(cloneMe, sentinelNotUsed)
        {
        }

        public ObjectProperty(object propertyName, object Object) : this(propertyName, Object, false)
        {
        }

        public ObjectProperty(object propertyName, object Object, bool readOnly) : base(propertyName, Object, readOnly, ValueValidationFailureResult.Ignore)
        {
        }

        public override Property Clone() => 
            new ObjectProperty(this, this);

        protected override object OnClampNewValueT(object newValue) => 
            newValue;

        protected override bool ValidateNewValueT(object newValue) => 
            true;
    }
}

