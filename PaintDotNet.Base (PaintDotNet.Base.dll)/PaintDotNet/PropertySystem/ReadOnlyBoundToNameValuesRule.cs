namespace PaintDotNet.PropertySystem
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public sealed class ReadOnlyBoundToNameValuesRule : PropertyCollectionRule
    {
        private readonly bool inverse;
        private readonly TupleStruct<string, object>[] sourcePropertyNameValuePairs;
        private readonly string targetPropertyName;

        [Obsolete("Use the overload", true)]
        public ReadOnlyBoundToNameValuesRule(object targetPropertyName, bool inverse, params Pair<object, object>[] sourcePropertyNameValuePairs) : this(targetPropertyName, inverse, sourcePropertyNameValuePairs.Select<Pair<object, object>, TupleStruct<object, object>>(p => ((TupleStruct<object, object>) p)).ToArrayEx<TupleStruct<object, object>>())
        {
        }

        public ReadOnlyBoundToNameValuesRule(object targetPropertyName, bool inverse, params TupleStruct<object, object>[] sourcePropertyNameValuePairs)
        {
            this.targetPropertyName = targetPropertyName.ToString();
            this.inverse = inverse;
            this.sourcePropertyNameValuePairs = sourcePropertyNameValuePairs.Select<TupleStruct<object, object>, TupleStruct<string, object>>(p => TupleStruct.Create<string, object>(p.Item1.ToString(), p.Item2)).ToArrayEx<TupleStruct<string, object>>();
        }

        public override PropertyCollectionRule Clone() => 
            new ReadOnlyBoundToNameValuesRule(this.targetPropertyName, this.inverse, this.sourcePropertyNameValuePairs.Select<TupleStruct<string, object>, TupleStruct<object, object>>(t => TupleStruct.Create<object, object>(t.Item1, t.Item2)).ToArrayEx<TupleStruct<object, object>>());

        protected override void OnInitialized()
        {
            IEnumerable<Property> items = from name in this.sourcePropertyNameValuePairs.Select<TupleStruct<string, object>, string>(p => p.Item1).Distinct<string>() select base.Owner[name];
            items.ForEach<Property>(delegate (Property p) {
                if (string.Compare(this.targetPropertyName, p.Name, StringComparison.InvariantCulture) == 0)
                {
                    throw new ArgumentException("source and target properties must be different");
                }
            });
            items.ForEach<Property>(delegate (Property p) {
                p.ValueChanged += (s, e) => this.OnSourcePropertyValueChanged(p, e.Value);
            });
        }

        private void OnSourcePropertyValueChanged(Property sender, object newVal)
        {
            this.Sync();
        }

        private void Sync()
        {
            Property property = base.Owner[this.targetPropertyName];
            bool flag = false;
            foreach (TupleStruct<string, object> struct2 in this.sourcePropertyNameValuePairs)
            {
                string str = struct2.Item1;
                Property property2 = base.Owner[str];
                if (struct2.Item2.Equals(property2.Value))
                {
                    flag = true;
                    break;
                }
            }
            property.ReadOnly = flag ^ this.inverse;
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly ReadOnlyBoundToNameValuesRule.<>c <>9 = new ReadOnlyBoundToNameValuesRule.<>c();
            public static Func<Pair<object, object>, TupleStruct<object, object>> <>9__3_0;
            public static Func<TupleStruct<object, object>, TupleStruct<string, object>> <>9__4_0;
            public static Func<TupleStruct<string, object>, string> <>9__5_0;
            public static Func<TupleStruct<string, object>, TupleStruct<object, object>> <>9__8_0;

            internal TupleStruct<object, object> <.ctor>b__3_0(Pair<object, object> p) => 
                ((TupleStruct<object, object>) p);

            internal TupleStruct<string, object> <.ctor>b__4_0(TupleStruct<object, object> p) => 
                TupleStruct.Create<string, object>(p.Item1.ToString(), p.Item2);

            internal TupleStruct<object, object> <Clone>b__8_0(TupleStruct<string, object> t) => 
                TupleStruct.Create<object, object>(t.Item1, t.Item2);

            internal string <OnInitialized>b__5_0(TupleStruct<string, object> p) => 
                p.Item1;
        }
    }
}

