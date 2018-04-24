using EMR.DAL2.EF;
using EMR.DAL2.Identity;
using EMR.DAL2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Controllers
{
    [Authorize]
    public class MainController : BaseController, IController
    {
        private IUnitOfWork db;
        public MainController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }       
        
        // GET: Main
        public ActionResult Index()
        {
            AppUser usr = GetCurrentUser();
            ViewBag.User = usr;
            return View();
        }

        public ActionResult Visitors()
        {
            AppUser usr = GetCurrentUser();
            ViewBag.User = usr;


            return View();
        }
    }
}