namespace PaintDotNet
{
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Threading;

    public static class ExceptionUtil
    {
        private static readonly FieldInfo _messageField = typeof(Exception).GetField("_message", BindingFlags.NonPublic | BindingFlags.Instance);

        public static PaintDotNet.InternalErrorException InternalErrorException() => 
            new PaintDotNet.InternalErrorException();

        public static PaintDotNet.InternalErrorException InternalErrorException(string message) => 
            new PaintDotNet.InternalErrorException(message);

        public static System.ComponentModel.InvalidEnumArgumentException InvalidEnumArgumentException<T>(T value, string valueName) where T: struct, IComparable, IFormattable, IConvertible
        {
            long invalidValue = value.ToInt64(null);
            if ((invalidValue < -2147483648L) || (invalidValue > 0x7fffffffL))
            {
                return new InvalidEnum64ArgumentException(valueName, invalidValue, typeof(T));
            }
            return new System.ComponentModel.InvalidEnumArgumentException(valueName, value.ToInt32(null), typeof(T));
        }

        public static void SetMessage(Exception exception, string message)
        {
            Validate.IsNotNull<Exception>(exception, "exception");
            _messageField.SetValue(exception, message);
        }

        public static void Throw(Exception exception)
        {
            throw exception;
        }

        public static void ThrowArgumentException()
        {
            throw new ArgumentException();
        }

        public static void ThrowArgumentException(string paramName)
        {
            throw new ArgumentException(null, paramName);
        }

        public static void ThrowArgumentException(string message, string paramName)
        {
            throw new ArgumentException(message, paramName);
        }

        public static void ThrowArgumentNullException()
        {
            throw new ArgumentNullException();
        }

        public static void ThrowArgumentNullException(string paramName)
        {
            throw new ArgumentNullException(paramName);
        }

        public static void ThrowArgumentNullException(string paramName, string message)
        {
            throw new ArgumentNullException(paramName, message);
        }

        public static void ThrowArgumentOutOfRangeException()
        {
            throw new ArgumentOutOfRangeException();
        }

        public static void ThrowArgumentOutOfRangeException(string paramName)
        {
            throw new ArgumentOutOfRangeException(paramName);
        }

        public static void ThrowArgumentOutOfRangeException(string paramName, string message)
        {
            throw new ArgumentOutOfRangeException(paramName, message);
        }

        public static void ThrowArgumentOutOfRangeException(string paramName, object actualValue, string message)
        {
            throw new ArgumentOutOfRangeException(paramName, actualValue, message);
        }

        public static void ThrowInterfaceNotSupportedException(Type interfaceType)
        {
            throw new InterfaceNotSupportedException(interfaceType);
        }

        public static void ThrowInternalErrorException()
        {
            throw new PaintDotNet.InternalErrorException();
        }

        public static void ThrowInternalErrorException(Exception innerException)
        {
            throw new PaintDotNet.InternalErrorException(innerException);
        }

        public static void ThrowInternalErrorException(string message)
        {
            throw new PaintDotNet.InternalErrorException(message);
        }

        public static void ThrowInternalErrorException(string message, Exception innerException)
        {
            throw new PaintDotNet.InternalErrorException(message, innerException);
        }

        public static void ThrowInvalidEnumArgumentException<T>(T value, string valueName) where T: struct, IComparable, IFormattable, IConvertible
        {
            long invalidValue = value.ToInt64(null);
            if ((invalidValue < -2147483648L) || (invalidValue > 0x7fffffffL))
            {
                throw new InvalidEnum64ArgumentException(valueName, invalidValue, typeof(T));
            }
            int num2 = value.ToInt32(null);
            throw new System.ComponentModel.InvalidEnumArgumentException(valueName, num2, typeof(T));
        }

        public static void ThrowInvalidEnumArgumentException(string paramName, int invalidValue, Type enumType)
        {
            throw new System.ComponentModel.InvalidEnumArgumentException(paramName, invalidValue, enumType);
        }

        public static void ThrowInvalidOperationException()
        {
            throw new InvalidOperationException();
        }

        public static void ThrowInvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }

        public static void ThrowInvalidOperationException(string message, Exception innerException)
        {
            throw new InvalidOperationException(message, innerException);
        }

        public static void ThrowKeyNotFoundException()
        {
            throw new KeyNotFoundException();
        }

        public static void ThrowKeyNotFoundException(string message)
        {
            throw new KeyNotFoundException(message);
        }

        public static void ThrowLockRecursionException()
        {
            throw new LockRecursionException();
        }

        public static void ThrowLockRecursionException(string message)
        {
            throw new LockRecursionException(message);
        }

        public static void ThrowLockRecursionException(string message, Exception innerException)
        {
            throw new LockRecursionException(message, innerException);
        }

        public static void ThrowNotSupportedException()
        {
            throw new NotSupportedException();
        }

        public static void ThrowNotSupportedException(string message)
        {
            throw new NotSupportedException(message);
        }

        public static void ThrowObjectDisposedException<T>()
        {
            throw new ObjectDisposedException(typeof(T).Name);
        }

        public static void ThrowObjectDisposedException(string objectName)
        {
            throw new ObjectDisposedException(objectName);
        }

        public static void ThrowOperationCanceledException()
        {
            throw new OperationCanceledException();
        }

        public static void ThrowUnreachableCodeException()
        {
            throw new UnreachableCodeException();
        }

        public static void ThrowUnreachableCodeException(string message)
        {
            throw new UnreachableCodeException(message);
        }
    }
}

