using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.EF;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Infrastructure.Tasks;

namespace Vnsf.WebHost.Infrastructure
{
    public class TransactionPerRequest // : IRunOnEachRequest, IRunAfterEachRequest, IRunOnError
    {
        private readonly HttpContextBase _httpContext;
        private readonly IUnitOfWork _dbContext;
        public TransactionPerRequest(HttpContextBase httpContext, IUnitOfWork dbContext)
        {
            _httpContext = httpContext;
            _dbContext = dbContext;
        }

        //void IRunOnEachRequest.Execute()
        //{
        //    //_dbContext = (UnitOfWork)DependencyResolver.Current.GetService<IUnitOfWork>();
        //    _httpContext.Items["_Transaction"] = ((UnitOfWork)_dbContext).DbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);
        //}

        //void IRunAfterEachRequest.Execute()
        //{
        //    var transaction = (DbContextTransaction)_httpContext.Items["_Transaction"];
        //    if (_httpContext.Items["_Error"] != null)
        //        transaction.Rollback();
        //    else
        //        transaction.Commit();
        //}

        //void IRunOnError.Execute()
        //{
        //    _httpContext.Items["_Error"] = true;
        //}

    }
}