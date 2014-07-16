using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Document;

namespace Vnsf.Data.Entities.Registration
{
    public class ApplicationForm
    {
        public Guid Id { get; set; }
        public string Code { get; set; } // KHTN_V1
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public Opportunity Opportunity { get; set; }
        public virtual ICollection<ApplicationDocument> Documents { get; set; }

        public ApplicationForm()
        {
            Documents = new List<ApplicationDocument>();
        }
    }

    
}
