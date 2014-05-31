using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.WebHost.Models
{
    public class UserAccountRegisterModel
    {        
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public string Mobile { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }
        [Required, MinLength(8)]
        public string ConfirmPassword { set; get; }

    }
}