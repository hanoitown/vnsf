using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGrease.Css.Extensions;

namespace Vnsf.WebHost.Infrastructure.Tasks
{
    public class TaskManager : ITaskManager
    {
        private readonly IRunAtInit[] _initTasks;

        public TaskManager(IRunAtInit[] initTasks)
        {
            _initTasks = initTasks;
        }

        public void RunInitTask()
        {
            throw new NotImplementedException();
            _initTasks.ForEach(t => t.Execute());
        }
    }
}