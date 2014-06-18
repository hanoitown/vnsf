using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Account;

namespace Vnsf.Data.Entities
{
    public class TaskAssignment
    {        
        public AssignmentType AssignmentType { get; set; } // coperate, FYI, requestforApproval
        
        public UserAccount Assigner { get; set; }
        public UserAccount Assignee { get; set; }
        
        public DateTime DeadLine { get; set; }        
        public DateTime AcceptedDate { get; set; }

        

        public virtual ICollection<TaskOperation> Discussions { get; set; }
    }
}
