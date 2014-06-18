using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public abstract class Researcher : Person
    {
        public University Organization { get; set; } //must be university or research institue
        public virtual ICollection<Job> JobHistory { get; set; }
        public virtual ICollection<Education> EducationHistory { get; set; }
        public virtual ICollection<Publication> Publications { set; get; }
    }
}
