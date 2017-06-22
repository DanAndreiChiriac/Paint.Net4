namespace PaintDotNet
{
    using System;

    public abstract class PooledEventArgs<TDerivedArgs, TValue1> : PooledEventArgs<TDerivedArgs> where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1>, new()
    {
        private TValue1 value1;

        protected override void ClearValues()
        {
            this.value1 = default(TValue1);
        }

        public override TDerivedArgs Clone() => 
            PooledEventArgs<TDerivedArgs, TValue1>.Get(this.Value1);

        protected internal static TDerivedArgs Get(TValue1 value1)
        {
            TDerivedArgs local1 = PooledEventArgs<TDerivedArgs>.Get();
            local1.SetValues(value1);
            local1.Validate();
            return local1;
        }

        private void SetValues(TValue1 value1)
        {
            this.value1 = value1;
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
    }
}

