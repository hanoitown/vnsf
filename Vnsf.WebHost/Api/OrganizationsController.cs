using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vnsf.Data.Entities;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Api
{
    public class OrganizationsController : ApiBaseController
    {
        public OrganizationsController(IUnitOfWork uow)
            : base(uow)
        {

        }

        public IQueryable<OrganizationViewModel> Get()
        {
            return _uow.Organizations.GetAll().Select(org => new OrganizationViewModel
            {
                Id = org.Id,
                Name = org.Name,
                Description = org.Description,
                ShortName = org.ShortName,
                Address = org.Address,
                Phone = org.Phone,
                Email = org.Email,
                Website = org.Website,
                LastUpdated = org.LastUpdated
            });
        }

        public IHttpActionResult Get(Guid id)
        {
            var org = _uow.Organizations.Get(id);
            if (org == null)
            {
                return NotFound();
            }

            return Ok(new OrganizationViewModel
            {
                Id = org.Id,
                Name = org.Name,
                Description = org.Description,
                ShortName = org.ShortName,
                Address = org.Address,
                Phone = org.Phone,
                Email = org.Email,
                Website = org.Website,
                LastUpdated = org.LastUpdated
            });
        }

        public IHttpActionResult Post(OrganizationBindingModel model)
        {
            //validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var org = new Organization
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                ShortName = model.ShortName,
                Address = model.Address,
                Phone = model.Phone,
                Email = model.Email,
                Website = model.Website,
                Created = DateTime.Now
            };

            _uow.Organizations.Add(org);
            _uow.Commit();

            return Ok(org);
        }

        public IHttpActionResult PutOrg(Guid id, OrganizationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != model.Id)
            //{
            //    return BadRequest();
            //}

            var item = _uow.Organizations.Get(id);

            if (item == null)
            {
                return NotFound();
            }
            
            item.Name = model.Name;
            item.Description = model.Description;
            item.ShortName = model.ShortName;
            item.Address = model.Address;
            item.Email = model.Email;
            item.Phone = model.Phone;
            item.Website = model.Website;
            item.LastUpdated = DateTime.Now;

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteOrg(Guid id)
        {
            var org = _uow.Organizations.Get(id);
            if (org == null)
            {
                return NotFound();
            }

            _uow.Organizations.Remove(org);
            _uow.Commit();

            return Ok(org);
        }


    }
}
