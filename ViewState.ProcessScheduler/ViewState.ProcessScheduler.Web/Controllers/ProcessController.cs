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
    public class ProcessController : Controller
    {
        private readonly IService<Process, ProcessViewModel> _processService;

        public ProcessController(IService<Process, ProcessViewModel> processService)
        {
            _processService = processService;
        }

        // GET: Process
        public ViewResult Index(String sortOrder, String searchString, String currentFilter, Int32? page)
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

            IEnumerable<ProcessViewModel> processViewModels = _processService.GetAll().ToList();

            if (!String.IsNullOrEmpty(searchString))
                processViewModels = processViewModels.Where(i => i.Name.Contains(searchString));
            
            switch (sortOrder)
            {
                case "name_desc":
                    processViewModels = processViewModels.OrderByDescending(i => i.Name);
                    break;
                default:
                    processViewModels = processViewModels.OrderBy(i => i.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ModelState.Remove("SearchString");

            return View(processViewModels.ToPagedList(pageNumber, pageSize));
        }

        // GET: Process/Details/5
        public ActionResult Details(Guid? id)
        {
            if(id == null)
                return  new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProcessViewModel processViewModel = _processService.GetById(id);

            if (processViewModel == null)
                return HttpNotFound();
            
            return View(processViewModel);
        }

        // GET: Process/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Process/Create
        [HttpPost]
        public ActionResult Create(ProcessViewModel processViewModel)
        {
            try
            {
                processViewModel.Active = true;
                processViewModel.DateCreated = DateTime.Now;
                processViewModel.ID = Guid.NewGuid();

                _processService.Create(processViewModel);
                _processService.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Process/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if(id == null)
                return  new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProcessViewModel processViewModel = _processService.GetById(id);

            if (processViewModel == null)
                return HttpNotFound();
            
            return View(processViewModel);
        }

        // POST: Process/Edit/5
        [HttpPost]
        public ActionResult Edit(ProcessViewModel processViewModel)
        {
            try
            {
                _processService.Update(processViewModel);
                _processService.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Deactivate(Guid? id)
        {
            if(id == null)
                return  new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProcessViewModel processViewModel = _processService.GetById(id);

            if (processViewModel == null)
                return HttpNotFound();
            
            return View(processViewModel);
        }

        [HttpPost,ActionName("Deactivate")]
        public ActionResult DeactivatePost(Guid id)
        {
            try
            {
                ProcessViewModel processViewModel = _processService.GetById(id);

                processViewModel.Active = false;

                _processService.Update(processViewModel);
                _processService.Save();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
