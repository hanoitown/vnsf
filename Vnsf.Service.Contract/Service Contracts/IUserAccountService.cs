using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Account;
using Vnsf.Service.Common.Exceptions;

namespace Vnsf.Service.Contract
{
    [ServiceContract]
    public interface IUserAccountService
    {
        [OperationContract]
        [FaultContract(typeof(AuthorizationValidationException))]
        UserAccount[] GetAll();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [FaultContract(typeof(AuthorizationValidationException))]
        UserAccount GetByID(Guid id); 

        [OperationContract]
        bool Authenticate(string username, string password, out UserAccount account);

        bool IsPasswordExpired(Guid accountID);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(AuthorizationValidationException))]
        UserAccount CreateAccount(string username, string password, string email);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(AuthorizationValidationException))]
        bool VerifyAccount(string key);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(AuthorizationValidationException))]
        bool DeleteAccount(string username);

        //bool ChangePassword(string username);
        //bool ResendConfirmationEmail(string username);
        //bool ForgotPassword(string username);

        //UserSettings GetAccountSettings(string username);
    }
}
