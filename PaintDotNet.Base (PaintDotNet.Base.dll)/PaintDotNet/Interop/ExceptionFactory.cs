namespace PaintDotNet.Interop
{
    using PaintDotNet.Animation;
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public static class ExceptionFactory
    {
        private static readonly Type[] exCtorArgTypes = new Type[] { typeof(string), typeof(Exception) };
        private static readonly Type[] hrEnumTypes = new Type[] { typeof(InteropError), typeof(ImagingError), typeof(DxgiError), typeof(Direct2DError), typeof(DirectWriteError), typeof(AnimationError) };

        private static Exception CreateException(Type exceptionType, int hr, string message, Exception innerEx)
        {
            if (hr == -2144731133)
            {
                return new IllegalReentrancyException(message, innerEx);
            }
            ConstructorInfo constructor = exceptionType.GetConstructor(exCtorArgTypes);
            object[] parameters = new object[] { message, innerEx };
            Exception exception = (Exception) constructor.Invoke(parameters);
            COMException exception2 = exception as COMException;
            if ((exception2 == null) || (exception2.ErrorCode != hr))
            {
                PropertyInfo info2 = exceptionType.GetProperty("HResult", BindingFlags.NonPublic | BindingFlags.Instance) ?? exceptionType.GetProperty("HResult", BindingFlags.Public | BindingFlags.Instance);
                if (info2 != null)
                {
                    info2.SetValue(exception, hr, null);
                }
            }
            return exception;
        }

        public static Exception CreateFromHR(int hr, string message = null, Exception innerEx = null)
        {
            Exception exception = null;
            Type[] hrEnumTypes = ExceptionFactory.hrEnumTypes;
            for (int i = 0; i < hrEnumTypes.Length; i++)
            {
                Type exceptionType = TryMapHRToExceptionType(hrEnumTypes[i], hr);
                if (exceptionType != null)
                {
                    exception = CreateException(exceptionType, hr, message, innerEx);
                    break;
                }
            }
            if (exception == null)
            {
                exception = CreateException(Marshal.GetExceptionForHR(hr).GetType(), hr, message, innerEx);
            }
            return exception;
        }

        public static void ThrowOnError(int hr, string message = null, Exception innerEx = null)
        {
            if (hr < 0)
            {
                throw CreateFromHR(hr, message, innerEx);
            }
        }

        private static Type TryMapHRToExceptionType(Type enumType, int hr)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException($"enumType({enumType.Name}) is not an enumeration");
            }
            Type underlyingType = Enum.GetUnderlyingType(enumType);
            if (!underlyingType.Equals(typeof(int)) && !underlyingType.Equals(typeof(uint)))
            {
                throw new ArgumentException($"enumType({enumType.Name}):{underlyingType.Name}, is not based on int or uint");
            }
            object obj2 = hr;
            object obj3 = (uint) hr;
            foreach (FieldInfo info in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                object rawConstantValue = info.GetRawConstantValue();
                if (rawConstantValue.Equals(obj2) || rawConstantValue.Equals(obj3))
                {
                    object[] customAttributes = info.GetCustomAttributes(typeof(ExceptionMappingAttribute), false);
                    if (customAttributes.Length == 1)
                    {
                        return ((ExceptionMappingAttribute) customAttributes[0]).ExceptionType;
                    }
                }
            }
            return null;
        }
    }
}

