using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class TaskItem : BaseBusiness
    {

        public bool IsCompleted { get; set; }
        public string Status { get; set; }
        public BusinessProcess BusinessProcess { get; set; }
        public virtual ICollection<TaskAssignment> Assignments { get; set; }
        public virtual ICollection<TaskApproval> Approvals { get; set; }
        public virtual ICollection<TaskOperation> TaskOperations { get; set; }
        public virtual ICollection<Doc> Documents { get; set; }

    }
}
