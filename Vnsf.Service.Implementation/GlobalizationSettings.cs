using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Vnsf.Data.Contracts;
using Vnsf.Data.Entities.Globalization;
using Vnsf.Service.Contract;
using Vnsf.Service.Data.Globalization;
using Vnsf.Service.Data.Mapping;
using Vnsf.Service.Data.Messaging.ConfigurationService;

namespace Vnsf.Service.Implementation
{
    public class GlobalizationSettings : IGlobalizationSettings
    {
        private IUow Uow { get; set; }

        public GlobalizationSettings(IUow uow)
        {
            Uow = uow;
        }

        public IQueryable<CultureData> GetAvailableCulture(GetAvailableRequestCulture request)
        {
            return Uow.Cultures.Get(null, null, c => c._localizations)
                        .Where(c => c._localizations.Any(l => l.CultureId.Equals(request.CultureId))) // only localized
                        .Select(c => new CultureData
                        {
                            Id = c.Id,
                            Code = c.Code,
                            Name = c._localizations.First(l => l.CultureId.Equals(request.CultureId)).Name,
                        });
        }
        public IQueryable<LanguageData> GetAvailableData()
        {
            throw new NotImplementedException();
        }

        public GetCulturesResponse GetAllCulture(GetRequestCultures request)
        {
            if (!Uow.Cultures.Get(c => c.Id.Equals(request.CultureId)).Any())
                throw new CultureNotFoundException("Request culture not supported");

            var result = Uow.Cultures.Get(null, null, icl => icl._localizations, icl => icl.Language,
                                          icl => icl.Country, icl => icl.ParentCulture);

            var response = new GetCulturesResponse
            {
                Cultures = result.Select(d => new CultureData
                                     {
                                         Id = d.Id,
                                         Code = d.Code,
                                         Name = d._localizations.Join(new[]
                                                    {
                                                        new {Index = 0, CultureId = request.CultureId},
                                                        new { Index = 1, CultureId = CultureInfo.InvariantCulture.LCID }
                                                    }, cl => cl.CultureId,
                                                    o => o.CultureId, (cl, o) => new { Index = o.Index, Name = cl.Name })
                                             .OrderBy(o => o.Index)
                                             .Select(o => o.Name)
                                             .FirstOrDefault(),
                                         Language = new LanguageData
                                         {
                                             Id = d.Id,
                                             Iso2 = d.Language.Iso2,
                                             Iso3 = d.Language.Iso3,
                                             Name = d.Language.Localizations.Join(new[]
                                                    {
                                                        new {Index = 0, CultureId = request.CultureId},
                                                        new { Index = 1, CultureId = CultureInfo.InvariantCulture.LCID }
                                                    }, cl => cl.CultureId,
                                                 o => o.CultureId, (cl, o) => new { Index = o.Index, Name = cl.Name })
                                                 .OrderBy(o => o.Index)
                                                 .Select(o => o.Name)
                                                 .FirstOrDefault()
                                         },
                                         Country = new CountryData
                                         {
                                             Id = d.Id,
                                             Iso2 = d.Country.Iso2,
                                             Iso3 = d.Country.Iso3,
                                             Name = d.Country.Localizations.Join(new[]
                                                    {
                                                        new {Index = 0, CultureId = request.CultureId},
                                                        new { Index = 1, CultureId = CultureInfo.InvariantCulture.LCID }
                                                    }, cl => cl.CultureId,
                                                 o => o.CultureId, (cl, o) => new { Index = o.Index, Name = cl.Name })
                                                 .OrderBy(o => o.Index)
                                                 .Select(o => o.Name)
                                                 .FirstOrDefault()
                                         }

                                     }).OrderBy(c => c.Name)
                            .Skip((request.Index - 1) * request.NumberOfResultsPerPage)
                            .Take(request.NumberOfResultsPerPage).ToList(),
                CurrentPage = request.Index,
                TotalNumberOfPage = result.Count() / request.NumberOfResultsPerPage
            };

            return response;
        }

        public GetCultureDetailResponse GetCultureDetail(GetCultureDetailRequest request)
        {
            var response = new GetCultureDetailResponse();
            // Include statement need to deep enough to cover all information return
            var cul = Uow.Cultures.Get(c => c.Id == request.Id, null, o => o.Language.Localizations, o => o.Country.Localizations, o => o._localizations.Select(c => c.Culture._localizations)).SingleOrDefault();
            if (cul != null)
                response.CultureData = new CultureData
                                       {
                                           Id = cul.Id,
                                           Code = cul.Code,
                                           Name = cul._localizations.Join(new[]
                                                    {
                                                        new {Index = 0, CultureId = request.CultureId},
                                                        new { Index = 1, CultureId = CultureInfo.InvariantCulture.LCID }
                                                    }, cl => cl.CultureId,
                                                 o => o.CultureId, (cl, o) => new { Index = o.Index, Name = cl.Name })
                                                 .OrderBy(o => o.Index)
                                                 .Select(o => o.Name)
                                                 .FirstOrDefault(),
                                           Language = cul.Language != null ? cul.Language.ToLanaguageData(request.CultureId) :
                                                    new LanguageData { Iso2 = "IV", Iso3 = "IVL", Name = "Invariant Lanaguage" },
                                           Country = cul.Country != null ? cul.Country.ToCountryData(request.CultureId) :
                                                    new CountryData() { Iso2 = "IV", Iso3 = "IVL", Name = "Invariant Country" },
                                           Localized = cul._localizations.Select(c => new CultureLocalizedData
                                                {
                                                    Id = c.Id,
                                                    CultureId = c.CultureId,
                                                    CultureName = c.Culture._localizations.Join(new[]
                                                        {
                                                            new { Index = 0, CultureId = request.CultureId},
                                                            new { Index = 1, CultureId = CultureInfo.InvariantCulture.LCID }
                                                        }, cl => cl.CultureId,
                                                        o => o.CultureId, (cl, o) => new { Index = o.Index, Name = cl.Name })
                                                        .OrderBy(o => o.Index)
                                                        .Select(o => o.Name)
                                                        .FirstOrDefault(),
                                                    Name = c.Name
                                                })
                                       };

            return response;
        }

        public CreateCultureResponse CreateCulture(CreateCultureRequest request)
        {
            var response = new CreateCultureResponse();
            if (request.Data != null)
            {
                var culture = CultureInfo.GetCultureInfo(request.Data.Code);
                var region = new RegionInfo(culture.LCID);
                //locate associted info
                var language = Uow.Languages.Get(o => o.Iso3.Equals(culture.ThreeLetterISOLanguageName), null, null).FirstOrDefault();
                var country = Uow.Countries.Get(o => o.Iso3.Equals(region.ThreeLetterISORegionName), null, null).FirstOrDefault();
                // insert culture 
                Uow.Cultures.Add(new Culture
                    {
                        Id = request.Data.Id,
                        ParentCultureId = request.Data.ParentCulture.Id,
                        Code = request.Data.Code,
                        Language = language ?? new Language { Id = culture.LCID, Iso2 = culture.TwoLetterISOLanguageName, Iso3 = culture.ThreeLetterISOLanguageName, Localizations = new Collection<LanguageLocalized> { new LanguageLocalized { LanguageId = culture.LCID, CultureId = CultureInfo.InvariantCulture.LCID, Name = culture.NativeName } } },
                        Country = country ?? new Country { Id = region.GeoId, Iso2 = region.TwoLetterISORegionName, Iso3 = region.ThreeLetterISORegionName, Localizations = new Collection<CountryLocalized> { new CountryLocalized { CountryId = region.GeoId, CultureId = CultureInfo.InvariantCulture.LCID, Name = region.NativeName } } },
                        _localizations = new List<CultureLocalized>
                            {
                                new CultureLocalized{ Id = request.Data.Id, CultureId = CultureInfo.InvariantCulture.LCID, Name = request.Data.Name}
                            },
                    });
                Uow.Commit();
            }
            else
            {
                throw new Exception("Cannot create empty element");
            }

            return response;
        }
        public GetLanguagesResponse GetLanguages(GetLanguagesRequest request)
        {
            if (!Uow.Languages.Get(c => c.Id.Equals(request.CultureId)).Any())
                throw new CultureNotFoundException("Request culture not supported");

            var result = Uow.Languages.Get(null, null, icl => icl.Localizations, icl => icl.Cultures);

            var response = new GetLanguagesResponse
            {
                Languages = result.Select(d => new LanguageData
                {
                    Id = d.Id,
                    Iso2 = d.Iso2,
                    Iso3 = d.Iso3,
                    Name = d.Localizations.Join(new[]
                                                        {
                                                            new {Index = 0, CultureId = request.CultureId},
                                                            new { Index = 1, CultureId = CultureInfo.InvariantCulture.LCID }
                                                        }, cl => cl.CultureId,
                               o => o.CultureId, (cl, o) => new { Index = o.Index, Name = cl.Name })
                        .OrderBy(o => o.Index)
                        .Select(o => o.Name)
                        .FirstOrDefault()
                }).OrderBy(c => c.Name)
                .Skip((request.Index - 1) * request.NumberOfResultsPerPage)
                .Take(request.NumberOfResultsPerPage).ToList(),
                CurrentPage = request.Index,
                TotalNumberOfPage = result.Count() / request.NumberOfResultsPerPage
            };

            return response;

        }
        public GetLanguageDetailResponse GetLanguageDetail(GetLanguageDetailRequest detailRequest)
        {
            var response = new GetLanguageDetailResponse();
            // Include statement need to deep enough to cover all information return
            var cul = Uow.Languages.Get(c => c.Id == detailRequest.Id, null, o => o.Localizations.Select(c => c.Culture._localizations)).SingleOrDefault();
            if (cul != null)
                response.Data = new LanguageData
                {
                    Id = cul.Id,
                    Iso2 = cul.Iso2,
                    Iso3 = cul.Iso3,
                    Name = cul.Localizations.Join(new[]
                                                    {
                                                        new {Index = 0, CultureId = detailRequest.CultureId},
                                                        new { Index = 1, CultureId = CultureInfo.InvariantCulture.LCID }
                                                    }, cl => cl.CultureId,
                          o => o.CultureId, (cl, o) => new { Index = o.Index, Name = cl.Name })
                          .OrderBy(o => o.Index)
                          .Select(o => o.Name)
                          .FirstOrDefault(),
                    Localizations = cul.Localizations.Select(c => new LanguageLocalizedData
                    {
                        Id = c.LanguageId,
                        CultureId = c.CultureId,
                        CultureName = c.Culture._localizations.Join(new[]
                                                        {
                                                            new { Index = 0, CultureId = detailRequest.CultureId},
                                                            new { Index = 1, CultureId = CultureInfo.InvariantCulture.LCID }
                                                        }, cl => cl.CultureId,
                            o => o.CultureId, (cl, o) => new { Index = o.Index, Name = cl.Name })
                            .OrderBy(o => o.Index)
                            .Select(o => o.Name)
                            .FirstOrDefault(),
                        Name = c.Name
                    })
                };

            return response;
        }
    }
}
