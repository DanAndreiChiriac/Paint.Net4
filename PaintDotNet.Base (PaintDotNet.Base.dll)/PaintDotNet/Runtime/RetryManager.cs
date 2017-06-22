namespace PaintDotNet.Runtime
{
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Threading;
    using System;
    using System.Collections.Generic;
    using System.Runtime;

    public static class RetryManager
    {
        private const int defaultMaxAttempts = 5;
        private static readonly ProtectedRegion retryRegion = new ProtectedRegion("RetryManager.Loop", ProtectedRegionOptions.None);

        public static T Eval<T>(int maxAttempts, Func<T> func, Action<Exception> onRetry, Func<AggregateException, T> onFailure)
        {
            Validate.Begin().IsNotNegative(maxAttempts, "maxAttempts").IsNotNull<Func<T>>(func, "func").IsNotNull<Action<Exception>>(onRetry, "onRetry").IsNotNull<Func<AggregateException, T>>(onFailure, "onFailure").Check();
            List<Exception> innerExceptions = null;
            bool isThreadEntered = retryRegion.IsThreadEntered;
            using (retryRegion.UseEnterScope())
            {
                for (int i = 0; i < maxAttempts; i++)
                {
                    try
                    {
                        return func();
                    }
                    catch (Exception exception)
                    {
                        if (innerExceptions == null)
                        {
                            innerExceptions = new List<Exception>(maxAttempts);
                        }
                        innerExceptions.Add(exception);
                        onRetry(exception);
                        if (isThreadEntered)
                        {
                            goto Label_0099;
                        }
                    }
                }
            }
        Label_0099:
            return onFailure(new AggregateException(innerExceptions));
        }

        public static void RunMemorySensitiveOperation(Action action)
        {
            RunMemorySensitiveOperation(5, action);
        }

        public static T RunMemorySensitiveOperation<T>(Func<T> func) => 
            RunMemorySensitiveOperation<T>(5, func);

        public static void RunMemorySensitiveOperation(int maxAttempts, Action action)
        {
            Validate.Begin().IsPositive(maxAttempts, "maxAttempts").IsNotNull<Action>(action, "action").Check();
            List<Exception> innerExceptions = null;
            bool isThreadEntered = retryRegion.IsThreadEntered;
            using (retryRegion.UseEnterScope())
            {
                for (int i = 0; i < maxAttempts; i++)
                {
                    try
                    {
                        action();
                        return;
                    }
                    catch (OutOfMemoryException exception)
                    {
                        GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                        CleanupManager.RequestCleanup();
                        if (innerExceptions == null)
                        {
                            innerExceptions = new List<Exception>(maxAttempts);
                        }
                        innerExceptions.Add(exception);
                        if (isThreadEntered)
                        {
                            goto Label_0089;
                        }
                        CleanupManager.WaitForPendingCleanup();
                    }
                }
            }
        Label_0089:
            throw new OutOfMemoryException(innerExceptions[0].Message, new AggregateException(innerExceptions));
        }

        public static T RunMemorySensitiveOperation<T>(int maxAttempts, Func<T> func)
        {
            Validate.Begin().IsPositive(maxAttempts, "maxAttempts").IsNotNull<Func<T>>(func, "func").Check();
            T result = default(T);
            Action action = delegate {
                result = func();
            };
            RunMemorySensitiveOperation(maxAttempts, action);
            return result;
        }

        public static void Try(int maxAttempts, Action action, Action<Exception> onRetry, Action<AggregateException> onFailure)
        {
            Validate.Begin().IsNotNegative(maxAttempts, "maxAttempts").IsNotNull<Action>(action, "action").IsNotNull<Action<Exception>>(onRetry, "onRetry").IsNotNull<Action<AggregateException>>(onFailure, "onFailure").Check();
            List<Exception> innerExceptions = null;
            bool isThreadEntered = retryRegion.IsThreadEntered;
            using (retryRegion.UseEnterScope())
            {
                for (int i = 0; i < maxAttempts; i++)
                {
                    try
                    {
                        action();
                        return;
                    }
                    catch (Exception exception)
                    {
                        if (innerExceptions == null)
                        {
                            innerExceptions = new List<Exception>(maxAttempts);
                        }
                        innerExceptions.Add(exception);
                        onRetry(exception);
                        if (isThreadEntered)
                        {
                            goto Label_0097;
                        }
                    }
                }
            }
        Label_0097:
            onFailure(new AggregateException(innerExceptions));
        }
    }
}

