using Day6Demo.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestProjectDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            //create Instance from controller 
            DemosController demo = new DemosController();
            //Act
            ViewResult result = demo.TestAction() as ViewResult;

            //Assert
            Assert.AreEqual("Welcome in Test With MVC ", result.ViewData["Title"]);

        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            //create Instance from controller 
            DemosController demo = new DemosController();
            //Act
            int result = demo.divi(100, 2);

            //assent
            Assert.AreEqual(50, result);

        }
    }
}