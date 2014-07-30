using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class ReportManageViewModel
    {
        public string Organization { get; set; }
        public string AwardNumber { get; set; }
        public ReportKind ReportKind { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public int Deadline { get; set; }
        public string PIName { get; set; }
    }
}