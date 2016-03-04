using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Services;
using ViewState.ProcessScheduler.ViewModels;
using ViewState.ProcessScheduler.Web.Controllers;

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

        [TestCategory("DepartmentController")]
        [TestMethod]
        public void Create_Returns_A_View()
        {
            ViewResult result = _controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("DepartmentController")]
        [TestMethod]
        public void Create_Post_Calls_Create_And_Save_On_Service()
        {
            ViewResult result = _controller.Create(new DepartmentViewModel() {Name = "Test"}) as ViewResult;

            Mock.Assert(()=>_service.Create(Arg.IsAny<DepartmentViewModel>()), Occurs.AtLeastOnce());
            Mock.Assert(()=>_service.Save(), Occurs.AtLeastOnce());
        }

        [TestCategory("DepartmentController")]
        [TestMethod]
        public void Edit_Returns_A_View()
        {
            ViewResult result = _controller.Edit(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("DepartmentController")]
        [TestMethod]
        public void Edit_Calls_Update_And_Save_On_Service()
        {
            ViewResult result = _controller.Edit(new DepartmentViewModel()) as ViewResult;

            Mock.Assert(()=>_service.Update(Arg.IsAny<DepartmentViewModel>()), Occurs.AtLeastOnce());
            Mock.Assert(()=>_service.Save(), Occurs.AtLeastOnce());
        }

        [TestCategory("DepartmentController")]
        [TestMethod]
        public void Details_Returns_A_View()
        {
            ViewResult result = _controller.Details(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("DepartmentController")]
        [TestMethod]
        public void Deactivate_Returns_A_View()
        {
            ViewResult result = _controller.Deactivate(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("DepartmentController")]
        [TestMethod]
        public void DeactivatePost_Calls_Update_And_Save_On_Service()
        {
            _controller.DeactivatePost(Guid.NewGuid());

            Mock.Assert(()=>_service.Update(Arg.IsAny<DepartmentViewModel>()), Occurs.AtLeastOnce());
            Mock.Assert(()=>_service.Save(), Occurs.AtLeastOnce());
        }
    }
}
