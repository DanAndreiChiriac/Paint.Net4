namespace PaintDotNet.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public sealed class Validation
    {
        private List<Exception> exceptions;
        private bool observed;

        public Validation AddException(Exception ex)
        {
            Type type = typeof(Validation);
            lock (type)
            {
                if (this.exceptions == null)
                {
                    this.exceptions = new List<Exception>();
                }
                this.exceptions.Add(ex);
                this.observed = false;
                GC.ReRegisterForFinalize(this);
            }
            return this;
        }

        ~Validation()
        {
            if ((!this.observed && (this.exceptions != null)) && (this.exceptions.Count > 0))
            {
                try
                {
                    this.Check();
                }
                catch (Exception exception)
                {
                    throw new ValidationException("This validation has exceptions, and was not observed", exception);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Observe()
        {
            Type type = typeof(Validation);
            lock (type)
            {
                this.observed = true;
                GC.SuppressFinalize(this);
            }
        }

        public IEnumerable<Exception> Exceptions
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.Observe();
                return this.exceptions;
            }
        }
    }
}

