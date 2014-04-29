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
        public string SecurityCode { get; set; }
        public Permission Permission { get; set; } // Allow Download
    }
}
