using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Contracts;
using Vnsf.Service.Contract;
using Vnsf.Service.Data.Messaging.ConfigurationService;

namespace Vnsf.Registration.Web.Controllers
{
    public class LanguageController : BaseController
    {
        private readonly IGlobalizationSettings _globalizationSettings;
        
        //
        // GET: /Language/
        public LanguageController(IUow uow, IGlobalizationSettings settings)
        {
            Uow = uow;
            _globalizationSettings = settings;
        }

        public ActionResult Index()
        {
            var request = new GetLanguagesRequest
                              {
                                  CultureId = CultureInfo.GetCultureInfo("vi-VN").LCID,
                                  Index = 1,
                                  NumberOfResultsPerPage = 5
                              };
            var response = _globalizationSettings.GetLanguages(request);

            return View(response.Languages);
        }

        public ActionResult Details(int id)
        {
            var request = new GetLanguageDetailRequest
            {
                Id = id,
                CultureId = CultureInfo.GetCultureInfo("vi-VN").LCID
            };

            var response = _globalizationSettings.GetLanguageDetail(request);

            return View(response.Data);


        }

    }
}
