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
    public class DesignController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: Design
        public ActionResult Index(String sortOrder, String searchDesignNumberString, String searchDesignerString, String currentDesignNumberFilter, String currentDesignerFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DesignNumberSortParm = String.IsNullOrEmpty(sortOrder) ? "designNumber_desc" : "";
            ViewBag.DesignerSortParm = sortOrder == "Designer" ? "designer_desc" : "Designer";

            if (searchDesignNumberString != null)
            {
                page = 1;
            }
            else
            {
                searchDesignNumberString = currentDesignNumberFilter;
            }

            if (searchDesignerString != null)
            {
                page = 1;
            }
            else
            {
                searchDesignerString = currentDesignerFilter;
            }

            ViewBag.CurrentDesignerFilter = searchDesignerString;

            ViewBag.CurrentDesignNumberFilter = searchDesignNumberString;

            var designs = db.Designs.Include(d => d.Designer);

            if (!String.IsNullOrEmpty(searchDesignNumberString))
                designs = designs.Where(d => d.DesignNumber.Contains(searchDesignNumberString));

            if (!String.IsNullOrEmpty(searchDesignerString))
                designs = designs.Where(d => (d.Designer.Staff.FirstName.Contains(searchDesignerString) || d.Designer.Staff.LastName.Contains(searchDesignerString)));

            switch (sortOrder)
            {
                case "designNumber_desc":
                    designs = designs.OrderBy(n => n.DesignNumber);
                    break;
                case "Designer":
                    designs = designs.OrderBy(g => g.Designer.Staff.LastName);
                    break;
                case "designer_desc":
                    designs = designs.OrderByDescending(g => g.Designer.Staff.LastName);
                    break;
                default:
                    designs = designs.OrderByDescending(n => n.DesignNumber);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ModelState.Remove("searchDesignNumberString");
            ModelState.Remove("searchDesignerString");

            return View(designs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Design/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Design design = db.Designs.Find(id);

            if (design == null)
                return HttpNotFound();

            return View(design);
        }

        // GET: Design/Create
        public ActionResult Create()
        {
            PopulateDesignersDropDown();
            return View();
        }

        // POST: Design/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DesignerID,Active,DesignNumber")] Design design)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    design.Created = DateTime.Now;
                    db.Designs.Add(design);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(design);
        }

        // GET: Design/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Design design = db.Designs.Find(id);

            if (design == null)
                return HttpNotFound();

            PopulateDesignersDropDown(design.Designer.ID);
            return View(design);
        }

        // POST: Design/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DesignerID,Created,Active,DesignNumber")] Design design)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(design).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(design);
        }

        // GET: Design/Delete/5
        public ActionResult Delete(Guid? id, Boolean? saveChangesError = false)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";

            Design design = db.Designs.Find(id);

            if (design == null)
                return HttpNotFound();

            return View(design);
        }

        // POST: Design/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            try
            {
                Design design = db.Designs.Find(id);
                db.Designs.Remove(design);
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

        private void PopulateDesignersDropDown(object selectedDesigner = null)
        {
            var designers = from d in db.Staffs where d.Designer.Active orderby d.FirstName select d;

            ViewBag.Designers = new SelectList(designers, "ID", "FullName", selectedDesigner);
        }
    }
}
