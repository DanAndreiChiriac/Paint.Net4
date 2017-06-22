namespace PaintDotNet.Functional
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal sealed class ResultErrorData
    {
        private Guid id;
        private bool needsObservation;
        private static Dictionary<Guid, ErrorData> staticErrorData = new Dictionary<Guid, ErrorData>();
        private static object staticSync = new object();

        public ResultErrorData(Exception error, bool requireObservation)
        {
            Validate.IsNotNull<Exception>(error, "error");
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            ErrorData data = new ErrorData(error, stackTrace);
            this.needsObservation = requireObservation;
            int num = 0x3e8;
            this.id = Guid.NewGuid();
            object staticSync = ResultErrorData.staticSync;
            lock (staticSync)
            {
                while (staticErrorData.ContainsKey(this.id))
                {
                    this.id = Guid.NewGuid();
                    num--;
                    if (num == 0)
                    {
                        throw new InternalErrorException($"Could not create a new, locally unused GUID after {num.ToString()} attempts. Statistically, this is impossible.");
                    }
                }
                staticErrorData.Add(this.id, data);
            }
            if (!this.needsObservation)
            {
                GC.SuppressFinalize(this);
            }
        }

        private static bool DoesExceptionRequireObservation(Exception ex)
        {
            if (ex != null)
            {
                if (ex is OperationCanceledException)
                {
                    return false;
                }
                if (!(ex is AggregateException))
                {
                    return true;
                }
                using (IEnumerator<Exception> enumerator = ((AggregateException) ex).Flatten().InnerExceptions.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (!(enumerator.Current is OperationCanceledException))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        ~ResultErrorData()
        {
            try
            {
                if (this.needsObservation)
                {
                    ErrorData data = this.Data;
                    if (DoesExceptionRequireObservation(data.Error))
                    {
                        throw new UnobservedErrorException("This result is an error, but it was not observed. Stack trace: (--- " + data.StackTrace.ToString() + " ---)", data.Error);
                    }
                }
            }
            finally
            {
                object staticSync = ResultErrorData.staticSync;
                lock (staticSync)
                {
                    staticErrorData.Remove(this.id);
                }
            }
        }

        public void Observe()
        {
            this.needsObservation = false;
        }

        private ErrorData Data
        {
            get
            {
                object staticSync = ResultErrorData.staticSync;
                lock (staticSync)
                {
                    return staticErrorData[this.id];
                }
            }
        }

        public Exception Error =>
            this.Data.Error;

        public bool NeedsObservation =>
            this.needsObservation;

        public System.Diagnostics.StackTrace StackTrace =>
            this.Data.StackTrace;

        private sealed class ErrorData
        {
            private readonly Exception error;
            private readonly System.Diagnostics.StackTrace stackTrace;

            public ErrorData(Exception error, System.Diagnostics.StackTrace stackTrace)
            {
                this.error = error;
                this.stackTrace = stackTrace;
            }

            public Exception Error =>
                this.error;

            public System.Diagnostics.StackTrace StackTrace =>
                this.stackTrace;
        }
    }
}

