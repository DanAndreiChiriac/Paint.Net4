namespace PaintDotNet.Functional
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    internal sealed class ResultValueUnit : ResultValue<Unit>
    {
        private static readonly ResultValueUnit instance = new ResultValueUnit();

        internal ResultValueUnit()
        {
        }

        public override void Observe()
        {
        }

        internal static ResultValue<Unit> Instance =>
            instance;

        public override Unit Value =>
            new Unit();
    }
}

