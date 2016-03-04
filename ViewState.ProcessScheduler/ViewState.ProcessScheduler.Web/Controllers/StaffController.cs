using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Services;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly IService<Staff, StaffWithDesignerViewModel> _staffService;
        private readonly IService<Designer, StaffWithDesignerViewModel> _designerService;

        public StaffController(IService<Staff, StaffWithDesignerViewModel> staffService, IService<Designer, StaffWithDesignerViewModel> designerService )
        {
            _staffService = staffService;
            _designerService = designerService;
        }

        public ActionResult Index(String sortOrder, String searchString, String currentFilter, Int32? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            IEnumerable<StaffWithDesignerViewModel> staffsViewModels = _staffService.GetAll().ToList();

            if (!String.IsNullOrEmpty(searchString))
                staffsViewModels = staffsViewModels.Where(i => i.FirstName.Contains(searchString) || i.LastName.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    staffsViewModels = staffsViewModels.OrderByDescending(i => i.LastName);
                    break;
                default:
                    staffsViewModels = staffsViewModels.OrderBy(i => i.LastName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ModelState.Remove("searchString");

            return View(staffsViewModels.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffWithDesignerViewModel staffViewModel)
        {
            try
            {
                staffViewModel.Active = true;
                staffViewModel.ID = Guid.NewGuid();
                staffViewModel.DateCreated = DateTime.Now;

                _staffService.Create(staffViewModel);

                if (staffViewModel.IsDesigner)
                {
                    _designerService.Create(staffViewModel);
                }

                _staffService.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                return View();
            }
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StaffWithDesignerViewModel staffViewModel = _staffService.GetById(id);

            if (staffViewModel == null)
                return HttpNotFound();

            return View(staffViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffWithDesignerViewModel staffViewModel)
        {
            try
            {
                _staffService.Update(staffViewModel);
                _staffService.Save();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StaffWithDesignerViewModel staffViewModel = _staffService.GetById(id);

            if (staffViewModel == null)
                return HttpNotFound();

            return View(staffViewModel);
        }

        public ActionResult Deactivate(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);

            StaffWithDesignerViewModel staffViewModel = _staffService.GetById(id);

            if (staffViewModel == null)
                return HttpNotFound();

            return View(staffViewModel);
        }

        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public ActionResult DeactivatePost(Guid id)
        {
            try
            {
                StaffWithDesignerViewModel staffViewModel = _staffService.GetById(id);

                staffViewModel.Active = false;

                _staffService.Update(staffViewModel);
                _staffService.Save();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}