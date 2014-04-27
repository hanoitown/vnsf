using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Repository;
using Vnsf.Infrastructure.Messanging;
using Vnsf.Infrastructure.Repository;

namespace Vnsf.Data.EF
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(DbContext dbContext)
            : base(dbContext)
        {
        }


        public UserAccount getAccountByUserName(string userName)
        {
            return DbSet.FirstOrDefault(u => u.Username == userName);
        }
    }
}
