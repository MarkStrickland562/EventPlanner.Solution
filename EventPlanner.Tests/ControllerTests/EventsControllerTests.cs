using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EventPlanner.Controllers;
using EventPlanner.Models;

namespace EventPlanner.Tests
{
  [TestClass]
  public class EventsControllerTest : IDisposable
  {
    public void Dispose()
    {
      Event.ClearAll();
    }

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      EventsController controller = new EventsController();
      Assert.IsInstanceOfType(controller.Index(), typeof(ViewResult));
    }
    [TestMethod]
    public void Index_HasCorrectModelType_EventsList()
    {
      ViewResult indexView = new EventsController().Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Event>));
    }

    [TestMethod]
    public void New_ReturnCorrectViewOfForm_True()
    {
      ActionResult newView = new EventsController().New();
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }
    [TestMethod]
    public void Create_CreatesNewInstanceOfStylist_True()
    {
      ActionResult createPost = new EventsController().Create("TestName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);
      Assert.IsInstanceOfType(createPost, typeof(ActionResult));
    }

    // [TestMethod]
    // public void Show_ProcessesShowModelCorrectly_True()
    // {
    //   Event newEvent = new Event("TestName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);
    //   newEvent.Save();
    //   ActionResult show = new EventsController().Show(newEvent.GetId());
    //   Assert.AreEqual(3, show.Count);
    // }

    [TestMethod]
    public void Delete_DeletesEventObject_True()
    {
      Event newEvent = new Event("TestName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);
      newEvent.Save();
      ActionResult deletePost = new EventsController().Delete(newEvent.GetId());
      Assert.IsInstanceOfType(deletePost, typeof(ActionResult));
      CollectionAssert.AreEqual(new List<Event> { }, Event.GetAll());
    }
  }
}
