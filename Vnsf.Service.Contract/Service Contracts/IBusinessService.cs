using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Service.Common.Exceptions;

namespace Vnsf.Service.Contract.Service_Contracts
{
    public interface IBusinessService
    {
        [OperationContract]
        [FaultContract(typeof(AuthorizationValidationException))]
        Grant[] GetAll();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(AuthorizationValidationException))]
        Grant CreateAccount(string code, string name, double total, int max, string description);


    }
}
