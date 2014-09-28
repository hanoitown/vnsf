using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Models;
using Microsoft.Web.Mvc;
using Vnsf.WebHost.Infrastructure.Alerts;
using Vnsf.Data.Entities;
using System.Threading.Tasks;
using System.Text;

namespace Vnsf.WebHost.Controllers
{
    public class NewsController : MvcBaseController
    {
        public NewsController(IUnitOfWork uow)
            : base(uow)
        {

        }
        // GET: News
        public ActionResult Index()
        {
            var post = _uow.Posts.AllIncluding(p => p.Category).OrderByDescending(p => p.PublishDate).Project().To<PostDisplayModel>();
            return View(post);
        }

        public ActionResult Post(Guid id)
        {
            var post = _uow.Posts.AllIncluding(p => p.Category).FirstOrDefault(p => p.Id == id);
            var vm = AutoMapper.Mapper.Map<PostDisplayModel>(post);

            return View(vm);
        }

    }
}