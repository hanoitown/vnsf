using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class UserAccountManageModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

    }
}