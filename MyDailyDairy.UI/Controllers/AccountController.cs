using MyDailyDairy.Data.EF;
using MyDailyDairy.UI.Filters;
using MyDailyDairy.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uow.Package.Data;

namespace MyDailyDairy.UI.Controllers
{
    public class AccountController : Controller
    {
        private IUnitOfWork _unit;

        public AccountController()
        {
            _unit = new UnitOfWork();
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        [MyCookieSettingFilterAttribute]
        public ActionResult Login(string returnUrl)
        {
            HttpCookie myCookie = Request.Cookies["LastURl"];
            if(myCookie!=null)
            {
                var request = myCookie.Value;

                Uri u = new Uri(request);               

                return RedirectToAction(request);
            }


            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var objUser = _unit.Users.GetAll().FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (objUser != null)
            {
                Session["Auth"] = objUser.UserName;

                if (objUser.RoleID == 1)
                {
                    return RedirectToAction("Index", "Roles", new { area = "Admin" });
                }
                else
                {
                    
                    return RedirectToLocal(returnUrl);
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            //// This doesn't count login failures towards account lockout
            //// To enable password failures to trigger account lockout, change to shouldLockout: true
            //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        return RedirectToLocal(returnUrl);
            //    case SignInStatus.LockedOut:
            //        return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            //    case SignInStatus.Failure:
            //    default:
            //        ModelState.AddModelError("", "Invalid login attempt.");
            //        return View(model);
            //}
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["Auth"] = null;
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                // Add the following to populate the new user properties
                // from the ViewModel data:
                var user = new User()
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password,
                    Email = model.Email,
                    IsLocked = false,
                    IsApproved = false,
                    RoleID = 2
                };

                _unit.Users.Create(user);
                _unit.Commit();

                //var result = await UserManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                //{

                //    //var role = new ApplicationRole("roleViewModel");
                //    //var roleresult = ApplicationRoleManager.Create((role));

                //    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //    // Send an email with this link
                //    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                //    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                //    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                //    return RedirectToAction("Index", "Home");
                //}
                //AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("About", "Home");
        }
    }
}