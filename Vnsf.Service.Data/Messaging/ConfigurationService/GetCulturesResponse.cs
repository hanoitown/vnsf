using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Service.Data.Globalization;

namespace Vnsf.Service.Data.Messaging.ConfigurationService
{
    public class GetCulturesResponse
    {
        public int TotalNumberOfPage { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<CultureData> Cultures { get; set; }
    }
}
