using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NeoTokyo.ProductionBook.DAL;
using NeoTokyo.ProductionBook.Models;
using PagedList;

namespace NeoTokyo.ProductionBook.Controllers
{
    public class ResourceGroupController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: ResourceGroup
        public ActionResult Index(String sortOrder, String searchString, String currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ResourceGroupNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var resourceGroups = db.ResourceGroups.Include(r=>r.StaffResourceGroupLinks);

            if (!String.IsNullOrEmpty(searchString))
                resourceGroups = resourceGroups.Where(r => r.Name.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    resourceGroups = resourceGroups.OrderBy(n => n.Name);
                    break;
                default:
                    resourceGroups = resourceGroups.OrderByDescending(n => n.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ModelState.Remove("searchString");

            return View(resourceGroups.ToPagedList(pageNumber, pageSize));
        }

        // GET: ResourceGroup/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ResourceGroup resourceGroup = db.ResourceGroups.Find(id);

            if (resourceGroup == null)
                return HttpNotFound();

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
        public ActionResult Create([Bind(Include = "Name")] ResourceGroup resourceGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ResourceGroups.Add(resourceGroup);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(resourceGroup);
        }

        // GET: ResourceGroup/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ResourceGroup resourceGroup = db.ResourceGroups.Find(id);

            if (resourceGroup == null)
                return HttpNotFound();

            return View(resourceGroup);
        }

        // POST: ResourceGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name")] ResourceGroup resourceGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(resourceGroup).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(resourceGroup);
        }

        // GET: ResourceGroup/Delete/5
        public ActionResult Delete(Guid? id, Boolean? saveChangesError = false)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";

            ResourceGroup resourceGroup = db.ResourceGroups.Find(id);

            if (resourceGroup == null)
                return HttpNotFound();

            return View(resourceGroup);
        }

        // POST: ResourceGroup/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            try
            {
                ResourceGroup resourceGroup = db.ResourceGroups.Find(id);

                db.ResourceGroups.Remove(resourceGroup);
                db.SaveChanges();
            }
            catch (DataException /*dex*/)
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
