namespace PaintDotNet.Functional
{
    using PaintDotNet;
    using PaintDotNet.Concurrency;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class Func
    {
        private static readonly Action noOp = new Action(<>c.<>9.<.cctor>b__44_0);

        public static Func<IAsync> At(this Action f, IAsyncWorkQueue queue) => 
            () => queue.BeginTry(f);

        public static Func<T, IAsync> At<T>(this Action<T> f, IAsyncWorkQueue queue) => 
            val => queue.BeginTry<T>(f, val);

        public static Func<IAsync<T>> At<T>(this Func<T> f, IAsyncWorkQueue queue) => 
            () => queue.BeginEval<T>(f);

        public static Func<T1, IAsync<TRet>> At<T1, TRet>(this Func<T1, TRet> f, IAsyncWorkQueue queue) => 
            val => queue.BeginEval<T1, TRet>(f, val);

        public static Action Bind<T1>(this Action<T1> f, T1 arg1) => 
            delegate {
                f(arg1);
            };

        public static Func<TRet> Bind<T1, TRet>(this Func<T1, TRet> f, T1 arg1) => 
            () => f(arg1);

        public static Action Bind<T1, T2>(this Action<T1, T2> f, T1 arg1, T2 arg2) => 
            delegate {
                f(arg1, arg2);
            };

        public static Func<TRet> Bind<T1, T2, TRet>(this Func<T1, T2, TRet> f, T1 arg1, T2 arg2) => 
            () => f(arg1, arg2);

        public static Action Bind<T1, T2, T3>(this Action<T1, T2, T3> f, T1 arg1, T2 arg2, T3 arg3) => 
            delegate {
                f(arg1, arg2, arg3);
            };

        public static Func<TRet> Bind<T1, T2, T3, TRet>(this Func<T1, T2, T3, TRet> f, T1 arg1, T2 arg2, T3 arg3) => 
            () => f(arg1, arg2, arg3);

        public static Action Bind<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> f, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => 
            delegate {
                f(arg1, arg2, arg3, arg4);
            };

        public static Func<TRet> Bind<T1, T2, T3, T4, TRet>(this Func<T1, T2, T3, T4, TRet> f, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => 
            () => f(arg1, arg2, arg3, arg4);

        public static Func<T2, TRet> Bind1<T1, T2, TRet>(this Func<T1, T2, TRet> f, T1 arg1) => 
            arg2 => f(arg1, arg2);

        public static Func<T2, T3, TRet> Bind1<T1, T2, T3, TRet>(this Func<T1, T2, T3, TRet> f, T1 arg1) => 
            (arg2, arg3) => f(arg1, arg2, arg3);

        public static Func<T2, T3, T4, TRet> Bind1<T1, T2, T3, T4, TRet>(this Func<T1, T2, T3, T4, TRet> f, T1 arg1) => 
            (arg2, arg3, arg4) => f(arg1, arg2, arg3, arg4);

        public static Func<T1, TRet> Bind2<T1, T2, TRet>(this Func<T1, T2, TRet> f, T2 arg2) => 
            arg1 => f(arg1, arg2);

        public static Func<T1, T3, TRet> Bind2<T1, T2, T3, TRet>(this Func<T1, T2, T3, TRet> f, T2 arg2) => 
            (arg1, arg3) => f(arg1, arg2, arg3);

        public static Func<T1, T3, T4, TRet> Bind2<T1, T2, T3, T4, TRet>(this Func<T1, T2, T3, T4, TRet> f, T2 arg2) => 
            (arg1, arg3, arg4) => f(arg1, arg2, arg3, arg4);

        public static Func<T1, T2, TRet> Bind3<T1, T2, T3, TRet>(this Func<T1, T2, T3, TRet> f, T3 arg3) => 
            (arg1, arg2) => f(arg1, arg2, arg3);

        public static Func<T1, T2, T4, TRet> Bind3<T1, T2, T3, T4, TRet>(this Func<T1, T2, T3, T4, TRet> f, T3 arg3) => 
            (arg1, arg2, arg4) => f(arg1, arg2, arg3, arg4);

        public static Func<T1, T2, T3, TRet> Bind4<T1, T2, T3, T4, TRet>(this Func<T1, T2, T3, T4, TRet> f, T4 arg4) => 
            (arg1, arg2, arg3) => f(arg1, arg2, arg3, arg4);

        public static Func<TRet> Const<TRet>(TRet value) => 
            () => value;

        public static Func<TRet> ConstDefault<TRet>() => 
            ConstDefaultHelper<TRet>.instance;

        public static Result<TRet> Eval<TRet>(this Func<TRet> f)
        {
            TRet local;
            try
            {
                local = f();
            }
            catch (Exception exception1)
            {
                return Result.NewError<TRet>(exception1, true);
            }
            return Result.New<TRet>(local);
        }

        public static Result<TRet> Eval<T1, TRet>(this Func<T1, TRet> f, T1 arg1)
        {
            TRet local;
            try
            {
                local = f(arg1);
            }
            catch (Exception exception1)
            {
                return (Result<TRet>) Result.NewError<TRet>(exception1, true);
            }
            return (Result<TRet>) Result.New<TRet>(local);
        }

        public static Action<T> GetNoOp<T>() => 
            NoOpHelper1<T>.instance;

        public static Action<T1, T2> GetNoOp<T1, T2>() => 
            NoOpHelper1<T1>.NoOpHelper2<T2>.instance;

        public static Action<T1, T2, T3> GetNoOp<T1, T2, T3>() => 
            NoOpHelper1<T1>.NoOpHelper2<T2>.NoOpHelper3<T3>.instance;

        public static Action<T1, T2, T3, T4> GetNoOp<T1, T2, T3, T4>() => 
            NoOpHelper1<T1>.NoOpHelper2<T2>.NoOpHelper3<T3>.NoOpHelper4<T4>.instance;

        public static Func<T, T> Identity<T>() => 
            IdentityHelper<T>.instance;

        public static Func<T> Infer<T>(Func<T> f) => 
            f;

        public static Func<T1, TRet> Infer<T1, TRet>(Func<T1, TRet> f) => 
            f;

        public static Func<T, TResult> Memoize<T, TResult>(Func<T, TResult> func)
        {
            Validate.IsNotNull<Func<T, TResult>>(func, "func");
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            ConcurrentDictionary<T, TResult> cache = new ConcurrentDictionary<T, TResult>(comparer);
            return arg => cache.GetOrAdd(arg, func);
        }

        public static Func<T1, T2, TResult> Memoize<T1, T2, TResult>(Func<T1, T2, TResult> func)
        {
            Validate.IsNotNull<Func<T1, T2, TResult>>(func, "func");
            EqualityComparer<TupleStruct<T1, T2>> comparer = EqualityComparer<TupleStruct<T1, T2>>.Default;
            ConcurrentDictionary<TupleStruct<T1, T2>, TResult> cache = new ConcurrentDictionary<TupleStruct<T1, T2>, TResult>(comparer);
            Func<TupleStruct<T1, T2>, TResult> tupledFunc = args => func(args.Item1, args.Item2);
            return (arg1, arg2) => cache.GetOrAdd(TupleStruct.Create<T1, T2>(arg1, arg2), tupledFunc);
        }

        public static Action ToAction(this Func<Unit> f) => 
            delegate {
                f();
            };

        public static Func<Unit> ToFunc(this Action f) => 
            delegate {
                f();
                return new Unit();
            };

        public static Result Try(this Action f)
        {
            try
            {
                f();
            }
            catch (Exception exception1)
            {
                return Result.NewError(exception1, true);
            }
            return Result.Void;
        }

        public static Result Try<T1>(this Action<T1> f, T1 arg1)
        {
            try
            {
                f(arg1);
            }
            catch (Exception exception1)
            {
                return Result.NewError(exception1, true);
            }
            return Result.Void;
        }

        public static Action NoOp =>
            noOp;

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly Func.<>c <>9 = new Func.<>c();

            internal void <.cctor>b__44_0()
            {
            }
        }

        private static class ConstDefaultHelper<T>
        {
            public static Func<T> instance;

            static ConstDefaultHelper()
            {
                Func.ConstDefaultHelper<T>.instance = new Func<T>(<>c<T>.<>9.<.cctor>b__1_0);
            }

            [Serializable, CompilerGenerated]
            private sealed class <>c
            {
                public static readonly Func.ConstDefaultHelper<T>.<>c <>9;

                static <>c()
                {
                    Func.ConstDefaultHelper<T>.<>c.<>9 = new Func.ConstDefaultHelper<T>.<>c();
                }

                internal T <.cctor>b__1_0() => 
                    default(T);
            }
        }

        private static class IdentityHelper<T>
        {
            public static readonly Func<T, T> instance;

            static IdentityHelper()
            {
                Func.IdentityHelper<T>.instance = new Func<T, T>(<>c<T>.<>9.<.cctor>b__1_0);
            }

            [Serializable, CompilerGenerated]
            private sealed class <>c
            {
                public static readonly Func.IdentityHelper<T>.<>c <>9;

                static <>c()
                {
                    Func.IdentityHelper<T>.<>c.<>9 = new Func.IdentityHelper<T>.<>c();
                }

                internal T <.cctor>b__1_0(T x) => 
                    x;
            }
        }

        private static class NoOpHelper1<T1>
        {
            public static readonly Action<T1> instance;

            static NoOpHelper1()
            {
                Func.NoOpHelper1<T1>.instance = new Action<T1>(<>c<T1>.<>9.<.cctor>b__2_0);
            }

            [Serializable, CompilerGenerated]
            private sealed class <>c
            {
                public static readonly Func.NoOpHelper1<T1>.<>c <>9;

                static <>c()
                {
                    Func.NoOpHelper1<T1>.<>c.<>9 = new Func.NoOpHelper1<T1>.<>c();
                }

                internal void <.cctor>b__2_0(T1 _)
                {
                }
            }

            public static class NoOpHelper2<T2>
            {
                public static readonly Action<T1, T2> instance;

                static NoOpHelper2()
                {
                    Func.NoOpHelper1<T1>.NoOpHelper2<T2>.instance = new Action<T1, T2>(<>c<T1, T2>.<>9.<.cctor>b__2_0);
                }

                [Serializable, CompilerGenerated]
                private sealed class <>c
                {
                    public static readonly Func.NoOpHelper1<T1>.NoOpHelper2<T2>.<>c <>9;

                    static <>c()
                    {
                        Func.NoOpHelper1<T1>.NoOpHelper2<T2>.<>c.<>9 = new Func.NoOpHelper1<T1>.NoOpHelper2<T2>.<>c();
                    }

                    internal void <.cctor>b__2_0(T1 a, T2 b)
                    {
                    }
                }

                public static class NoOpHelper3<T3>
                {
                    public static readonly Action<T1, T2, T3> instance;

                    static NoOpHelper3()
                    {
                        Func.NoOpHelper1<T1>.NoOpHelper2<T2>.NoOpHelper3<T3>.instance = new Action<T1, T2, T3>(<>c<T1, T2, T3>.<>9.<.cctor>b__2_0);
                    }

                    [Serializable, CompilerGenerated]
                    private sealed class <>c
                    {
                        public static readonly Func.NoOpHelper1<T1>.NoOpHelper2<T2>.NoOpHelper3<T3>.<>c <>9;

                        static <>c()
                        {
                            Func.NoOpHelper1<T1>.NoOpHelper2<T2>.NoOpHelper3<T3>.<>c.<>9 = new Func.NoOpHelper1<T1>.NoOpHelper2<T2>.NoOpHelper3<T3>.<>c();
                        }

                        internal void <.cctor>b__2_0(T1 a, T2 b, T3 c)
                        {
                        }
                    }

                    public static class NoOpHelper4<T4>
                    {
                        public static readonly Action<T1, T2, T3, T4> instance;

                        static NoOpHelper4()
                        {
                            Func.NoOpHelper1<T1>.NoOpHelper2<T2>.NoOpHelper3<T3>.NoOpHelper4<T4>.instance = new Action<T1, T2, T3, T4>(<>c<T1, T2, T3, T4>.<>9.<.cctor>b__1_0);
                        }

                        [Serializable, CompilerGenerated]
                        private sealed class <>c
                        {
                            public static readonly Func.NoOpHelper1<T1>.NoOpHelper2<T2>.NoOpHelper3<T3>.NoOpHelper4<T4>.<>c <>9;

                            static <>c()
                            {
                                Func.NoOpHelper1<T1>.NoOpHelper2<T2>.NoOpHelper3<T3>.NoOpHelper4<T4>.<>c.<>9 = new Func.NoOpHelper1<T1>.NoOpHelper2<T2>.NoOpHelper3<T3>.NoOpHelper4<T4>.<>c();
                            }

                            internal void <.cctor>b__1_0(T1 a, T2 b, T3 c, T4 d)
                            {
                            }
                        }
                    }
                }
            }
        }
    }
}

