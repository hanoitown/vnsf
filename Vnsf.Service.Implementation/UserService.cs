using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Anticorruption;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Repository;
using Vnsf.Service.Contract.Service_Contracts;


namespace Vnsf.Service.Implementation
{

    public class UserService : ServiceBase, IUserService
    {
        OmsConnection oms = new OmsConnection();
        public UserService(IUnitOfWork uow)
            : base(uow)
        {

        }

        public UserAccount GetUserByUserName(string username, string password)
        {
            var usr = _uow.UserAccounts.FilterBy(u => u.Username == username).FirstOrDefault();
            if (usr == null)
            {
                var pass = CalculateMD5Hash(password);
                var user = oms.tbl_profile.Where(p => p.S_EMAIL_P == username && p.S_PASSWORD == pass).FirstOrDefault();
                var account = new UserAccount();
                account.Init(user.S_EMAIL_P, user.S_PASSWORD, user.S_EMAIL_P);
                return account;
            }
            if (usr.VerifyHashedPassword(password))
                return usr;


            return null;
        }

        private string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
