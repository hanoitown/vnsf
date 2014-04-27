using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class CategorgyHierchy
    {
        public Guid Id { get; set; }
        public Guid Parent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}
