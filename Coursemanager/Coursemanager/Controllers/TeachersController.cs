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
    public class TeachersController : Controller
    {   //实体上下文： CoursemanagerEntities
        //实例化上下文
        private CoursemanagerEntities db = new CoursemanagerEntities();

        //
        // GET: /Teachers/

        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }

        //
        // GET: /Teachers/Details/5

        public ActionResult Details(int id = 0)
        {
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        //
        // GET: /Teachers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Teachers/Create

        [HttpPost]
        public ActionResult Create(Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teachers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teachers);
        }

        //
        // GET: /Teachers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        //
        // POST: /Teachers/Edit/5

        [HttpPost]
        public ActionResult Edit(Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teachers);
        }

        //
        // GET: /Teachers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        //
        // POST: /Teachers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Teachers teachers = db.Teachers.Find(id);
            db.Teachers.Remove(teachers);
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