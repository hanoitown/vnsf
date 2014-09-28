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
    public class ApplicationController : MvcBaseController
    {

        ICurrentUser _user;
        public ApplicationController(IUnitOfWork uow, ICurrentUser user)
            : base(uow)
        {
            _user = user;
        }


        public ActionResult Create(Guid id)
        {
            var vm = AutoMapper.Mapper.Map<AppBindingModel>(_uow.Apps.FindById(id));

            return View(vm);
        }

        public ActionResult NewProposal(Guid applicationId)
        {
            var app = _uow.Apps.AllIncluding(a => a.Proposal, a => a.Proposal.Field, a => a.Opportunity.Grant.Classification).FirstOrDefault(a => a.Id == applicationId);

            var vm = new ProposalBindingModel()
            {
                StartDate = DateTime.Today,
                FinishDate = DateTime.Today
            };
            if (app.Proposal != null)
                vm = AutoMapper.Mapper.Map<ProposalBindingModel>(app.Proposal);

            ViewData["Hostings"] = _uow.Organizations.All
                                        .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), string.Empty);


            var categories = _uow.Categories.AllIncluding(c => c.Parent).Where(c => c.Parent == null)
            .Project().To<CategoryViewModel>().ToList();

            categories.ForEach(n => BuildChildNode(n));
            var list = new List<SelectListItem>();
            foreach (var item in categories)
            {
                list.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                    Selected = app.Proposal == null ? false : item.Id == app.Proposal.Field.Id
                });
                ToSelectList(item, list, app.Proposal);
            }

            ViewData["Categories"] = list;


            return View("_Proposal", vm);
        }

        /// <summary>
        /// Add or update proposal depend on available data
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewProposal(Guid applicationId, ProposalBindingModel form)
        {
            var app = _uow.Apps.AllIncluding(a => a.Proposal).FirstOrDefault(a => a.Id == applicationId);

            var cat = _uow.Categories.FindById(form.FieldId);
            var org = _uow.Organizations.FindById(form.HostingId);
            if (app.Proposal == null)
                app.Proposal = Proposal.New(form.Title, form.Abstract, form.StartDate, form.FinishDate, form.Duration, form.TotalBudget, form.RequetBudget, form.Content);
            else
                UpdateProposal(app.Proposal, form);

            app.Proposal.Kind = form.Kind;
            app.Proposal.Field = cat;
            app.Proposal.Hosting = org;

            _uow.Save();

            return RedirectToAction<ApplicationController>(c => c.Details(app.Id));
        }

        public void UpdateProposal(Proposal toUpdate, ProposalBindingModel form)
        {

            toUpdate.Title = form.Title;
            toUpdate.Abstract = form.Abstract;
            toUpdate.Content = form.Content;

        }


        [Authorize]
        public ActionResult Details(Guid id)
        {

            var application = _uow.Apps.AllIncluding(a => a.Documents, a => a.Opportunity, a=>a.Opportunity.Grant).First(a => a.Id == id);
            //ModelState.AddModelError("Documents", "Document is not fullfil requirements");

            if (application != null)
            {
                var vm = AutoMapper.Mapper.Map<AppBindingModel>(application);

                return View(vm);
            }
            else
                return RedirectToAction<OpportunityController>(c => c.Index());

        }

        [ChildActionOnly]
        public ActionResult AppDocs(Guid id)
        {
            var item = _uow.Apps.AllIncluding(d => d.Documents, d => d.Opportunity, d => d.Applicant).FirstOrDefault(a => a.Id == id && a.Applicant.Id == _user.User.Id);
            if (item == null)
                throw new ArgumentNullException();
            var doc = item.Documents;
            var form = _uow.AppForms.All.Where(f => f.Opportunity.Id == item.Opportunity.Id).ToList();

            // in order to join, need 2 lists first, queryable not support
            var vm = form.OrderBy(f => f.Code).GroupJoin(doc, f => f.Id, d => d.Form.Id,
                    (p, c) => c
                    .Select(a => new AppDocumentViewModel { Id = a.Id, FormId = p.Id, FileName = a.FileName, FormName = p.Name, FormCode = p.Code })
                    .DefaultIfEmpty(new AppDocumentViewModel { FormId = p.Id, FileName = string.Empty, FormName = p.Name, FormCode = p.Code }))
                    .SelectMany(c => c).ToList();

            return PartialView("_AppDocs", vm);
        }

        public ActionResult Upload(Guid formId)
        {
            return View(new AppDocumentBindingModel { AppFormId = formId });
        }

        [HttpPost]
        public ActionResult Upload(AppDocumentBindingModel form)
        {
            var appForm = _uow.AppForms.AllIncluding(a => a.Opportunity).First(f => f.Id == form.AppFormId);

            var app = _uow.Apps.AllIncluding(a => a.Documents).First(a => a.Opportunity.Id == appForm.Opportunity.Id && a.Applicant.Id == _user.User.Id);

            if (ModelState.IsValid)
            {
                //find out which application
                if (form.File != null)
                {
                    //_uow.AppDocuments.Add(ApplicationDocument.NewDocument(app, appForm, form.File.FileName, form.Description, form.File.ContentType, form.File.ContentLength, form.File.FileName));
                    var folder = Path.Combine(Server.MapPath("/documents/applications/"), _user.User.Email);

                    bool isExists = System.IO.Directory.Exists(folder);
                    if (!isExists)
                        System.IO.Directory.CreateDirectory(folder);

                    form.File.SaveAs(Path.Combine(folder, form.File.FileName));

                    app.AddOrUpdateDocument(appForm, form.File.FileName, form.Description, MimeMapping.GetMimeMapping(form.File.FileName), form.File.ContentLength, Path.Combine(folder, form.File.FileName));
                    _uow.Save();
                }
            }
            return RedirectToAction<ApplicationController>(a => a.Details(app.Id));
        }
        [HttpPost]
        public ActionResult Details(Guid Id, FormCollection form)
        {
            var app = _uow.Apps.FindById(Id);
            // Validate application detail
            // Save application
            app.Status = ApplicationStatus.Submitted;
            _uow.Save();
            // Raise event

            return RedirectToAction<ApplicationController>(a => a.Details(Id));
        }

        [HttpPost]
        public ActionResult SaveApplication()
        {
            // Save application state

            return View();
        }

        [Authorize]
        public ActionResult Download(Guid id)
        {
            var file = _uow.AppDocuments.FindById(id);
            return File(file.Path, MimeMapping.GetMimeMapping(file.FileName), file.FileName);
        }


        private void ToSelectList(CategoryViewModel cat, List<SelectListItem> list, Proposal proposal)
        {
            if (cat.Children != null)
            {
                foreach (var item in cat.Children)
                {
                    list.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = Prefix(2 * item.Depth) + item.Name,
                        Selected = proposal == null ? false : item.Id == proposal.Field.Id
                    });
                    ToSelectList(item, list, proposal);

                }
            }
        }

        private string Prefix(int count)
        {
            if (count == 0)
                return "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append("&nbsp;");
            }
            return Server.HtmlDecode(sb.ToString());
        }

        private void BuildChildNode(CategoryViewModel cat)
        {
            if (cat != null)
            {
                var children = _uow.Categories.AllIncluding(c => c.Children).Where(c => c.Parent.Id == cat.Id)
                                        .Project().To<CategoryViewModel>().ToList();
                if (children != null)
                {
                    foreach (var child in children)
                    {
                        BuildChildNode(child);
                        cat.Children.Add(child);
                    }
                }
            }
        }


    }
}