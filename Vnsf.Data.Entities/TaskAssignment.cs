using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class TaskAssignment
    {
        public bool IsMain { get; set; } // keeper
        public AssignmentType AssignmentType { get; set; } // coperate, FYI, requestforApproval
        public TaskItem Task { get; set; }
        public Staff Assigner { get; set; }
        public Staff Assignee { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime AcceptedDate { get; set; }
        public virtual ICollection<TaskOperation> Discussions { get; set; }
    }
}
