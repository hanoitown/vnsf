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
        [Display(Name="Email or Mobile")]
        public string Username { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }
        [Required, MinLength(8)]
        public string RePassword { set; get; }

    }
}