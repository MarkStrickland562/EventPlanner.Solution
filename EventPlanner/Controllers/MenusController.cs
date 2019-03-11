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
      List<menus> allMenus = Menu.GetAll();
      return View(allmenus);
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
      model.Add("menuItems", items);
      return View(model);
    }

    [HttpPost("/menus/{menuId}/tasks/new")]
    public ActionResult AddTask(int menuId, int taskId)
    {
      Menu Menu = Menu.Find(menuId);
      Menu.AddTask(Task.Find(taskId));
      return RedirectToAction("Show");
    }

    [HttpPost("/menus/{menuId}/tasks/delete")]
    public ActionResult DeleteTask(int menuId, int taskId)
    {
      Menu Menu = Menu.Find(menuId);
      Menu.DeleteTask(Task.Find(taskId));
      return RedirectToAction("Show");
    }

    [HttpPost("/menus/{menuId}/invitees/new")]
    public ActionResult AddInvitee(int menuId, int inviteeId)
    {
      Menu Menu = Menu.Find(menuId);
      Menu.AddTask(Invitee.Find(inviteeId));
      return RedirectToAction("Show");
    }

    [HttpPost("/menus/{menuId}/invitees/delete")]
    public ActionResult DeleteInvitee(int menuId, int inviteeId)
    {
      Menu Menu = Menu.Find(menuId);
      Menu.DeleteTask(Invitee.Find(inviteeId));
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
      Menu Menu = Menu.Find(menuId);
      Dictionary<string, object) model = new Dictionary<string, object>();
      model.Add("Menu", Menu);
      return View(model);
    }
    [HttpGet("/menus/{menuId}/edit")]
    public ActionResult Update(int menuId, string menuTheme)
    {
      Menu Menu = Menu.Find(menuId);
      Menu.Edit(menuId, menuTheme);
      return RedirectToAction("Index");
    }
  }
}
