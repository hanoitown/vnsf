using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataSync.Models
{
    public class ProjectViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Abstract { get; set; }
        public string Field { get; set; }
        public string Group { get; set; }
        public string Type { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int? Duration { get; set; }
        public int? Human { get; set; }
        public int? Expense { get; set; }
        public IEnumerable<tbl_review> Reviews { get; set; }
        public IEnumerable<tbl_report> Reports { get; set; }
        public IEnumerable<MemberViewModel> Members { get; set; }


    }

    public class MemberViewModel
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
}