namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public sealed class PropertyCollection : INotifyPropertyChanged, IEnumerable<Property>, IEnumerable, ICloneable
    {
        private bool eventAddAllowed;
        private Dictionary<string, Property> properties;
        private Dictionary<Property, ValueEventHandler<bool>> readOnlyChangedHandlers;
        private List<PropertyCollectionRule> rules;
        private Dictionary<Property, ValueEventHandler<object>> valueChangedHandlers;

        [field: CompilerGenerated]
        public event PropertyChangedEventHandler PropertyChanged;

        public PropertyCollection(IEnumerable<Property> properties)
        {
            this.eventAddAllowed = true;
            this.properties = new Dictionary<string, Property>();
            this.rules = new List<PropertyCollectionRule>();
            this.valueChangedHandlers = new Dictionary<Property, ValueEventHandler<object>>();
            this.readOnlyChangedHandlers = new Dictionary<Property, ValueEventHandler<bool>>();
            this.Initialize(properties, Array.Empty<PropertyCollectionRule>());
        }

        public PropertyCollection(IEnumerable<Property> properties, IEnumerable<PropertyCollectionRule> rules)
        {
            this.eventAddAllowed = true;
            this.properties = new Dictionary<string, Property>();
            this.rules = new List<PropertyCollectionRule>();
            this.valueChangedHandlers = new Dictionary<Property, ValueEventHandler<object>>();
            this.readOnlyChangedHandlers = new Dictionary<Property, ValueEventHandler<bool>>();
            this.Initialize(properties, rules);
        }

        internal IDisposable BeginEventAddMoratorium()
        {
            if (!this.eventAddAllowed)
            {
                ExceptionUtil.ThrowInvalidOperationException("An event add moratorium is already in effect");
            }
            List<IDisposable> second = new List<IDisposable>(this.properties.Count);
            using (Dictionary<string, Property>.ValueCollection.Enumerator enumerator = this.properties.Values.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    IDisposable item = enumerator.Current.BeginEventAddMoratorium();
                    second.Add(item);
                }
            }
            IDisposable tail = Disposable.FromAction(delegate {
                this.eventAddAllowed = true;
            }, false);
            this.eventAddAllowed = false;
            return Disposable.Combine(Enumerable.Empty<IDisposable>().Concat<IDisposable>(tail).Concat<IDisposable>(second), false);
        }

        public PropertyCollection Clone()
        {
            List<Property> properties = new List<Property>();
            using (IEnumerator<Property> enumerator = this.Properties.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Property item = enumerator.Current.Clone();
                    properties.Add(item);
                }
            }
            List<PropertyCollectionRule> rules = new List<PropertyCollectionRule>();
            using (List<PropertyCollectionRule>.Enumerator enumerator2 = this.rules.GetEnumerator())
            {
                while (enumerator2.MoveNext())
                {
                    PropertyCollectionRule rule = enumerator2.Current.Clone();
                    rules.Add(rule);
                }
            }
            return new PropertyCollection(properties, rules);
        }

        public void CopyCompatibleValuesFrom(PropertyCollection srcProps)
        {
            this.CopyCompatibleValuesFrom(srcProps, false);
        }

        public void CopyCompatibleValuesFrom(PropertyCollection srcProps, bool ignoreReadOnlyFlags)
        {
            foreach (Property property in srcProps)
            {
                Property property2 = this[property.Name];
                if ((property2 != null) && (property2.ValueType == property.ValueType))
                {
                    if (property2.ReadOnly & ignoreReadOnlyFlags)
                    {
                        property2.ReadOnly = false;
                        property2.Value = property.Value;
                        property2.ReadOnly = true;
                    }
                    else
                    {
                        property2.Value = property.Value;
                    }
                }
            }
        }

        public static PropertyCollection CreateEmpty() => 
            new PropertyCollection(Array.Empty<Property>());

        public static PropertyCollection CreateMerged(PropertyCollection pc1, PropertyCollection pc2)
        {
            foreach (Property property in pc1.Properties)
            {
                if (pc2[property.Name] != null)
                {
                    throw new ArgumentException("pc1 must not have any properties with the same name as in pc2");
                }
            }
            Property[] properties = new Property[pc1.Count + pc2.Count];
            int index = 0;
            foreach (Property property2 in pc1)
            {
                properties[index] = property2.Clone();
                index++;
            }
            foreach (Property property3 in pc2)
            {
                properties[index] = property3.Clone();
                index++;
            }
            List<PropertyCollectionRule> rules = new List<PropertyCollectionRule>();
            foreach (PropertyCollectionRule rule in pc1.Rules)
            {
                rules.Add(rule);
            }
            foreach (PropertyCollectionRule rule2 in pc2.Rules)
            {
                rules.Add(rule2);
            }
            return new PropertyCollection(properties, rules);
        }

        public IEnumerator<Property> GetEnumerator() => 
            this.Properties.GetEnumerator();

        private void HookUpEvents()
        {
            using (Dictionary<string, Property>.ValueCollection.Enumerator enumerator = this.properties.Values.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ValueEventHandler<object> handler;
                    ValueEventHandler<bool> handler3;
                    Property property = enumerator.Current;
                    if (this.valueChangedHandlers.TryGetValue(property, out handler))
                    {
                        property.ValueChanged -= handler;
                    }
                    ValueEventHandler<object> handler2 = (s, e) => this.OnPropertyValueChanged(property, e.Value);
                    property.ValueChanged += handler2;
                    this.valueChangedHandlers.Add(property, handler2);
                    if (this.readOnlyChangedHandlers.TryGetValue(property, out handler3))
                    {
                        property.ReadOnlyChanged -= handler3;
                    }
                    ValueEventHandler<bool> handler4 = (s, e) => this.OnPropertyReadOnlyChanged(property, e.Value);
                    property.ReadOnlyChanged += handler4;
                    this.readOnlyChangedHandlers.Add(property, handler4);
                }
            }
        }

        private void Initialize(IEnumerable<Property> properties, IEnumerable<PropertyCollectionRule> rules)
        {
            using (IEnumerator<Property> enumerator = properties.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Property property = enumerator.Current.Clone();
                    this.properties.Add(property.Name, property);
                }
            }
            using (IEnumerator<PropertyCollectionRule> enumerator2 = rules.GetEnumerator())
            {
                while (enumerator2.MoveNext())
                {
                    PropertyCollectionRule item = enumerator2.Current.Clone();
                    this.rules.Add(item);
                }
            }
            using (List<PropertyCollectionRule>.Enumerator enumerator3 = this.rules.GetEnumerator())
            {
                while (enumerator3.MoveNext())
                {
                    enumerator3.Current.Initialize(this);
                }
            }
            this.HookUpEvents();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnPropertyReadOnlyChanged(Property sender, bool newReadOnlyValue)
        {
            this.OnPropertyChanged(sender.Name);
        }

        private void OnPropertyValueChanged(Property sender, object newValue)
        {
            this.OnPropertyChanged(sender.Name);
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        object ICloneable.Clone() => 
            this.Clone();

        public int Count =>
            this.properties.Count;

        public Property this[object propertyName]
        {
            get
            {
                Property property;
                string key = propertyName.ToString();
                this.properties.TryGetValue(key, out property);
                return property;
            }
        }

        public IEnumerable<Property> Properties =>
            this.properties.Values;

        public IEnumerable<string> PropertyNames =>
            this.properties.Keys;

        public IEnumerable<PropertyCollectionRule> Rules =>
            this.rules;
    }
}

