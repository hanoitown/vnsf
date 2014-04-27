using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class BusinessDocument
    {
        public Doc Content { get; set; }
        public string Url { get; set; }
        public BusinessDocumentType DocumentType { get; set; }
    }
}
