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
    public class ActionlinkController : Controller
    {
        private CoursemanagerEntities db = new CoursemanagerEntities();

        //
        // GET: /Actionlink/

        public ActionResult Index()
        {
            return View(db.ActionLink.ToList());
        }

        //
        // GET: /Actionlink/Details/5

        public ActionResult Details(int id = 0)
        {
            ActionLink actionlink = db.ActionLink.Find(id);
            if (actionlink == null)
            {
                return HttpNotFound();
            }
            return View(actionlink);
        }

        //
        // GET: /Actionlink/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Actionlink/Create

        [HttpPost]
        public ActionResult Create(ActionLink actionlink)
        {
            if (ModelState.IsValid)
            {
                db.ActionLink.Add(actionlink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actionlink);
        }

        //
        // GET: /Actionlink/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ActionLink actionlink = db.ActionLink.Find(id);
            if (actionlink == null)
            {
                return HttpNotFound();
            }
            return View(actionlink);
        }

        //
        // POST: /Actionlink/Edit/5

        [HttpPost]
        public ActionResult Edit(ActionLink actionlink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actionlink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actionlink);
        }

        //
        // GET: /Actionlink/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ActionLink actionlink = db.ActionLink.Find(id);
            if (actionlink == null)
            {
                return HttpNotFound();
            }
            return View(actionlink);
        }

        //
        // POST: /Actionlink/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ActionLink actionlink = db.ActionLink.Find(id);
            db.ActionLink.Remove(actionlink);
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