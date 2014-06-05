using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTO.Web;
using PTO.Web.Controllers;
using PTO.Service;

namespace PTO.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IAppService _service;

        public HomeControllerTest(IAppService service)
        {
            _service = service;
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_service);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(_service);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(_service);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
