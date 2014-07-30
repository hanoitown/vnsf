using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class JobBindingModel : IMapFrom<Job>
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Position { get; set; }
        public string QuitReseason { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Company { get; set; }
        [HiddenInput]
        public Guid ProfileId { get; set; }

    }
}
