using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Vnsf.Data.Entities;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Api
{
    public class GrantsController : ApiBaseController
    {
        public GrantsController(IUnitOfWork uow)
            : base(uow)
        {

        }
        [Route("api/grants/upload")]
        public async Task<HttpResponseMessage> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        // GET api/Grants
        public IQueryable<GrantViewModel> Get()
        {
            return _uow.Grants.All.Select(g => new GrantViewModel
            {
                Id = g.Id,
                Code = g.Code,
                Name = g.Name,
                Description = g.Description,
                Objective = g.Objective,
                MaxAward = g.MaxAward,
                MaxDuration = g.MaxDuration,
                Total = g.Total,
                LastUpdated = g.LastUpdated
            });
        }

        public IHttpActionResult Get(Guid id)
        {
            var g = _uow.Grants.FindById(id);
            if (g == null)
            {
                return NotFound();
            }

            return Ok(new GrantViewModel
            {
                Id = g.Id,
                Code = g.Code,
                Name = g.Name,
                Description = g.Description,
                Objective = g.Objective,
                MaxAward = g.MaxAward,
                MaxDuration = g.MaxDuration,
                Total = g.Total,
                LastUpdated = g.LastUpdated
            });
        }

        //[Route("api/grants/{id}/budgets")]
        //public IHttpActionResult GetBudgets(Guid id)
        //{
        //    var grant = _uow.Grants.GetAll().Include(g => g.Budgets).Where(g => g.Id == id).FirstOrDefault();
        //    if (grant == null)
        //    {
        //        return NotFound();
        //    }

        //    var data = grant.Budgets.Select(b => new BudgetViewModel
        //    {
        //        Id = b.Id,
        //        Name = b.Name,
        //        Description = b.Description,
        //        Year = b.FinancialYear,
        //        Amount = b.Amount,
        //        Supplier = _uow.Organizations.FindById(b.SupplierId).Name
        //    });

        //    return Ok(data);
        //}

        //[Route("api/grants/{grantId}/budgets/{budgetId}")]
        //public IHttpActionResult GetBudgets(Guid grantId, Guid budgetId)
        //{
        //    var grant = _uow.Grants.GetAll().Include(g => g.Budgets).Where(g => g.Id == grantId).FirstOrDefault();
        //    if (grant == null)
        //    {
        //        return NotFound();
        //    }

        //    var data = grant.Budgets.Where(b => b.Id == budgetId).Select(b => new BudgetBindingModel
        //    {
        //        Name = b.Name,
        //        Description = b.Description,
        //        FinancialYear = b.FinancialYear,
        //        Amount = b.Amount,
        //        SupplierId = b.SupplierId
        //    }).FirstOrDefault();

        //    return Ok(data);
        //}

        //[Route("api/grants/{grantId}/budgets/{budgetId}")]
        //public IHttpActionResult PutGetBudgets(Guid grantId, Guid budgetId, BudgetBindingModel model)
        //{
        //    var grant = _uow.Grants.GetAll().Include(g => g.Budgets).Where(g => g.Id == grantId).FirstOrDefault();

        //    if (grant == null)
        //    {
        //        return NotFound();
        //    }

        //    var data = grant.Budgets.Where(b => b.Id == budgetId).FirstOrDefault();
        //    var org = _uow.Organizations.FindById(model.SupplierId);

        //    data.Name = model.Name;
        //    data.Description = model.Description;
        //    data.FinancialYear = model.FinancialYear;
        //    data.Amount = model.Amount;
        //    data.Supplier = org;

        //    grant.LastUpdated = DateTime.Now;

        //    _uow.Commit();

        //    return Ok();
        //}


        //[Route("api/grants/{id}/budgets")]
        //public IHttpActionResult Post(Guid id, BudgetBindingModel model)
        //{
        //    //validation
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Grant grant = _uow.Grants.FindById(id);
        //    //var org = _uow.Organizations.FindById(model.Supplier);
        //    if (grant == null)
        //    {
        //        return NotFound();
        //    }
        //    var supplier = _uow.Organizations.FindById(model.SupplierId);
        //    grant.Budgets.Add(new Budget
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = model.Name,
        //        Description = model.Description,
        //        FinancialYear = model.FinancialYear,
        //        Amount = model.Amount,
        //        Supplier = supplier
        //    });
        //    grant.LastUpdated = DateTime.Now;
        //    _uow.Commit();

        //    return Ok();
        //}

        public IHttpActionResult Post(GrantBindingModel model)
        {
            //validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grant = new Grant
            {
                Id = Guid.NewGuid(),
                Code = model.Code,
                Name = model.Name,
                Description = model.Description,
                Objective = model.Objective,
                MaxDuration = model.MaxDuration,
                MaxAward = model.MaxAward,
                Total = model.Total,
                //Agency = _uow.Organizations.FindById(model.Issuer),
                Created = DateTime.Now
            };
            //item.Init(grant.Code, grant.Name, grant.Description, grant.Total, grant.MaxAward);

            _uow.Grants.Add(grant);
            _uow.Save();

            return Ok(grant);
        }


        // PUT api/Grant/5
        public IHttpActionResult PutGrant(Guid id, GrantBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _uow.Grants.FindById(id);

            if (item == null)
            {
                return NotFound();
            }

            item.Code = model.Code;
            item.Name = model.Name;
            item.Description = model.Description;
            item.MaxAward = model.MaxAward;
            item.MaxDuration = model.MaxDuration;
            item.Total = model.Total;
            item.LastUpdated = DateTime.Now;

            try
            {
                _uow.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteGrant(Guid id)
        {
            var grant = _uow.Grants.FindById(id);
            if (grant == null)
            {
                return NotFound();
            }

            _uow.Grants.Remove(grant);
            _uow.Save();

            return Ok(grant);
        }


    }
}
