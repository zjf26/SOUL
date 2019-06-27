using Coursemanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coursemanager.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private CoursemanagerEntities db = new CoursemanagerEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login([Bind(Include = "Account,Password")] Users user)
        {
            if (ModelState.IsValid)
            {
                var account = db.Users.FirstOrDefault(u => u.Account == user.Account && u.Passwoed == user.Passwoed);

                if(account == null)
                {
                    return View(user);
                }

                HttpContext.Session?.Add("user",user);

                var cookie = new HttpCookie("user",user.Account)
                {
                  Expires = DateTime.Now.AddHours(3)
                };
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index","Home");
            }
            return View(user);
        }

    }
}
