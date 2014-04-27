using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Repository;
using Vnsf.Service.Common.Exceptions;

namespace Vnsf.Service.Implementation
{
    public class ServiceBase
    {
        protected IUnitOfWork _uow;
        public ServiceBase()
        {

        }
        public ServiceBase(IUnitOfWork unitOfWork)
        {

            _uow = unitOfWork;
        }

        protected T ExcecuteFaultOperation<T>(Func<T> codeToExecute)
        {
            try
            {
                return codeToExecute.Invoke();
            }
            catch (AuthorizationValidationException ex)
            {
                throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            }
            catch (FaultException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new FaultException(ex.InnerException.Message);
            }
        }

        protected void ExecuteFaultHandledOperation(Action codetoExecute)
        {
            try
            {
                codetoExecute.Invoke();
            }
            catch (AuthorizationValidationException ex)
            {
                throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            }
            catch (FaultException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
