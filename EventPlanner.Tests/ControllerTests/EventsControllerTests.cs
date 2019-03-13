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
      _controller = new EventsController();
      _newEvent = new Event("TestName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);
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

    private EventsController _controller;
    private Event _newEvent;

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

    [TestMethod]
    public void New_ReturnCorrectViewOfForm_True()
    {
      ActionResult newView = _controller.New() as ActionResult;
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }
    [TestMethod]
    public void Create_CreatesNewInstanceOfEvent_True()
    {
      ActionResult createPost = _controller.Create("TestName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);
      Assert.IsInstanceOfType(createPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      ActionResult showView = _controller.Show(1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void AddTask_AddInstanceOfTaskForEvent_True()
    {
      _newEvent.Save();
      ActionResult showPost = _controller.AddTask(_newEvent.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }
    [TestMethod]
    public void DeleteTask_DeleteInstanceOfTaskForEvent_True()
    {
      _newEvent.Save();
      ActionResult showPost = _controller.DeleteTask(_newEvent.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }

    [TestMethod]
    public void AddInvitee_AddInstanceOfInviteeForEvent_True()
    {
      _newEvent.Save();
      ActionResult showPost = _controller.AddInvitee(_newEvent.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }
    [TestMethod]
    public void DeleteInvitee_DeleteInstanceOfInviteeForEvent_True()
    {
      _newEvent.Save();
      ActionResult showPost = _controller.DeleteInvitee(_newEvent.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Delete_DeletesEventObject_True()
    {
      _newEvent.Save();
      ActionResult deletePost = _controller.Delete(_newEvent.GetId());
      Assert.IsInstanceOfType(deletePost, typeof(ActionResult));
      CollectionAssert.AreEqual(new List<Event> { }, Event.GetAll());
    }
    [TestMethod]
    public void DeleteAll_ReturnsCorrectActionType_RedirectToActionResult()
    {
      IActionResult view = _controller.DeleteAll();
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_EventList()
    {
      Assert.IsInstanceOfType(_controller.Edit(_newEvent.GetId()), typeof(ViewResult));
    }
    [TestMethod]
    public void Update_UpdatesInstanceOfEvent_True()
    {
      _newEvent.Save();
      ActionResult updatePost = _controller.Update(_newEvent.GetId(), "NewName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)), "TestLocation", 1);
      Assert.AreEqual("NewName", Event.Find(_newEvent.GetId()).GetEventName());
    }
  }
}
