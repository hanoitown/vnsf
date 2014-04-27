using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using BrockAllen.MembershipReboot;
using DataSync.Models;

namespace DataSync.Controllers
{
    public class HomeController : Controller
    {
        oms_nsEntities context = new oms_nsEntities();
        private UserAccountService userAccountService;
        private AuthenticationService authenticationService;

        //
        // GET: /Default1/

        public HomeController(UserAccountService userAccountService, AuthenticationService authenticationService)
        {
            this.userAccountService = userAccountService;
            this.authenticationService = authenticationService;
        }

        public ActionResult Index()
        {
            var account = userAccountService.GetByUsername(User.Identity.Name);
            if (account != null)
            {
                account.AddClaim(ClaimTypes.Gender, "male");
                userAccountService.Update(account);
                authenticationService.SignIn(account);
            }
            var vm = new ProgramModel
            {
                ProgramTypes = context.tbl_program_type.ToList()
            };

            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.userAccountService.TryDispose();
                this.userAccountService = null;
                this.authenticationService.TryDispose();
                this.authenticationService = null;
            }
            base.Dispose(disposing);
        }


    }
}
