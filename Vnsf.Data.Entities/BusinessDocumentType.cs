using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class BusinessDocumentType : BaseBusiness
    {
        public string Code { get; set; }
        public bool IsMainCopyRequired { get; set; }
        public Doc Template { get; set; }
    }
}
