using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using Vnsf.Data.Entities.Account;

namespace Vnsf.Presentation.Web.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;

        public ModelFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }
        public UserAccountModel Create(UserAccount item)
        {
            return new UserAccountModel()
                       {
                           Url = _urlHelper.Link("UserAccount", new { id = item.ID }),
                           Fullname = item.Username,
                           LastCreate = item.Created
                       };
        }
    }
}