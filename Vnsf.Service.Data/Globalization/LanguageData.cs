using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Service.Data.Globalization
{
    public class LanguageData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public IEnumerable<LanguageLocalizedData> Localizations { set; get; }
    }

    public class LanguageLocalizedData
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public LanguageData Language { get; set; }
        public CultureData Culture { get; set; }
        public string CultureName { set; get; }
        public string Name { set; get; }
    }
}
