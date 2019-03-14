using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EventPlanner.Controllers;
using EventPlanner.Models;

namespace EventPlanner.Tests
{
  [TestClass]
  public class MenuItemIngredientsControllerTest : IDisposable
  {
    public MenuItemIngredientsControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
      _controller = new MenuItemIngredientsController();
      _menuItemIngredient = new MenuItemIngredient("TestDescription", 0, 0);
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

    private MenuItemIngredientsController _controller;
    private MenuItemIngredient _menuItemIngredient;

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      Assert.IsInstanceOfType(_controller.Index(), typeof(ViewResult));
    }
    [TestMethod]
    public void Index_HasCorrectModelType_MenuItemIngredientsList()
    {
      ViewResult indexView = _controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<MenuItemIngredient>));
    }

    [TestMethod]
    public void New_ReturnCorrectViewOfForm_True()
    {
      ActionResult newView = _controller.New() as ActionResult;
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }
    [TestMethod]
    public void Create_CreatesNewInstanceOfMenuItemIngredient_True()
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
    public void Delete_DeletesMenuItemIngredientObject_True()
    {
      _menuItemIngredient.Save();
      ActionResult deletePost = _controller.Delete(_menuItemIngredient.GetId());
      Assert.IsInstanceOfType(deletePost, typeof(ActionResult));
      CollectionAssert.AreEqual(new List<MenuItemIngredient> { }, MenuItemIngredient.GetAll());
    }
    [TestMethod]
    public void DeleteAll_ReturnsCorrectActionType_RedirectToActionResult()
    {
      IActionResult view = _controller.DeleteAll();
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_MenuItemIngredientList()
    {
      Assert.IsInstanceOfType(_controller.Edit(_menuItemIngredient.GetId()), typeof(ViewResult));
    }
    [TestMethod]
    public void Update_UpdatesInstanceOfMenuItemIngredient_True()
    {
      _menuItemIngredient.Save();
      ActionResult updatePost = _controller.Update((_menuItemIngredient.GetId()), "NewDescription", 0, 0);
      Assert.AreEqual("NewDescription", MenuItemIngredient.Find(_menuItemIngredient.GetId()).GetIngredientDescription());
    }
  }
}
