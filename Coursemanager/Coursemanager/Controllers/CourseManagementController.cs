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
    public class CourseManagementController : Controller
    {
        private CoursemanagerEntities db = new CoursemanagerEntities();

        //
        // GET: /CourseManagement/

        public ActionResult Index()
        {
            return View(db.CourseManagements.ToList());
        }

        //
        // GET: /CourseManagement/Details/5

        public ActionResult Details(int id = 0)
        {
            CourseManagement coursemanagement = db.CourseManagements.Find(id);
            if (coursemanagement == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagement);
        }

        //
        // GET: /CourseManagement/Create

        public ActionResult Create()
        {
            var teachers = db.Teachers.ToList();

            ViewBag.Teachers = teachers;
            var classse = db.Classse.ToList();

            ViewBag.classse = classse;
            var course = db.Courses.ToList();

            ViewBag.course = course;
            return View();
        }

        //
        // POST: /CourseManagement/Create

        [HttpPost]
        public ActionResult Create(CourseManagement coursemanagement)
        {
            if (ModelState.IsValid)
            {
                db.CourseManagements.Add(coursemanagement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coursemanagement);
        }

        //
        // GET: /CourseManagement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CourseManagement coursemanagement = db.CourseManagements.Find(id);
            if (coursemanagement == null)
            {
                return HttpNotFound();
            }
            var teachers = db.Teachers.ToList();

            ViewBag.Teachers = teachers;
            var classse = db.Classse.ToList();

            ViewBag.classse = classse;
            var course = db.Courses.ToList();

            ViewBag.course = course;
            return View(coursemanagement);
        }

        //
        // POST: /CourseManagement/Edit/5

        [HttpPost]
        public ActionResult Edit(CourseManagement coursemanagement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursemanagement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coursemanagement);
        }

        //
        // GET: /CourseManagement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CourseManagement coursemanagement = db.CourseManagements.Find(id);
            if (coursemanagement == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagement);
        }

        //
        // POST: /CourseManagement/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseManagement coursemanagement = db.CourseManagements.Find(id);
            db.CourseManagements.Remove(coursemanagement);
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