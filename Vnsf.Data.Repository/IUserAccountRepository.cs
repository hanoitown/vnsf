using Vnsf.Data.Entities.Account;
using Vnsf.Infrastructure.Repository;

namespace Vnsf.Data.Repository
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        UserAccount getAccountByUserName(string userName);
    }
}
