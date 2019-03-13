using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EventPlanner.Controllers;
using EventPlanner.Models;

namespace EventPlanner.Tests
{
  [TestClass]
  public class MenuItemsControllerTest : IDisposable
  {
    public MenuItemsControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
      _controller = new MenuItemsController();
      _menuItem = new MenuItem("TestDescription");
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

    private MenuItemsController _controller;
    private MenuItem _menuItem;

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      Assert.IsInstanceOfType(_controller.Index(), typeof(ViewResult));
    }
    [TestMethod]
    public void Index_HasCorrectModelType_MenuItemsList()
    {
      ViewResult indexView = _controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<MenuItem>));
    }

    [TestMethod]
    public void New_ReturnCorrectViewOfForm_True()
    {
      ActionResult newView = _controller.New() as ActionResult;
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }
    [TestMethod]
    public void Create_CreatesNewInstanceOfMenuItem_True()
    {
      ActionResult createPost = _controller.Create("TestDescription");
      Assert.IsInstanceOfType(createPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      ActionResult showView = _controller.Show(1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void AddMenu_AddInstanceOfTaskForMenu_True()
    {
      _menuItem.Save();
      ActionResult showPost = _controller.AddMenu(_menuItem.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }
    [TestMethod]
    public void DeleteMenu_DeleteInstanceOfTaskForMenu_True()
    {
      _menuItem.Save();
      ActionResult showPost = _controller.DeleteMenu(_menuItem.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Delete_DeletesMenuItemObject_True()
    {
      _menuItem.Save();
      ActionResult deletePost = _controller.Delete(_menuItem.GetId());
      Assert.IsInstanceOfType(deletePost, typeof(ActionResult));
      CollectionAssert.AreEqual(new List<MenuItem> { }, MenuItem.GetAll());
    }
    [TestMethod]
    public void DeleteAll_ReturnsCorrectActionType_RedirectToActionResult()
    {
      IActionResult view = _controller.DeleteAll();
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_MenuItemList()
    {
      Assert.IsInstanceOfType(_controller.Edit(_menuItem.GetId()), typeof(ViewResult));
    }
    [TestMethod]
    public void Update_UpdatesInstanceOfMenuItem_True()
    {
      _menuItem.Save();
      ActionResult updatePost = _controller.Update((_menuItem.GetId()), "NewDescription");
      Assert.AreEqual("NewDescription", MenuItem.Find(_menuItem.GetId()).GetMenuItemDescription());
    }
  }
}
