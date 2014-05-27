using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Account;

namespace Vnsf.Data.Entities.Shared
{
    public abstract class Audit : IAudit
    {
        public virtual DateTime? Created { set; get; }
        public virtual DateTime? LastUpdated { set; get; }
        public virtual UserAccount User { set; get; }
    }
}
