using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Document;

namespace Vnsf.Data.Entities
{
    public class ApplicationItem : FileBase
    {
        public virtual Opportunity Opportunity { get; set; }
    }
}
