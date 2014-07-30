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
using Vnsf.WebHost.Areas.Manage.Models;
using Vnsf.WebHost.Infrastructure;
using Vnsf.Data;
using System.IO;
using Vnsf.Data.Entities.Registration;
using Vnsf.Anticorruption;


namespace Vnsf.WebHost.Areas.Manage.Controllers
{

    public class ReportsController : MvcBaseController
    {
        ICurrentUser _user;
        OmsConnection oms = new OmsConnection();
        public ReportsController(IUnitOfWork uow, ICurrentUser user)
            : base(uow)
        {
            _user = user;
        }

        public ActionResult Index()
        {
            var reports = _uow.Reports.All.Select(r => new ReportManageViewModel()
            {
                Organization = r.Contract.Award.Application.Proposal.Hosting.Name,
                PIName = r.Contract.Award.Application.Proposal.Participants.FirstOrDefault(p => p.Role == Data.Entities.Proposals.ParticipantRole.PI).Profile.Name.ToString()
            });

            var report2 = _uow.Reports.AllIncluding(r=>r.Contract.Award.Application.Proposal.Hosting);

            var list = new List<ReportManageViewModel>();
            foreach (var item in report2)
            {
                var org = item.Contract.Award.Application.Proposal.Hosting.Name;
            }

            var vm = oms.tbl_finare_list.Select(r => new Report()
                {
                    Purpose = r.target,
                    Scope = r.content_range,
                    Methodology = r.method,
                    Accomplishment = r.result,
                    Changes = r.changes
                }
            );

            var profile = _uow.Profiles.All;




            return View(vm);
        }

        public ActionResult Synchronize()
        {
            var vm = oms.tbl_finare_list.Select(r => new Report()
                {
                    Id = Guid.NewGuid(),
                    Purpose = r.target,
                    Scope = r.content_range
                }
            );

            return RedirectToAction<ReportsController>(c => c.Index());
        }

    }


}