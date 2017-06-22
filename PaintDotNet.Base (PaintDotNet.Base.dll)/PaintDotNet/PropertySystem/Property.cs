namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public abstract class Property : ICloneable, INotifyPropertyChanged
    {
        private readonly object defaultValue;
        private bool eventAddAllowed;
        private readonly string name;
        private readonly System.ValueType originalNameValue;
        private object ourValue;
        private PropertyChangedEventHandler propertyChanged;
        private bool readOnly;
        private readonly object sync;
        private readonly Type valueType;
        private readonly PaintDotNet.PropertySystem.ValueValidationFailureResult vvfResult;

        [field: CompilerGenerated]
        public event ValueEventHandler<bool> ReadOnlyChanged;

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                object sync = this.Sync;
                lock (sync)
                {
                    this.propertyChanged = (PropertyChangedEventHandler) Delegate.Combine(this.propertyChanged, value);
                }
            }
            remove
            {
                object sync = this.Sync;
                lock (sync)
                {
                    this.propertyChanged = (PropertyChangedEventHandler) Delegate.Remove(this.propertyChanged, value);
                }
            }
        }

        [field: CompilerGenerated]
        public event ValueEventHandler<object> ValueChanged;

        internal Property(Property cloneMe, Property sentinelNotUsed)
        {
            this.sync = new object();
            this.eventAddAllowed = true;
            sentinelNotUsed.NoOp();
            this.name = cloneMe.name;
            this.originalNameValue = cloneMe.originalNameValue;
            this.valueType = cloneMe.valueType;
            this.ourValue = cloneMe.ourValue;
            this.defaultValue = cloneMe.defaultValue;
            this.readOnly = cloneMe.readOnly;
            this.vvfResult = cloneMe.vvfResult;
        }

        internal Property(object name, Type valueType, object defaultValue, bool readOnly, PaintDotNet.PropertySystem.ValueValidationFailureResult vvfResult)
        {
            this.sync = new object();
            this.eventAddAllowed = true;
            if (defaultValue != null)
            {
                Type c = defaultValue.GetType();
                if (!valueType.IsAssignableFrom(c))
                {
                    throw new ArgumentOutOfRangeException("valueType", $"defaultValue is not of type specified in constructor. valueType.Name = {valueType.Name}, defaultValue.GetType().Name = {defaultValue.GetType().Name}");
                }
            }
            if (name.GetType().IsValueType)
            {
                this.originalNameValue = (System.ValueType) name;
            }
            this.name = name.ToString();
            this.valueType = valueType;
            this.ourValue = defaultValue;
            this.defaultValue = defaultValue;
            this.readOnly = readOnly;
            switch (vvfResult)
            {
                case PaintDotNet.PropertySystem.ValueValidationFailureResult.Ignore:
                case PaintDotNet.PropertySystem.ValueValidationFailureResult.Clamp:
                case PaintDotNet.PropertySystem.ValueValidationFailureResult.ThrowException:
                    this.vvfResult = vvfResult;
                    return;
            }
            throw ExceptionUtil.InvalidEnumArgumentException<PaintDotNet.PropertySystem.ValueValidationFailureResult>(vvfResult, "vvfResult");
        }

        internal IDisposable BeginEventAddMoratorium()
        {
            if (!this.eventAddAllowed)
            {
                ExceptionUtil.ThrowInvalidOperationException("An event add moratorium is already in effect");
            }
            this.eventAddAllowed = false;
            return Disposable.FromAction(delegate {
                this.eventAddAllowed = true;
            }, false);
        }

        private object ClampNewValue(object newValue) => 
            this.OnClampNewValue(newValue);

        public abstract Property Clone();
        public static Property Create(Type valueType, object name) => 
            Create(valueType, name, null);

        public static Property Create(Type valueType, object name, object defaultValue)
        {
            if (valueType == typeof(bool))
            {
                return new BooleanProperty(name, defaultValue ?? false);
            }
            if (valueType == typeof(double))
            {
                return new DoubleProperty(name, defaultValue ?? 0.0);
            }
            if (valueType == typeof(Tuple<double, double, double>))
            {
                return new DoubleVector3Property(name, defaultValue ?? Tuple.Create<double, double, double>(0.0, 0.0, 0.0));
            }
            if (valueType == typeof(Pair<double, double>))
            {
                return new DoubleVectorProperty(name, defaultValue ?? Pair.Create<double, double>(0.0, 0.0));
            }
            if (valueType == typeof(int))
            {
                return new Int32Property(name, defaultValue ?? 0);
            }
            if (valueType == typeof(string))
            {
                return new StringProperty(name, (string) defaultValue);
            }
            if (typeof(ImageResource).IsAssignableFrom(valueType))
            {
                return new ImageProperty(name, (ImageResource) defaultValue);
            }
            if (!valueType.IsEnum)
            {
                return new ObjectProperty(name, defaultValue);
            }
            return StaticListChoiceProperty.CreateForEnum(valueType, name, defaultValue ?? ((object[]) Enum.GetValues(valueType))[0], false);
        }

        public object GetOriginalNameValue() => 
            this.originalNameValue;

        protected void NoOp()
        {
        }

        protected abstract object OnClampNewValue(object newValue);
        protected virtual object OnCoerceValue(object newValue) => 
            newValue;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = null;
            object sync = this.Sync;
            lock (sync)
            {
                propertyChanged = this.propertyChanged;
            }
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnReadOnlyChanged(bool newReadOnlyValue)
        {
            this.ReadOnlyChanged.Raise<bool>(this, newReadOnlyValue);
            this.OnPropertyChanged("ReadOnly");
        }

        protected virtual void OnValueChanged(object newValue)
        {
            this.ValueChanged.Raise<object>(this, newValue);
            this.OnPropertyChanged("Value");
        }

        protected virtual string PropertyValueToString(object value) => 
            value.ToString();

        private void SetValueCore(object value)
        {
            bool flag;
            object obj3;
            object newValue = value;
            object sync = this.Sync;
            lock (sync)
            {
                object obj5;
                this.VerifyNotReadOnly();
            Label_001A:
                obj5 = this.Value;
                object obj6 = this.OnCoerceValue(newValue);
                if (obj6.Equals(obj5))
                {
                    obj3 = null;
                    flag = false;
                }
                else if (this.ValidateNewValue(obj6))
                {
                    obj3 = obj6;
                    this.ourValue = obj6;
                    flag = true;
                }
                else
                {
                    switch (this.vvfResult)
                    {
                        case PaintDotNet.PropertySystem.ValueValidationFailureResult.Clamp:
                            newValue = this.ClampNewValue(obj6);
                            break;

                        case PaintDotNet.PropertySystem.ValueValidationFailureResult.ThrowException:
                            throw new ArgumentOutOfRangeException($"Not a valid value for property named {this.name.ToString()} of underlying type {this.valueType.FullName}: coercedNewValue={obj6.ToString()}, newValue={newValue.ToString()}, value={value.ToString()}");
                    }
                    goto Label_001A;
                }
            }
            if (flag)
            {
                this.OnValueChanged(obj3);
            }
        }

        object ICloneable.Clone() => 
            this.Clone();

        protected virtual bool ValidateNewValue(object newValue) => 
            true;

        protected void VerifyNotReadOnly()
        {
            if (this.readOnly)
            {
                throw new ReadOnlyException("This property is read only");
            }
        }

        public object DefaultValue =>
            this.defaultValue;

        public static PaintDotNet.PropertySystem.ValueValidationFailureResult DefaultValueValidationFailureResult =>
            PaintDotNet.PropertySystem.ValueValidationFailureResult.Clamp;

        public string Name =>
            this.name;

        public bool ReadOnly
        {
            get => 
                this.readOnly;
            set
            {
                bool flag = false;
                object sync = this.Sync;
                lock (sync)
                {
                    if (this.readOnly != value)
                    {
                        this.readOnly = value;
                        flag = true;
                    }
                }
                if (flag)
                {
                    this.OnReadOnlyChanged(value);
                }
            }
        }

        protected object Sync =>
            this.sync;

        public object Value
        {
            get
            {
                object sync = this.Sync;
                lock (sync)
                {
                    return this.ourValue;
                }
            }
            set
            {
                this.SetValueCore(value);
            }
        }

        public Type ValueType =>
            this.valueType;

        public PaintDotNet.PropertySystem.ValueValidationFailureResult ValueValidationFailureResult =>
            this.vvfResult;
    }
}

