using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Registration
{
    public class ProposalColaboration: Organization
    {
        public bool IsMain { get; set; }
        public string Description { get; set; } // detail about corabolation plan
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }        
        public virtual Organization Institution { get; set; }
        public virtual Proposal Proposal { get; set; }

        // evident: memo, agreement
    }
}
