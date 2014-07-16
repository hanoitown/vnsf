using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public interface IAudit
    {
        DateTime? Created { set; get; }
        DateTime? LastUpdated { set; get; }
        UserAccount User { set; get; }

    }
}
