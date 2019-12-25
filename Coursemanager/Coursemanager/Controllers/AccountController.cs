using Coursemanager.Models;
using Coursemanager.Models.ValidatableObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public ActionResult Login(LoginInput input)
        {
            if (ModelState.IsValid)
            {
                var account = db.Users.FirstOrDefault(u => u.Account == input.Account && u.Passwoed == input.Passwoed);

                if(account == null)
                {
                    ModelState.AddModelError("Passwoed","用户名不存在或密码错误");

                    return View(input);
                }

            HttpContext.Session.Add("user",input.Account);

            var cookie = new HttpCookie("user", input.Account)
                {
                  Expires = DateTime.Now.AddHours(3)
                };
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index","Home");
            }
            return View(input);
        }
     

    }
}
