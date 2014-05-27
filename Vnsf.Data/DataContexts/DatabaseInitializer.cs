using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;

namespace Vnsf.Data.EF.Samples
{
    public class VnsfDatabaseInitializer :
        //CreateDatabaseIfNotExists<VnsfDbContext>      // when model is stable
        CreateDatabaseIfNotExists<VnsfDbContext> // when iterating
    {
        private const string FallbackCulture = "vi-VN";
        private const string Secondary = "en-US";

        protected override void Seed(VnsfDbContext context)
        {
            // Seed code here
            //InitializeCultureData(context);
            //context.Grants.AddOrUpdate(
            //    g => g.Code,
            //    new Grant { Id = Guid.NewGuid(), Code = "119", Name = "Đề tài 119", Description = "Đề tài theo nghị định 119NDCP", MaxAward = 0, MaxDuration = 24, Objective = "119" }
            //    );

            //var admin = UserAccount.Init("admin", "654321", "admin@hanoitown.com");
            //var hanm = UserAccount.Init("hanm", "123456", "ha@hanoitown.com");
            //context.UserAccounts.AddOrUpdate(p => p.Email, admin);
            //context.UserAccounts.AddOrUpdate(p => p.Email, hanm);


            //context.Classification.AddOrUpdate(c => c.Name, new Classification
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "119",
            //    Categories = new List<Category>
            //                        {
            //                            new Category( "Đơn đề nghị", string.Empty),
            //                            new Category("Thuyết minh đề cương", string.Empty)
            //                        }
            //});

            //context.Organizations.AddOrUpdate(o => o.ShortName, new FundingAgency
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "QUY PTKHCN QG",
            //    ShortName = "Nafosted",
            //    Contact = new Contact()
            //});

            //context.SaveChanges();

        }

        //private static void InitializeCultureData(VnsfDbContext context)
        //{

        //    var cultures = new List<Culture>();

        //    // Create entry for Invariant culture the root of all culture
        //    var invariant = CultureInfo.InvariantCulture;
        //    var item = new Culture
        //    {
        //        LcId = invariant.LCID,
        //        Code = string.Empty,
        //        Country = null,
        //        Language = null,
        //        Localizations = new List<CultureLocalized>
        //            {
        //                new CultureLocalized
        //                    {
        //                        Name = invariant.NativeName, 
        //                        CultureId = CultureInfo.InvariantCulture.LCID, 
        //                        Id = CultureInfo.InvariantCulture.LCID
        //                    }
        //            }
        //    };
        //    context.Cultures.Add(item);
        //    context.SaveChanges();

        //    var fallback = CultureInfo.GetCultureInfo(FallbackCulture);
        //    // initialize language and country info based on invariant culture
        //    var vi = InitializeLanguageData(fallback, context);
        //    var vn = InitializedCountryData(fallback, context);
        //    var vivnCulture = new Culture
        //                          {
        //                              Id = fallback.LCID,
        //                              Code = fallback.Name,
        //                              ParentCultureId = CultureInfo.InvariantCulture.LCID,
        //                              Country = vn,
        //                              Language = vi,
        //                              _localizations = new List<CultureLocalized>
        //                                                {
        //                                                    new CultureLocalized
        //                                                        {
        //                                                            Id=fallback.LCID, CultureId = CultureInfo.InvariantCulture.LCID, Name = fallback.DisplayName
        //                                                        },
        //                                                    new CultureLocalized
        //                                                        {
        //                                                            Id = fallback.LCID, CultureId = fallback.LCID, Name = fallback.NativeName
        //                                                        }
        //                                                }
        //                          };
        //    context.Cultures.Add(vivnCulture);
        //    context.SaveChanges();

        //    var second = CultureInfo.GetCultureInfo(Secondary);
        //    var en = InitializeLanguageData(second, context);
        //    var us = InitializedCountryData(second, context);

        //    var enusCulture = new Culture
        //    {
        //        Id = second.LCID,
        //        Code = second.Name,
        //        ParentCultureId = CultureInfo.InvariantCulture.LCID,
        //        Country = us,
        //        Language = en,
        //        _localizations = new List<CultureLocalized>
        //                                                {
        //                                                    new CultureLocalized
        //                                                        {
        //                                                            Id=second.LCID, CultureId = CultureInfo.InvariantCulture.LCID, Name = second.DisplayName
        //                                                        },
        //                                                    new CultureLocalized
        //                                                        {
        //                                                            Id = second.LCID, CultureId = second.LCID, Name = second.NativeName
        //                                                        },
        //                                                    new CultureLocalized
        //                                                        {
        //                                                            Id = second.LCID, CultureId = fallback.LCID, Name = "Anh (My)"
        //                                                        }
        //                                                }
        //    };
        //    context.Cultures.Add(enusCulture);
        //    context.SaveChanges();


        //    item._localizations.Add(new CultureLocalized
        //                               {
        //                                   Id = CultureInfo.InvariantCulture.LCID,
        //                                   CultureId = fallback.LCID,
        //                                   Name = invariant.NativeName
        //                               });

        //}


        //private static Language InitializeLanguageData(CultureInfo culture, VnsfDbContext context)
        //{
        //    var item = new Language
        //                         {
        //                             Id = culture.LCID,
        //                             Iso2 = culture.TwoLetterISOLanguageName,
        //                             Iso3 = culture.ThreeLetterISOLanguageName,
        //                             Localizations = new List<LanguageLocalized>
        //                                                 {
        //                                                     new LanguageLocalized
        //                                                         {
        //                                                             LanguageId = culture.LCID,
        //                                                             CultureId = CultureInfo.InvariantCulture.LCID,
        //                                                             Name = culture.EnglishName
        //                                                         }
        //                                                 }

        //                         };
        //    context.Languages.Add(item);
        //    context.SaveChanges();
        //    return item;
        //}

        ///// <summary>
        ///// Gets the list of countries based on ISO 3166-1
        ///// </summary>
        ///// <returns>Returns the list of countries based on ISO 3166-1</returns>
        //private static Country InitializedCountryData(CultureInfo culture, VnsfDbContext context)
        //{
        //    var fallbackCountry = new RegionInfo(culture.LCID);
        //    var item = new Country
        //                 {
        //                     Iso2 = fallbackCountry.TwoLetterISORegionName,
        //                     Iso3 = fallbackCountry.ThreeLetterISORegionName,
        //                     Id = fallbackCountry.GeoId,
        //                     Localizations = new List<CountryLocalized>
        //                                                 {
        //                                                     new CountryLocalized
        //                                                         {
        //                                                             CountryId = fallbackCountry.GeoId,
        //                                                             CultureId = CultureInfo.InvariantCulture.LCID,
        //                                                             Name = fallbackCountry.EnglishName
        //                                                         },
        //                                                 }
        //                 };
        //    context.Countries.Add(item);
        //    context.SaveChanges();
        //    return item;
        //}

        //private static void InitializeRegion(VnsfDbContext context)
        //{

        //}
    }
}