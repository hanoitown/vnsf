using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class EducationBindingModel : IMapFrom<Education>
    {
        [HiddenInput]
        public Guid Id { get; set; }
        //public EducationLevel Level { get; set; }
        public string Specialization { get; set; }
        public string ProgramDescription { get; set; }
        public string EducationPlace { get; set; }
        public int Duration { get; set; }
        public MonthYear StartDate { get; set; }
        public MonthYear EndDate { get; set; }
        [HiddenInput]
        public virtual Guid ProfileId { get; set; }

    }
}