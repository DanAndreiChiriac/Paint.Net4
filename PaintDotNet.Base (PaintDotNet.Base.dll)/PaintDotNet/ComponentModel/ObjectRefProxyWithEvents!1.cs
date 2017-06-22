namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;

    public abstract class ObjectRefProxyWithEvents<T> : ObjectRefProxy<T> where T: class, IObjectRef
    {
        private List<TupleStruct<Delegate, Delegate, Action<T, Delegate>>> clientHandlerToRemoveProxyHandlerFnMap;

        internal ObjectRefProxyWithEvents(T objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
            this.clientHandlerToRemoveProxyHandlerFnMap = new List<TupleStruct<Delegate, Delegate, Action<T, Delegate>>>();
        }

        protected void AddEventHandler(Delegate clientHandler, Delegate proxyHandler, Action<T, Delegate> removeProxyHandlerFn)
        {
            Validate.Begin().IsNotNull<Delegate>(proxyHandler, "proxyHandler").IsNotNull<Action<T, Delegate>>(removeProxyHandlerFn, "removeProxyHandlerFn").Check();
            if (clientHandler != null)
            {
                lock (events)
                {
                    if (this.clientHandlerToRemoveProxyHandlerFnMap == null)
                    {
                        this.clientHandlerToRemoveProxyHandlerFnMap = new List<TupleStruct<Delegate, Delegate, Action<T, Delegate>>>(1);
                    }
                    this.clientHandlerToRemoveProxyHandlerFnMap.Add(TupleStruct.Create<Delegate, Delegate, Action<T, Delegate>>(clientHandler, proxyHandler, removeProxyHandlerFn));
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                List<TupleStruct<Delegate, Delegate, Action<T, Delegate>>> clientHandlerToRemoveProxyHandlerFnMap;
                lock (events)
                {
                    clientHandlerToRemoveProxyHandlerFnMap = this.clientHandlerToRemoveProxyHandlerFnMap;
                    this.clientHandlerToRemoveProxyHandlerFnMap = null;
                }
                if (clientHandlerToRemoveProxyHandlerFnMap != null)
                {
                    for (int i = clientHandlerToRemoveProxyHandlerFnMap.Count - 1; i >= 0; i--)
                    {
                        TupleStruct<Delegate, Delegate, Action<T, Delegate>> struct2 = clientHandlerToRemoveProxyHandlerFnMap[i];
                        struct2.Item3(base.innerRefT, struct2.Item2);
                    }
                }
            }
            base.Dispose(disposing);
        }

        protected void RemoveEventHandler(Delegate clientHandler, Action<T, Delegate> removeProxyHandlerFn)
        {
            Validate.IsNotNull<Action<T, Delegate>>(removeProxyHandlerFn, "removeProxyHandlerFn");
            if (clientHandler != null)
            {
                Delegate delegate2 = null;
                lock (events)
                {
                    if (this.clientHandlerToRemoveProxyHandlerFnMap == null)
                    {
                        return;
                    }
                    for (int i = this.clientHandlerToRemoveProxyHandlerFnMap.Count - 1; i >= 0; i--)
                    {
                        TupleStruct<Delegate, Delegate, Action<T, Delegate>> struct2 = this.clientHandlerToRemoveProxyHandlerFnMap[i];
                        if ((struct2.Item1 == clientHandler) && (struct2.Item3 == removeProxyHandlerFn))
                        {
                            this.clientHandlerToRemoveProxyHandlerFnMap.RemoveAt(i);
                            delegate2 = struct2.Item2;
                            break;
                        }
                    }
                }
                if (delegate2 != null)
                {
                    removeProxyHandlerFn(base.innerRefT, delegate2);
                }
            }
        }
    }
}

