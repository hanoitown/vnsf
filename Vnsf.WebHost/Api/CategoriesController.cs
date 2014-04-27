using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vnsf.Data.Entities;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;

namespace Vnsf.WebHost.Api
{
    public class CategoriesController : ApiBaseController
    {
        public CategoriesController(IUnitOfWork uow)
            : base(uow)
        {

        }

        public IQueryable<Category> Get(Guid Id)
        {
            return _uow.ClassificationRepo.FindById(Id).GetCategoryById(Id).AsQueryable();
        }

        public IHttpActionResult PostCategory()
        {

            //var cs = _uow.ClassificationRepo.Create();
            //cs.Init();

            //var cat = new Category("bar", string.Empty);
            //cs.AddCategory(cat);
            //_uow.Commit();

            return Ok();
        }


    }
}
