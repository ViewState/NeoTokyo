using System.Web.Mvc;
using AutoMapper;
using ViewState.ProcessScheduler.Services;

namespace ViewState.ProcessScheduler.Web.Controllers
{
    public class ProcessController : Controller
    {
        private readonly IProcessService _processService;
        private readonly IMapper _mapper;

        public ProcessController(IProcessService processService, IMapper mapper)
        {
            _processService = processService;
            _mapper = mapper;
        }

        // GET: Process
        public ActionResult Index()
        {
            return View();
        }

        // GET: Process/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Process/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Process/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Process/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Process/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Process/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Process/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
