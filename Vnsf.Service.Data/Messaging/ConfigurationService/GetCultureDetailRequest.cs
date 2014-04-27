using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Service.Data.Messaging.ConfigurationService
{
    public class GetCultureDetailRequest
    {
        public int Id { set; get; }
        public int CultureId { get; set; }
    }
}
