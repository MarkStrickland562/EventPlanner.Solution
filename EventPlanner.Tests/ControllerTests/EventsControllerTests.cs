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
    public EventsControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
    }
    public void Dispose()
    {
      Event.ClearAll();
      Invitee.ClearAll();
      Menu.ClearAll();
      MenuItem.ClearAll();
      MenuItemIngredient.ClearAll();
      Store.ClearAll();
      Task.ClearAll();
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
    public void Create_CreatesNewInstanceOfEvent_True()
    {
      ActionResult createPost = new EventsController().Create("TestName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);
      Assert.IsInstanceOfType(createPost, typeof(ActionResult));
    }

    // [TestMethod]
    // public void Show_ProcessesShowModelCorrectly_True()
    // {
    //   Event newEvent = new Event("TestName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);
    //   newEvent.Save();
    //   EventsController controller = new EventsController();
    //   ViewResult result = controller.Show(count);
    //   Assert.AreEqual(3, show.Count);
    // }

    // [TestMethod]
    // public void AddTask_AddInstanceOfTaskForEvent_True()
    // {
    //   Event newEvent = new Event ("TestName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);
    //   event.Save();
    //   ActionResult showPost = new EventsController().AddTask(event.GetId());
    //   Assert.IsInstanceOfType(showPost, typeof(ActionResult));
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
