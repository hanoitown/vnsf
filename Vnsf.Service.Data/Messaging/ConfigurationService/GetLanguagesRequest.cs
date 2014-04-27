using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Service.Data.Messaging.ConfigurationService
{
    public class GetLanguagesRequest
    {
        public int Index { set; get; }
        public int CultureId { set; get; }
        public int NumberOfResultsPerPage { get; set; }
    }
}
