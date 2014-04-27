using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;
using Vnsf.Data.Repository;

namespace Vnsf.WebHost.Base
{
    public class ApiBaseController : ApiController
    {
        //protected ModelFactory _modelFactory;
        protected IUnitOfWork _uow;

        public ApiBaseController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public ApiBaseController()
        {
        }

        //protected ModelFactory TheModelFactory
        //{
        //    get
        //    {
        //        if (_modelFactory == null)
        //            _modelFactory = new ModelFactory(this.Request);
        //        return _modelFactory;
        //    }
        //}


        protected HttpResponseMessage GetResponse(HttpRequestMessage request, Func<HttpResponseMessage> codeToExecute)
        {
            HttpResponseMessage response = null;

            try
            {
                response = codeToExecute.Invoke();
            }
            //catch (SecurityException ex)
            //{
            //    response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            //}
            //catch (FaultException<AuthorizationValidationException> ex)
            //{
            //    response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            //}
            //catch (FaultException ex)
            //{
            //    response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
            catch (Exception ex)
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

    }
}
