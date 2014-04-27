using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.WebHost.Models
{
    public class ContactBindingModel
    {
        public Guid Id { set; get; }
        public string Name { get; set; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
    }
}