using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Service.Data.Messaging
{
    public abstract class RequestCultureAware
    {
        public virtual int CultureId { get; set; }
    }
}
