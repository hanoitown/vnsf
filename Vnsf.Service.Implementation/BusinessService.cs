using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Repository;
using Vnsf.Service.Contract.Service_Contracts;

namespace Vnsf.Service.Implementation
{
    public class BusinessService : ServiceBase, IBusinessService
    {
        public BusinessService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Grant[] GetAll()
        {
            return this._uow.Grants.All.ToArray();
        }

        public Grant CreateAccount(string code, string name, double total, int max,  string description)
        {
            var grant = this._uow.Grants.Create();
            grant.Code = code;
            grant.Name = name;
            grant.Total = total;
            grant.MaxAward = max;
            grant.Description = description;
            grant.Created = DateTime.Now;
            grant.LastUpdated = DateTime.Now;
            this._uow.Grants.Add(grant);
            this._uow.Commit();
            return grant;
        }
    }
}
