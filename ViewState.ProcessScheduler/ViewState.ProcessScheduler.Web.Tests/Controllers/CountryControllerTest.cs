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
        private IService<Country> _countryService;
        private CountryController _controller;

        [TestInitialize]
        public void InitialiseMembers()
        {
            _mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            }).CreateMapper();

            _countryService = Mock.Create<IService<Country>>();

            _controller = new CountryController(_countryService, _mapper);
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void Index_Should_Return_ViewResult_With_Model_Count_3_And_First_Name_In_Model_United_Kingdom()
        {
            Country unitedKingdom = new Country()
            {
                Name = "United Kingdom",
                Active = true,
                Code = "UK",
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid()
            };

            Country america = new Country()
            {
                Name = "United States of America",
                Code = "USA",
                DateCreated = DateTime.Now,
                Active = true,
                ID = Guid.NewGuid()
            };

            Country france = new Country()
            {
                Name = "France",
                Code = "FR",
                DateCreated = DateTime.Now,
                Active = true,
                ID = Guid.NewGuid()
            };

            Country germany = new Country()
            {
                Name = "Deuschland",
                Code = "DE",
                DateCreated = DateTime.Now,
                Active = true,
                ID = Guid.NewGuid()
            };

            Mock.Arrange(() => _countryService.GetAll()).Returns(new List<Country>
            {
                unitedKingdom,
                america,
                france,
                germany
            });

            String searchString = null;

            ViewResult result = _controller.Index(null, searchString, null, null);
            var countries = result.Model as IEnumerable<CountryViewModel>;

            Assert.AreEqual(3, countries?.Count());
            Assert.AreEqual(germany.Name, countries?.FirstOrDefault()?.Name);
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void Index_Should_Return_ViewResult_With_First_Name_In_Model_United_States_of_America()
        {
            Country unitedKingdom = new Country()
            {
                Name = "United Kingdom",
                Active = true,
                Code = "UK",
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid()
            };

            Country america = new Country()
            {
                Name = "United States of America",
                Code = "USA",
                DateCreated = DateTime.Now,
                Active = true,
                ID = Guid.NewGuid()
            };

            Mock.Arrange(() => _countryService.GetAll()).Returns(new List<Country>
            {
                unitedKingdom,
                america
            });

            String sortOrder = "name_desc";
            String searchString = null;

            ViewResult result = _controller.Index(sortOrder, searchString, null,null);
            var countries = result.Model as IEnumerable<CountryViewModel>;

            Assert.AreEqual(2, countries?.Count());
            Assert.AreEqual(america.Name, countries?.FirstOrDefault()?.Name);
        }

        [TestCategory("CountryController")]
        [TestMethod]
        public void Index_Should_Return_ViewResult_With_Model_Count_2()
        {
            Country unitedKingdom = new Country()
            {
                Name = "United Kingdom",
                Active = true,
                Code = "UK",
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid()
            };

            Country america = new Country()
            {
                Name = "United States of America",
                Code = "USA",
                DateCreated = DateTime.Now,
                Active = true,
                ID = Guid.NewGuid()
            };

            Country france = new Country()
            {
                Name = "France",
                Code = "FR",
                DateCreated = DateTime.Now,
                Active = true,
                ID = Guid.NewGuid()
            };

            Country germany = new Country()
            {
                Name = "Deuschland",
                Code = "DE",
                DateCreated = DateTime.Now,
                Active = true,
                ID = Guid.NewGuid()
            };

            Mock.Arrange(() => _countryService.GetAll()).Returns(new List<Country>
            {
                unitedKingdom,
                america,
                france,
                germany
            });

            String searchString = "United";

            ViewResult result = _controller.Index(null, searchString, null, null);
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

            Mock.Assert(()=>_countryService.Create(Arg.IsAny<Country>()), Occurs.AtLeastOnce());
            Mock.Assert(() => _countryService.Save(), Occurs.AtLeastOnce());
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

            Mock.Assert(()=>_countryService.Update(Arg.IsAny<Country>()), Occurs.AtLeastOnce());
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

            Mock.Assert(()=>_countryService.Update(Arg.IsAny<Country>()), Occurs.AtLeastOnce());
        }
    }
}
