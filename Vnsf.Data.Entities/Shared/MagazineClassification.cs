using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Shared
{
    public class MagazineClassification
    {
        public Guid Id { get; set; }
        public Magazine Magazine { get; set; }
        public Category Kind { get; set; } //ISI/SCIE
        public DateTime UpdateDate { get; set; }
    }
}
