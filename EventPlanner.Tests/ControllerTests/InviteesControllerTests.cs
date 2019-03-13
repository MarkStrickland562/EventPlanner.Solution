using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EventPlanner.Controllers;
using EventPlanner.Models;

namespace EventPlanner.Tests
{
  [TestClass]
  public class InviteesControllerTest : IDisposable
  {
    public InviteesControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
      _controller = new InviteesController();
      _invitee = new Invitee("TestName", "Test@Email.com");
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

    private InviteesController _controller;
    private Invitee _invitee;

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      Assert.IsInstanceOfType(_controller.Index(), typeof(ViewResult));
    }
    [TestMethod]
    public void Index_HasCorrectModelType_InviteesList()
    {
      ViewResult indexView = _controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Invitee>));
    }

    [TestMethod]
    public void New_ReturnCorrectViewOfForm_True()
    {
      ActionResult newView = _controller.New() as ActionResult;
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }
    [TestMethod]
    public void Create_CreatesNewInstanceOfInvitee_True()
    {
      ActionResult createPost = _controller.Create("TestName", "Test@Email.com");
      Assert.IsInstanceOfType(createPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      ActionResult showView = _controller.Show(1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void AddEvent_AddInstanceOfEventForInvitee_True()
    {
      _invitee.Save();
      ActionResult showPost = _controller.AddEvent(_invitee.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }
    [TestMethod]
    public void DeleteEvent_DeleteInstanceOfEventForInvitee_True()
    {
      _invitee.Save();
      ActionResult showPost = _controller.DeleteEvent(_invitee.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Delete_DeletesInviteeObject_True()
    {
      _invitee.Save();
      ActionResult deletePost = _controller.Delete(_invitee.GetId());
      Assert.IsInstanceOfType(deletePost, typeof(ActionResult));
      CollectionAssert.AreEqual(new List<Invitee> { }, Invitee.GetAll());
    }
    [TestMethod]
    public void DeleteAll_ReturnsCorrectActionType_RedirectToActionResult()
    {
      IActionResult view = _controller.DeleteAll();
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_InviteeList()
    {
      Assert.IsInstanceOfType(_controller.Edit(_invitee.GetId()), typeof(ViewResult));
    }
    [TestMethod]
    public void Update_UpdatesInstanceOfInvitee_True()
    {
      _invitee.Save();
      ActionResult updatePost = _controller.Update(_invitee.GetId(), "NewName", "Test@Email.com");
      Assert.AreEqual("NewName", Invitee.Find(_invitee.GetId()).GetInviteeName());
    }
  }
}
