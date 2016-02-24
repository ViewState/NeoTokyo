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
    public class ProcessControllerTest
    {
        private IService<Process, ProcessViewModel> _processService;
        private ProcessController _controller;

        [TestInitialize]
        public void InitialiseTests()
        {
            _processService = Mock.Create<IService<Process, ProcessViewModel>>();
            _controller = new ProcessController(_processService);
        }

        [TestCategory("ProcessController")]
        [TestMethod]
        public void Index_Should_Return_A_View_With_First_Name_In_Model_Finish()
        {
            ProcessViewModel preparation = new ProcessViewModel
            {
                Name = "Preparation",
                CompletedStatusText = "Prepared",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            ProcessViewModel winding = new ProcessViewModel
            {
                Name = "Winding",
                CompletedStatusText = "Wound",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            ProcessViewModel plating = new ProcessViewModel
            {
                Name = "Plating",
                CompletedStatusText = "Plated",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            ProcessViewModel varnish = new ProcessViewModel
            {
                Name = "Varnish",
                CompletedStatusText = "Varnished",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = true
            };

            ProcessViewModel finish = new ProcessViewModel
            {
                Name = "Finishing",
                CompletedStatusText = "Finished",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            Mock.Arrange(() => _processService.GetAll()).Returns(new List<ProcessViewModel>
            {
                preparation,
                winding,
                plating,
                varnish,
                finish,
            });

            String sortOrder = null;
            String searchString = "ish";
            String currentFilter = null;
            int? page = null;

            ViewResult result = _controller.Index(sortOrder, searchString, currentFilter, page);
            var processes = result.Model as IEnumerable<ProcessViewModel>;

            Assert.AreEqual(2, processes?.Count());
            Assert.AreEqual(finish.Name, processes?.FirstOrDefault().Name);
        }

        [TestCategory("ProcessController")]
        [TestMethod]
        public void Index_Should_Return_A_View_With_First_Name_In_Model_Winding_And_Model_Count_3()
        {
            ProcessViewModel preparation = new ProcessViewModel
            {
                Name = "Preparation",
                CompletedStatusText = "Prepared",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            ProcessViewModel winding = new ProcessViewModel
            {
                Name = "Winding",
                CompletedStatusText = "Wound",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            ProcessViewModel plating = new ProcessViewModel
            {
                Name = "Plating",
                CompletedStatusText = "Plated",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            ProcessViewModel varnish = new ProcessViewModel
            {
                Name = "Varnish",
                CompletedStatusText = "Varnished",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = true
            };

            ProcessViewModel finish = new ProcessViewModel
            {
                Name = "Finishing",
                CompletedStatusText = "Finished",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            Mock.Arrange(() => _processService.GetAll()).Returns(new List<ProcessViewModel>
            {
                preparation,
                winding,
                plating,
                varnish,
                finish,
            });

            String sortOrder = "name_desc";

            ViewResult result = _controller.Index(sortOrder, null, null, null);
            var processes = result.Model as IEnumerable<ProcessViewModel>;

            Assert.AreEqual(3, processes?.Count());
            Assert.AreEqual(winding.Name, processes?.FirstOrDefault().Name);

        }

        [TestCategory("ProcessController")]
        [TestMethod]
        public void Details_Returns_A_View()
        {
            ViewResult result = _controller.Details(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result?.Model);
        }

        [TestCategory("ProcessController")]
        [TestMethod]
        public void Create_Returns_A_View()
        {
            ViewResult result = _controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("ProcessController")]
        [TestMethod]
        public void CreatePost_Calls_Create_And_Save_On_Service()
        {
            var processViewModel = Mock.Create<ProcessViewModel>();

            _controller.Create(processViewModel);

            Mock.Assert(() => _processService.Create(Arg.IsAny<ProcessViewModel>()), Occurs.AtLeastOnce());
            Mock.Assert(()=>_processService.Save(), Occurs.AtLeastOnce());
        }

        [TestCategory("ProcessController")]
        [TestMethod]
        public void Edit_Returns_A_View_With_A_Model()
        {
            ViewResult result = _controller.Edit(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result?.Model);
        }

        [TestCategory("ProcessController")]
        [TestMethod]
        public void Edit_Post_Calls_Update_And_Save_On_Service()
        {
            var processViewModel = Mock.Create<ProcessViewModel>();

            _controller.Edit(processViewModel);

            Mock.Assert(()=>_processService.Update(Arg.IsAny<ProcessViewModel>()), Occurs.AtLeastOnce());
            Mock.Assert(()=>_processService.Save(), Occurs.AtLeastOnce());
        }

        [TestCategory("ProcessController")]
        [TestMethod]
        public void Deactivate_Returns_A_View()
        {
            ViewResult result = _controller.Deactivate(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result?.Model);
        }

        [TestCategory("ProcessController")]
        [TestMethod]
        public void DeactivatePost_Sets_Active_To_False_Calls_Update_And_Save_On_Service()
        {
            _controller.DeactivatePost(Guid.NewGuid());
            
            Mock.Assert(()=>_processService.Update(Arg.IsAny<ProcessViewModel>()),Occurs.AtLeastOnce());
            Mock.Assert(()=>_processService.Save(), Occurs.AtLeastOnce());
        }
    }
}
