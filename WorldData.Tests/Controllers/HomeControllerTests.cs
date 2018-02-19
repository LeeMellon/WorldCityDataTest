using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorldData.Controllers;
using WorldData.Models;

namespace WorldData.Tests
{
  [TestClass]
  public class HomeControllerTest
  {
    [TestMethod]
    public void Index_ReturnCorrectView_Red()
    {
      //arrange
      HomeController controller = new HomeController();

      //act
      IActionResult indexView = controller.Index();
      ViewResult result = indexView as ViewResult;

      //assert
      Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void Index_ReturnCorrectView_Green()
    {
      //arrange
      HomeController controller = new HomeController();

      //act
      IActionResult indexView = controller.Index();
      ViewResult result = indexView as ViewResult;

      //assert
      Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
  }
}
