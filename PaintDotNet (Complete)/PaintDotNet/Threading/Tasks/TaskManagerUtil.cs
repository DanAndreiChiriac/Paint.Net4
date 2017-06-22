namespace PaintDotNet.Threading.Tasks
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Functional;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    internal static class TaskManagerUtil
    {
        internal static Task<Unit> CreateFrameworkTasksWrapper(this TaskManager taskManager, IReadOnlyList<TupleStruct<Task, double>> fxTasksAndProgressWeights)
        {
            Validate.IsNotNull<IReadOnlyList<TupleStruct<Task, double>>>(fxTasksAndProgressWeights, "fxTasksAndProgressWeights");
            object sync = new object();
            int count = fxTasksAndProgressWeights.Count;
            int completedCount = 0;
            double num = ((IEnumerable<double>) (from tapw in fxTasksAndProgressWeights select tapw.Item2)).Sum();
            double totalProgressWeight = (num <= 0.0) ? 1.0 : num;
            VirtualTask<Unit> virtualTask = taskManager.CreateVirtualTask(TaskState.Running);
            Action<int, Task> continueWithAction = delegate (int index, Task task) {
                object obj1 = sync;
                lock (obj1)
                {
                    TupleStruct<Task, double> struct2 = fxTasksAndProgressWeights[index];
                    double increment = struct2.Item2 / totalProgressWeight;
                    virtualTask.IncrementProgressBy(increment);
                    completedCount += 1;
                    if (completedCount == count)
                    {
                        List<Exception> innerExceptions = null;
                        for (int k = 0; k < count; k++)
                        {
                            struct2 = fxTasksAndProgressWeights[k];
                            AggregateException exception = struct2.Item1.Exception;
                            if (exception != null)
                            {
                                innerExceptions = innerExceptions ?? new List<Exception>();
                                innerExceptions.AddRange(exception.InnerExceptions);
                            }
                        }
                        if (innerExceptions == null)
                        {
                            virtualTask.TaskResult = Result.Unit;
                        }
                        else
                        {
                            virtualTask.TaskResult = Result.NewError((innerExceptions.Count == 1) ? innerExceptions[0] : new AggregateException(innerExceptions), false);
                        }
                        virtualTask.SetState(TaskState.Finished);
                    }
                }
            };
            for (int j = 0; j < count; j++)
            {
                int index = j;
                TupleStruct<Task, double> struct2 = fxTasksAndProgressWeights[j];
                struct2.Item1.ContinueWith(delegate (Task t) {
                    continueWithAction(index, t);
                });
            }
            return virtualTask;
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly TaskManagerUtil.<>c <>9 = new TaskManagerUtil.<>c();
            public static Func<TupleStruct<Task, double>, double> <>9__0_0;

            internal double <CreateFrameworkTasksWrapper>b__0_0(TupleStruct<Task, double> tapw) => 
                tapw.Item2;
        }
    }
}

