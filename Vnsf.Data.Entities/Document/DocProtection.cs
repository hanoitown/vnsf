using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Security;

namespace Vnsf.Data.Entities
{
    public class DocProtection
    {
        public Guid Id { get; set; }
        public Doc Doc { get; set; }  // Thuyet minh de tai
        public UserClaim User { get; set; } // ldlap@most.gov.vn
        public Permission Permission { get; set; } // Allow Download
    }
}
