using Coursemanager.Filters;
using Coursemanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coursemanager.Controllers
{
    [RequireAuthentication]
    [ActionResultExceptionFilter]

    public class HomeController : Controller
    {
        private CoursemanagerEntities db = new CoursemanagerEntities();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "你的应用程序说明页。";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "你的联系方式页。";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Navbar()
        {
            var Site = new Websiteinfo();
            ViewBag.Site = Site;
            Site.ActionLinks = db.ActionLink.ToList();
            return PartialView("~/Views/Shared/Navbar.cshtml");
        }
        [ChildActionOnly]

        public ActionResult Sidebar()
        {
            var sidebars = db.Sidebar.ToList();
            ViewBag.Sidebar = sidebars;
            return PartialView("~/Views/Shared/sidebar.cshtml");
        }
    }
}
