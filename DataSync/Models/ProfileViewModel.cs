using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataSync.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public string Office { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IEnumerable<tbl_education> Educations { get; set; }
        public IEnumerable<tbl_publication> Publications { get; set; }
        public IEnumerable<tbl_work> Works { get; set; }
        
    }
}