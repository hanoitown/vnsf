using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class ResearchMember : BaseBusiness
    {
        public string Organization { get; set; }
        public EducationLevel EducationLevel { get; set; }
    }
}
