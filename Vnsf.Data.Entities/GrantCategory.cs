using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class GrantCategory : BaseBusiness
    {
        public ICollection<Grant> Grants { get; set; }

    }
}
