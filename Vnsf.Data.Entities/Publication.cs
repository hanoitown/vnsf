using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Publication : BaseBusiness
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string ISSN { get; set; }
        public virtual Category Category { get; set; }
        public string OtherOganization { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Doc Document { get; set; }
    }
}
