﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Repository;
using Vnsf.Service.Contract.Service_Contracts;
using Vnsf.WebHost.Models;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Infrastructure;

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
        //
        // GET: /Cheetah/Application/
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Detail(Guid id)
        {

            var application = _user.User.Applications.First(a => a.Id == id);
            if (application!=null)
            {
                var docs = _uow.OpportunitiesRepo.AllIncluding(o => o.ApplicationPackage).First(o => o.Id == application.Opportunity.Id);


                var documentCategories = _uow.Categories.All;//FilterBy(c => c.ClassificationId == opportunity.ClassificationId).ToList();

                //if (!_user.User.Applications.Where(a => a.OpportunityId == opportunityId).Any())
                //{
                //    var application = _user.User.ApplyForGrant(opportunity);
                //    _uow.Save();
                //}

                //var vm = new ApplicationBindingModel(new Application(), _user.User, opportunity, documentCategories);
                //return View(vm);

                return null;
            }
            else
                return RedirectToAction<OpportunityController>(o => o.Index());

        }

        public ActionResult SubmitApplication()
        {
            // Validate application detail

            // Save application

            // Raise event

            return View();
        }

        [HttpPost]
        public ActionResult SaveApplication()
        {
            // Save application state

            return View();
        }


    }
}