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
    public class ResourceGroupController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: ResourceGroup
        public ActionResult Index(String sortOrder, String searchString, String currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ResourceGroupDepartmentSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

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
                    resourceGroups = resourceGroups.OrderBy(n => n.Department.Name);
                    break;
                default:
                    resourceGroups = resourceGroups.OrderByDescending(n => n.Department.Name);
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
            PopulateDepartmentDropDownList();
            return View();
        }

        // POST: ResourceGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, DepartmentID")] ResourceGroup resourceGroup)
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
            catch (RetryLimitExceededException /*dex*/)
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

            PopulateDepartmentDropDownList(resourceGroup.DepartmentID);
            return View(resourceGroup);
        }

        // POST: ResourceGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Name, DepartmentID")] ResourceGroup resourceGroup)
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
            catch (RetryLimitExceededException /*dex*/)
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

        private void PopulateDepartmentDropDownList(object selectedDepartment = null)
        {
            var departments = from d in db.Departments orderby d.Name select d;

            ViewBag.Departments = new SelectList(departments, "ID", "Name", selectedDepartment);
        }
    }
}
