using System.Security.Principal;
using Microsoft.AspNet.Identity;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Repository;
using System;

namespace Vnsf.WebHost.Infrastructure
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity _identity;
        private readonly IUnitOfWork _unitOfWork;

        private UserAccount _user;
        public CurrentUser(IIdentity identity, IUnitOfWork unitOfWork)
        {
            _identity = identity;
            _unitOfWork = unitOfWork;
        }

        public UserAccount User
        {
            get { return _user ?? (_user = _unitOfWork.UserAccounts.FindById(Guid.Parse(_identity.GetUserId()))); }
        }
    }
}