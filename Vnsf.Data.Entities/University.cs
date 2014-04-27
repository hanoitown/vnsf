using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class University : Organization
    {
        public bool IsStateOwn { get; set; }
    }
}
