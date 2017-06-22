namespace PaintDotNet
{
    using PaintDotNet.Diagnostics;
    using PaintDotNet.IO;
    using PaintDotNet.Serialization;
    using System;
    using System.Collections;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable]
    public abstract class ReferenceValue : ICloneable, IEquatable<ReferenceValue>, IDeserializationCallback
    {
        [NonSerialized]
        private int? hashCode;
        [NonSerialized]
        private InstantiationSource instantiationSource = InstantiationSource.Constructor;

        protected ReferenceValue()
        {
        }

        private static bool AreFieldValuesEqual(object fieldValue1, object fieldValue2)
        {
            if (fieldValue1 == fieldValue2)
            {
                return true;
            }
            bool flag = fieldValue1 == null;
            bool flag2 = fieldValue2 == null;
            if (flag & flag2)
            {
                return true;
            }
            if (flag | flag2)
            {
                return false;
            }
            if (fieldValue1.GetType() != fieldValue2.GetType())
            {
                return false;
            }
            if ((fieldValue1 is IEnumerable) && (fieldValue2 is IEnumerable))
            {
                return ((IEnumerable) fieldValue1).Cast<object>().SequenceEqual<object>(((IEnumerable) fieldValue2).Cast<object>());
            }
            return EquatableUtil.Equals(fieldValue1, fieldValue2);
        }

        private int CalculateHashCodeViaReflection()
        {
            int num = 0;
            foreach (FieldInfo info in TypeUtil.GetAllFields(base.GetType()))
            {
                if (info.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length == 0)
                {
                    int num2 = CreateFieldHashCode(info.GetValue(this));
                    num = HashCodeUtil.CombineHashCodes(num, num2);
                }
            }
            return num;
        }

        private void ClearCachedHashCode()
        {
            ReferenceValue value2 = this;
            lock (value2)
            {
                this.hashCode = null;
            }
        }

        public ReferenceValue Clone() => 
            this.CloneCore<ReferenceValue>();

        protected TResult CloneCore<TResult>() where TResult: ReferenceValue
        {
            using (SegmentedMemoryStream stream = new SegmentedMemoryStream())
            {
                SerializationFallbackBinder binder = new SerializationFallbackBinder();
                binder.SetNextRequiredBaseType(typeof(TResult));
                BinaryFormatter formatter1 = new BinaryFormatter {
                    Binder = binder
                };
                formatter1.Serialize(stream, this);
                stream.Seek(0L, SeekOrigin.Begin);
                GC.KeepAlive(this);
                return (TResult) formatter1.Deserialize(stream);
            }
        }

        private static int CreateFieldHashCode(object fieldValue)
        {
            if (fieldValue == null)
            {
                return 0;
            }
            if (fieldValue is IEnumerable)
            {
                return HashCodeUtil.CreateHashCode<object>(((IEnumerable) fieldValue).Cast<object>());
            }
            return fieldValue.GetHashCode();
        }

        public bool Equals(ReferenceValue other) => 
            this.EqualsCore(other);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ReferenceValue, object>(this, obj);

        protected bool EqualsCore(ReferenceValue other)
        {
            if (this == other)
            {
                return true;
            }
            if (other == null)
            {
                return false;
            }
            if (other.GetType() != base.GetType())
            {
                return false;
            }
            if (this.GetHashCode() != other.GetHashCode())
            {
                return false;
            }
            return this.EqualsViaReflection(other);
        }

        private bool EqualsViaReflection(ReferenceValue other)
        {
            if (other == null)
            {
                return false;
            }
            foreach (FieldInfo info in TypeUtil.GetAllFields(base.GetType()))
            {
                if (info.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length == 0)
                {
                    object obj2 = info.GetValue(this);
                    object obj3 = info.GetValue(other);
                    if (!AreFieldValuesEqual(obj2, obj3))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            ReferenceValue value2 = this;
            lock (value2)
            {
                int? hashCode = this.hashCode;
                if (hashCode.HasValue)
                {
                    return hashCode.Value;
                }
            }
            int num = this.CalculateHashCodeViaReflection();
            value2 = this;
            lock (value2)
            {
                this.hashCode = new int?(num);
            }
            return num;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            this.OnDeserializedThis(context);
        }

        protected virtual void OnDeserializedGraph()
        {
        }

        protected virtual void OnDeserializedThis(StreamingContext context)
        {
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            this.instantiationSource = InstantiationSource.Deserialization;
            this.OnDeserializingThis(context);
        }

        protected virtual void OnDeserializingThis(StreamingContext context)
        {
        }

        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            this.OnSerializedThis(context);
        }

        protected virtual void OnSerializedThis(StreamingContext context)
        {
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            this.OnSerializingThis(context);
        }

        protected virtual void OnSerializingThis(StreamingContext context)
        {
        }

        public static bool operator ==(ReferenceValue a, ReferenceValue b) => 
            EquatableUtil.OperatorEquals<ReferenceValue>(a, b);

        public static bool operator !=(ReferenceValue a, ReferenceValue b) => 
            !(a == b);

        object ICloneable.Clone() => 
            this.Clone();

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            this.OnDeserializedGraph();
        }

        protected ChangeScope UseChangeScope() => 
            new ChangeScope(this);

        [StructLayout(LayoutKind.Sequential)]
        protected struct ChangeScope : IDisposable
        {
            private ReferenceValue owner;
            internal ChangeScope(ReferenceValue owner)
            {
                Validate.IsNotNull<ReferenceValue>(owner, "owner");
                this.owner = owner;
            }

            public void Dispose()
            {
                if (this.owner != null)
                {
                    this.owner.ClearCachedHashCode();
                    this.owner = null;
                }
            }
        }

        private enum InstantiationSource
        {
            Unknown,
            Constructor,
            Deserialization
        }
    }
}

