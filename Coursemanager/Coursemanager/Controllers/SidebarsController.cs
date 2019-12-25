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
    public class SidebarsController : Controller
    {
        private CoursemanagerEntities db = new CoursemanagerEntities();

        //
        // GET: /Sidebars/

        public ActionResult Index()
        {
            return View(db.Sidebar.ToList());
        }

        //
        // GET: /Sidebars/Details/5

        public ActionResult Details(int id = 0)
        {
            Sidebar sidebar = db.Sidebar.Find(id);
            if (sidebar == null)
            {
                return HttpNotFound();
            }
            return View(sidebar);
        }

        //
        // GET: /Sidebars/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sidebars/Create

        [HttpPost]
        public ActionResult Create(Sidebar sidebar)
        {
            if (ModelState.IsValid)
            {
                db.Sidebar.Add(sidebar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sidebar);
        }

        //
        // GET: /Sidebars/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sidebar sidebar = db.Sidebar.Find(id);
            if (sidebar == null)
            {
                return HttpNotFound();
            }
            return View(sidebar);
        }

        //
        // POST: /Sidebars/Edit/5

        [HttpPost]
        public ActionResult Edit(Sidebar sidebar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sidebar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sidebar);
        }

        //
        // GET: /Sidebars/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sidebar sidebar = db.Sidebar.Find(id);
            if (sidebar == null)
            {
                return HttpNotFound();
            }
            return View(sidebar);
        }

        //
        // POST: /Sidebars/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sidebar sidebar = db.Sidebar.Find(id);
            db.Sidebar.Remove(sidebar);
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