using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NeoTokyo.ProductionBook.DAL;
using NeoTokyo.ProductionBook.Models;
using NeoTokyo.ProductionBook.ViewModel;
using PagedList;

namespace NeoTokyo.ProductionBook.Controllers
{
    public class CustomerOrdersController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: CustomerOrders
        public ActionResult Index(String customer)
        {
            String allCustomersHeader = "All";

            var allCustomers = db.Customers.Select(i => i.Name).OrderBy(i=> i).ToList();
            allCustomers.Insert(0, allCustomersHeader);
            ViewBag.Customers = allCustomers;

            var customerOrders = (from i in db.CustomerOrders
                                 orderby i.OrderDate descending
                                 where
                                 (customer == allCustomersHeader || customer == String.Empty || customer == null || i.Customer.Name == customer)
                                 select i).Include(c => c.Customer).Include(c => c.CustomerOrderStatus);


            return View(customerOrders.ToList());
        }

        // GET: CustomerOrders/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // GET: CustomerOrders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            ViewBag.CustomerOrderStatusID = new SelectList(db.CustomerOrderStatuses, "ID", "Status");
            return View();
        }

        // POST: CustomerOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerID,CustomerPONumber,OrderDate,Comments,CustomerOrderStatusID")] CustomerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                customerOrder.ID = Guid.NewGuid();
                db.CustomerOrders.Add(customerOrder);
                db.SaveChanges();

                var customerOrderStatusHistoriesController = new CustomerOrderStatusHistoriesController();
                customerOrderStatusHistoriesController.Create(new CustomerOrderStatusHistory
                {
                    CustomerOrderID = customerOrder.ID,
                    CustomerOrderStatusID = customerOrder.CustomerOrderStatusID,
                    DateCreated = DateTime.Now,
                });

                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", customerOrder.CustomerID);
            ViewBag.CustomerOrderStatusID = new SelectList(db.CustomerOrderStatuses, "ID", "Status", customerOrder.CustomerOrderStatusID);
            return View(customerOrder);
        }

        // GET: CustomerOrders/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", customerOrder.CustomerID);
            ViewBag.CustomerOrderStatusID = new SelectList(db.CustomerOrderStatuses, "ID", "Status", customerOrder.CustomerOrderStatusID);
            return View(customerOrder);
        }

        // POST: CustomerOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerID,CustomerPONumber,OrderDate,Comments,CustomerOrderStatusID")] CustomerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                var originalCustomerOrder = db.CustomerOrders.AsNoTracking().SingleOrDefault(i => i.ID == customerOrder.ID);

                if (originalCustomerOrder.CustomerOrderStatusID != customerOrder.CustomerOrderStatusID)
                {
                    var customerOrderStatusHistoriesController = new CustomerOrderStatusHistoriesController();
                    customerOrderStatusHistoriesController.Create(new CustomerOrderStatusHistory
                    {
                        CustomerOrderID = customerOrder.ID,
                        CustomerOrderStatusID = customerOrder.CustomerOrderStatusID,
                        DateCreated = DateTime.Now,
                    });
                }

                db.Entry(customerOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", customerOrder.CustomerID);
            ViewBag.CustomerOrderStatusID = new SelectList(db.CustomerOrderStatuses, "ID", "Status", customerOrder.CustomerOrderStatusID);
            return View(customerOrder);
        }

        // GET: CustomerOrders/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // POST: CustomerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            db.CustomerOrders.Remove(customerOrder);
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
