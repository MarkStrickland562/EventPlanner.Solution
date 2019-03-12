using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EventPlanner.Controllers;
using EventPlanner.Models;

namespace EventPlanner.Tests
{
  [TestClass]
  public class HomeControllerTest
  {

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      HomeController controller = new HomeController();
      Assert.IsInstanceOfType(controller.Index(), typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModelType_EventsList()
    {
      ViewResult indexView = new HomeController().Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Events>));
    }

  }
}
