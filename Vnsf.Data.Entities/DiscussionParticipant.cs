using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class DiscussionParticipant
    {
        public Staff User { get; set; }
        public DiscussionRole Role { get; set; }
        public DateTime JoinDate { get; set; }        
    }
}
