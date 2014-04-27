using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Vnsf.Data.Repository;
using Vnsf.Presentation.Web.Core;
using Vnsf.Presentation.Web.Models;
using Vnsf.Service.Contract;


namespace Vnsf.Presentation.Web.Api
{
    public class UserAccountController : ApiControllerBase
    {
        IUserAccountService _userService;

        public UserAccountController(IUserAccountService userService)
            : base()
        {
            _userService = userService;
        }

        [System.Web.Mvc.HttpGet]
        [GET("api/users")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return GetResponse(request, () =>
                                            {
                                                var results = _userService.GetAll()
                                                    .Select(u => new
                                                            {
                                                                Id = u.ID,
                                                                name = u.Username,
                                                                email = u.Email,
                                                                allowLogin = u.IsLoginAllowed,
                                                                isVerified = u.IsAccountVerified,
                                                                lastUpdated = u.LastUpdated,
                                                                created = u.Created
                                                            });
                                                if (results == null)
                                                    return request.CreateResponse(HttpStatusCode.NotFound);

                                                return request.CreateResponse(HttpStatusCode.OK, results);
                                            });



        }

        [System.Web.Mvc.HttpPost]
        [POST("api/account/login")]
        public HttpResponseMessage Login(HttpRequestMessage request, [FromBody]AccountLoginModel model)
        {
            return GetResponse(request, () =>
                                    {
                                        return request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Access denied");
                                    });
        }

        [System.Web.Mvc.HttpPost]
        [POST("api/account/register/validate1")]
        public HttpResponseMessage Validate1(HttpRequestMessage request, [FromBody]AccountLoginModel model)
        {
            return GetResponse(request, () =>
            {
                return request.CreateResponse(HttpStatusCode.OK);
            });
        }


    }
}
