namespace PaintDotNet.Functional
{
    using System;
    using System.Runtime.CompilerServices;

    public abstract class Result
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Result()
        {
        }

        public virtual ResultError<TRet> CastError<TRet>()
        {
            throw new InvalidOperationException("Can only cast to ResultError<TRet> if IsError is true");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ResultValue<T> Default<T>() => 
            ResultValueImpl<T>.Default;

        public virtual bool EnsureEvaluated() => 
            false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ResultValue<T> New<T>(T value) => 
            new ResultValueImpl<T>(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ResultError<PaintDotNet.Functional.Unit> NewError(Exception error) => 
            new ResultError<PaintDotNet.Functional.Unit>(error, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ResultError<T> NewError<T>(Exception error) => 
            new ResultError<T>(error, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ResultError<PaintDotNet.Functional.Unit> NewError(Exception error, bool requireObservation) => 
            new ResultError<PaintDotNet.Functional.Unit>(error, requireObservation);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ResultError<T> NewError<T>(Exception error, bool requireObservation) => 
            new ResultError<T>(error, requireObservation);

        public abstract void Observe();
        public virtual Exception PeekError()
        {
            throw new InvalidOperationException("PeekError is only valid when IsError is true");
        }

        public virtual Exception Error
        {
            get
            {
                throw new InvalidOperationException("Error is only valid when IsError is true");
            }
        }

        public virtual bool IsError =>
            false;

        public virtual bool IsEvaluated =>
            true;

        public virtual bool NeedsObservation =>
            false;

        public static ResultValue<PaintDotNet.Functional.Unit> Unit =>
            ResultValueUnit.Instance;

        public virtual Type ValueType =>
            typeof(PaintDotNet.Functional.Unit);

        public static Result Void =>
            ResultValueUnit.Instance;
    }
}

