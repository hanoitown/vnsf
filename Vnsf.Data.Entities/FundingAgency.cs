using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class FundingAgency : Organization
    {
        public bool IsPublic { get; set; }
        public bool? IsActive { get; set; }

        public FundingAgency()
            : base()
        {

        }
    }
}
