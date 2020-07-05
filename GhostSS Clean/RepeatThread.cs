using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GhostSS
{
    public static class TaskExtensions
    {
     
        public static void Repeat(this Task taskToRepeat, CancellationToken cancellationToken, TimeSpan intervalTimeSpan)
        {
            var action = taskToRepeat
                .GetType()
                .GetField("m_action", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(taskToRepeat) as Action;

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (cancellationToken.WaitHandle.WaitOne(intervalTimeSpan))
                        break;
                    if (cancellationToken.IsCancellationRequested)
                        break;
                    Task.Factory.StartNew(action, cancellationToken);
                }
            }, cancellationToken);
        }
    }
}
