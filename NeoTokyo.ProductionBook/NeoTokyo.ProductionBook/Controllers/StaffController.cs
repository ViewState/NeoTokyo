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
            //Staff staff = db.Staffs.Include(i => i.StaffResourceGroupLink).Include(a => a.StaffResourceGroupLink.ResourceGroup).Where(s => s.ID == id).Single();
            Staff staff = db.Staffs.Find(id);
            StaffResourceGroupViewModel staffResourceGroup = new StaffResourceGroupViewModel
            {
                ID = staff.ID,
                Active = staff.Active,
                FirstName = staff.FirstName,
                MiddleName = staff.MiddleName,
                LastName = staff.LastName,
                ResourceGroupID = staff.StaffResourceGroupLink != null ? staff.StaffResourceGroupLink.ResourceGroupID : (Guid?)null,
                ResourceGroupName = staff.StaffResourceGroupLink != null ? staff.StaffResourceGroupLink.ResourceGroup.Name : String.Empty,
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
            PopulateResourceGroupDropDown();
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,MiddleName,LastName,Active, ResourceGroupID")] StaffResourceGroupViewModel staffResourceGroupViewModel)
        {
            if (ModelState.IsValid)
            {
                Staff staff = new Staff
                {
                    Active = staffResourceGroupViewModel.Active,
                    FirstName = staffResourceGroupViewModel.FirstName,
                    MiddleName = staffResourceGroupViewModel.MiddleName,
                    LastName = staffResourceGroupViewModel.LastName,
                };

                db.Staffs.Add(staff);

                if(staffResourceGroupViewModel.ResourceGroupID.HasValue)
                {
                    StaffResourceGroupLink link = new StaffResourceGroupLink
                    {
                        ResourceGroupID = staffResourceGroupViewModel.ResourceGroupID.Value,
                        StaffID = staff.ID,
                    };
                    db.StaffResourceGroupLinks.Add(link);
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.StaffResourceGroupLinks, "StaffID", "StaffID", staffResourceGroupViewModel.ID);
            return View(staffResourceGroupViewModel);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Staff staff = db.Staffs.Find(id);

            StaffResourceGroupViewModel staffResourceGroup = new StaffResourceGroupViewModel
            {
                Active = staff.Active,
                ID = staff.ID,
                FirstName = staff.FirstName,
                MiddleName = staff.MiddleName,
                LastName = staff.LastName,
                ResourceGroupID = staff.StaffResourceGroupLink != null ? staff.StaffResourceGroupLink.ResourceGroupID : (Guid?)null,
                ResourceGroupName = staff.StaffResourceGroupLink != null ? staff.StaffResourceGroupLink.ResourceGroup.Name : String.Empty,
            };

            if (staff == null)
            {
                return HttpNotFound();
            }

            if(staff.StaffResourceGroupLink != null)
            {
                PopulateResourceGroupDropDown(staff.StaffResourceGroupLink.ResourceGroupID);
            }
            else
            {
                PopulateResourceGroupDropDown();
            }
            return View(staffResourceGroup);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,Active, ResourceGroupID")] StaffResourceGroupViewModel staffResourceGroup)
        {
            if (ModelState.IsValid)
            {
                Staff staff = new Staff
                {
                    ID = staffResourceGroup.ID,
                    Active = staffResourceGroup.Active,
                    FirstName = staffResourceGroup.FirstName,
                    MiddleName = staffResourceGroup.MiddleName,
                    LastName = staffResourceGroup.LastName,
                };
                db.Entry(staff).State = EntityState.Modified;

                StaffResourceGroupLink link = db.StaffResourceGroupLinks.Find(staffResourceGroup.ID);

                if(link != null)
                {
                    db.StaffResourceGroupLinks.Remove(link);
                }

                if(staffResourceGroup.ResourceGroupID.HasValue)
                {
                    StaffResourceGroupLink newLink = new StaffResourceGroupLink
                    {
                        ResourceGroupID = staffResourceGroup.ResourceGroupID.Value,
                        StaffID = staffResourceGroup.ID,
                    };
                    db.StaffResourceGroupLinks.Add(newLink);
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            if (staffResourceGroup.ResourceGroupID.HasValue)
            {
                PopulateResourceGroupDropDown(staffResourceGroup.ResourceGroupID.Value);
            }
            else
            {
                PopulateResourceGroupDropDown();
            }

            return View(staffResourceGroup);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Staff staff = db.Staffs.Find(id);

            if (staff == null)
                return HttpNotFound();

            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Staff staff = db.Staffs.Find(id);

            db.Staffs.Remove(staff);
            StaffResourceGroupLink link = db.StaffResourceGroupLinks.Find(id);

            if (link != null)
                db.StaffResourceGroupLinks.Remove(link);

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

        private void PopulateResourceGroupDropDown(object selectedResourceGroup = null)
        {
            var resourceGroups = from r in db.ResourceGroups orderby r.Name select r;

            ViewBag.ResourceGroups = new SelectList(resourceGroups, "ID", "Name", selectedResourceGroup);
        }
    }
}
