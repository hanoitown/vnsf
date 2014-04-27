using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.Presentation.Web.Models
{
    public class AccountRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}