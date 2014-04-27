using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Http;
using Vnsf.Presentation.Web.Core;
using Vnsf.Service.Contract.Service_Contracts;

namespace Vnsf.Presentation.Web.Api
{
    public class ProgramController : ApiControllerBase
    {
        //
        // GET: /Program/
        private IBusinessService _service;

        public ProgramController(IBusinessService service)
        {
            _service = service;
        }

        [System.Web.Http.HttpGet]
        [GET("api/program")]

        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return GetResponse(request, () =>
            {
                var results = _service.GetAll()
                    .Select(u => new
                    {
                        name = u.Name,
                        code = u.Code,
                        total = u.Total,
                        max = u.MaxAward,
                        //lastUpdated = u.LastUpdated.ToLocalTime(),
                        //created = u.Created.ToLocalTime()
                    });
                if (results == null)
                    return request.CreateResponse(HttpStatusCode.NotFound);

                return request.CreateResponse(HttpStatusCode.OK, results);
            });
        }

        [System.Web.Http.HttpGet]
        [GET("api/add")]

        public HttpResponseMessage Add(HttpRequestMessage request)
        {
            return GetResponse(request, () =>
                                        {
                                            var results = _service.CreateAccount("ABC", "Abc", 100, 10, "a b c");


                                            return request.CreateResponse(HttpStatusCode.OK, results);
                                        });
        }

    }
}
