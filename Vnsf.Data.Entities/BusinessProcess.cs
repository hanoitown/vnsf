using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class BusinessProcess : BaseBusiness
    {
        public string Name { get; set; }
        public int ProcessTime { get; set; }
        public string ResultAnnouncement { get; set; }
        public decimal Fee { get; set; }
        public ICollection<Process> Processes { get; set; }
        public virtual ICollection<TaskItem> Tasks { get; set; }
    }
}
