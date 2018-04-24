using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMR.DAL2.EF;
using EMR.DAL2.Identity;
using EMR.DAL2.Interfaces;
using Microsoft.AspNet.Identity;
using EMR.Models;

namespace EMR.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {

        private IUnitOfWork uow;
        private Lazy<EMRContext> db = new Lazy<EMRContext>();
        public UsersController(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        // GET: Users
        public ActionResult Index()
        {
            ViewBag.User = GetCurrentUser();
            return View();
        }

        [HttpPost]
        public ActionResult UserList(String filter)
        {
            IEnumerable<AppUser> users = UserManager.Users.Where(u => u.Name.Contains(filter) || u.UserName.Contains(filter)).OrderBy(u => u.Role_Id).OrderBy(u => u.Name).ToList();
            return View(users);
        }

        public ActionResult Create()
        {
            ViewBag.Roles = db.Value.AppRoles.ToList().Select(d => new SelectListItem() { Value = d.Id.ToString(), Text = d.Name }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = db.Value.AppRoles.ToList().Select(d => new SelectListItem() { Value = d.Id.ToString(), Text = d.Name }).ToList();
                return View(user);
            }

            AppUser usr_new = new AppUser() { Name = user.Name, UserName = user.UserName, Role_Id = user.Role_Id };
            UserManager.Create(usr_new, user.Password);
            return Json(1);
        }

        public ActionResult Edit(String Id)
        {
            AppUser usr = UserManager.Users.FirstOrDefault(u => u.Id == Id);
            UserEditModel view = new UserEditModel() { UserId = usr.Id, Name = usr.Name, UserName = usr.UserName, Role_Id = usr.Role_Id };
            ViewBag.Roles = db.Value.AppRoles.ToList().Select(d => new SelectListItem() { Value = d.Id.ToString(), Text = d.Name }).ToList();
            return View(view);
        }

        [HttpPost]
        public ActionResult Edit(UserEditModel user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = db.Value.AppRoles.ToList().Select(d => new SelectListItem() { Value = d.Id.ToString(), Text = d.Name }).ToList();
                return View(user);
            }

            AppUser usr_new = UserManager.Users.FirstOrDefault(u => u.Id == user.UserId);
            usr_new.Name = user.Name;
            usr_new.UserName = user.UserName;
            usr_new.Role_Id = user.Role_Id;
            UserManager.Update(usr_new);
            return Json(1);
        }


        public ActionResult Delete(String Id)
        {
            if (UserManager.Delete(UserManager.Users.FirstOrDefault(u => u.Id == Id)).Succeeded)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else return Json(0, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ResetPwd(String Id)
        {
            UserManager.RemovePassword(Id);
            UserManager.AddPassword(Id, "111111");
            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}