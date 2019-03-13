using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public EventsController controller = new EventsController();
    public Event newEvent = new Event("TestName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      Assert.IsInstanceOfType(controller.Index(), typeof(ViewResult));
    }
    [TestMethod]
    public void Index_HasCorrectModelType_EventsList()
    {
      ViewResult indexView = controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Event>));
    }

    [TestMethod]
    public void New_ReturnCorrectViewOfForm_True()
    {
      ActionResult newView = controller.New() as ActionResult;
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }
    [TestMethod]
    public void Create_CreatesNewInstanceOfEvent_True()
    {
      ActionResult createPost = controller.Create("TestName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);
      Assert.IsInstanceOfType(createPost, typeof(ActionResult));
    }

    // [TestMethod]
    // public void Show_ProcessesShowModelCorrectly_True()
    // {
    //   newEvent.Save();
    //   var showView = controller.Show(newEvent.GetId()) as ViewResult;
    //   var result = showView.ViewData.Model;
    //   Assert.AreEqual(result, typeof(Dictionary<string, object>));
    // }

    [TestMethod]
    public void AddTask_AddInstanceOfTaskForEvent_True()
    {
      newEvent.Save();
      ActionResult showPost = controller.AddTask(newEvent.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }
    [TestMethod]
    public void DeleteTask_DeleteInstanceOfTaskForEvent_True()
    {
      newEvent.Save();
      ActionResult showPost = controller.DeleteTask(newEvent.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }

    [TestMethod]
    public void AddInvitee_AddInstanceOfInviteeForEvent_True()
    {
      newEvent.Save();
      ActionResult showPost = controller.AddInvitee(newEvent.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }
    [TestMethod]
    public void DeleteInvitee_DeleteInstanceOfInviteeForEvent_True()
    {
      newEvent.Save();
      ActionResult showPost = controller.DeleteInvitee(newEvent.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Delete_DeletesEventObject_True()
    {
      newEvent.Save();
      ActionResult deletePost = controller.Delete(newEvent.GetId());
      Assert.IsInstanceOfType(deletePost, typeof(ActionResult));
      CollectionAssert.AreEqual(new List<Event> { }, Event.GetAll());
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_EventList()
    {
      Assert.IsInstanceOfType(controller.Edit(newEvent.GetId()), typeof(ViewResult));
    }
    [TestMethod]
    public void Update_UpdatesInstanceOfEvent_True()
    {
      newEvent.Save();
      ActionResult updatePost = controller.Update(newEvent.GetId(), "NewName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);
      Assert.AreEqual("NewName", Event.Find(newEvent.GetId()).GetEventName());
    }
  }
}
