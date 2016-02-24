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
        private IService<Process> _processService;
        private IMapper _mapper;
        private ProcessController _controller;

        [TestInitialize]
        public void InitialiseTests()
        {
            _processService = Mock.Create<IService<Process>>();
            _mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            }).CreateMapper();
            _controller = new ProcessController(_processService, _mapper);
        }

        [TestCategory("ProcessController")]
        [TestMethod]
        public void Index_Should_Return_A_View_With_First_Name_In_Model_Finish()
        {
            Process preparation = new Process
            {
                Name = "Preparation",
                CompletedStatusText = "Prepared",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            Process winding = new Process
            {
                Name = "Winding",
                CompletedStatusText = "Wound",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            Process plating = new Process
            {
                Name = "Plating",
                CompletedStatusText = "Plated",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            Process varnish = new Process
            {
                Name = "Varnish",
                CompletedStatusText = "Varnished",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = true
            };

            Process finish = new Process
            {
                Name = "Finishing",
                CompletedStatusText = "Finished",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            Mock.Arrange(() => _processService.GetAll()).Returns(new List<Process>
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
            Process preparation = new Process
            {
                Name = "Preparation",
                CompletedStatusText = "Prepared",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            Process winding = new Process
            {
                Name = "Winding",
                CompletedStatusText = "Wound",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            Process plating = new Process
            {
                Name = "Plating",
                CompletedStatusText = "Plated",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            Process varnish = new Process
            {
                Name = "Varnish",
                CompletedStatusText = "Varnished",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = true
            };

            Process finish = new Process
            {
                Name = "Finishing",
                CompletedStatusText = "Finished",
                Active = true,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid(),
                IsOverNightProcess = false
            };

            Mock.Arrange(() => _processService.GetAll()).Returns(new List<Process>
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

            Mock.Assert(() => _processService.Create(Arg.IsAny<Process>()), Occurs.AtLeastOnce());
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

            Mock.Assert(()=>_processService.Update(Arg.IsAny<Process>()), Occurs.AtLeastOnce());
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
            
            Mock.Assert(()=>_processService.Update(Arg.IsAny<Process>()),Occurs.AtLeastOnce());
            Mock.Assert(()=>_processService.Save(), Occurs.AtLeastOnce());
        }
    }
}
