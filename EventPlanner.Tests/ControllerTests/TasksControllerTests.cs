using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EventPlanner.Controllers;
using EventPlanner.Models;

namespace EventPlanner.Tests
{
  [TestClass]
  public class TasksControllerTest : IDisposable
  {
    public TasksControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
      _controller = new TasksController();
      _task = new Task("TestDescription", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)));
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

    private TasksController _controller;
    private Task _task;

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      Assert.IsInstanceOfType(_controller.Index(), typeof(ViewResult));
    }
    [TestMethod]
    public void Index_HasCorrectModelType_TasksList()
    {
      ViewResult indexView = _controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Task>));
    }

    [TestMethod]
    public void New_ReturnCorrectViewOfForm_True()
    {
      ActionResult newView = _controller.New() as ActionResult;
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }
    [TestMethod]
    public void Create_CreatesNewInstanceOfTask_True()
    {
      ActionResult createPost = _controller.Create("TestName", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)));
      Assert.IsInstanceOfType(createPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      ActionResult showView = _controller.Show(1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void AddEvent_AddInstanceOfEventForTask_True()
    {
      _task.Save();
      ActionResult showPost = _controller.AddEvent(_task.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }
    [TestMethod]
    public void DeleteEvent_DeleteInstanceOfEventForTask_True()
    {
      _task.Save();
      ActionResult showPost = _controller.DeleteEvent(_task.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Delete_DeletesTaskObject_True()
    {
      _task.Save();
      ActionResult deletePost = _controller.Delete(_task.GetId());
      Assert.IsInstanceOfType(deletePost, typeof(ActionResult));
      CollectionAssert.AreEqual(new List<Task> { }, Task.GetAll());
    }
    [TestMethod]
    public void DeleteAll_ReturnsCorrectActionType_RedirectToActionResult()
    {
      IActionResult view = _controller.DeleteAll();
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_TaskList()
    {
      Assert.IsInstanceOfType(_controller.Edit(_task.GetId()), typeof(ViewResult));
    }
    [TestMethod]
    public void Update_UpdatesInstanceOfTask_True()
    {
      _task.Save();
      ActionResult updatePost = _controller.Update(_task.GetId(), "NewDescription", (new DateTime(2019, 12, 31, 21, 30, 0, DateTimeKind.Utc)));
      Assert.AreEqual("NewDescription", Task.Find(_task.GetId()).GetTaskDescription());
    }
  }
}
