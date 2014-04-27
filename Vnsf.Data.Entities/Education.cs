using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Education : BaseBusiness
    {
        public string Name { get; set; }
        public string Program { get; set; }
        public Category Field { get; set; }
        public EducationLevel Level { get; set; }
        public string OtherOrganization { get; set; }
        public University Organization { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ParticipationDuration { get; set; }
    }
}
