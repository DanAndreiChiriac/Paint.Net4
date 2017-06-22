namespace PaintDotNet.Functional
{
    using System;
    using System.Diagnostics;

    [Serializable]
    public sealed class ResultError<T> : Result<T>
    {
        private readonly ResultErrorData data;

        internal ResultError(ResultErrorData data)
        {
            this.data = data;
        }

        internal ResultError(Exception error, bool requireObservation) : this(new ResultErrorData(error, requireObservation))
        {
        }

        public override ResultError<TRet> CastError<TRet>() => 
            new ResultError<TRet>(this.data);

        public sealed override void Observe()
        {
            this.data.Observe();
        }

        public static implicit operator ResultError<Unit>(ResultError<T> errorT) => 
            errorT.CastError<Unit>();

        public static implicit operator ResultError<T>(ResultError<Unit> error) => 
            error.CastError<T>();

        public override Exception PeekError() => 
            this.data.Error;

        [DebuggerDisplay("Error = {this.data.Error}")]
        public override Exception Error
        {
            get
            {
                this.data.Observe();
                return this.data.Error;
            }
        }

        public override bool IsError =>
            true;

        public override bool NeedsObservation =>
            this.data.NeedsObservation;

        [DebuggerDisplay("(value)")]
        public override T Value
        {
            get
            {
                this.Observe();
                throw new InvalidOperationException("This result is an error, not a value", this.data.Error);
            }
        }
    }
}

