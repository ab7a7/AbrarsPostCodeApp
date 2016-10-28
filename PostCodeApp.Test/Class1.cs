using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using PostCodeApp;
using PostCodeApp.Controllers;
using System.Web.Mvc;

namespace PostCodeApp.Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void checkSetup()
        {
            Assert.True(true);
        }

        [Test]
        public void checkController()
        {
            //Arrange
            var controller = new HomeController();
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
