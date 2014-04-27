using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Account;

namespace Vnsf.Service.Contract.Service_Contracts
{
    public interface IUserService
    {
        UserAccount GetUserByUserName(string username, string password);
    }
}
