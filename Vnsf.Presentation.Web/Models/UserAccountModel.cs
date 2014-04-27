using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.Presentation.Web.Models
{
    public class UserAccountModel
    {
        public string Url { get; set; }
        public string Fullname { get; set; }
        public DateTime LastCreate { get; set; }
        public string Avatar { get; set; }
    }
}