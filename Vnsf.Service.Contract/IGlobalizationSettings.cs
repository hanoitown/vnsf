using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Globalization;
using Vnsf.Service.Data.Globalization;
using Vnsf.Service.Data.Messaging.ConfigurationService;

namespace Vnsf.Service.Contract
{
    public interface IGlobalizationSettings
    {
        GetCulturesResponse GetAllCulture(GetRequestCultures request);
        GetCultureDetailResponse GetCultureDetail(GetCultureDetailRequest detailRequest);
        CreateCultureResponse CreateCulture(CreateCultureRequest request);

        GetLanguagesResponse GetLanguages(GetLanguagesRequest request);
        GetLanguageDetailResponse GetLanguageDetail(GetLanguageDetailRequest detailRequest);
    }


}
