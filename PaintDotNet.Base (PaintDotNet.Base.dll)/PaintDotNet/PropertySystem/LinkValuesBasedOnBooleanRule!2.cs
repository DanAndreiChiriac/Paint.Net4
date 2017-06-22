namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public sealed class LinkValuesBasedOnBooleanRule<TValue, TProperty> : PropertyCollectionRule where TValue: struct, IComparable<TValue> where TProperty: ScalarProperty<TValue>
    {
        private readonly bool inverse;
        private string lastChangedPropertyName;
        private readonly string sourcePropertyName;
        private readonly string[] targetPropertyNames;

        public LinkValuesBasedOnBooleanRule(IEnumerable<TProperty> targetProperties, BooleanProperty sourceProperty, bool inverse) : this((from p in targetProperties select p.Name).ToArrayEx<string>(), sourceProperty.Name, inverse)
        {
        }

        public LinkValuesBasedOnBooleanRule(object[] targetPropertyNames, object sourcePropertyName, bool inverse)
        {
            if (targetPropertyNames.Length < 2)
            {
                throw new ArgumentException("Must have at least 2 items in targetPropertyNames");
            }
            this.targetPropertyNames = new string[targetPropertyNames.Length];
            for (int i = 0; i < this.targetPropertyNames.Length; i++)
            {
                this.targetPropertyNames[i] = targetPropertyNames[i].ToString();
            }
            this.sourcePropertyName = sourcePropertyName.ToString();
            this.inverse = inverse;
            this.lastChangedPropertyName = this.targetPropertyNames[0];
        }

        public override PropertyCollectionRule Clone() => 
            new LinkValuesBasedOnBooleanRule<TValue, TProperty>(this.targetPropertyNames, this.sourcePropertyName, this.inverse);

        protected override void OnInitialized()
        {
            if (-1 != Array.IndexOf<string>(this.targetPropertyNames, this.sourcePropertyName))
            {
                throw new ArgumentException("sourceProperty may not be in the list of targetProperties");
            }
            HashSet<string> set = null;
            foreach (LinkValuesBasedOnBooleanRule<TValue, TProperty> rule in base.Owner.Rules)
            {
                if ((rule != null) && (this != rule))
                {
                    if (set == null)
                    {
                        set = new HashSet<string>(this.targetPropertyNames);
                    }
                    HashSet<string> set2 = new HashSet<string>(rule.targetPropertyNames);
                    if (HashSetUtil.Intersect<string>(set, set2).Count != 0)
                    {
                        throw new ArgumentException("Cannot assign a property to be linked with more than one LinkValuesBasedOnBooleanRule instance");
                    }
                }
            }
            TProperty local = (TProperty) base.Owner[this.targetPropertyNames[0]];
            foreach (string str in this.targetPropertyNames)
            {
                TProperty targetProperty = (TProperty) base.Owner[str];
                if (targetProperty == null)
                {
                    throw new ArgumentException("All of the target properties must be of type TProperty (" + typeof(TProperty).FullName + ")");
                }
                if (!ScalarProperty<TValue>.IsEqualTo(targetProperty.MinValue, local.MinValue) || !ScalarProperty<TValue>.IsEqualTo(targetProperty.MaxValue, local.MaxValue))
                {
                    throw new ArgumentException("All of the target properties must have the same min/max range");
                }
                targetProperty.ValueChanged += (s, e) => ((LinkValuesBasedOnBooleanRule<TValue, TProperty>) this).OnTargetPropertyValueChanged(targetProperty, e.Value);
            }
            BooleanProperty sourceProperty = (BooleanProperty) base.Owner[this.sourcePropertyName];
            sourceProperty.ValueChanged += (s, e) => ((LinkValuesBasedOnBooleanRule<TValue, TProperty>) this).OnSourcePropertyValueChanged(sourceProperty, e.Value);
            this.Sync();
        }

        private void OnSourcePropertyValueChanged(Property sender, bool newValue)
        {
            this.Sync();
        }

        private void OnTargetPropertyValueChanged(Property sender, TValue newValue)
        {
            this.lastChangedPropertyName = ((TProperty) sender).Name;
            this.Sync();
        }

        private void Sync()
        {
            if (((BooleanProperty) base.Owner[this.sourcePropertyName]).Value ^ this.inverse)
            {
                TValue local = ((TProperty) base.Owner[this.lastChangedPropertyName]).Value;
                foreach (string str in this.targetPropertyNames)
                {
                    TProperty local2 = (TProperty) base.Owner[str];
                    if (local2.ReadOnly)
                    {
                        local2.ReadOnly = false;
                        local2.Value = local;
                        local2.ReadOnly = true;
                    }
                    else
                    {
                        local2.Value = local;
                    }
                }
            }
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly LinkValuesBasedOnBooleanRule<TValue, TProperty>.<>c <>9;
            public static Func<TProperty, string> <>9__4_0;

            static <>c()
            {
                LinkValuesBasedOnBooleanRule<TValue, TProperty>.<>c.<>9 = new LinkValuesBasedOnBooleanRule<TValue, TProperty>.<>c();
            }

            internal string <.ctor>b__4_0(TProperty p) => 
                p.Name;
        }
    }
}

