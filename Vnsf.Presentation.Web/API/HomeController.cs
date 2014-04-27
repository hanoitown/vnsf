using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vnsf.Presentation.Web.Core;
using Vnsf.Service.Contract;

namespace Vnsf.Presentation.Web.Api
{
    public class HomeController : ApiControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public HomeController(IUserAccountService accountService) : base()
        {
            _userAccountService = accountService;
        }

        [HttpGet]
        public HttpResponseMessage CreateAccount(HttpRequestMessage request)
        {
            return GetResponse(request, () =>
                        {
                            _userAccountService.CreateAccount("hanm", "test", "ha@hanoitown.com");
                            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, "Hello"); ;
                            return response;
                        });
        }
    }
}
