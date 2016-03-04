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
    public class StaffControllerTest
    {
        private IService<Staff, StaffWithDesignerViewModel> _staffService;
        private IService<Designer, StaffWithDesignerViewModel> _designerService;
        private StaffController _controller;

        [TestInitialize]
        public void InitialiseTests()
        {
            _staffService = Mock.Create<IService<Staff, StaffWithDesignerViewModel>>();
            _designerService = Mock.Create<IService<Designer, StaffWithDesignerViewModel>>();
            _controller = new StaffController(_staffService, _designerService);
        }

        [TestCategory("StaffController")]
        [TestMethod]
        public void Index_Should_Return_A_View_With_First_Name_In_Model_Dan()
        {
            StaffWithDesignerViewModel benPlews = new StaffWithDesignerViewModel
            {
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
                FirstName = "Ben",
                MiddleName = String.Empty,
                LastName = "Plews"
            };

            StaffWithDesignerViewModel danSkillcorn = new StaffWithDesignerViewModel
            {
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
                FirstName = "Dan",
                MiddleName = String.Empty,
                LastName = "Skillcorn"
            };

            StaffWithDesignerViewModel peteRowley = new StaffWithDesignerViewModel
            {
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
                FirstName = "Peter",
                MiddleName = "David",
                LastName = "Rowley"
            };

            StaffWithDesignerViewModel juliaRowley = new StaffWithDesignerViewModel
            {
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
                FirstName = "Julia",
                MiddleName = "Doreen",
                LastName = "Rowley"
            };

            StaffWithDesignerViewModel nicola = new StaffWithDesignerViewModel
            {
                ID = Guid.NewGuid(),
                Active = true,
                DateCreated = DateTime.Now,
                FirstName = "Nicola",
                MiddleName = String.Empty,
                LastName = "Clement"
            };

            Mock.Arrange(() => _staffService.GetAll()).Returns(new List<StaffWithDesignerViewModel>
            {
                benPlews,
                danSkillcorn,
                peteRowley,
                juliaRowley,
                nicola
            });

            String sortOrder = "name_desc";

            ViewResult result = _controller.Index(sortOrder, null, null, null) as ViewResult;

            IEnumerable<StaffWithDesignerViewModel> staffs = result?.Model as IEnumerable<StaffWithDesignerViewModel>;

            Assert.AreEqual(danSkillcorn.FirstName, staffs?.FirstOrDefault()?.FirstName);
        }

        [TestCategory("StaffController")]
        [TestMethod]
        public void Create_Returns_A_View()
        {
            ViewResult result = _controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("StaffController")]
        [TestMethod]
        public void Create_Post_Calls_Create_And_Save_On_Service()
        {
            _controller.Create(new StaffWithDesignerViewModel() {FirstName = "Test"});

            Mock.Assert(() => _staffService.Create(Arg.IsAny<StaffWithDesignerViewModel>()), Occurs.AtLeastOnce());
            Mock.Assert(() => _staffService.Save(), Occurs.AtLeastOnce());
        }

        [TestCategory("StaffController")]
        [TestMethod]
        public void Edit_Returns_A_View()
        {
            ViewResult result = _controller.Edit(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("StaffController")]
        [TestMethod]
        public void Edit_Calls_Update_And_Save_On_Service()
        {
            _controller.Edit(new StaffWithDesignerViewModel());

            Mock.Assert(() => _staffService.Update(Arg.IsAny<StaffWithDesignerViewModel>()), Occurs.AtLeastOnce());
            Mock.Assert(() => _staffService.Save(), Occurs.AtLeastOnce());
        }

        [TestCategory("StaffController")]
        [TestMethod]
        public void Details_Returns_A_View()
        {
            ViewResult result = _controller.Details(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("StaffController")]
        [TestMethod]
        public void Deactivate_Returns_A_View()
        {
            ViewResult result = _controller.Deactivate(Guid.NewGuid()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestCategory("StaffController")]
        [TestMethod]
        public void DeactivatePost_Calls_Update_And_Save_On_Service()
        {
            _controller.DeactivatePost(Guid.NewGuid());

            Mock.Assert(() => _staffService.Update(Arg.IsAny<StaffWithDesignerViewModel>()), Occurs.AtLeastOnce());
            Mock.Assert(() => _staffService.Save(), Occurs.AtLeastOnce());
        }
    }
}
