namespace PaintDotNet.Animation.Proxies
{
    using PaintDotNet;
    using PaintDotNet.Animation;
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class AnimationVariableProxy : ObjectRefProxyWithEvents<IAnimationVariable>, IAnimationVariable, IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        private static readonly Action<IAnimationVariable, Delegate> removeIntegerValueChangedHandler = new Action<IAnimationVariable, Delegate>(<>c.<>9.<.cctor>b__29_0);
        private static readonly Action<IAnimationVariable, Delegate> removeValueChangedHandler = new Action<IAnimationVariable, Delegate>(<>c.<>9.<.cctor>b__29_1);

        public event AnimationVariableValueChangedEventHandler<int> IntegerValueChanged
        {
            add
            {
                AnimationVariableValueChangedEventHandler<int> proxyHandler = (s, e) => value(this, e);
                base.AddEventHandler(value, proxyHandler, removeIntegerValueChangedHandler);
                base.innerRefT.IntegerValueChanged += proxyHandler;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)] remove
            {
                base.RemoveEventHandler(value, removeIntegerValueChangedHandler);
            }
        }

        public event AnimationVariableValueChangedEventHandler<double> ValueChanged
        {
            add
            {
                AnimationVariableValueChangedEventHandler<double> proxyHandler = (s, e) => value(this, e);
                base.AddEventHandler(value, proxyHandler, removeValueChangedHandler);
                base.innerRefT.ValueChanged += proxyHandler;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)] remove
            {
                base.RemoveEventHandler(value, removeValueChangedHandler);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnimationVariableProxy(IAnimationVariable objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLowerBound(double bound)
        {
            base.innerRefT.SetLowerBound(bound);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetRoundingMode(AnimationRoundingMode mode)
        {
            base.innerRefT.SetRoundingMode(mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetUpperBound(double bound)
        {
            base.innerRefT.SetUpperBound(bound);
        }

        public IAnimationStoryboard CurrentStoryboard =>
            base.innerRefT.CurrentStoryboard;

        public int FinalIntegerValue =>
            base.innerRefT.FinalIntegerValue;

        public double FinalValue =>
            base.innerRefT.FinalValue;

        public int IntegerValue =>
            base.innerRefT.IntegerValue;

        public int PreviousIntegerValue =>
            base.innerRefT.PreviousIntegerValue;

        public double PreviousValue =>
            base.innerRefT.PreviousValue;

        public object Tag
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.Tag;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Tag = value;
            }
        }

        public double Value =>
            base.innerRefT.Value;

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly AnimationVariableProxy.<>c <>9 = new AnimationVariableProxy.<>c();

            internal void <.cctor>b__29_0(IAnimationVariable innerRefT, Delegate handler)
            {
                innerRefT.IntegerValueChanged -= ((AnimationVariableValueChangedEventHandler<int>) handler);
            }

            internal void <.cctor>b__29_1(IAnimationVariable innerRefT, Delegate handler)
            {
                innerRefT.ValueChanged -= ((AnimationVariableValueChangedEventHandler<double>) handler);
            }
        }
    }
}

