namespace PaintDotNet.Diagnostics
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ValidatorExtensions
    {
        public static void Verify<T, TValidator>(this TValidator validator, T value, string valueName) where TValidator: IValidator<T>
        {
            if (!validator.Check(value))
            {
                throw validator.CreateException(value, valueName, null);
            }
        }

        public static void Verify<T, TValidator>(this TValidator validator, ref T value, string valueName) where TValidator: IValidatorByRef<T>
        {
            if (!validator.Check(ref value))
            {
                throw validator.CreateException(ref value, valueName, null);
            }
        }

        public static void Verify<T, TValidator, TCriteria>(this TValidator validator, TCriteria criteria, T value, string valueName) where TValidator: IValidator<T, TCriteria>
        {
            if (!validator.Check(criteria, value))
            {
                throw validator.CreateException(criteria, value, valueName, null);
            }
        }

        public static void Verify<T, TValidator, TCriteria>(this TValidator validator, ref TCriteria criteria, ref T value, string valueName) where TValidator: IValidatorByRef<T, TCriteria>
        {
            if (!validator.Check(ref criteria, ref value))
            {
                throw validator.CreateException(ref criteria, ref value, valueName, null);
            }
        }
    }
}

