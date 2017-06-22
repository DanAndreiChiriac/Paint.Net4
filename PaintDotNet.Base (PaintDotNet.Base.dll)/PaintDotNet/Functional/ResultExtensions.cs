namespace PaintDotNet.Functional
{
    using PaintDotNet.Concurrency;
    using System;
    using System.Runtime.CompilerServices;

    public static class ResultExtensions
    {
        public static ResultStruct<T> AsStruct<T>(this Result<T> result)
        {
            if (result.IsError)
            {
                return new ResultStruct<T>(default(T), result);
            }
            return new ResultStruct<T>(result.Value, null);
        }

        public static T CancelableValue<T>(this Result<T> result)
        {
            if (result.IsError && (result.Error is OperationCanceledException))
            {
                throw new OperationCanceledException(new OperationCanceledException().Message, result.Error);
            }
            return result.Value;
        }

        public static bool ErrorInto<T, U>(this Result<T> tResult, IAsyncSource<U> source) => 
            (tResult.IsError && source.Throw<U>(tResult.Error));

        public static Result<T> IfNullValue<T>(this Result<T> resultT, Func<T> f) where T: class
        {
            if (resultT.IsValue && (resultT.Value == null))
            {
                return f.Eval<T>();
            }
            return resultT;
        }

        public static Result IfValue<T>(this Result<T> resultT, Action<T> f) => 
            resultT.IfValue<T, Unit>(delegate (T tValue) {
                f(tValue);
                return new Unit();
            });

        public static Result<U> IfValue<T, U>(this Result<T> resultT, Func<T, U> f)
        {
            if (resultT.IsError)
            {
                return (Result<U>) resultT.CastError<U>();
            }
            return f.Eval<T, U>(resultT.Value);
        }

        public static bool Into(this Result result, IAsyncSource async) => 
            async.SetResult(result);

        public static bool Into<T>(this Result<T> result, IAsyncSource<T> async) => 
            async.SetResult(result);

        public static Result Repair(this Result result, Action<Exception> f)
        {
            if (result.IsError)
            {
                return f.Try<Exception>(result.Error);
            }
            return result;
        }

        public static Result Repair<TEx>(this Result result, Action<TEx> f) where TEx: Exception
        {
            if (result.IsError && (result.Error is TEx))
            {
                return f.Try<TEx>(((TEx) result.Error));
            }
            return result;
        }

        public static Result<T> Repair<T>(this Result<T> resultT, Func<Exception, T> f)
        {
            if (resultT.IsError)
            {
                return f.Eval<Exception, T>(resultT.Error);
            }
            return resultT;
        }

        public static Result<T> Repair<T, TEx>(this Result<T> resultT, Func<TEx, T> f) where TEx: Exception
        {
            if (resultT.IsError && (resultT.Error is TEx))
            {
                return f.Eval<TEx, T>(((TEx) resultT.Error));
            }
            return resultT;
        }
    }
}

