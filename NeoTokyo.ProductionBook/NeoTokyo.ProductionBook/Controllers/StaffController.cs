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
    public class StaffController : Controller
    {
        private ProductionBookContext db = new ProductionBookContext();

        // GET: Staff
        public ActionResult Index(String sortOrder, String searchNameString, String searchResourceGroupString, String currentNameFilter, String currentResourceGroupFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ResourceGroupNameSortParm = sortOrder == "Group" ? "group_desc" : "Group";

            if (searchNameString != null)
            {
                page = 1;
            }
            else
            {
                searchNameString = currentNameFilter;
            }

            ViewBag.CurrentNameFilter = searchNameString;

            if (searchResourceGroupString != null)
            {
                page = 1;
            }
            else
            {
                searchResourceGroupString = currentResourceGroupFilter;
            }

            ViewBag.CurrentResourceGroupFilter = searchResourceGroupString;

            var staffs = db.Staffs.Include(s => s.StaffResourceGroupLink);

            if (!String.IsNullOrEmpty(searchNameString))
                staffs = staffs.Where(s => s.FirstName.Contains(searchNameString) || s.LastName.Contains(searchNameString));

            if (!String.IsNullOrEmpty(searchResourceGroupString))
                staffs = staffs.Where(r => r.StaffResourceGroupLink.ResourceGroup.Name.Contains(searchResourceGroupString));

            switch (sortOrder)
            {
                case "name_desc":
                    staffs = staffs.OrderBy(n => n.LastName);
                    break;
                case "Group":
                    staffs = staffs.OrderBy(g => g.StaffResourceGroupLink.ResourceGroup.Name);
                    break;
                case "group_desc":
                    staffs = staffs.OrderByDescending(g => g.StaffResourceGroupLink.ResourceGroup.Name);
                    break;
                default:
                    staffs = staffs.OrderByDescending(n => n.LastName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ModelState.Remove("searchNameString");
            ModelState.Remove("searchResourceGroupString");

            return View(staffs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Staff/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Staff staff = db.Staffs.Find(id);
            StaffResourceGroupViewModel staffResourceGroup = new StaffResourceGroupViewModel
            {
                ID = staff.ID,
                Active = staff.Active,
                FirstName = staff.FirstName,
                MiddleName = staff.MiddleName,
                LastName = staff.LastName,
                ResourceGroupID = staff.StaffResourceGroupLink?.ResourceGroupID,
                ResourceGroupName = staff.StaffResourceGroupLink != null ? staff.StaffResourceGroupLink.ResourceGroup.Name : String.Empty,
                IsDesigner = staff.Designer != null ? staff.Designer.Active : false,
            };
            
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
        public ActionResult Create([Bind(Include = "FirstName,MiddleName,LastName,Active, ResourceGroupID, IsDesigner")] StaffResourceGroupViewModel staffResourceGroupViewModel)
        {
            try
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

                    if (staffResourceGroupViewModel.ResourceGroupID.HasValue)
                    {
                        StaffResourceGroupLink link = new StaffResourceGroupLink
                        {
                            ResourceGroupID = staffResourceGroupViewModel.ResourceGroupID.Value,
                            StaffID = staff.ID,
                        };
                        db.StaffResourceGroupLinks.Add(link);
                    }

                    if (staffResourceGroupViewModel.IsDesigner)
                    {
                        Designer designer = new Designer
                        {
                            ID = staff.ID,
                            Active = true,
                        };
                        db.Designers.Add(designer);
                    }
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                ViewBag.ID = new SelectList(db.StaffResourceGroupLinks, "StaffID", "StaffID", staffResourceGroupViewModel.ID);
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
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
                ResourceGroupID = staff.StaffResourceGroupLink?.ResourceGroupID,
                ResourceGroupName = staff.StaffResourceGroupLink != null ? staff.StaffResourceGroupLink.ResourceGroup.Name : String.Empty,
                IsDesigner = staff.Designer != null ? staff.Designer.Active : false,
            };
            
            if (staff.StaffResourceGroupLink != null)
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
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,Active, ResourceGroupID, IsDesigner")] StaffResourceGroupViewModel staffResourceGroup)
        {
            try
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

                    if (link != null)
                    {
                        db.StaffResourceGroupLinks.Remove(link);
                    }

                    if (staffResourceGroup.ResourceGroupID.HasValue)
                    {
                        StaffResourceGroupLink newLink = new StaffResourceGroupLink
                        {
                            ResourceGroupID = staffResourceGroup.ResourceGroupID.Value,
                            StaffID = staffResourceGroup.ID,
                        };
                        db.StaffResourceGroupLinks.Add(newLink);
                    }

                    Designer designer = db.Designers.Find(staffResourceGroup.ID);

                    if (designer != null)
                    {
                        designer.Active = staffResourceGroup.IsDesigner;

                        db.Entry(designer).State = EntityState.Modified;
                    }

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
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
        public ActionResult Delete(Guid? id, Boolean? saveChangesError = false)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";

            Staff staff = db.Staffs.Find(id);

            if (staff == null)
                return HttpNotFound();

            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            try
            {
                Staff staff = db.Staffs.Find(id);

                db.Staffs.Remove(staff);
                StaffResourceGroupLink link = db.StaffResourceGroupLinks.Find(id);

                if (link != null)
                    db.StaffResourceGroupLinks.Remove(link);

                db.SaveChanges();
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                RedirectToAction("Delete", new {id, saveChangesError = true });
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

        private void PopulateResourceGroupDropDown(object selectedResourceGroup = null)
        {
            var resourceGroups = from r in db.ResourceGroups orderby r.Name select r;

            ViewBag.ResourceGroups = new SelectList(resourceGroups, "ID", "Name", selectedResourceGroup);
        }
    }
}
