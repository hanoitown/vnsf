using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Principle
{
    public class UserTitle
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TitleKind Kind { get; set; }
    }

    public enum TitleKind
    {
        Admin,
        Science
    }

}
