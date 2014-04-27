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
    public class DocumentsController : ApiBaseController
    {
        public DocumentsController(IUnitOfWork uow)
            : base(uow)
        {

        }

        
    }
}
