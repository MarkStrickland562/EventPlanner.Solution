using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using EventPlanner.Models;

namespace EventPlanner.Controllers
{
  public class MenusController : Controller
  {
    [HttpGet("/menus")]
    public ActionResult Index()
    {
      List<Menu> allMenus = Menu.GetAll();
      return View(allMenus);
    }

    [HttpGet("/menus/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/menus/new")]
    public ActionResult Create(string menuTheme)
    {
      Menu newMenu = new Menu(menuTheme);
      newMenu.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/menus/{menuId}")]
    public ActionResult Show(int menuId)
    {
      Menu menu = Menu.Find(menuId);
      List<MenuItem> menuItems = menu.GetMenuItems();
      List<MenuItem> allMenuItems = MenuItem.GetAll();
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("menu", menu);
      model.Add("menuItems", menuItems);
      model.Add("allMenuItems", allMenuItems);
      return View(model);
    }

    [HttpPost("/menus/{menuId}/menuItems/new")]
    public ActionResult AddMenuItem(int menuId, int menuItemId)
    {
      Menu menu = Menu.Find(menuId);
      menu.AddMenuItem(MenuItem.Find(menuItemId));
      return RedirectToAction("Show");
    }

    [HttpGet("/menus/{menuId}/menuItems/{menuItemId}/delete")]
    public ActionResult DeleteMenuItem(int menuId, int menuItemId)
    {
      Menu menu = Menu.Find(menuId);
      menu.DeleteMenuItem(MenuItem.Find(menuItemId));
      return RedirectToAction("Show");
    }

    [HttpGet("/menus/{menuId}/delete")]
    public ActionResult Delete(int menuId)
    {
      Menu menu = Menu.Find(menuId);
      menu.Delete();
      return RedirectToAction("Index");
    }
    [HttpGet("/menus/delete")]
    public ActionResult DeleteAll()
    {
      Menu.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/menus/{menuId}/edit")]
    public ActionResult Edit(int menuId)
    {
      Menu menu = Menu.Find(menuId);
      List<MenuItem> menuItems = menu.GetMenuItems();
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("menu", menu);
      model.Add("menuItems", menuItems);
      return View(model);
    }
    [HttpPost("/menus/{menuId}/edit")]
    public ActionResult Update(int menuId, string menuTheme)
    {
      Menu menu = Menu.Find(menuId);
      menu.Edit(menuTheme);
      return RedirectToAction("Index");
    }
  }
}
