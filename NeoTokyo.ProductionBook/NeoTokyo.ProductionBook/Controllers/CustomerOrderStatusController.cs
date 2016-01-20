using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NeoTokyo.ProductionBook.DAL;
using NeoTokyo.ProductionBook.Models;

namespace NeoTokyo.ProductionBook.Controllers
{
    public class CustomerOrderStatusController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: CustomerOrderStatus
        public ActionResult Index()
        {
            return View(db.CustomerOrderStatuses.ToList());
        }

        // GET: CustomerOrderStatus/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrderStatus customerOrderStatus = db.CustomerOrderStatuses.Find(id);
            if (customerOrderStatus == null)
            {
                return HttpNotFound();
            }
            return View(customerOrderStatus);
        }

        // GET: CustomerOrderStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerOrderStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Status,Description,Order,Finished")] CustomerOrderStatus customerOrderStatus)
        {
            if (ModelState.IsValid)
            {
                customerOrderStatus.ID = Guid.NewGuid();
                db.CustomerOrderStatuses.Add(customerOrderStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerOrderStatus);
        }

        // GET: CustomerOrderStatus/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrderStatus customerOrderStatus = db.CustomerOrderStatuses.Find(id);
            if (customerOrderStatus == null)
            {
                return HttpNotFound();
            }
            return View(customerOrderStatus);
        }

        // POST: CustomerOrderStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Status,Description,Order,Finished")] CustomerOrderStatus customerOrderStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerOrderStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerOrderStatus);
        }

        // GET: CustomerOrderStatus/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrderStatus customerOrderStatus = db.CustomerOrderStatuses.Find(id);
            if (customerOrderStatus == null)
            {
                return HttpNotFound();
            }
            return View(customerOrderStatus);
        }

        // POST: CustomerOrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CustomerOrderStatus customerOrderStatus = db.CustomerOrderStatuses.Find(id);
            db.CustomerOrderStatuses.Remove(customerOrderStatus);
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
