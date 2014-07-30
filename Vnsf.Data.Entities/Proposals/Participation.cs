using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities.Proposals
{
    public class Participation
    {
        public Guid Id { get; set; }
        public ParticipantRole Role { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Proposal Proposal { get; set; }
        public virtual UserProfile Profile { get; set; }

    }

    public enum ParticipantRole
    {
        PI,
        Assistant,
        Technical,
        Secretary
    }
}
