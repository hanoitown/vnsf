using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vnsf.Data.Entities
{
    public class DocShare : BaseBusiness
    {
        public DateTime ExpireDate { get; set; }
        public string SecurityCode { get; set; }
        public virtual ICollection<Doc> Documents { get; set; }
        public virtual ICollection<DocProtection> Rights { get; set; }

    }
}
