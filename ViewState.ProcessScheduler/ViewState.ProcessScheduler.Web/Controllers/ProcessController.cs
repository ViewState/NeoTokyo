using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Services;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Web.Controllers
{
    public class ProcessController : Controller
    {
        private readonly IService<Process> _processService;
        private readonly IMapper _mapper;

        public ProcessController(IService<Process> processService, IMapper mapper)
        {
            _processService = processService;
            _mapper = mapper;
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

            var processes = _processService.GetAll().ToList();
            IEnumerable<ProcessViewModel> processViewModels = _mapper.Map<IEnumerable<Process>, IEnumerable<ProcessViewModel>>(processes);

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

            Process process = _processService.GetById(id);

            if (process == null)
                return HttpNotFound();

            ProcessViewModel processViewModel = _mapper.Map<ProcessViewModel>(process);

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
                Process process = new Process
                {
                    Name = processViewModel.Name,
                    ID = Guid.NewGuid(),
                    DateCreated = DateTime.Now,
                    Active = true,
                    IsOverNightProcess = processViewModel.IsOverNightProcess,
                    CompletedStatusText = processViewModel.CompletedStatusText
                };

                _processService.Create(process);
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

            var process = _processService.GetById(id);

            if (process == null)
                return HttpNotFound();

            var processViewModel = _mapper.Map<ProcessViewModel>(process);

            return View(processViewModel);
        }

        // POST: Process/Edit/5
        [HttpPost]
        public ActionResult Edit(ProcessViewModel processViewModel)
        {
            try
            {
                Process process = _mapper.Map<Process>(processViewModel);

                _processService.Update(process);
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

            Process process = _processService.GetById(id);

            if (process == null)
                return HttpNotFound();

            ProcessViewModel processViewModel = _mapper.Map<ProcessViewModel>(process);

            return View(processViewModel);
        }

        [HttpPost,ActionName("Deactivate")]
        public ActionResult DeactivatePost(Guid id)
        {
            try
            {
                Process process = _processService.GetById(id);

                process.Active = false;

                _processService.Update(process);
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
