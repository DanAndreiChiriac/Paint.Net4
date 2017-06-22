namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using System;

    public sealed class ReadOnlyBoundToBooleanRule : PropertyCollectionRule
    {
        private readonly bool inverse;
        private readonly string sourceBooleanPropertyName;
        private readonly string targetPropertyName;

        public ReadOnlyBoundToBooleanRule(Property targetProperty, BooleanProperty sourceProperty, bool inverse) : this(targetProperty.Name, sourceProperty.Name, inverse)
        {
        }

        public ReadOnlyBoundToBooleanRule(object targetPropertyName, object sourceBooleanPropertyName, bool inverse)
        {
            this.targetPropertyName = targetPropertyName.ToString();
            this.sourceBooleanPropertyName = sourceBooleanPropertyName.ToString();
            this.inverse = inverse;
        }

        public override PropertyCollectionRule Clone() => 
            new ReadOnlyBoundToBooleanRule(this.targetPropertyName, this.sourceBooleanPropertyName, this.inverse);

        protected override void OnInitialized()
        {
            Property property = base.Owner[this.targetPropertyName];
            BooleanProperty sourceProperty = (BooleanProperty) base.Owner[this.sourceBooleanPropertyName];
            if (string.Compare(property.Name, sourceProperty.Name, StringComparison.InvariantCulture) == 0)
            {
                throw new ArgumentException("source and target properties must be different");
            }
            this.Sync();
            sourceProperty.ValueChanged += (s, e) => this.OnSourcePropertyValueChanged(sourceProperty, e.Value);
        }

        private void OnSourcePropertyValueChanged(Property sender, bool newVal)
        {
            this.Sync();
        }

        private void Sync()
        {
            base.Owner[this.targetPropertyName].ReadOnly = ((BooleanProperty) base.Owner[this.sourceBooleanPropertyName]).Value ^ this.inverse;
        }
    }
}

