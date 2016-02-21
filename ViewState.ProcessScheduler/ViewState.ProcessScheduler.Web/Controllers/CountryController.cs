using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Services;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }
        
        public ViewResult Index()
        {
            IEnumerable<Country> countries = _countryService.GetAll().ToList();
            IEnumerable<CountryViewModel> countriesViewModel = _mapper.Map<IEnumerable<CountryViewModel>>(countries);

            return View(countriesViewModel);
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
                var country = _mapper.Map<CountryViewModel, Country>(countryViewModel);
                country.ID = Guid.NewGuid();
                country.DateCreated = DateTime.Now;

                _countryService.CreateEntity(country);
                _countryService.SaveEntity();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occured while trying to save country to the database";
                return View();
            }
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var country = _countryService.GetById(id);

            if (country == null)
                return HttpNotFound();

            var countryViewModel = _mapper.Map<Country, CountryViewModel>(country);

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
                    var country = _mapper.Map<CountryViewModel, Country>(countryViewModel);

                    _countryService.UpdateEntity(country);
                    _countryService.SaveEntity();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
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

            var country = _countryService.GetById(id);

            if (country == null)
                return HttpNotFound();

            var countryViewModel = _mapper.Map<Country, CountryViewModel>(country);

            return View(countryViewModel);
        }

        public ActionResult Deactivate(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var country = _countryService.GetById(id);

            if (country == null)
                return HttpNotFound();

            var countryViewModel = _mapper.Map<Country, CountryViewModel>(country);

            return View(countryViewModel);
        }
        [HttpPost,ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public ActionResult DeactivePost(Guid id)
        {
            Country country = _countryService.GetById(id);
            country.Active = false;
            _countryService.UpdateEntity(country);

            return RedirectToAction("Index");
        }
    }
}