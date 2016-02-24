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
        private IService<Department, DepartmentViewModel> _service;
        private DepartmentController _controller;

        [TestInitialize]
        public void InitialiseTests()
        {
            _service = Mock.Create<IService<Department, DepartmentViewModel>>();
            _controller = new DepartmentController(_service);
        }
        [TestCategory("DepartmentController")]
        [TestMethod]
        public void Index_Should_Return_A_View_With_First_Name_In_Model_Alstom_Line()
        {
            DepartmentViewModel alstom = new DepartmentViewModel
            {
                Name = "Alstom Line",
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
            };

            DepartmentViewModel smallWinding = new DepartmentViewModel
            {
                Name = "Small Winding",
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
            };

            DepartmentViewModel largeWinding = new DepartmentViewModel
            {
                Name = "Large Winding",
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
            };

            DepartmentViewModel plating = new DepartmentViewModel
            {
                Name = "Plating",
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
            };

            DepartmentViewModel finishing = new DepartmentViewModel
            {
                Name = "Finishing",
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
            };

            Mock.Arrange(() => _service.GetAll()).Returns(new List<DepartmentViewModel>
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
