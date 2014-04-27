using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    /// <summary>
    /// Purpose of discussion is complete single process. Once the task is complete, it kick off next task in businessprocess
    /// </summary>
    public class TaskOperation : BaseBusiness
    {
        public Process Process { get; set; }
        public TaskItem Assignment { get; set; }
        public string Status { get; set; } // open, closed
        public DateTime StartedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public virtual ICollection<Doc> Documents { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }

    }
}


