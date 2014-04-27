using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using Vnsf.Data.Entities.Globalization;
using Vnsf.Service.Data.Globalization;
using Vnsf.Service.Data.Messaging.ConfigurationService;

namespace Vnsf.Service.Data.Mapping
{
    public static class GlobalizationSettingsExtensions
    {
        public static CultureData ToCultureData(this Culture item, int cId)
        {
            var result = Mapper.Map<Culture, CultureData>(item);
            result.Name = item._localizations.Join(new[]
                            {
                                new {Index = 0, CultureId = cId},
                                new {Index = 1, CultureId = CultureInfo.InvariantCulture.LCID}
                            }, cl => cl.CultureId, o => o.CultureId, (cl, o) => new { Index = o.Index, Name = cl.Name })
                .OrderBy(o => o.Index)
                .Select(o => o.Name)
                .FirstOrDefault();
            return result;
        }

        public static LanguageData ToLanaguageData(this Language item, int cId)
        {
            var result = Mapper.Map<Language, LanguageData>(item);
            result.Name = item.Localizations.Join(new[]
                            {
                                new {Index = 0, CultureId = cId},
                                new {Index = 1, CultureId = CultureInfo.InvariantCulture.LCID}
                            }, cl => cl.CultureId, o => o.CultureId, (cl, o) => new { Index = o.Index, Name = cl.Name })
                .OrderBy(o => o.Index)
                .Select(o => o.Name)
                .FirstOrDefault();

            return result;
        }

        public static CountryData ToCountryData(this Country item, int cId)
        {
            var result = Mapper.Map<Country, CountryData>(item);
            result.Name = item.Localizations.Join(new[]
                                                      {
                                                          new {Index = 0, CultureId = cId},
                                                          new {Index = 1, CultureId = CultureInfo.InvariantCulture.LCID}
                                                      }, cl => cl.CultureId,
                                                  o => o.CultureId, (cl, o) => new { Index = o.Index, Name = cl.Name })
                .OrderBy(o => o.Index)
                .Select(o => o.Name)
                .FirstOrDefault();

            return result;
        }

        public static GetCulturesResponse GetResponseFrom(this IEnumerable<Culture> data, GetRequestCultures request)
        {
            /*
                        return new GetCulturesResponse
                                    {
                                        TotalNumberOfPage = NoOfResultPagesGiven(request.NumberOfResultsPerPage, data.Count()),
                                        Languages = CropCultureListToSatisfyGivenIndex(request.Index, request.NumberOfResultsPerPage, data)
                                            .Select(d => new CultureData
                                                {
                                                    Id = d.Id,
                                                    Code = d.Code,
                                                    Name = d._localizations.Join(new[] {
                                                                        new { Index = 0, CultureId = request.CultureId },
                                                                        new { Index = 1, CultureId = CultureInfo.InvariantCulture.LCID }
                                                                    }, cl => cl.CultureId, o => o.CultureId, 
                                                                    (cl, o) => new { Index = o.Index, Name = cl.Name })
                                                                    .OrderBy(o => o.Index)
                                                                    .Select(o => o.Name)
                                                                    .FirstOrDefault(),
                                                    Language = d.Language.ConvertToData(request.CultureId),
                                                    Country = null
                                                })
                                    };
            */
            return null;
        }

        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfTitlesFound)
        {
            if (numberOfTitlesFound < numberOfResultsPerPage)
                return 1;
            else
            {
                return (numberOfTitlesFound / numberOfResultsPerPage) + (numberOfTitlesFound % numberOfResultsPerPage);
            }
        }
        private static IEnumerable<Culture> CropCultureListToSatisfyGivenIndex(int pageIndex, int numberOfResultsPerPage, IEnumerable<Culture> cultures)
        {
            if (pageIndex <= 1)
                return cultures.Take(numberOfResultsPerPage);
            else
            {
                var numToSkip = (pageIndex - 1) * numberOfResultsPerPage;
                return cultures.Skip(numToSkip).Take(numberOfResultsPerPage);
            }
        }

        private static LanguageData ConvertToData(this Language item, int cul)
        {
            if (item == null)
            {
                return null;
            }
            else
            {
                var language = Mapper.Map<Language, LanguageData>(item);
                language.Name = item.Localizations.Any() ? item.Localizations.First(c => c.CultureId.Equals(cul)).Name : string.Empty;
                return language;
            }
        }
        private static CountryData ConvertToCountryData(this Country item, int cul)
        {
            if (item != null)
            {
                var country = Mapper.Map<Country, CountryData>(item);
                country.Name = item.Localizations.Any() ? item.Localizations.First(c => c.CultureId.Equals(cul)).Name : string.Empty;
                return country;
            }
            else
            {
                return null;
            }
        }
    }
}
