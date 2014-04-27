using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;

namespace Vnsf.WebHost.Models
{
    public class ContactViewModel
    {
        public string Name { get; set; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string Website { get; set; }
        public DateTime? LastUpdated { get; set; }

    }
}