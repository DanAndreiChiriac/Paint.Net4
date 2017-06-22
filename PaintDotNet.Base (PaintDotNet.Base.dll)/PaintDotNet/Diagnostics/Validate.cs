namespace PaintDotNet.Diagnostics
{
    using PaintDotNet;
    using System;
    using System.Runtime.CompilerServices;

    public static class Validate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AreEqual(bool value, bool comparisonValue, string valueName)
        {
            if (value != comparisonValue)
            {
                AreEqualThrow(value, comparisonValue, valueName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AreEqual(int value, int comparisonValue, string valueName, string comparisonName)
        {
            if (value != comparisonValue)
            {
                AreEqualThrow(value, comparisonValue, valueName, comparisonName);
            }
        }

        private static void AreEqualThrow(bool value, bool comparisonValue, string valueName)
        {
            ExceptionUtil.ThrowArgumentException(valueName, $"{valueName}={value.ToString()} must be equal to {comparisonValue.ToString()}");
        }

        private static void AreEqualThrow(int value, int comparisonValue, string valueName, string comparisonName)
        {
            ExceptionUtil.ThrowArgumentException(valueName, $"{valueName}={value.ToString()} must be equal to {comparisonName}={comparisonValue.ToString()}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation Begin() => 
            null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConditionIsFalse(bool value, string errorWhenTrue)
        {
            if (value)
            {
                ConditionIsFalseThrow(errorWhenTrue);
            }
        }

        private static void ConditionIsFalseThrow(string errorWhenTrue)
        {
            ExceptionUtil.ThrowInvalidOperationException(errorWhenTrue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConditionIsTrue(bool value, string errorWhenFalse)
        {
            if (!value)
            {
                ConditionIsTrueThrow(errorWhenFalse);
            }
        }

        private static void ConditionIsTrueThrow(string errorWhenFalse)
        {
            ExceptionUtil.ThrowInvalidOperationException(errorWhenFalse);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsClamped(double value, double min, double max, string valueName)
        {
            if (!DoubleUtil.SafeIsClamped(value, min, max))
            {
                IsClampedThrow(value, min, max, valueName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsClamped(int value, int min, int max, string valueName)
        {
            if (!Int32Util.SafeIsClamped(value, min, max))
            {
                IsClampedThrow(value, min, max, valueName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsClamped(long value, long min, long max, string valueName)
        {
            if (!Int64Util.SafeIsClamped(value, min, max))
            {
                IsClampedThrow(value, min, max, valueName);
            }
        }

        private static void IsClampedThrow(double value, double min, double max, string valueName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{valueName}:{typeof(double).Name}={value}, min={min}, max={max}");
        }

        private static void IsClampedThrow(int value, int min, int max, string valueName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{valueName}:{typeof(int).Name}={value}, min={min}, max={max}");
        }

        private static void IsClampedThrow(long value, long min, long max, string valueName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{valueName}:{typeof(long).Name}={value}, min={min}, max={max}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsFinite(double value, string paramName)
        {
            if (!value.IsFinite())
            {
                IsFiniteThrow(value, paramName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsFinite(float value, string paramName)
        {
            if (!value.IsFinite())
            {
                IsFiniteThrow(value, paramName);
            }
        }

        private static void IsFiniteThrow(double value, string paramName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{paramName}:{typeof(double).Name}={value}", "must be finite");
        }

        private static void IsFiniteThrow(float value, string paramName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{paramName}:{typeof(float).Name}={value}", "must be finite");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsGreaterThan(long value, long greaterThan, string valueName)
        {
            if (value <= greaterThan)
            {
                IsGreaterThanThrow(value, greaterThan, valueName);
            }
        }

        private static void IsGreaterThanThrow(long value, long greaterThan, string valueName)
        {
            ExceptionUtil.ThrowArgumentException(valueName, $"{valueName}={value.ToString("N0")} must be greater than {greaterThan.ToString("N0")}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsLessThan(long value, long lessThan, string valueName)
        {
            if (value >= lessThan)
            {
                IsLessThanThrow(value, lessThan, valueName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsLessThanOrEqualTo(long value, long lessThanOrEqual, string valueName)
        {
            if (value > lessThanOrEqual)
            {
                IsLessThanOrEqualToThrow(value, lessThanOrEqual, valueName);
            }
        }

        private static void IsLessThanOrEqualToThrow(long value, long lessThanOrEqual, string valueName)
        {
            ExceptionUtil.ThrowArgumentException(valueName, $"{valueName}={value.ToString("N0")} must be less than or equal to {lessThanOrEqual.ToString("N0")}");
        }

        private static void IsLessThanThrow(long value, long lessThan, string valueName)
        {
            ExceptionUtil.ThrowArgumentException(valueName, $"{valueName}={value.ToString("N0")} must be less than {lessThan.ToString("N0")}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotDisposed<T>(T param, string paramName) where T: IIsDisposed
        {
            if (param.IsDisposed)
            {
                IsNotDisposedThrow<T>(param, paramName);
            }
        }

        private static void IsNotDisposedThrow<T>(T param, string paramName) where T: IIsDisposed
        {
            ExceptionUtil.ThrowObjectDisposedException($"{paramName}:{param.GetType().Name}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNegative(double value, string paramName)
        {
            if (value < 0.0)
            {
                IsNotNegativeThrow(value, paramName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNegative(int value, string paramName)
        {
            if (value < 0)
            {
                IsNotNegativeThrow(value, paramName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNegative(long value, string paramName)
        {
            if (value < 0L)
            {
                IsNotNegativeThrow(value, paramName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNegative(float value, string paramName)
        {
            if (value < 0f)
            {
                IsNotNegativeThrow(value, paramName);
            }
        }

        private static void IsNotNegativeThrow(double value, string paramName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{paramName}:{typeof(double).Name}={value}", "must be non-negative");
        }

        private static void IsNotNegativeThrow(int value, string paramName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{paramName}:{typeof(int).Name}={value}", "must be non-negative");
        }

        private static void IsNotNegativeThrow(long value, string paramName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{paramName}:{typeof(long).Name}={value}", "must be non-negative");
        }

        private static void IsNotNegativeThrow(float value, string paramName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{paramName}:{typeof(float).Name}={value}", "must be non-negative");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T IsNotNull<T>(T param) where T: class
        {
            if (param == null)
            {
                ExceptionUtil.ThrowArgumentNullException();
            }
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void IsNotNull(void* param, string paramName)
        {
            if (param == null)
            {
                ExceptionUtil.ThrowArgumentNullException(paramName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T IsNotNull<T>(T param, string paramName) where T: class
        {
            if (param == null)
            {
                ExceptionUtil.ThrowArgumentNullException(paramName);
            }
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNull<T>(T param, string paramNameFormat, int arg0)
        {
            if (param == null)
            {
                IsNotNullThrow(paramNameFormat, arg0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNull<T>(T param, string paramNameFormat, object arg0)
        {
            if (param == null)
            {
                IsNotNullThrow(paramNameFormat, arg0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNull<T>(T param, string paramNameFormat, params object[] args)
        {
            if (param == null)
            {
                IsNotNullThrow(paramNameFormat, args);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNullIfRefType<T>(ref T theObject, string paramName)
        {
            if (!typeof(T).IsValueType && (((T) theObject) == null))
            {
                ExceptionUtil.ThrowArgumentNullException(paramName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNullOrWhiteSpace(string param, string paramName)
        {
            if (param == null)
            {
                ExceptionUtil.ThrowArgumentNullException(paramName);
            }
            else if (string.IsNullOrWhiteSpace(param))
            {
                ExceptionUtil.ThrowArgumentException(paramName);
            }
        }

        private static void IsNotNullThrow(string paramNameFormat, int arg0)
        {
            ExceptionUtil.ThrowArgumentNullException(string.Format(paramNameFormat, arg0.ToString()));
        }

        private static void IsNotNullThrow(string paramNameFormat, object arg0)
        {
            ExceptionUtil.ThrowArgumentNullException(string.Format(paramNameFormat, arg0.ToString()));
        }

        private static void IsNotNullThrow(string paramNameFormat, object[] args)
        {
            ExceptionUtil.ThrowArgumentNullException(string.Format(paramNameFormat, args));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotZero(IntPtr param, string paramName)
        {
            if (param == IntPtr.Zero)
            {
                ExceptionUtil.ThrowArgumentNullException(paramName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsPositive(double value, string paramName)
        {
            if (value <= 0.0)
            {
                IsPositiveThrow(value, paramName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsPositive(int value, string paramName)
        {
            if (value <= 0)
            {
                IsPositiveThrow(value, paramName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsPositive(long value, string paramName)
        {
            if (value <= 0L)
            {
                IsPositiveThrow(value, paramName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsPositive(float value, string paramName)
        {
            if (value <= 0f)
            {
                IsPositiveThrow(value, paramName);
            }
        }

        private static void IsPositiveThrow(double value, string paramName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{paramName}:{typeof(double).Name}={value}", "must be positive");
        }

        private static void IsPositiveThrow(int value, string paramName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{paramName}:{typeof(int).Name}={value}", "must be positive");
        }

        private static void IsPositiveThrow(long value, string paramName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{paramName}:{typeof(long).Name}={value}", "must be positive");
        }

        private static void IsPositiveThrow(float value, string paramName)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException($"{paramName}:{typeof(float).Name}={value}", "must be positive");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsValid<T, TValidator>(TValidator validator, T value, string valueName) where TValidator: IValidator<T>
        {
            if (!validator.Check(value))
            {
                ExceptionUtil.Throw(validator.CreateException(value, valueName, null));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsValid<T, TValidator, TCriteria>(TValidator validator, TCriteria criteria, T value, string valueName) where TValidator: IValidator<T, TCriteria>
        {
            if (!validator.Check(criteria, value))
            {
                ExceptionUtil.Throw(validator.CreateException(criteria, value, valueName, null));
            }
        }
    }
}

