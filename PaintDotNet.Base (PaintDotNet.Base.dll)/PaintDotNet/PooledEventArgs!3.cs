namespace PaintDotNet
{
    using System;

    public abstract class PooledEventArgs<TDerivedArgs, TValue1, TValue2> : PooledEventArgs<TDerivedArgs> where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1, TValue2>, new()
    {
        private TValue1 value1;
        private TValue2 value2;

        protected override void ClearValues()
        {
            this.value1 = default(TValue1);
            this.value2 = default(TValue2);
        }

        public override TDerivedArgs Clone() => 
            PooledEventArgs<TDerivedArgs, TValue1, TValue2>.Get(this.Value1, this.Value2);

        protected internal static TDerivedArgs Get(TValue1 value1, TValue2 value2)
        {
            TDerivedArgs local1 = PooledEventArgs<TDerivedArgs>.Get();
            local1.SetValues(value1, value2);
            local1.Validate();
            return local1;
        }

        private void SetValues(TValue1 value1, TValue2 value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        protected TValue1 Value1
        {
            get
            {
                base.VerifyIsValid();
                return this.value1;
            }
            set
            {
                base.VerifyIsValid();
                this.value1 = value;
            }
        }

        protected TValue2 Value2
        {
            get
            {
                base.VerifyIsValid();
                return this.value2;
            }
            set
            {
                base.VerifyIsValid();
                this.value2 = value;
            }
        }
    }
}

