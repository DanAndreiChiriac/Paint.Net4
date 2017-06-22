namespace PaintDotNet.Animation
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.CompilerServices;

    [NativeInterfaceID("8ceeb155-2849-4ce5-9448-91ff70e1e4d9")]
    public interface IAnimationVariable : IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        event AnimationVariableValueChangedEventHandler<int> IntegerValueChanged;

        event AnimationVariableValueChangedEventHandler<double> ValueChanged;

        void SetLowerBound(double bound);
        void SetRoundingMode(AnimationRoundingMode mode);
        void SetUpperBound(double bound);

        IAnimationStoryboard CurrentStoryboard { get; }

        int FinalIntegerValue { get; }

        double FinalValue { get; }

        int IntegerValue { get; }

        int PreviousIntegerValue { get; }

        double PreviousValue { get; }

        object Tag { get; set; }

        double Value { get; }
    }
}

