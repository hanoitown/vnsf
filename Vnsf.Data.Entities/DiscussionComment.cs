using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class DiscussionComment : BaseBusiness
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual DiscussionParticipant User { get; set; }
        public virtual ICollection<Doc> Documents { get; set; }
    }
}
