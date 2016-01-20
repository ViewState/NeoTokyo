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
    public class CustomerOrderStatusHistoriesController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: CustomerOrderStatusHistories
        public ActionResult Index()
        {
            var customerOrderStatusHistories = db.CustomerOrderStatusHistories.Include(c => c.CustomerOrder).Include(c => c.CustomerOrderStatus);
            return View(customerOrderStatusHistories.ToList());
        }

        public ActionResult AllForOrder(Guid p_CustomerOrderID)
        {
            var customerOrderStatusHistories = db.CustomerOrderStatusHistories.Include(c => c.CustomerOrder).Include(c => c.CustomerOrderStatus);
            return View(customerOrderStatusHistories.Where(i => i.CustomerOrderID == p_CustomerOrderID).ToList());
        }

        // GET: CustomerOrderStatusHistories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrderStatusHistory customerOrderStatusHistory = db.CustomerOrderStatusHistories.Find(id);
            if (customerOrderStatusHistory == null)
            {
                return HttpNotFound();
            }
            return View(customerOrderStatusHistory);
        }

        // GET: CustomerOrderStatusHistories/Create
        public ActionResult Create()
        {
            ViewBag.CustomerOrderID = new SelectList(db.CustomerOrders, "ID", "CustomerPONumber");
            ViewBag.CustomerOrderStatusID = new SelectList(db.CustomerOrderStatuses, "ID", "Status");
            return View();
        }

        // POST: CustomerOrderStatusHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerOrderID,CustomerOrderStatusID,DateCreated")] CustomerOrderStatusHistory customerOrderStatusHistory)
        {
            if (ModelState.IsValid)
            {
                customerOrderStatusHistory.ID = Guid.NewGuid();
                db.CustomerOrderStatusHistories.Add(customerOrderStatusHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerOrderID = new SelectList(db.CustomerOrders, "ID", "CustomerPONumber", customerOrderStatusHistory.CustomerOrderID);
            ViewBag.CustomerOrderStatusID = new SelectList(db.CustomerOrderStatuses, "ID", "Status", customerOrderStatusHistory.CustomerOrderStatusID);
            return View(customerOrderStatusHistory);
        }

        // GET: CustomerOrderStatusHistories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrderStatusHistory customerOrderStatusHistory = db.CustomerOrderStatusHistories.Find(id);
            if (customerOrderStatusHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerOrderID = new SelectList(db.CustomerOrders, "ID", "CustomerPONumber", customerOrderStatusHistory.CustomerOrderID);
            ViewBag.CustomerOrderStatusID = new SelectList(db.CustomerOrderStatuses, "ID", "Status", customerOrderStatusHistory.CustomerOrderStatusID);
            return View(customerOrderStatusHistory);
        }

        // POST: CustomerOrderStatusHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerOrderID,CustomerOrderStatusID,DateCreated")] CustomerOrderStatusHistory customerOrderStatusHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerOrderStatusHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerOrderID = new SelectList(db.CustomerOrders, "ID", "CustomerPONumber", customerOrderStatusHistory.CustomerOrderID);
            ViewBag.CustomerOrderStatusID = new SelectList(db.CustomerOrderStatuses, "ID", "Status", customerOrderStatusHistory.CustomerOrderStatusID);
            return View(customerOrderStatusHistory);
        }

        // GET: CustomerOrderStatusHistories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrderStatusHistory customerOrderStatusHistory = db.CustomerOrderStatusHistories.Find(id);
            if (customerOrderStatusHistory == null)
            {
                return HttpNotFound();
            }
            return View(customerOrderStatusHistory);
        }

        // POST: CustomerOrderStatusHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CustomerOrderStatusHistory customerOrderStatusHistory = db.CustomerOrderStatusHistories.Find(id);
            db.CustomerOrderStatusHistories.Remove(customerOrderStatusHistory);
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
