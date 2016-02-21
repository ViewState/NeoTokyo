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
        private ICountryService _countryService;
        private CountryController _controller;

        [TestInitialize]
        public void InitialiseMembers()
        {
            _mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            }).CreateMapper();

            _countryService = Mock.Create<ICountryService>();

            _controller = new CountryController(_countryService, _mapper);
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void Index_Should_Return_ViewResult_With_Model_Count_2()
        {
            Mock.Arrange(() => _countryService.GetAll()).Returns(new List<Country>
            {
                new Country() {Name = "United Kingdom",Active = true,Code = "UK",DateCreated = DateTime.Now,ID = Guid.NewGuid()},
                new Country() { Name = "United States of America", Code = "USA",DateCreated = DateTime.Now, Active = true, ID = Guid.NewGuid()}
            });
            
            ViewResult result = _controller.Index();
            var countries = result.Model as IEnumerable<CountryViewModel>;

            Assert.AreEqual(2, countries?.Count());
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void Create_Returns_A_View()
        {
            ViewResult result = _controller.Create();

            Assert.IsNotNull(result);
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void CreatePost_Calls_CreateEntity_And_SaveEntity_On_Service()
        {
            _controller.CreatePost(new CountryViewModel());

            Mock.Assert(()=>_countryService.CreateEntity(Arg.IsAny<Country>()), Occurs.AtLeastOnce());
            Mock.Assert(() => _countryService.SaveEntity(), Occurs.AtLeastOnce());
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void Edit_Returns_A_View()
        {
            ViewResult result = _controller.Edit(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void EditPost_Calls_Update_And_Save_On_Service()
        {
            _controller.EditPost(new CountryViewModel());

            Mock.Assert(()=>_countryService.UpdateEntity(Arg.IsAny<Country>()), Occurs.AtLeastOnce());
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void Details_Returns_A_View()
        {
            ViewResult result = _controller.Details(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void Deactivate_Returns_A_View()
        {
            ViewResult result = _controller.Deactivate(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void DeactivatePost_Calls_UpdateEntity_On_Service()
        {
            _controller.DeactivePost(Guid.NewGuid());

            Mock.Assert(()=>_countryService.UpdateEntity(Arg.IsAny<Country>()), Occurs.AtLeastOnce());
        }
    }
}
