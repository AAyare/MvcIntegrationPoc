// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeControllerTest.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcPoc.Web.Controllers;

namespace MvcPoc.Tests.Controllers
{
    /// <summary>
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// </summary>
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void About()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void Contact()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}