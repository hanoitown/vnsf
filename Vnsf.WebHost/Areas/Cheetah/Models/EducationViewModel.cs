using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class EducationViewModel : IMapFrom<Education>
    {
        public Guid Id { get; set; }
        public EducationLevel Level { get; set; }
        public string Specialization { get; set; }
        public string ProgramDescription { get; set; }
        public string EducationPlace { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}