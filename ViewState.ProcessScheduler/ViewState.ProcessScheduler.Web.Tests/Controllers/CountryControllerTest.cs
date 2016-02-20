using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Services;
using ViewState.ProcessScheduler.ViewModels;
using ViewState.ProcessScheduler.Web.Controllers;
using ViewState.ProcessScheduler.Web.Mappings;

namespace ViewState.ProcessScheduler.Web.Tests.Controllers
{
    [TestClass]
    public class CountryControllerTest
    {
        private IMapper _mapper;

        [TestInitialize]
        public void InitialiseMembers()
        {
            _mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            }).CreateMapper();
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void Index_Should_Return_ViewResult_With_Model_Count_2()
        {
            var countryService = Mock.Create<ICountryService>();
            
            Mock.Arrange(() => countryService.GetAll()).Returns(new List<Country>
            {
                new Country() {Name = "United Kingdom",Active = true,Code = "UK",DateCreated = DateTime.Now,ID = Guid.NewGuid()},
                new Country() { Name = "United States of America", Code = "USA",DateCreated = DateTime.Now, Active = true, ID = Guid.NewGuid()}
            });

            CountryController controller = new CountryController(countryService, _mapper);
            ViewResult result = controller.Index();
            var countries = result.Model as IEnumerable<CountryViewModel>;

            Assert.AreEqual(2, countries?.Count());
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void Create_Returns_A_View()
        {
            var countryService = Mock.Create<ICountryService>();

            CountryController controller = new CountryController(countryService, _mapper);

            ViewResult result = controller.Create();

            Assert.IsNotNull(result);
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void CreatePost_Calls_CreateEntity_And_SaveEntity_On_Service()
        {
            var countryService = Mock.Create<ICountryService>();

            CountryController controller = new CountryController(countryService, _mapper);

            controller.CreatePost(new CountryViewModel());

            Mock.Assert(()=>countryService.CreateEntity(Arg.IsAny<Country>()), Occurs.AtLeastOnce());
            Mock.Assert(() => countryService.SaveEntity(), Occurs.AtLeastOnce());
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void Edit_Returns_A_View()
        {
            var countryService = Mock.Create<ICountryService>();

            CountryController controller = new CountryController(countryService, _mapper);

            ViewResult result = controller.Edit(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void EditPost_Calls_Update_And_Save_On_Service()
        {
            var countryService = Mock.Create<ICountryService>();

            CountryController controller = new CountryController(countryService, _mapper);

            controller.EditPost(new CountryViewModel());

            Mock.Assert(()=>countryService.UpdateEntity(Arg.IsAny<Country>()), Occurs.AtLeastOnce());
        }
    }
}
