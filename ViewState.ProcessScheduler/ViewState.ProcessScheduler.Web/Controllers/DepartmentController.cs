using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Services;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IService<Department> _service;
        private readonly IMapper _mapper;

        public DepartmentController(IService<Department> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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

            IEnumerable<Department> departments = _service.GetAll().ToList();
            IEnumerable<DepartmentViewModel> departmentsViewModels = _mapper.Map<IEnumerable<DepartmentViewModel>> (departments);

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
    }
}