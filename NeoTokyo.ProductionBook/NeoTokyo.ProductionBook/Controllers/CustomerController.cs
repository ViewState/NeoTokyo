using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NeoTokyo.ProductionBook.DAL;
using NeoTokyo.ProductionBook.Models;
using NeoTokyo.ProductionBook.ViewModel;
using PagedList;

namespace NeoTokyo.ProductionBook.Controllers
{
    public class CustomerController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: Customer
        public ActionResult Index(String sortOrder, String searchCustomerNameString, String currentCustomerNameFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CustomerNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchCustomerNameString != null)
            {
                page = 1;
            }
            else
            {
                searchCustomerNameString = currentCustomerNameFilter;
            }

            ViewBag.CurrentCustomerNameFilter = currentCustomerNameFilter;

            var customers = db.Customers.AsQueryable();

            if (searchCustomerNameString != null)
                customers = customers.Where(i => i.Name.Contains(searchCustomerNameString));

            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(i => i.Name);
                    break;
                default:
                    customers = customers.OrderBy(i => i.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ModelState.Remove("searchCustomerNameString");

            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Customer/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            PopulateCountryDropDown();
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customer.ID = Guid.NewGuid();
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(Guid? id, Boolean? saveChangesError = false)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";

            Customer customer = db.Customers.Find(id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Customer customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                RedirectToAction("Delete", new { id, saveChangesError = true });
            }
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

        [HttpPost]
        public ActionResult _AddCustomerAddress(CustomerAddressViewModel customerAddressViewModel)
        {
            try
            {
                var address = customerAddressViewModel.Address;
                address.Active = true;

                var customerAddressLink = new CustomerAddressLink
                {
                    CustomerID = customerAddressViewModel.ID,
                    AddressID = address.ID
                };

                db.Addresses.Add(address);
                db.CustomerAddressLinks.Add(customerAddressLink);

                if (customerAddressViewModel.AsDefaultDelivery)
                {
                    var defaultDeliveryAddress = db.CustomerDefaultDeliveryAddresses.Find(customerAddressViewModel.ID);

                    if (defaultDeliveryAddress != null)
                    {
                        defaultDeliveryAddress.AddressID = address.ID;
                    }
                    else
                    {
                        defaultDeliveryAddress = new CustomerDefaultDeliveryAddress
                        {
                            AddressID = address.ID,
                            CustomerID = customerAddressViewModel.ID
                        };
                    }
                    db.CustomerDefaultDeliveryAddresses.AddOrUpdate(defaultDeliveryAddress);
                }

                if (customerAddressViewModel.AsDefaultInvoice)
                {
                    var defaultInvoiceAddress = db.CustomerDefaultInvoiceAddresses.Find(customerAddressViewModel.ID);

                    if (defaultInvoiceAddress != null)
                    {
                        defaultInvoiceAddress.AddressID = address.ID;
                    }
                    else
                    {
                        defaultInvoiceAddress = new CustomerDefaultInvoiceAddress
                        {
                            AddressID = address.ID,
                            CustomerID = customerAddressViewModel.ID
                        };
                    }
                    db.CustomerDefaultInvoiceAddresses.AddOrUpdate(defaultInvoiceAddress);
                }
                db.SaveChanges();
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ViewBag.ErrorMessage = "Error Trying to Add New Address";
                RedirectToAction("Details", new {id = customerAddressViewModel.ID});
            }
            return RedirectToAction("Details", new {id = customerAddressViewModel.ID});
        }

        private void PopulateCountryDropDown(object selectedCountry = null)
        {
            var countries = from c in db.Countries orderby c.CountryName select c;

            ViewBag.Countries = new SelectList(countries, "ID", "CountryName", selectedCountry);
        }
    }
}
