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
    public class ContactsController : ApiBaseController
    {
        public ContactsController(IUnitOfWork uow)
            : base(uow)
        {

        }

        //public IQueryable<ContactViewModel> FindById()
        //{
        //    return _uow.Contacts.GetAll().Select(c => new ContactViewModel
        //    {
        //        Name = c.Name,
        //        Phone = c.Phone,
        //        Email = c.Email,
        //        Address = c.Address,
        //        Website = c.Website,
        //        LastUpdated = c.LastUpdated
        //    });
        //}

        //public IHttpActionResult FindById(Guid id)
        //{
        //    var contact = _uow.Contacts.FindById(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(new ContactViewModel
        //    {
        //        Name = contact.Name,
        //        Phone = contact.Phone,
        //        Email = contact.Email,
        //        Address = contact.Address,
        //        Website = contact.Website,
        //        LastUpdated = contact.LastUpdated
        //    });
        //}


        //public IHttpActionResult Post(ContactBindingModel model)
        //{
        //    //validation
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var contact = new IContact
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = model.Name,
        //        Email = model.Email,
        //        Phone = model.Phone,
        //        Address = model.Address,
        //        Created = DateTime.Now,
        //        LastUpdated = DateTime.Now
        //    };

        //    _uow.Contacts.Add(contact);
        //    _uow.Commit();

        //    return Ok(contact);
        //}


        //// PUT api/Grant/5
        //public IHttpActionResult PutGrant(Guid id, ContactBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != model.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var contact = _uow.Contacts.FindById(id);

        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }

        //    contact.Name = model.Name;
        //    contact.Address = model.Address;
        //    contact.Email = model.Email;
        //    contact.Phone = model.Phone;
        //    contact.LastUpdated = DateTime.Now;

        //    try
        //    {
        //        _uow.Commit();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //public IHttpActionResult Delete(Guid id)
        //{
        //    var contact = _uow.Contacts.FindById(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }

        //    _uow.Contacts.Remove(contact);
        //    _uow.Commit();

        //    return Ok(contact);
        //}
    }
}
