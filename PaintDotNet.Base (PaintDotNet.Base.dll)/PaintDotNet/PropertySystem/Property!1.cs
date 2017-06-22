namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public abstract class Property<T> : Property
    {
        [field: CompilerGenerated]
        public event ValueEventHandler<T> ValueChanged;

        internal Property(Property<T> cloneMe, Property<T> sentinelNotUsed) : base(cloneMe, sentinelNotUsed)
        {
            this.InitEvents();
        }

        internal Property(object name, T defaultValue, bool readOnly, ValueValidationFailureResult vvfResult) : base(name, typeof(T), defaultValue, readOnly, vvfResult)
        {
            this.InitEvents();
        }

        private void InitEvents()
        {
        }

        protected sealed override object OnClampNewValue(object newValue) => 
            this.OnClampNewValueT((T) newValue);

        protected abstract T OnClampNewValueT(T newValue);
        protected sealed override object OnCoerceValue(object newValue) => 
            this.OnCoerceValueT(newValue);

        protected virtual T OnCoerceValueT(object newValue) => 
            ((T) newValue);

        protected sealed override void OnValueChanged(object newValue)
        {
            T local = (T) newValue;
            this.OnValueChangedT(local);
            this.ValueChanged.Raise<T>(this, local);
            base.OnValueChanged(newValue);
        }

        protected virtual void OnValueChangedT(T newValue)
        {
        }

        protected sealed override string PropertyValueToString(object value) => 
            base.PropertyValueToString(value);

        protected virtual string PropertyValueToStringT(T value) => 
            value.ToString();

        protected sealed override bool ValidateNewValue(object newValue)
        {
            T local = (T) newValue;
            return this.ValidateNewValueT(local);
        }

        protected virtual bool ValidateNewValueT(T newValue) => 
            true;

        public T DefaultValue =>
            ((T) base.DefaultValue);

        public T Value
        {
            get => 
                ((T) base.Value);
            set
            {
                base.Value = value;
            }
        }
    }
}

