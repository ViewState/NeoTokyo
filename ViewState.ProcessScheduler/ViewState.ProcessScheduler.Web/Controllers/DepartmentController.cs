﻿using System;
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
    public class DepartmentController : Controller
    {
        private readonly IService<Department, DepartmentViewModel> _service;

        public DepartmentController(IService<Department, DepartmentViewModel> service)
        {
            _service = service;
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

            IEnumerable<DepartmentViewModel> departmentsViewModels = _service.GetAll().ToList();

            if (!String.IsNullOrEmpty(searchString))
                departmentsViewModels = departmentsViewModels.Where(i => i.Name.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    departmentsViewModels = departmentsViewModels.OrderByDescending(i => i.Name);
                    break;
                default:
                    departmentsViewModels = departmentsViewModels.OrderBy(i => i.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ModelState.Remove("searchString");

            return View(departmentsViewModels.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel departmentViewModel)
        {
            try
            {
                departmentViewModel.Active = true;
                departmentViewModel.ID = Guid.NewGuid();
                departmentViewModel.DateCreated = DateTime.Now;

                _service.Create(departmentViewModel);
                _service.Save();

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
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            DepartmentViewModel departmentViewModel = _service.GetById(id);

            if (departmentViewModel == null)
                return HttpNotFound();

            return View(departmentViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentViewModel departmentViewModel)
        {
            try
            {
                _service.Update(departmentViewModel);
                _service.Save();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Details(Guid? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            DepartmentViewModel departmentViewModel = _service.GetById(id);

            if (departmentViewModel == null)
                return HttpNotFound();

            return View(departmentViewModel);
        }

        public ActionResult Deactivate(Guid? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);

            DepartmentViewModel departmentViewModel = _service.GetById(id);

            if (departmentViewModel == null)
                return HttpNotFound();

            return View(departmentViewModel);
        }

        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public ActionResult DeactivatePost(Guid id)
        {
            try
            {
                DepartmentViewModel departmentViewModel = _service.GetById(id);

                departmentViewModel.Active = false;

                _service.Update(departmentViewModel);
                _service.Save();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}