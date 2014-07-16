using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class ProposalEducation 
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public EducationLevel Level { get; set; }

        public virtual Proposal Proposal { get; set; }
    }
}
