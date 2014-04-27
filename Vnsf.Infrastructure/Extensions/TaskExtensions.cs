﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Infrastructure.Extensions
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Logs the exeptions that may occur in a task
        /// http://stackoverflow.com/questions/7883052/a-tasks-exceptions-were-not-observed-either-by-waiting-on-the-task-or-accessi
        /// </summary>
        /// <param name="source">Task to log exceptions</param>
        public static void LogExceptions(this Task source)
        {
            Logger log = LogManager.GetCurrentClassLogger();

            source.ContinueWith(x =>
            {
                foreach (var exception in x.Exception.Flatten().InnerExceptions)
                {
                    log.Debug(exception);
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

    }
}
