using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataSync.Models
{
    public class ReviewModel
    {
        public string Code { get; set; }
        public string Project { get; set; }
        public string PI { get; set; }
        public string Role { get; set; }
        public IEnumerable<ReviewBrief> Reviews { get; set; }
    }

    public class ReviewBrief
    {
        public int Reviewer { get; set; }
        public int Status { get; set; }
    }
}