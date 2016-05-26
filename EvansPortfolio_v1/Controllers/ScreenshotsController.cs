using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EvansPortfolio_v1.Content;

namespace EvansPortfolio_v1.Controllers
{
    public class ScreenshotsController : Controller
    {
        private PortfolioDBEntities db = new PortfolioDBEntities();

        // GET: Screenshots
        public ActionResult Index()
        {
            var screenshots = db.Screenshots.Include(s => s.Project);
            return View(screenshots.ToList());
        }

        // GET: Screenshots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screenshot screenshot = db.Screenshots.Find(id);
            if (screenshot == null)
            {
                return HttpNotFound();
            }
            return View(screenshot);
        }

        // GET: Screenshots/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Name");
            return View();
        }

        // POST: Screenshots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScreenshotID,ProjectID,Name,ImagePath")] Screenshot screenshot)
        {
            if (ModelState.IsValid)
            {
                db.Screenshots.Add(screenshot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Name", screenshot.ProjectID);
            return View(screenshot);
        }

        // GET: Screenshots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screenshot screenshot = db.Screenshots.Find(id);
            if (screenshot == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Name", screenshot.ProjectID);
            return View(screenshot);
        }

        // POST: Screenshots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScreenshotID,ProjectID,Name,ImagePath")] Screenshot screenshot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(screenshot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Name", screenshot.ProjectID);
            return View(screenshot);
        }

        // GET: Screenshots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screenshot screenshot = db.Screenshots.Find(id);
            if (screenshot == null)
            {
                return HttpNotFound();
            }
            return View(screenshot);
        }

        // POST: Screenshots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Screenshot screenshot = db.Screenshots.Find(id);
            db.Screenshots.Remove(screenshot);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
