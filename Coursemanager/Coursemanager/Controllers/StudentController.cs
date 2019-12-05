using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coursemanager.Models;

namespace Coursemanager.Controllers
{
    public class StudentController : Controller
    {
        private CoursemanagerEntities db = new CoursemanagerEntities();

        //
        // GET: /Student/

        public ActionResult Index()
        {
            return View(db.Stutents.ToList());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Stutents stutents = db.Stutents.Find(id);
            if (stutents == null)
            {
                return HttpNotFound();
            }
            return View(stutents);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            var classse = db.Classse.ToList();

            ViewBag.classse = classse;
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(Stutents stutents)
        {
            if (ModelState.IsValid)
            {
                db.Stutents.Add(stutents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stutents);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Stutents stutents = db.Stutents.Find(id);
            if (stutents == null)
            {
                return HttpNotFound();
            }
            return View(stutents);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(Stutents stutents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stutents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stutents);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Stutents stutents = db.Stutents.Find(id);
            if (stutents == null)
            {
                return HttpNotFound();
            }
            return View(stutents);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Stutents stutents = db.Stutents.Find(id);
            db.Stutents.Remove(stutents);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}