using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThiagoLemos.Web.MVC;
using ThiagoLemos.Web.MVC.Controllers;

namespace ThiagoLemos.Web.MVC.Testes.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private PessoaController controller;
        public HomeControllerTest()
        {
            controller = new PessoaController();
        }
        [TestMethod]
        public void PessoaController_Index()
        {
            
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void PessoaController_Create()
        {

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void PessoaController_Edit()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Edit() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
