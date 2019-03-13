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
    public HomeControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
      _controller = new HomeController();
    }

    private HomeController _controller;

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      Assert.IsInstanceOfType(_controller.Index(), typeof(ViewResult));
    }
    [TestMethod]
    public void Index_HasCorrectModelType_EventsList()
    {
      ViewResult indexView = _controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Event>));
    }

  }
}
