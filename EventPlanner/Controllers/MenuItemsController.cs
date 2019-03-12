using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using EventPlanner.Models;

namespace EventPlanner.Controllers
{
  public class MenuItemsController : Controller
  {
    [HttpGet("/menuItems")]
    public ActionResult Index()
    {
      List<MenuItem> allMenuItems = MenuItem.GetAll();
      return View(allMenuItems);
    }

    [HttpGet("/menuItems/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/menuItems/new")]
    public ActionResult Create(string menuItemDescription)
    {
      MenuItem newMenuItem = new MenuItem(menuItemDescription);
      newMenuItem.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/menuItems/{menuItemId}")]
    public ActionResult Show(int menuItemId)
    {
      MenuItem menuItem = MenuItem.Find(menuItemId);
      // List <MenuItemIngredient> menuItemIngredients = MenuItem.GetMenuItemIngredients(menuItemId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("menuItem", menuItem);
      // model.Add("menuItemIngredients", menuItemIngredients);
      return View(model);
    }

    // [HttpPost("/menuItems/{menuItemId}/ingredients/new")]
    // public ActionResult AddIngredient(int menuItemId, int menuItemIngredientId)
    // {
    //   MenuItem menuItem = MenuItem.Find(menuItemId);
    //   menuItem.AddMenuItemIngredient(menuItemIngredient.Find(menuItemIngredientId));
    //   return RedirectToAction("Show");
    // }
    // [HttpPost("/menuItems/{menuItemId}/ingredients/delete")]
    // public ActionResult DeleteIngredient(int menuItemId, int menuItemIngredientId)
    // {
    //   MenuItem menuItem = MenuItem.Find(menuItemId);
    //   menuItem.DeleteMenuItemIngredient(menuItemIngredient.Find(menuItemIngredientId));
    //   return RedirectToAction("Show");
    // }

    [HttpPost("/menuItems/{menuItemId}/menu/new")]
    public ActionResult AddMenu(int menuItemId, int menuId)
    {
      MenuItem menuItem = MenuItem.Find(menuItemId);
      menuItem.AddMenu(Menu.Find(menuId));
      return RedirectToAction("Show");
    }
    [HttpPost("/menuItems/{menuItemId}/menu/delete")]
    public ActionResult DeleteMenu(int menuItemId, int menuId)
    {
      MenuItem menuItem = MenuItem.Find(menuItemId);
      menuItem.DeleteMenu(Menu.Find(menuId));
      return RedirectToAction("Show");
    }

    [HttpPost("/menuItems/{menuItemId}/delete")]
    public ActionResult Delete(int menuItemId)
    {
      MenuItem menuItem = MenuItem.Find(menuItemId);
      menuItem.Delete();
      return RedirectToAction("Index");
    }
    [HttpPost("/menuItems/delete")]
    public ActionResult DeleteAll()
    {
      MenuItem.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/menuItems/{menuItemId}/edit")]
    public ActionResult Edit(int menuItemId)
    {
      MenuItem menuItem = MenuItem.Find(menuItemId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("menuItem", menuItem);
      return View(model);
    }
    [HttpPost("/menuItems/{menuItemId}/edit")]
    public ActionResult Update(int menuItemId, string menuItemDescription)
    {
      MenuItem menuItem = MenuItem.Find(menuItemId);
      menuItem.Edit(menuItemDescription);
      return RedirectToAction("Index");
    }
  }
}
