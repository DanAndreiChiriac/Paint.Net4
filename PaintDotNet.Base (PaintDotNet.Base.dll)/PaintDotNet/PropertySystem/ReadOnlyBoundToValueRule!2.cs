namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using System;

    public sealed class ReadOnlyBoundToValueRule<TValue, TProperty> : PropertyCollectionRule where TProperty: Property<TValue>
    {
        private readonly bool inverse;
        private readonly string sourcePropertyName;
        private readonly string targetPropertyName;
        private readonly TValue[] valuesForReadOnly;

        public ReadOnlyBoundToValueRule(Property targetProperty, TProperty sourceProperty, TValue valueForReadOnly, bool inverse) : this(targetProperty.Name, sourceProperty.Name, localArray1, inverse)
        {
            TValue[] localArray1 = new TValue[] { valueForReadOnly };
        }

        public ReadOnlyBoundToValueRule(Property targetProperty, TProperty sourceProperty, TValue[] valuesForReadOnly, bool inverse) : this(targetProperty.Name, sourceProperty.Name, valuesForReadOnly, inverse)
        {
        }

        public ReadOnlyBoundToValueRule(object targetPropertyName, object sourcePropertyName, TValue valueForReadOnly, bool inverse) : this(targetPropertyName, sourcePropertyName, localArray1, inverse)
        {
            TValue[] localArray1 = new TValue[] { valueForReadOnly };
        }

        public ReadOnlyBoundToValueRule(object targetPropertyName, object sourcePropertyName, TValue[] valuesForReadOnly, bool inverse)
        {
            this.targetPropertyName = targetPropertyName.ToString();
            this.sourcePropertyName = sourcePropertyName.ToString();
            this.valuesForReadOnly = valuesForReadOnly.CloneT<TValue>();
            this.inverse = inverse;
        }

        public override PropertyCollectionRule Clone() => 
            new ReadOnlyBoundToValueRule<TValue, TProperty>(this.targetPropertyName, this.sourcePropertyName, this.valuesForReadOnly, this.inverse);

        protected override void OnInitialized()
        {
            Property property = base.Owner[this.targetPropertyName];
            TProperty sourceProperty = (TProperty) base.Owner[this.sourcePropertyName];
            if (string.Compare(property.Name, sourceProperty.Name, StringComparison.InvariantCulture) == 0)
            {
                throw new ArgumentException("source and target properties must be different");
            }
            this.Sync();
            sourceProperty.ValueChanged += (s, e) => ((ReadOnlyBoundToValueRule<TValue, TProperty>) this).OnSourcePropertyValueChanged(sourceProperty, e.Value);
        }

        private void OnSourcePropertyValueChanged(Property sender, TValue newVal)
        {
            this.Sync();
        }

        private void Sync()
        {
            Property property = base.Owner[this.targetPropertyName];
            TProperty local = (TProperty) base.Owner[this.sourcePropertyName];
            bool flag = false;
            foreach (TValue local2 in this.valuesForReadOnly)
            {
                if (local2.Equals(local.Value))
                {
                    flag = true;
                    break;
                }
            }
            property.ReadOnly = flag ^ this.inverse;
        }
    }
}

