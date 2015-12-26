using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NeoTokyo.ProductionBook.DAL;
using NeoTokyo.ProductionBook.Models;
using NeoTokyo.ProductionBook.ViewModel;

namespace NeoTokyo.ProductionBook.Controllers
{
    public class StaffController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: Staff
        public ActionResult Index()
        {
            var staffs = db.Staffs.Include(s => s.StaffResourceGroupLink);
            return View(staffs.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Include(i => i.StaffResourceGroupLink).Include(a => a.StaffResourceGroupLink.ResourceGroup).Where(s => s.ID == id).Single();

            StaffResourceGroupViewModel staffResourceGroup = new StaffResourceGroupViewModel
            {
                ID = staff.ID,
                Active = staff.Active,
                FirstName = staff.FirstName,
                MiddleName = staff.MiddleName,
                LastName = staff.LastName,
                ResourceGroupID = staff.StaffResourceGroupLink.ResourceGroupID,
                ResourceGroupName = staff.StaffResourceGroupLink.ResourceGroup.Name,
            };

            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staffResourceGroup);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.StaffResourceGroupLinks, "StaffID", "StaffID");
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,Active")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                staff.ID = Guid.NewGuid();
                db.Staffs.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.StaffResourceGroupLinks, "StaffID", "StaffID", staff.ID);
            return View(staff);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.StaffResourceGroupLinks, "StaffID", "StaffID", staff.ID);
            return View(staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,Active")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.StaffResourceGroupLinks, "StaffID", "StaffID", staff.ID);
            return View(staff);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Staff staff = db.Staffs.Find(id);
            db.Staffs.Remove(staff);
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
