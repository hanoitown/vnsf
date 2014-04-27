using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Vnsf.Data.Contracts;
using Vnsf.Data.Entities;
using Vnsf.Registration.Web.ViewModels;
using Vnsf.Service.Contract;
using Vnsf.Service.Data.Messaging.ConfigurationService;

namespace Vnsf.Registration.Web.Controllers
{
    public class CultureViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class CultureController : BaseController
    {

        private class ConfigurationsDefaultParameters
        {
            public Guid StoreId { get; set; }
            public Int32 DefaultCultureId { get; set; }
            public int? DefaultCurrencyId { get; set; }
            public int? DefaultCountryId { get; set; }
        }

        private readonly IGlobalizationSettings _globalizationSettings;

        public CultureController(IUow uow, IGlobalizationSettings settings)
        {
            Uow = uow;
            _globalizationSettings = settings;
        }

        public ActionResult Index()
        {
            var request = GenerateCultureListRequest();
            request.CultureId = CultureInfo.GetCultureInfo("vi-VN").LCID;
            request.Index = 1;
            request.NumberOfResultsPerPage = 5;
            var response = _globalizationSettings.GetAllCulture(request);

            return View(response);

            //return View(Uow.Languages.GetAll().ToList());
        }

        public ActionResult Create()
        {
            var civ = new CultureInsertViewModel
                          {
                              Culture = new SelectList(new SelectListItem[]
                                            {
                                                new SelectListItem{Selected = false, Text = string.Empty, Value = string.Empty}
                                            })
                          };
            return View();
        }


        [HttpPost]
        public ActionResult Create(CreateCultureRequest request)
        {
            if (ModelState.IsValid)
            {
                var culture = CultureInfo.GetCultureInfo(request.Data.Code);
                request.Data.Id = culture.LCID;

                _globalizationSettings.CreateCulture(request);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var request = new GetCultureDetailRequest
                              {
                                  Id = id,
                                  CultureId = CultureInfo.GetCultureInfo("vi-VN").LCID
                              };

            var response = _globalizationSettings.GetCultureDetail(request);

            return View(response);
        }

        private static GetRequestCultures GenerateCultureListRequest()
        {
            var request = new GetRequestCultures
                {
                    NumberOfResultsPerPage = 5,
                    Index = 1,
                    CultureSortBy = CultureSortBy.NameAcs
                };

            return request;
        }

        public ActionResult Edit(string id)
        {
            var item = Uow.Cultures.GetById(int.Parse(id));



            var cvm = new CultureViewModel
                          {
                              Code = item.Code,
                              Name = item._localizations.FirstOrDefault() == null ? item._localizations.FirstOrDefault(wl => wl.CultureId == CultureInfo.InvariantCulture.LCID).Name :
                              item._localizations.FirstOrDefault(l => l.CultureId == CultureInfo.CurrentCulture.LCID).Name

                          };
            //cvm.Country = Uow.Countries.GetAll().Select(new CountryViewModel())
            return View(cvm);
        }


    }

    public class CultureInsertViewModel
    {
        public SelectList Culture { get; set; }
    }
}
