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
    public class ResourceGroupController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: ResourceGroup
        public ActionResult Index()
        {
            return View(db.ResourceGroups.ToList());
        }

        // GET: ResourceGroup/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceGroup resourceGroup = db.ResourceGroups.Find(id);
            if (resourceGroup == null)
            {
                return HttpNotFound();
            }
            return View(resourceGroup);
        }

        // GET: ResourceGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResourceGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] ResourceGroup resourceGroup)
        {
            if (ModelState.IsValid)
            {
                resourceGroup.ID = Guid.NewGuid();
                db.ResourceGroups.Add(resourceGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resourceGroup);
        }

        // GET: ResourceGroup/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceGroup resourceGroup = db.ResourceGroups.Find(id);
            if (resourceGroup == null)
            {
                return HttpNotFound();
            }
            return View(resourceGroup);
        }

        // POST: ResourceGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] ResourceGroup resourceGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourceGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resourceGroup);
        }

        // GET: ResourceGroup/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceGroup resourceGroup = db.ResourceGroups.Find(id);
            if (resourceGroup == null)
            {
                return HttpNotFound();
            }
            return View(resourceGroup);
        }

        // POST: ResourceGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ResourceGroup resourceGroup = db.ResourceGroups.Find(id);
            db.ResourceGroups.Remove(resourceGroup);
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
