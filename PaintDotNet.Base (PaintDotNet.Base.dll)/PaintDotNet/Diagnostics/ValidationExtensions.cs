namespace PaintDotNet.Diagnostics
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    public static class ValidationExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation AreCountsEqual<T1, T2>(this Validation validation, IReadOnlyList<T1> list1, string list1Name, IReadOnlyList<T2> list2, string list2Name)
        {
            int count = list1.Count;
            int num2 = list2.Count;
            if (count != num2)
            {
                return AreCountsEqualThrow(validation, count, list1Name, num2, list2Name);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation AreCountsEqualThrow(Validation validation, int list1Count, string list1Name, int list2Count, string list2Name) => 
            validation.SafeAddException(new ArgumentException($"{list1Name}.Count({list1Count}) does not equal {list2Name}.Count({list2Count})"));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation AreEqual(this Validation validation, int val1, string val1Name, int val2, string val2Name)
        {
            if (val1 != val2)
            {
                return AreEqualThrow(validation, val1Name, val2Name);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation AreEqual<T>(this Validation validation, T val1, string val1Name, T val2, string val2Name) where T: IEquatable<T>
        {
            if (!val1.Equals(val2))
            {
                return AreEqualThrow(validation, val1Name, val2Name);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation AreEqualThrow(Validation validation, string val1Name, string val2Name) => 
            validation.SafeAddException(new ArgumentException($"{val1Name} must equal {val2Name}"));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation Check(this Validation validation)
        {
            if ((validation != null) && (validation.Exceptions != null))
            {
                ThrowValidationException(validation);
            }
            return validation;
        }

        public static Validation DoesNotContainNull<T>(this Validation validation, IEnumerable<T> list, string listName) where T: class
        {
            StringBuilder builder = null;
            bool flag = true;
            int num = 0;
            using (IEnumerator<T> enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current == null)
                    {
                        if (builder == null)
                        {
                            builder = new StringBuilder();
                            builder.Append(listName);
                            builder.Append("[");
                        }
                        if (!flag)
                        {
                            builder.Append(", ");
                        }
                        builder.Append(num.ToString());
                        flag = true;
                    }
                    num++;
                }
            }
            if (builder != null)
            {
                builder.Append("]");
                return validation.SafeAddException(new ArgumentNullException(builder.ToString()));
            }
            return validation;
        }

        public static Validation DoesNotContainNull<T>(this Validation validation, T[] array, string arrayName) where T: class
        {
            bool flag = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                return validation;
            }
            StringBuilder builder = new StringBuilder();
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] == null)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(", ");
                    }
                    builder.Append(j.ToString());
                }
            }
            builder.Insert(0, arrayName + "[");
            builder.Append("]");
            return validation.SafeAddException(new ArgumentNullException(builder.ToString()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsAssignableFrom(this Validation validation, Type baseType, Type derivedType)
        {
            if (!baseType.IsAssignableFrom(derivedType))
            {
                return IsAssignableFromThrow(validation, baseType, derivedType);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsAssignableFromThrow(Validation validation, Type baseType, Type derivedType) => 
            validation.SafeAddException(new InvalidCastException($"derivedType({derivedType.FullName}) is not assignable from baseType({baseType.FullName})"));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsFalse(this Validation validation, bool value, string message)
        {
            if (value)
            {
                return IsFalseThrow(validation, message);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsFalseThrow(Validation validation, string message) => 
            validation.SafeAddException(new InvalidOperationException(message));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsFinite(this Validation validation, double value, string valueName)
        {
            if (!value.IsFinite())
            {
                return IsFiniteThrow(validation, value, valueName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsFinite(this Validation validation, float value, string valueName)
        {
            if (!value.IsFinite())
            {
                return IsFiniteThrow(validation, value, valueName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsFiniteThrow(Validation validation, double value, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException(valueName, $"Value must be finite, not {value}"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsFiniteThrow(Validation validation, float value, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException(valueName, $"Value must be finite, not {value}"));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsGreaterThan(this Validation validation, double value, double greaterThan, string valueName)
        {
            if (value <= greaterThan)
            {
                return IsGreaterThanThrow(validation, value, greaterThan, valueName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsGreaterThan(this Validation validation, int value, int greaterThan, string valueName)
        {
            if (value <= greaterThan)
            {
                return IsGreaterThanThrow(validation, value, greaterThan, valueName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsGreaterThan(this Validation validation, long value, long greaterThan, string valueName)
        {
            if (value <= greaterThan)
            {
                return IsGreaterThanThrow(validation, value, greaterThan, valueName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsGreaterThanOrEqualTo(this Validation validation, double value, double greaterThanOrEqualTo, string valueName)
        {
            if (value < greaterThanOrEqualTo)
            {
                return IsGreaterThanOrEqualToThrow(validation, value, greaterThanOrEqualTo, valueName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsGreaterThanOrEqualTo(this Validation validation, int value, int greaterThanOrEqualTo, string valueName)
        {
            if (value < greaterThanOrEqualTo)
            {
                return IsGreaterThanOrEqualToThrow(validation, value, greaterThanOrEqualTo, valueName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsGreaterThanOrEqualTo(this Validation validation, long value, long greaterThanOrEqualTo, string valueName)
        {
            if (value < greaterThanOrEqualTo)
            {
                return IsGreaterThanOrEqualToThrow(validation, value, greaterThanOrEqualTo, valueName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsGreaterThanOrEqualToThrow(Validation validation, double value, double greaterThanOrEqualTo, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{valueName}:{valueName.GetType().Name}={value}, min={greaterThanOrEqualTo}"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsGreaterThanOrEqualToThrow(Validation validation, int value, int greaterThanOrEqualTo, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{valueName}:{valueName.GetType().Name}={value}, min={greaterThanOrEqualTo}"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsGreaterThanOrEqualToThrow(Validation validation, long value, long greaterThanOrEqualTo, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{valueName}:{valueName.GetType().Name}={value}, min={greaterThanOrEqualTo}"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsGreaterThanThrow(Validation validation, double value, double greaterThan, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{valueName}:{valueName.GetType().Name}={value}, min={greaterThan}"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsGreaterThanThrow(Validation validation, int value, int greaterThan, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{valueName}:{valueName.GetType().Name}={value}, min={greaterThan}"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsGreaterThanThrow(Validation validation, long value, long greaterThan, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{valueName}:{valueName.GetType().Name}={value}, min={greaterThan}"));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsIndexInBounds<T>(this Validation validation, IList<T> list, int index, string listName)
        {
            if ((index >= 0) && (index < list.Count))
            {
                return validation;
            }
            return IsIndexInBoundsThrow<T>(validation, list, index, listName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsIndexInBounds<T>(this Validation validation, T[] array, int index, string arrayName)
        {
            if ((index >= 0) && (index < array.Length))
            {
                return validation;
            }
            return IsIndexInBoundsThrow<T>(validation, array, index, arrayName);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsIndexInBoundsThrow<T>(Validation validation, IList<T> list, int index, string listName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{listName}={index}, array:{typeof(T).Name}.Count={list.Count}"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsIndexInBoundsThrow<T>(Validation validation, T[] array, int index, string arrayName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{arrayName}={index}, array:{typeof(T).Name}.Length={array.Length}"));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsNotDisposed<T>(this Validation validation, T param) where T: class, IIsDisposed
        {
            if (param.IsDisposed)
            {
                return IsNotDisposedThrow<T>(validation, param);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsNotDisposed<T>(this Validation validation, T param, string paramName) where T: class, IIsDisposed
        {
            if (param.IsDisposed)
            {
                return IsNotDisposedThrow<T>(validation, param, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotDisposedThrow<T>(Validation validation, T param) where T: class, IIsDisposed => 
            validation.SafeAddException(new ObjectDisposedException(param.GetType().Name));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotDisposedThrow<T>(Validation validation, T param, string paramName) where T: class, IIsDisposed => 
            validation.SafeAddException(new ObjectDisposedException($"{paramName}:{param.GetType().Name}"));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsNotEmpty(this Validation validation, string theString, string paramName)
        {
            if (theString.Length == 0)
            {
                return IsNotEmptyThrow(validation, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotEmptyThrow(Validation validation, string paramName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException(paramName));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsNotNegative(this Validation validation, double value, string paramName)
        {
            if (value < 0.0)
            {
                return IsNotNegativeThrow(validation, value, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsNotNegative(this Validation validation, int value, string paramName)
        {
            if (value < 0)
            {
                return IsNotNegativeThrow(validation, value, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsNotNegative(this Validation validation, long value, string paramName)
        {
            if (value < 0L)
            {
                return IsNotNegativeThrow(validation, value, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsNotNegative(this Validation validation, float value, string paramName)
        {
            if (value < 0f)
            {
                return IsNotNegativeThrow(validation, value, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotNegativeThrow(Validation validation, double value, string paramName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{paramName}:{typeof(double).Name}={value}", "must be non-negative"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotNegativeThrow(Validation validation, int value, string paramName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{paramName}:{typeof(int).Name}={value}", "must be non-negative"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotNegativeThrow(Validation validation, long value, string paramName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{paramName}:{typeof(long).Name}={value}", "must be non-negative"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotNegativeThrow(Validation validation, float value, string paramName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{paramName}:{typeof(float).Name}={value}", "must be non-negative"));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Validation IsNotNull(this Validation validation, void* pBuffer, string paramName)
        {
            if (pBuffer == null)
            {
                return IsNotNullThrow(validation, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsNotNull<T>(this Validation validation, T theObject, string paramName) where T: class
        {
            if (theObject == null)
            {
                return IsNotNullThrow(validation, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsNotNullIfRefType<T>(this Validation validation, ref T theObject, string paramName)
        {
            if (!TypeUtil.IsValueType<T>() && (((T) theObject) == null))
            {
                return IsNotNullIfRefTypeThrow(validation, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotNullIfRefTypeThrow(Validation validation, string paramName) => 
            validation.SafeAddException(new ArgumentNullException(paramName));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsNotNullOrWhiteSpace(this Validation validation, string theString, string paramName)
        {
            if (theString == null)
            {
                return IsNotNullOrWhiteSpaceThrowForNull(validation, paramName);
            }
            if (string.IsNullOrWhiteSpace(theString))
            {
                return IsNotNullOrWhiteSpaceThrowForWhiteSpace(validation, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotNullOrWhiteSpaceThrowForNull(Validation validation, string paramName) => 
            validation.SafeAddException(new ArgumentNullException(paramName));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotNullOrWhiteSpaceThrowForWhiteSpace(Validation validation, string paramName) => 
            validation.SafeAddException(new ArgumentException("must not be empty or whitespace", paramName));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotNullThrow(Validation validation, string paramName) => 
            validation.SafeAddException(new ArgumentNullException(paramName));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsNotZero(this Validation validation, IntPtr intPtr, string paramName)
        {
            if (intPtr == IntPtr.Zero)
            {
                return IsNotZeroThrow(validation, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsNotZeroThrow(Validation validation, string paramName) => 
            validation.SafeAddException(new ArgumentNullException(paramName));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsPositive(this Validation validation, double value, string paramName)
        {
            if (value <= 0.0)
            {
                return IsPositiveThrow(validation, value, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsPositive(this Validation validation, int value, string paramName)
        {
            if (value <= 0)
            {
                return IsPositiveThrow(validation, value, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsPositive(this Validation validation, long value, string paramName)
        {
            if (value <= 0L)
            {
                return IsPositiveThrow(validation, value, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsPositive(this Validation validation, float value, string paramName)
        {
            if (value <= 0f)
            {
                return IsPositiveThrow(validation, value, paramName);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsPositiveThrow(Validation validation, double value, string paramName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{paramName}:{typeof(double).Name}={value.ToString()}", "must be positive"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsPositiveThrow(Validation validation, int value, string paramName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{paramName}:{typeof(int).Name}={value.ToString()}", "must be positive"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsPositiveThrow(Validation validation, long value, string paramName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{paramName}:{typeof(long).Name}={value.ToString()}", "must be positive"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsPositiveThrow(Validation validation, float value, string paramName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{paramName}:{typeof(float).Name}={value.ToString()}", "must be positive"));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsRangeValid(this Validation validation, int arrayLength, int startIndex, int length, string arrayName)
        {
            if (((startIndex >= 0) && (length >= 0)) && ((startIndex <= arrayLength) && ((startIndex + length) <= arrayLength)))
            {
                return validation;
            }
            return IsRangeValidThrow(validation, arrayLength, startIndex, length, arrayName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsRangeValid(this Validation validation, long arrayLength, long startIndex, long length, string arrayName)
        {
            if (((startIndex >= 0L) && (length >= 0L)) && ((startIndex <= arrayLength) && ((startIndex + length) <= arrayLength)))
            {
                return validation;
            }
            return IsRangeValidThrow(validation, arrayLength, startIndex, length, arrayName);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsRangeValidThrow(Validation validation, int arrayLength, int startIndex, int length, string arrayName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"specified range, start={startIndex} length={length}, is invalid for array '{arrayName}' of size {arrayLength}"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsRangeValidThrow(Validation validation, long arrayLength, long startIndex, long length, string arrayName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"specified range, start={startIndex} length={length}, is invalid for array '{arrayName}' of size {arrayLength}"));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsTrue(this Validation validation, bool value, string message)
        {
            if (!value)
            {
                return IsTrueThrow(validation, message);
            }
            return validation;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsTrueThrow(Validation validation, string message) => 
            validation.SafeAddException(new InvalidOperationException(message));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsValid<T, TValidator>(this Validation validation, TValidator validator, T value, string valueName) where TValidator: IValidator<T>
        {
            if (validator.Check(value))
            {
                return validation;
            }
            return IsValidThrow<T, TValidator>(validation, validator, value, valueName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsValid<T, TValidator, TCriteria>(this Validation validation, TValidator validator, TCriteria criteria, T value, string valueName) where TValidator: IValidator<T, TCriteria>
        {
            if (validator.Check(criteria, value))
            {
                return validation;
            }
            return IsValidThrow<T, TValidator, TCriteria>(validation, validator, criteria, value, valueName);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsValidThrow<T, TValidator>(Validation validation, TValidator validator, T value, string valueName) where TValidator: IValidator<T> => 
            validation.SafeAddException(validator.CreateException(value, valueName, null));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsValidThrow<T, TValidator, TCriteria>(Validation validation, TValidator validator, TCriteria criteria, T value, string valueName) where TValidator: IValidator<T, TCriteria> => 
            validation.SafeAddException(validator.CreateException(criteria, value, valueName, null));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsValudInRangeThrow(Validation validation, int value, int min, int max, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{valueName}:{typeof(int).Name}={value}, min={min}, max={max}"));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsValueInRange(this Validation validation, double value, double min, double max, string valueName)
        {
            if (((value >= min) && (value <= max)) && ((value >= min) && (value <= max)))
            {
                return validation;
            }
            return IsValueInRangeThrow(validation, value, min, max, valueName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsValueInRange(this Validation validation, int value, int min, int max, string valueName)
        {
            if ((value >= min) && (value <= max))
            {
                return validation;
            }
            return IsValudInRangeThrow(validation, value, min, max, valueName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsValueInRange(this Validation validation, long value, long min, long max, string valueName)
        {
            if ((value >= min) && (value <= max))
            {
                return validation;
            }
            return IsValueInRangeThrow(validation, value, min, max, valueName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsValueInRange(this Validation validation, float value, float min, float max, string valueName)
        {
            if (((value >= min) && (value <= max)) && ((value >= min) && (value <= max)))
            {
                return validation;
            }
            return IsValueInRangeThrow(validation, value, min, max, valueName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation IsValueInRange<T>(this Validation validation, T value, T min, T max, string valueName) where T: IComparable<T>
        {
            if ((!value.IsLessThan<T>(min) && !value.IsGreaterThan<T>(max)) && (value.IsGreaterThanOrEqualTo<T>(min) && value.IsLessThanOrEqualTo<T>(max)))
            {
                return validation;
            }
            return IsValueInRangeThrow<T>(validation, value, min, max, valueName);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsValueInRangeThrow(Validation validation, double value, double min, double max, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{valueName}:{typeof(double).Name}={value}, min={min}, max={max}"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsValueInRangeThrow(Validation validation, long value, long min, long max, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{valueName}:{typeof(long).Name}={value}, min={min}, max={max}"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsValueInRangeThrow(Validation validation, float value, float min, float max, string valueName) => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{valueName}:{typeof(float).Name}={value}, min={min}, max={max}"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Validation IsValueInRangeThrow<T>(Validation validation, T value, T min, T max, string valueName) where T: IComparable<T> => 
            validation.SafeAddException(new ArgumentOutOfRangeException($"{valueName}:{typeof(T).Name}={value}, min={min}, max={max}"));

        private static ArgumentNullException ReduceArgumentNullExceptions(ICollection<Exception> exceptions)
        {
            if ((exceptions != null) && (exceptions.Count != 0))
            {
                IEnumerable<ArgumentNullException> source = exceptions.OfType<ArgumentNullException>().ToSegmentedList<ArgumentNullException>();
                if (source.Any<ArgumentNullException>())
                {
                    string str = string.Join(", ", (IEnumerable<string>) (from ex in source select ex.ParamName));
                    exceptions.RemoveRange<Exception>(source);
                    return new ArgumentNullException($"Multiple arguments were null: {str}", new AggregateException(exceptions));
                }
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation SafeAddException(this Validation validation, Exception ex)
        {
            Validate.IsNotNull<Exception>(ex, "ex");
            return (validation ?? new Validation()).AddException(ex);
        }

        private static Validation ThrowValidationException(Validation validation)
        {
            SegmentedList<Exception> exceptions = new SegmentedList<Exception>(validation.Exceptions, 7);
            SegmentedList<Exception> collection = new SegmentedList<Exception>();
            collection.AddIfNotNull<Exception>(ReduceArgumentNullExceptions(exceptions));
            if (collection.Count == 1)
            {
                throw collection[0];
            }
            throw new AggregateException(collection.Concat<Exception>(exceptions).Distinct<Exception>());
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly ValidationExtensions.<>c <>9 = new ValidationExtensions.<>c();
            public static Func<ArgumentNullException, string> <>9__86_0;

            internal string <ReduceArgumentNullExceptions>b__86_0(ArgumentNullException ex) => 
                ex.ParamName;
        }
    }
}

