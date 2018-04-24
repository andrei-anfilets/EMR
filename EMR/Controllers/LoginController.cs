using EMR.DAL2.EF;
using EMR.DAL2.Identity;
using EMR.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EMR.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            AppUser usr_new = new AppUser() { Name = "Admin", UserName = "Adm", Role_Id = "1" };
            UserManager.Create(usr_new, "111111");
            AppUser usr_new2 = new AppUser() { Name = "Doc", UserName = "Doc", Role_Id = "2" };
            UserManager.Create(usr_new2, "111111");
            return View();
        }

        public ActionResult SignIn()
        {
            

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(LoginViewModel login, String ReturnUrl)
        {
            AppUser usr = UserManager.Find(login.UserName, login.Password);
            if (usr == null || login.UserName == null || login.Password == null)
            {
                ModelState.AddModelError("Error", "Логин или пароль неправильные");
                return View();
            }
            ClaimsIdentity ident = await UserManager.CreateIdentityAsync(usr, DefaultAuthenticationTypes.ApplicationCookie);
            AuthManager.SignOut();
            AuthManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, ident);

            if (Url.IsLocalUrl(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction("Index", "Main");
        }

        public ActionResult SignOut()
        {
            AuthManager.SignOut();
            return RedirectToAction("SignIn");
        }

        //private AppRole GetCurrentRole()
        //{
        //    AppUser user = new AppUser();
        //    user = UserManager.FindById(User.Identity.GetUserId());
        //    if (user == null)
        //    {
        //        user = new AppUser() { Id = "0" };
        //        //user.Role = new EMRContext().AppRoles.Find("8");
        //        user.Role = new AppRole();
        //    }
        //    return user.Role;
        //}

        //private EMRContext UserContext
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().GetUserManager<EMRContext>();
        //    }
        //}
        //private IAuthenticationManager AuthManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}
        //private AppUserManager UserManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        //    }
        //}

    }
}