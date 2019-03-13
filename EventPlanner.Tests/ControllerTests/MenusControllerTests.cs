using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EventPlanner.Controllers;
using EventPlanner.Models;

namespace EventPlanner.Tests
{
  [TestClass]
  public class MenusControllerTest : IDisposable
  {
    public MenusControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
      _controller = new MenusController();
      _menu = new Menu("TestTheme");
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

    private MenusController _controller;
    private Menu _menu;

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      Assert.IsInstanceOfType(_controller.Index(), typeof(ViewResult));
    }
    [TestMethod]
    public void Index_HasCorrectModelType_MenusList()
    {
      ViewResult indexView = _controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Menu>));
    }

    [TestMethod]
    public void New_ReturnCorrectViewOfForm_True()
    {
      ActionResult newView = _controller.New() as ActionResult;
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }
    [TestMethod]
    public void Create_CreatesNewInstanceOfMenu_True()
    {
      ActionResult createPost = _controller.Create("TestTheme");
      Assert.IsInstanceOfType(createPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      ActionResult showView = _controller.Show(1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void AddMenuItem_AddInstanceOfTaskForMenuItem_True()
    {
      _menu.Save();
      ActionResult showPost = _controller.AddMenuItem(_menu.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }
    [TestMethod]
    public void DeleteMenuItem_DeleteInstanceOfTaskForMenuItem_True()
    {
      _menu.Save();
      ActionResult showPost = _controller.DeleteMenuItem(_menu.GetId(), 0);
      Assert.IsInstanceOfType(showPost, typeof(ActionResult));
    }

    [TestMethod]
    public void Delete_DeletesMenuObject_True()
    {
      _menu.Save();
      ActionResult deletePost = _controller.Delete(_menu.GetId());
      Assert.IsInstanceOfType(deletePost, typeof(ActionResult));
      CollectionAssert.AreEqual(new List<Menu> { }, Menu.GetAll());
    }
    [TestMethod]
    public void DeleteAll_ReturnsCorrectActionType_RedirectToActionResult()
    {
      IActionResult view = _controller.DeleteAll();
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_MenuList()
    {
      Assert.IsInstanceOfType(_controller.Edit(_menu.GetId()), typeof(ViewResult));
    }
    [TestMethod]
    public void Update_UpdatesInstanceOfMenu_True()
    {
      _menu.Save();
      ActionResult updatePost = _controller.Update((_menu.GetId()), "NewTheme");
      Assert.AreEqual("NewTheme", Menu.Find(_menu.GetId()).GetMenuTheme());
    }
  }
}
