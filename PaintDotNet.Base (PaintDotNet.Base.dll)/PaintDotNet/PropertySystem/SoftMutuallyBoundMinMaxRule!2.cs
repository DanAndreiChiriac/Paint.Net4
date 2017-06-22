namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using System;

    public sealed class SoftMutuallyBoundMinMaxRule<TValue, TProperty> : PropertyCollectionRule where TValue: struct, IComparable<TValue> where TProperty: ScalarProperty<TValue>
    {
        private readonly string maxPropertyName;
        private readonly string minPropertyName;

        public SoftMutuallyBoundMinMaxRule(Property minProperty, Property maxProperty) : this(minProperty.Name, maxProperty.Name)
        {
        }

        public SoftMutuallyBoundMinMaxRule(object minPropertyName, object maxPropertyName)
        {
            this.minPropertyName = minPropertyName.ToString();
            this.maxPropertyName = maxPropertyName.ToString();
        }

        public override PropertyCollectionRule Clone() => 
            new SoftMutuallyBoundMinMaxRule<TValue, TProperty>(this.minPropertyName, this.maxPropertyName);

        protected override void OnInitialized()
        {
            TProperty minProperty = (TProperty) base.Owner[this.minPropertyName];
            TProperty maxProperty = (TProperty) base.Owner[this.maxPropertyName];
            if (ScalarProperty<TValue>.IsGreaterThan(minProperty.MinValue, maxProperty.MinValue))
            {
                throw new ArgumentOutOfRangeException("MinProperty.MinValue must be less than or equal to MaxProperty.MinValue");
            }
            if (ScalarProperty<TValue>.IsGreaterThan(minProperty.MaxValue, maxProperty.MaxValue))
            {
                throw new ArgumentOutOfRangeException("MinProperty.MaxValue must be less than or equal to MaxProperty.MaxValue");
            }
            foreach (SoftMutuallyBoundMinMaxRule<TValue, TProperty> rule in base.Owner.Rules)
            {
                if ((rule != null) && (rule.maxPropertyName.ToString() == this.minPropertyName.ToString()))
                {
                    throw new ArgumentException("The graph of SoftMutuallyBoundMinMaxRule's in the PropertyCollection has a cycle in it");
                }
            }
            minProperty.ValueChanged += (s, e) => ((SoftMutuallyBoundMinMaxRule<TValue, TProperty>) this).OnMinPropertyValueChanged(minProperty, e.Value);
            maxProperty.ValueChanged += (s, e) => ((SoftMutuallyBoundMinMaxRule<TValue, TProperty>) this).OnMaxPropertyValueChanged(maxProperty, e.Value);
        }

        private void OnMaxPropertyValueChanged(TProperty sender, TValue newVal)
        {
            TProperty rhs = (TProperty) base.Owner[this.minPropertyName];
            TProperty local2 = sender;
            if (local2.IsLessThan(rhs))
            {
                rhs.Value = local2.Value;
            }
        }

        private void OnMinPropertyValueChanged(TProperty sender, TValue newValue)
        {
            TProperty local = sender;
            TProperty rhs = (TProperty) base.Owner[this.maxPropertyName];
            if (local.IsGreaterThan(rhs))
            {
                rhs.Value = local.Value;
            }
        }
    }
}

