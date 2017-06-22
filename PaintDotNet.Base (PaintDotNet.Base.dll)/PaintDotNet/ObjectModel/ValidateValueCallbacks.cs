namespace PaintDotNet.ObjectModel
{
    using PaintDotNet;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows;

    public static class ValidateValueCallbacks
    {
        public static readonly ValidateValueCallback DoubleIsFinite = new ValidateValueCallback(<>c.<>9.<.cctor>b__7_0);
        public static readonly ValidateValueCallback DoubleIsNaNOrFinite = new ValidateValueCallback(<>c.<>9.<.cctor>b__7_1);
        public static readonly ValidateValueCallback DoubleIsNaNOrPositiveFinite = new ValidateValueCallback(<>c.<>9.<.cctor>b__7_2);
        public static readonly ValidateValueCallback DoubleIsNaNOrPositiveInfinityOrPositiveFinite = new ValidateValueCallback(<>c.<>9.<.cctor>b__7_3);
        public static readonly ValidateValueCallback NullablePointDoubleIsNullOrFinite = new ValidateValueCallback(<>c.<>9.<.cctor>b__7_5);
        public static readonly ValidateValueCallback PointDoubleIsFinite = new ValidateValueCallback(<>c.<>9.<.cctor>b__7_4);
        public static readonly ValidateValueCallback VectorDoubleIsFinite = new ValidateValueCallback(<>c.<>9.<.cctor>b__7_6);

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly ValidateValueCallbacks.<>c <>9 = new ValidateValueCallbacks.<>c();

            internal bool <.cctor>b__7_0(object v) => 
                ((v is double) && ((double) v).IsFinite());

            internal bool <.cctor>b__7_1(object v)
            {
                if (!(v is double))
                {
                    return false;
                }
                if (!((double) v).IsFinite())
                {
                    return double.IsNaN((double) v);
                }
                return true;
            }

            internal bool <.cctor>b__7_2(object v)
            {
                double d = (double) v;
                return (double.IsNaN(d) || ((d >= 0.0) && d.IsFinite()));
            }

            internal bool <.cctor>b__7_3(object v)
            {
                double d = (double) v;
                return ((double.IsNaN(d) || double.IsPositiveInfinity(d)) || ((d >= 0.0) && d.IsFinite()));
            }

            internal bool <.cctor>b__7_4(object v)
            {
                PointDouble num = (PointDouble) v;
                return num.IsFinite;
            }

            internal bool <.cctor>b__7_5(object v)
            {
                PointDouble? nullable = (PointDouble?) v;
                return (!nullable.HasValue || nullable.Value.IsFinite);
            }

            internal bool <.cctor>b__7_6(object v)
            {
                VectorDouble num = (VectorDouble) v;
                return num.IsFinite;
            }
        }
    }
}

