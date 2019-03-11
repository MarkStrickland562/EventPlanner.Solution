using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MenuPlanner.Models;

namespace MenuPlanner.Controllers
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
      Menu menuItems = Menu.GetMenuItems(menuId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("menu", menu);
      model.Add("menuItems", menuItems);
      return View(model);
    }

    [HttpPost("/menus/{menuId}/menuItem/new")]
    public ActionResult AddMenuItem(int menuId, int menuItemId)
    {
      Menu menu = Menu.Find(menuId);
      menu.AddMenuItem(MenuItem.Find(menuItemId));
      return RedirectToAction("Show");
    }
    [HttpPost("/menus/{menuId}/menuItem/delete")]
    public ActionResult DeleteMenuItem(int menuId, int menuItemId)
    {
      Menu menu = Menu.Find(menuId);
      menu.DeleteMenuItem(MenuItem.Find(menuItemId));
      return RedirectToAction("Show");
    }

    [HttpPost("/menus/{menuId}/delete")]
    public ActionResult Delete(int menuId)
    {
      Menu.Delete(menuId);
      return RedirectToAction("Index");
    }
    [HttpPost("/menus/delete")]
    public ActionResult DeleteAll()
    {
      Menu.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/menus/{menuId}/edit")]
    public ActionResult Edit(int menuId)
    {
      Menu menu = Menu.Find(menuId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("Menu", menu);
      return View(model);
    }
    [HttpGet("/menus/{menuId}/edit")]
    public ActionResult Update(int menuId, string menuTheme)
    {
      Menu menu = Menu.Find(menuId);
      menu.Edit(menuId, menuTheme);
      return RedirectToAction("Index");
    }
  }
}
