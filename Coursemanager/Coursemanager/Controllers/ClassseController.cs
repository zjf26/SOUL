using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coursemanager.Models;
using Coursemanager.BLLS;

namespace Coursemanager.Controllers
{
    public class ClassseController : Controller
    {
        private CoursemanagerEntities db = new CoursemanagerEntities();

        private IClassRepository _respository = new ClassRepository();
        //
        // GET: /Classse/

        public ActionResult Index()
        {
            return View(db.Classse.ToList());
        }

        //
        // GET: /Classse/Details/5

        public ActionResult Details(int id = 0)
        {
            Classse classse = db.Classse.Find(id);
            if (classse == null)
            {
                return HttpNotFound();
            }
            return View(classse);
        }

        //
        // GET: /Classse/Create

        public ActionResult Create()
        {
            var teachers = db.Teachers.ToList();
           
            ViewBag.Teachers = teachers;

            return View();
        }

        //
        // POST: /Classse/Create

        [HttpPost]
        public ActionResult Create(Classse classse)
        {
            if (ModelState.IsValid)
            {
                db.Classse.Add(classse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classse);
        }

        //
        // GET: /Classse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Classse classse = db.Classse.Find(id);
            if (classse == null)
            {
                return HttpNotFound();
            }
            var teachers = db.Teachers.ToList();
            ViewBag.Teachers = teachers;
            return View(classse);
        }

        //
        // POST: /Classse/Edit/5

        [HttpPost]
        public ActionResult Edit(Classse classse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classse);
        }

        //
        // GET: /Classse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Classse classse = db.Classse.Find(id);
            if (classse == null)
            {
                return HttpNotFound();
            }
            var teachers = db.Teachers.ToList();

            ViewBag.Teachers = teachers;
            return View(classse);
        }

        //
        // POST: /Classse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Classse classse = db.Classse.Find(id);
            db.Classse.Remove(classse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowCourseMnanagement(int id)
        {
            return View(_respository.GetClassCourse(id));
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}