using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using com.gameoverdev.Models;

namespace com.gameoverdev.Controllers
{
    public class BLOGsController : Controller
    {
        private gameoverdevEntities1 db = new gameoverdevEntities1();

        // GET: BLOGs
        public ActionResult Index()
        {
            return View(db.BLOGs.ToList());
        }

        // GET: BLOGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // GET: BLOGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BLOGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BLOG_ID,BLOG_TITLE,BLOG_TEXT,BLOG_AUTHOR")] BLOG bLOG)
        {
            if (ModelState.IsValid)
            {
                db.BLOGs.Add(bLOG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bLOG);
        }

        // GET: BLOGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // POST: BLOGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BLOG_ID,BLOG_TITLE,BLOG_TEXT,BLOG_AUTHOR")] BLOG bLOG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bLOG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bLOG);
        }

        // GET: BLOGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // POST: BLOGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BLOG bLOG = db.BLOGs.Find(id);
            db.BLOGs.Remove(bLOG);
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
