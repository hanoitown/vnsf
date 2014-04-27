using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class CategoryChild : BaseBusiness
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { set; get; }
    }
}
