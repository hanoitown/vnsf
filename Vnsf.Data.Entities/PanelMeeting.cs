using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class PanelMeeting:BaseBusiness
    {
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
        public virtual Panel Panel { get; set; }
        public virtual ICollection<Review> ReviewAssignments { get; set; }
        public virtual ICollection<PanelMember> Attentdance { get; set; }
        public virtual ICollection<PanelEvaluation> Evaluations { get; set; }       

    }
}
