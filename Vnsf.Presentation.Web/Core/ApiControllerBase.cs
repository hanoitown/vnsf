using System;
using System.Net;
using System.Net.Http;
using System.Security;
using System.ServiceModel;
using System.Web.Http;
using Vnsf.Data.Repository;
using Vnsf.Presentation.Web.Models;
using Vnsf.Service.Common.Exceptions;

namespace Vnsf.Presentation.Web.Core
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ModelFactory _modelFactory;

        public ApiControllerBase()
        {
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                    _modelFactory = new ModelFactory(this.Request);
                return _modelFactory;
            }
        }


        protected HttpResponseMessage GetResponse(HttpRequestMessage request, Func<HttpResponseMessage> codeToExecute)
        {
            HttpResponseMessage response = null;

            try
            {
                response = codeToExecute.Invoke();
            }
            catch (SecurityException ex)
            {
                response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (FaultException<AuthorizationValidationException> ex)
            {
                response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (FaultException ex)
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

    }
}