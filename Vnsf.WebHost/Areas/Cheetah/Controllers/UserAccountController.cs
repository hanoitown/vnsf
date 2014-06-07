using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Repository;
using Vnsf.Service.Contract.Service_Contracts;
using Vnsf.Service.Implementation;
using Vnsf.WebHost.Areas.Cheetah.Models;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Infrastructure;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Cheetah.Controllers
{
    public class UserAccountController : MvcBaseController
    {
        ICurrentUser _User;
        public UserAccountController(IUnitOfWork uow)
            : base(uow)
        {

        }

        public UserAccountController(IUnitOfWork uow, ICurrentUser user)
            : base(uow)
        {
            _User = user;
        }

        public ActionResult Index()
        {
            var vm = ClaimsPrincipal.Current;

            return View(vm);
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult Documents()
        {
            //            var userDocs = _uow.Documents
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            ManageMessageId? message = null;
            var id = User.GetUserID();
            var account = _uow.UserAccounts.AllIncluding(u => u.LinkedAccounts).FirstOrDefault(a => a.Id == id);
            account.RemoveLinkedAccount(loginProvider, providerKey);
            await _uow.SaveAsync();


            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // POST: /Cheetah/UserAccount/Create
        [HttpPost]
        public async Task<ActionResult> Login(UserAccountLoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var account = _uow.UserAccounts.All.FirstOrDefault(u => u.Email == model.EmailOrMobile || u.MobilePhoneNumber == model.EmailOrMobile);
                var result = account.VerifyPassword(model.Password);
                if (result)
                {
                    //verify password
                    await LoginAsync(account, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserAccountRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserAccount.Init(model.Username, model.Password, model.Email);
                user.MobilePhoneNumber = model.Mobile;
                _uow.UserAccounts.Add(user);
                await _uow.SaveAsync();
                await LoginAsync(user, isPersistent: false);

                return RedirectToAction("Index", "UserAccount");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task LoginAsync(UserAccount account, bool isPersistent)
        {
            // get claims
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Username),
                new Claim(ClaimTypes.Email, account.Email)  
            };
            claims.AddRange(account.Claims.Select(c => new Claim(c.Type, c.Value)));

            var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            var principal = new ClaimsPrincipal(id);
            Thread.CurrentPrincipal = principal;
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, id);
        }

        [HttpPost]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "UserAccount", new { ReturnUrl = returnUrl }));
        }
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var user = _uow.UserAccounts.FilterBy(u => u.LinkedAccounts.Any(l => l.ProviderAccountID == loginInfo.Login.ProviderKey && l.ProviderName == loginInfo.Login.LoginProvider)).FirstOrDefault();
            if (user != null)
            {
                await LoginAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // If the user does not have an account, then prompt the user to create an account
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }
        [HttpPost]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }


                //_uow.UserAccounts.FilterBy(u => u.Email == info.Email).Any()

                if (!_uow.UserAccounts.FilterBy(u => u.Email == model.Email).Any())
                {
                    var user = UserAccount.Init(model.Email, Crypto.GenerateSalt(), model.Email);
                    user.AddOrUpdateLinkedAccount(info.Login.LoginProvider, info.Login.ProviderKey, info.ExternalIdentity.Claims);
                    _uow.UserAccounts.Add(user);
                    await _uow.SaveAsync();
                    await LoginAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
                else
                    ModelState.AddModelError("", "Duplicate username");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, Url.Action("LinkLoginCallback", "UserAccount"), User.Identity.GetUserId());
        }
        private const string XsrfKey = "XsrfId";

        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
            }

            // Check if this email have been used elsewhere
            if (_uow.UserAccounts.FilterBy(u => u.LinkedAccounts.Any(l => l.ProviderAccountID == loginInfo.Login.ProviderKey && l.ProviderName == loginInfo.Login.LoginProvider)).Any())
                return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
            else
            {
                var result = await _uow.UserAccounts.FindAsyncById(User.GetUserID());
                result.AddOrUpdateLinkedAccount(loginInfo.Login.LoginProvider, loginInfo.Login.ProviderKey, loginInfo.ExternalIdentity.Claims);
                await _uow.SaveAsync();
                return RedirectToAction<UserAccountController>(c => c.Manage(null));

            }

        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "UserAccount");
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        //private async System.Threading.Tasks.Task SignInAsync(ApplicationUser user, bool isPersistent)
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        //    var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        //    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        //}
        [HttpPost]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "UserAccount");
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }


        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        public ActionResult Setting()
        {
            ViewData["Cultures"] = new List<SelectListItem>();
            return View();
        }
        private bool HasPassword()
        {
            var user = _uow.UserAccounts.FindById(_User.User.Id);
            if (user != null)
            {
                return user.HashedPassword != null;
            }
            return false;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Manage(UserAccountManageModel model)
        //{
        //    bool hasPassword = HasPassword();
        //    ViewBag.HasLocalPassword = hasPassword;
        //    ViewBag.ReturnUrl = Url.Action("Manage");
        //    if (hasPassword)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
        //            }
        //            else
        //            {
        //                AddErrors(result);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        // User does not have a password so remove any validation errors caused by a missing OldPassword field
        //        ModelState state = ModelState["OldPassword"];
        //        if (state != null)
        //        {
        //            state.Errors.Clear();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
        //            }
        //            else
        //            {
        //                AddErrors(result);
        //            }
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            var linkedAccounts = _uow.UserAccounts.AllIncluding(a => a.LinkedAccounts).FirstOrDefault(u => u.Id == _User.User.Id).LinkedAccounts;

            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

    }


}
