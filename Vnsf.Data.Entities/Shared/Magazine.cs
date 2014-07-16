using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Shared
{
    public class Magazine : Publisher
    {
        public string ISSN { get; set; }
        public DateTime PublishDate { get; set; }
        public Category Sector { get; set; }
    }
}
