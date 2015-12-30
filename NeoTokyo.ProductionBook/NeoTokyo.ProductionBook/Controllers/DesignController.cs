using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeoTokyo.ProductionBook.DAL;
using NeoTokyo.ProductionBook.Models;

namespace NeoTokyo.ProductionBook.Controllers
{
    public class DesignController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: Design
        public ActionResult Index()
        {
            var designs = db.Designs.Include(d => d.Designer);
            return View(designs.ToList());
        }

        // GET: Design/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Design design = db.Designs.Find(id);
            if (design == null)
            {
                return HttpNotFound();
            }
            return View(design);
        }

        // GET: Design/Create
        public ActionResult Create()
        {
            ViewBag.DesignerID = new SelectList(db.Designers, "ID", "ID");
            return View();
        }

        // POST: Design/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DesignerID,Created,Active,DesignNumber")] Design design)
        {
            if (ModelState.IsValid)
            {
                design.ID = Guid.NewGuid();
                db.Designs.Add(design);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DesignerID = new SelectList(db.Designers, "ID", "ID", design.DesignerID);
            return View(design);
        }

        // GET: Design/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Design design = db.Designs.Find(id);
            if (design == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignerID = new SelectList(db.Designers, "ID", "ID", design.DesignerID);
            return View(design);
        }

        // POST: Design/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DesignerID,Created,Active,DesignNumber")] Design design)
        {
            if (ModelState.IsValid)
            {
                db.Entry(design).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DesignerID = new SelectList(db.Designers, "ID", "ID", design.DesignerID);
            return View(design);
        }

        // GET: Design/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Design design = db.Designs.Find(id);
            if (design == null)
            {
                return HttpNotFound();
            }
            return View(design);
        }

        // POST: Design/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Design design = db.Designs.Find(id);
            db.Designs.Remove(design);
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
