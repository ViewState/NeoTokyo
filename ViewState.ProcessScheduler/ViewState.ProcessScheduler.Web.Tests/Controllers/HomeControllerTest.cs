using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewState.ProcessScheduler.Web.Controllers;

namespace ViewState.ProcessScheduler.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestCategory("HomeController")]
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCategory("HomeController")]
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestCategory("HomeController")]
        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCategory("HomeController")]
        [TestMethod]
        public void SetUp()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.SetUp() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
