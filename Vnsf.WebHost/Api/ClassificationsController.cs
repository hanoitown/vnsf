using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;

namespace Vnsf.WebHost.Api
{
    public class ClassificationsController : ApiBaseController
    {
        public ClassificationsController(IUnitOfWork uow)
            : base(uow)
        {

        }

        
    }
}
