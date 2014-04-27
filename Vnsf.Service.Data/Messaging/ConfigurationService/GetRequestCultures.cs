using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Service.Data.Messaging.ConfigurationService
{
    public class GetRequestCultures
    {
        public int Index { set; get; }
        public int NumberOfResultsPerPage { get; set; }
        public int CultureId { get; set; }
        public CultureSortBy CultureSortBy { get; set; }
    }
}
