using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Service.Data.Globalization
{
    public class CultureData
    {
        public int Id { get; set; }
        public string Code { set; get; }
        public string Name { get; set; } //in the local

        public CountryData Country { set; get; }
        public LanguageData Language { set; get; }
        public CultureData ParentCulture { get; set; }

        public IEnumerable<CultureLocalizedData> Localized { get; set; }

        public CultureData Localize(CultureData targetCulture)
        {
            var result = new CultureData
                {
                    Name = Localized.Join(new[]
                        {
                            new {Index = 0, CultureId = targetCulture.Id},
                            new {Index = 1, CultureId = CultureInfo.InvariantCulture.LCID}
                        }, cl => cl.CultureId,
                        o => o.CultureId, (cl, o) => new {Index = o.Index, Name = cl.Name})
                    .OrderBy(o => o.Index)
                    .Select(o => o.Name)
                    .FirstOrDefault()
                };

            return result;

        }
    }

    public class CultureLocalizedData
    {
        public Int32 Id { get; set; }
        public Int32 CultureId { get; set; }
        public string CultureName { get; set; }
        public string Name { get; set; }
    }
}
