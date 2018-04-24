using EMR.DAL2.EF;
using EMR.DAL2.Identity;
using EMR.DAL2.Interfaces;
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
    public class BaseController : Controller
    {
        
        internal AppRole GetCurrentRole()
        {
            AppUser user = new AppUser();
            user = UserManager.FindById(User.Identity.GetUserId());
            if (user == null)
            {
                user = new AppUser() { Id = "0" };
                //user.Role = new EMRContext().AppRoles.Find("8");
                user.Role = new AppRole();
            }
            return user.Role;
        }

        internal AppUser GetCurrentUser()
        {
            AppUser user = new AppUser();
            user = UserManager.FindById(User.Identity.GetUserId());
            if (user.Role == null)
            {
                user.Role = UserContext.AppRoles.Where(r => r.Id == user.Role_Id).FirstOrDefault();
            }
            return user;
        }


        internal EMRContext UserContext
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<EMRContext>();
            }
        }
        internal IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        internal AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

       
    }
}