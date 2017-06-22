namespace PaintDotNet
{
    using System;
    using System.Threading;

    public static class RandomUtil
    {
        private static readonly ThreadLocal<Random> threadInstance = new ThreadLocal<Random>(new Func<Random>(RandomUtil.CreateThreadInstance));

        private static Random CreateThreadInstance() => 
            new Random(GetThreadSeed());

        public static int GetThreadSeed() => 
            (Thread.CurrentThread.GetHashCode() ^ ((int) DateTime.UtcNow.Ticks));

        public static Random ThreadInstance =>
            threadInstance.Value;
    }
}

