using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class UserAccountLoginModel
    {
        public string EmailOrMobile { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
