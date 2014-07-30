using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Models;
using Microsoft.Web.Mvc;
using Vnsf.WebHost.Infrastructure.Alerts;
using AutoMapper.QueryableExtensions;
using Vnsf.Data.Entities;
using System.Threading.Tasks;
using Vnsf.WebHost.Infrastructure;
using Vnsf.Data;
using System.IO;
using Vnsf.WebHost.Areas.Cheetah.Models;
using System.Text;

namespace Vnsf.WebHost.Areas.Cheetah.Controllers
{
    public class ProposalController : MvcBaseController
    {
        ICurrentUser _user;
        public ProposalController(IUnitOfWork uow, ICurrentUser user)
            : base(uow)
        {
            _user = user;
        }

        public ActionResult Update(Guid applicationId)
        {
            // check if there is an associated proposal
            var application = _uow.Apps.AllIncluding(a => a.Opportunity.Grant.Classification).First(a => a.Id == applicationId);
            var proposal = _uow.Proposals.AllIncluding(p => p.Application).FirstOrDefault(p => p.Application.Id == applicationId);


            if (proposal == null)
                proposal = Proposal.Create(application);


            ViewData["Categories"] = _uow.Categories.AllIncluding(c => c.Classification)
                        .Where(c => c.Classification.Id == application.Opportunity.Grant.Classification.Id && c.Depth == 0)
                                                        .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), string.Empty);

            var vm = AutoMapper.Mapper.Map<ProposalBindingModel>(proposal);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Update(ProposalBindingModel form)
        {
            var field = _uow.Categories.FindById(form.FieldId);
            var hosting = _uow.Organizations.FindById(form.HostingId);
            // in 01-1 relation, the key is the same for the dependence property, application.id=proposal.id
            var proposal = _uow.Proposals.FindById(form.Id);
            if (ModelState.IsValid)
            {
                proposal.Title = form.Title;
                proposal.Field = field ?? proposal.Field;
                proposal.Hosting = hosting;
                proposal.Abstract = form.Abstract;

                _uow.Save();
            }

            return RedirectToAction<ProposalController>(c => c.Update(proposal.Id));
        }

        public JsonResult GetCategories(Guid id)
        {
            var list = _uow.Categories.AllIncluding(c => c.Parent).Where(c => c.Parent.Id == id && c.Depth == 1)
                        .Select(c => new
                        {
                            Value = c.Id.ToString(),
                            Text = c.Name
                        });

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}