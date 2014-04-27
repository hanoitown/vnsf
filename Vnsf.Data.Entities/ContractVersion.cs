using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class ContractVersion : Version
    {
        public virtual Contract Contract { get; set; }
    }
}
