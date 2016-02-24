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
    public class DepartmentControllerTest
    {
        private IService<Department> _service;
        private IMapper _mapper;
        private DepartmentController _controller;

        [TestInitialize]
        public void InitialiseTests()
        {
            _service = Mock.Create<IService<Department>>();
            _mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            }).CreateMapper();
            _controller = new DepartmentController(_service, _mapper);
        }
        [TestCategory("DepartmentController")]
        [TestMethod]
        public void Index_Should_Return_A_View_With_First_Name_In_Model_Alstom_Line()
        {
            Department alstom = new Department
            {
                Name = "Alstom Line",
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
            };

            Department smallWinding = new Department
            {
                Name = "Small Winding",
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
            };

            Department largeWinding = new Department
            {
                Name = "Large Winding",
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
            };

            Department plating = new Department
            {
                Name = "Plating",
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
            };

            Department finishing = new Department
            {
                Name = "Finishing",
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
            };

            Mock.Arrange(() => _service.GetAll()).Returns(new List<Department>
            {
                alstom,
                smallWinding,
                largeWinding,
                plating,
                finishing
            });

            String sortOrder = null;
            String searchString = null;
            String currentFilter = null;
            int? page = null;

            ViewResult result = _controller.Index(sortOrder, searchString, currentFilter, page) as ViewResult;

            IEnumerable<DepartmentViewModel> departments = result?.Model as IEnumerable<DepartmentViewModel>;
            
            Assert.AreEqual(alstom.Name, departments?.FirstOrDefault()?.Name);
        }
    }
}
