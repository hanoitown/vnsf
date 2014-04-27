using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities.Account;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Models
{
    public class UserAccountBindingModel : IMapFrom<UserAccount>
    {
        [HiddenInput]
        public Guid? Id { get; set; }
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(8)]
        public string HashedPassword { set; get; }
    }

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

}