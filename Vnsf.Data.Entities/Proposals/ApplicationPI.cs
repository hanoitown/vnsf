using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Registration
{
    public class ApplicationPI : UserProfile
    {
        public bool LinkedProfile { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}
