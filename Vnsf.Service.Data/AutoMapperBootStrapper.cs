using System.Collections.Generic;
using AutoMapper;
using Vnsf.Data.Entities.Globalization;
using Vnsf.Service.Data.Globalization;

namespace Vnsf.Service.Data
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Language, LanguageData>().ForMember(dest => dest.Name, opt => opt.Ignore());
            Mapper.CreateMap<Country, CountryData>().ForMember(dest => dest.Name, opt => opt.Ignore());
            Mapper.CreateMap<Culture, CultureData>().ForMember(dest => dest.Name, opt => opt.Ignore());
            Mapper.CreateMap<CultureLocalized, CultureLocalizedData>();
            Mapper.CreateMap<LanguageLocalized, LanguageLocalizedData>();

            //Mapper.AssertConfigurationIsValid();
            //Mapper.CreateMap<IEnumerable<CultureId>, IEnumerable<CultureData>>();
        }


    }


}
