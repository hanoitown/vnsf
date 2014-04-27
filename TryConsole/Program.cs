using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var countries = new List<RegionInfo>();
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures).Where(c => (c.TwoLetterISOLanguageName.Length == 2) && (c.ThreeLetterISOLanguageName.Length == 3)))
            {
                var country = new RegionInfo(culture.LCID);
                if (countries.All(p => p.Name != country.Name))
                    countries.Add(country);
            }

            foreach (var country in countries)
            {
                Console.WriteLine(string.Format("{0}-{1}-{2}", country.GeoId, country.TwoLetterISORegionName, country.ThreeLetterISORegionName));
            }
            Console.ReadLine();

        }

        
        //Console.WriteLine(cultures.Count().ToString());
        
        //return cultureList;
    }
}

