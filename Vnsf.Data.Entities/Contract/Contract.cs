using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Contract
    {
        public Guid Id { get; set; }
        public DateTime SignDate { get; set; }
        public virtual Award Award { get; set; } // application version when contract is signed
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<ChangeRequest> Changes { get; set; }
    }
}
