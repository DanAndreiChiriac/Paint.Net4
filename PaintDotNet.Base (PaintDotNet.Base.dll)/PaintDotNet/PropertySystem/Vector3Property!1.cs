namespace PaintDotNet.PropertySystem
{
    using System;

    public abstract class Vector3Property<T> : Property<Tuple<T, T, T>> where T: struct, IComparable<T>
    {
        private readonly Tuple<T, T, T> maxValues;
        private readonly Tuple<T, T, T> minValues;

        internal Vector3Property(Vector3Property<T> cloneMe, Vector3Property<T> sentinelNotUsed) : base(cloneMe, sentinelNotUsed)
        {
            this.minValues = cloneMe.minValues;
            this.maxValues = cloneMe.maxValues;
        }

        internal Vector3Property(object name, Tuple<T, T, T> defaultValues, Tuple<T, T, T> minValues, Tuple<T, T, T> maxValues) : this(name, defaultValues, minValues, maxValues, false)
        {
        }

        internal Vector3Property(object name, Tuple<T, T, T> defaultValues, Tuple<T, T, T> minValues, Tuple<T, T, T> maxValues, bool readOnly) : this(name, defaultValues, minValues, maxValues, readOnly, Property.DefaultValueValidationFailureResult)
        {
        }

        internal Vector3Property(object name, Tuple<T, T, T> defaultValues, Tuple<T, T, T> minValues, Tuple<T, T, T> maxValues, bool readOnly, ValueValidationFailureResult vvfResult) : base(name, defaultValues, readOnly, vvfResult)
        {
            this.minValues = minValues;
            this.maxValues = maxValues;
        }

        public Tuple<T, T, T> ClampPotentialValue(Tuple<T, T, T> newValue) => 
            Tuple.Create<T, T, T>(this.ClampPotentialValueX(newValue.Item1), this.ClampPotentialValueY(newValue.Item2), this.ClampPotentialValueZ(newValue.Item3));

        public T ClampPotentialValueX(T newValue) => 
            ScalarProperty<T>.Clamp(newValue, this.MinValueX, this.MaxValueX);

        public T ClampPotentialValueY(T newValue) => 
            ScalarProperty<T>.Clamp(newValue, this.MinValueY, this.MaxValueY);

        public T ClampPotentialValueZ(T newValue) => 
            ScalarProperty<T>.Clamp(newValue, this.MinValueZ, this.MaxValueZ);

        public bool IsEqualTo(Vector3Property<T> rhs) => 
            Vector3Property<T>.IsEqualTo((Vector3Property<T>) this, rhs);

        public static bool IsEqualTo(Vector3Property<T> lhs, Vector3Property<T> rhs) => 
            Vector3Property<T>.IsEqualTo(lhs.Value, rhs.Value);

        public static bool IsEqualTo(Tuple<T, T, T> lhs, Tuple<T, T, T> rhs) => 
            lhs.Equals(rhs);

        protected override Tuple<T, T, T> OnClampNewValueT(Tuple<T, T, T> newValue) => 
            this.ClampPotentialValue(newValue);

        public T DefaultValueX =>
            base.DefaultValue.Item1;

        public T DefaultValueY =>
            base.DefaultValue.Item2;

        public T DefaultValueZ =>
            base.DefaultValue.Item3;

        public Tuple<T, T, T> MaxValues =>
            this.maxValues;

        public T MaxValueX =>
            this.MaxValues.Item1;

        public T MaxValueY =>
            this.MaxValues.Item2;

        public T MaxValueZ =>
            this.MaxValues.Item3;

        public Tuple<T, T, T> MinValues =>
            this.minValues;

        public T MinValueX =>
            this.MinValues.Item1;

        public T MinValueY =>
            this.MinValues.Item2;

        public T MinValueZ =>
            this.MinValues.Item3;

        public T ValueX
        {
            get => 
                base.Value.Item1;
            set
            {
                base.Value = Tuple.Create<T, T, T>(value, this.ValueY, this.ValueZ);
            }
        }

        public T ValueY
        {
            get => 
                base.Value.Item2;
            set
            {
                base.Value = Tuple.Create<T, T, T>(this.ValueX, value, this.ValueZ);
            }
        }

        public T ValueZ
        {
            get => 
                base.Value.Item3;
            set
            {
                base.Value = Tuple.Create<T, T, T>(this.ValueX, this.ValueY, value);
            }
        }
    }
}

