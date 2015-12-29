using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NeoTokyo.ProductionBook.DAL;
using NeoTokyo.ProductionBook.Models;
using PagedList;

namespace NeoTokyo.ProductionBook.Controllers
{
    public class ProcessController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: Process
        public ActionResult Index(String sortOrder, String searchString, String currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ProcessNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var processes = from p in db.Processes select p;

            if (!String.IsNullOrEmpty(searchString))
                processes = processes.Where(r => r.Name.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    processes = processes.OrderBy(n => n.Name);
                    break;
                default:
                    processes = processes.OrderByDescending(n => n.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ModelState.Remove("searchString");

            return View(processes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Process/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            return View(process);
        }

        // GET: Process/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Process/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,IsOvernightProcess,CompletedStatusText")] Process process)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Processes.Add(process);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(process);
        }

        // GET: Process/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            return View(process);
        }

        // POST: Process/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,IsOvernightProcess,CompletedStatusText")] Process process)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(process).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(process);
        }

        // GET: Process/Delete/5
        public ActionResult Delete(Guid? id, Boolean? saveChangesError = false)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";

            Process process = db.Processes.Find(id);

            if (process == null)
                return HttpNotFound();

            return View(process);
        }

        // POST: Process/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            try
            {
                Process process = db.Processes.Find(id);
                db.Processes.Remove(process);
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
    }
}
