namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using System;

    public abstract class PropertyCollectionRule : ICloneable
    {
        private PropertyCollection owner;

        internal PropertyCollectionRule()
        {
        }

        public abstract PropertyCollectionRule Clone();
        internal void Initialize(PropertyCollection owner)
        {
            if (this.owner != null)
            {
                ExceptionUtil.ThrowInvalidOperationException("Already initialized");
            }
            this.owner = owner;
            this.OnInitialized();
        }

        protected abstract void OnInitialized();
        object ICloneable.Clone() => 
            this.Clone();

        internal void VerifyInitialized()
        {
            if (!this.IsInitialized)
            {
                ExceptionUtil.ThrowInvalidOperationException("This rule was never initialized into a PropertyCollection");
            }
        }

        internal bool IsInitialized =>
            (this.owner > null);

        protected PropertyCollection Owner =>
            this.owner;
    }
}

