using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Shared
{
    public abstract class Publisher
    {
        public Guid Id { get; set; }
        public string Title{ get; set; }
        public string Description { get; set; }        
    }
}
