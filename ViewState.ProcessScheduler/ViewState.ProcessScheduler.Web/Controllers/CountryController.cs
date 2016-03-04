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
    public class CountryController : Controller
    {
        private readonly IService<Country, CountryViewModel> _countryService;

        public CountryController(IService<Country, CountryViewModel> countryService)
        {
            _countryService = countryService;
        }
        
        public ViewResult Index(String sortOrder, String searchString, String currentFilter, int? page)
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

            IEnumerable<CountryViewModel> countriesViewModel = _countryService.GetAll().ToList();

            if (!String.IsNullOrEmpty(searchString))
                countriesViewModel = countriesViewModel.Where(i => i.Name.Contains(searchString));

                switch (sortOrder)
            {
                case "name_desc":
                    countriesViewModel = countriesViewModel.OrderByDescending(i => i.Name);
                    break;
                default:
                    countriesViewModel = countriesViewModel.OrderBy(i => i.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ModelState.Remove("searchString");

            return View(countriesViewModel.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult Create()
        {
            return View();
        }
        
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(CountryViewModel countryViewModel)
        {
            try
            {
                countryViewModel.ID = Guid.NewGuid();
                countryViewModel.DateCreated = DateTime.Now;

                _countryService.Create(countryViewModel);
                _countryService.Save();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "An error occured while trying to save country to the database";
                return View();
            }
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            CountryViewModel countryViewModel = _countryService.GetById(id);

            if (countryViewModel == null)
                return HttpNotFound();
            
            return View(countryViewModel);
        }
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(CountryViewModel countryViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _countryService.Update(countryViewModel);
                    _countryService.Save();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewBag.ErrorMessage = "An error occured while trying to update this entity";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Details(Guid? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            CountryViewModel countryViewModel = _countryService.GetById(id);

            if (countryViewModel == null)
                return HttpNotFound();
            
            return View(countryViewModel);
        }

        public ActionResult Deactivate(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            CountryViewModel countryViewModel = _countryService.GetById(id);

            if (countryViewModel == null)
                return HttpNotFound();
            
            return View(countryViewModel);
        }
        [HttpPost,ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public ActionResult DeactivePost(Guid id)
        {
            CountryViewModel countryViewModel = _countryService.GetById(id);
            countryViewModel.Active = false;
            _countryService.Update(countryViewModel);
            _countryService.Save();

            return RedirectToAction("Index");
        }
    }
}