namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using System;

    public abstract class VectorProperty<T> : Property<Pair<T, T>> where T: struct, IComparable<T>
    {
        private readonly Pair<T, T> maxValues;
        private readonly Pair<T, T> minValues;

        internal VectorProperty(VectorProperty<T> cloneMe, VectorProperty<T> sentinelNotUsed) : base(cloneMe, sentinelNotUsed)
        {
            this.minValues = cloneMe.minValues;
            this.maxValues = cloneMe.maxValues;
        }

        internal VectorProperty(object name, Pair<T, T> defaultValues, Pair<T, T> minValues, Pair<T, T> maxValues) : this(name, defaultValues, minValues, maxValues, false)
        {
        }

        internal VectorProperty(object name, Pair<T, T> defaultValues, Pair<T, T> minValues, Pair<T, T> maxValues, bool readOnly) : this(name, defaultValues, minValues, maxValues, readOnly, Property.DefaultValueValidationFailureResult)
        {
        }

        internal VectorProperty(object name, Pair<T, T> defaultValues, Pair<T, T> minValues, Pair<T, T> maxValues, bool readOnly, ValueValidationFailureResult vvfResult) : base(name, defaultValues, readOnly, vvfResult)
        {
            this.minValues = minValues;
            this.maxValues = maxValues;
        }

        public Pair<T, T> ClampPotentialValue(Pair<T, T> newValue) => 
            Pair.Create<T, T>(this.ClampPotentialValueX(newValue.First), this.ClampPotentialValueY(newValue.Second));

        public T ClampPotentialValueX(T newValue) => 
            ScalarProperty<T>.Clamp(newValue, this.MinValueX, this.MaxValueX);

        public T ClampPotentialValueY(T newValue) => 
            ScalarProperty<T>.Clamp(newValue, this.MinValueY, this.MaxValueY);

        public bool IsEqualTo(VectorProperty<T> rhs) => 
            VectorProperty<T>.IsEqualTo((VectorProperty<T>) this, rhs);

        public static bool IsEqualTo(Pair<T, T> lhs, Pair<T, T> rhs) => 
            ((lhs.First.CompareTo(rhs.First) == 0) && (lhs.Second.CompareTo(rhs.Second) == 0));

        public static bool IsEqualTo(VectorProperty<T> lhs, VectorProperty<T> rhs) => 
            VectorProperty<T>.IsEqualTo(lhs.Value, rhs.Value);

        protected override Pair<T, T> OnClampNewValueT(Pair<T, T> newValue) => 
            this.ClampPotentialValue(newValue);

        public T DefaultValueX =>
            base.DefaultValue.First;

        public T DefaultValueY =>
            base.DefaultValue.Second;

        public Pair<T, T> MaxValues =>
            this.maxValues;

        public T MaxValueX =>
            this.MaxValues.First;

        public T MaxValueY =>
            this.MaxValues.Second;

        public Pair<T, T> MinValues =>
            this.minValues;

        public T MinValueX =>
            this.MinValues.First;

        public T MinValueY =>
            this.MinValues.Second;

        public T ValueX
        {
            get => 
                base.Value.First;
            set
            {
                base.Value = Pair.Create<T, T>(value, this.ValueY);
            }
        }

        public T ValueY
        {
            get => 
                base.Value.Second;
            set
            {
                base.Value = Pair.Create<T, T>(this.ValueX, value);
            }
        }
    }
}

