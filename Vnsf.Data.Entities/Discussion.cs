using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class Discussion
    {
        public string Topic { get; set; } // process name
        public virtual ICollection<DiscussionComment> Comments { get; set; }
        public virtual ICollection<DiscussionParticipant> Participants { get; set; }

    }
}
