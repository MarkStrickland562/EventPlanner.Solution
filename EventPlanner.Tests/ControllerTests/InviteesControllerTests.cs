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

    public InviteesController controller = new InviteesController();
    public Invitee invitee = new Invitee("TestName", "Test@Email.com");

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      Assert.IsInstanceOfType(controller.Index(), typeof(ViewResult));
    }
    [TestMethod]
    public void Index_HasCorrectModelType_InviteesList()
    {
      ViewResult indexView = controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Invitee>));
    }

    [TestMethod]
    public void New_ReturnCorrectViewOfForm_True()
    {
      ActionResult newView = controller.New() as ActionResult;
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }
    [TestMethod]
    public void Create_CreatesNewInstanceOfInvitee_True()
    {
      ActionResult createPost = controller.Create("TestName", "Test@Email.com");
      Assert.IsInstanceOfType(createPost, typeof(ActionResult));
    }

    [TestMethod]
    public void AddEvent_AddInstanceOfEventForInvitee_True()
    {
      invitee.Save();
      ActionResult showPost = controller.AddEvent(invitee.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }
    [TestMethod]
    public void DeleteEvent_DeleteInstanceOfEventForInvitee_True()
    {
      invitee.Save();
      ActionResult showPost = controller.DeleteEvent(invitee.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Delete_DeletesInviteeObject_True()
    {
      invitee.Save();
      ActionResult deletePost = controller.Delete(invitee.GetId());
      Assert.IsInstanceOfType(deletePost, typeof(ActionResult));
      CollectionAssert.AreEqual(new List<Invitee> { }, Invitee.GetAll());
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_InviteeList()
    {
      Assert.IsInstanceOfType(controller.Edit(invitee.GetId()), typeof(ViewResult));
    }
    [TestMethod]
    public void Update_UpdatesInstanceOfInvitee_True()
    {
      invitee.Save();
      ActionResult updatePost = controller.Update(invitee.GetId(), "NewName", "Test@Email.com");
      Assert.AreEqual("NewName", Invitee.Find(invitee.GetId()).GetInviteeName());
    }
  }
}
