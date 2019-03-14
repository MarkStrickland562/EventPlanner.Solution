using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using EventPlanner.Models;

namespace EventPlanner.Controllers
{
  public class MenuItemIngredientsController : Controller
  {
    [HttpGet("/menuItemIngredients")]
    public ActionResult Index()
    {
      List<MenuItemIngredient> allMenuItemIngredients = MenuItemIngredient.GetAll();
      return View(allMenuItemIngredients);
    }

    [HttpGet("/menuItemIngredients/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/menuItemIngredients/new")]
    public ActionResult Create(string ingredientDescription)
    {
      int menuItemId = 0;
      int storeId = 0;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(ingredientDescription, menuItemId, storeId);
      newMenuItemIngredient.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/menuItemIngredients/{menuItemIngredientId}")]
    public ActionResult Show(int menuItemIngredientId)
    {
      MenuItemIngredient menuItemIngredient = MenuItemIngredient.Find(menuItemIngredientId);
      int menuItemId = menuItemIngredient.GetMenuItemsId();
      MenuItem menuItem = MenuItem.Find(menuItemId);
      int storeId = menuItemIngredient.GetStoreId();
      Store store = Store.Find(storeId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("menuItemIngredient", menuItemIngredient);
      model.Add("menuItem", menuItem);
      model.Add("store", store);
      return View(model);
    }

    [HttpGet("/menuItemIngredients/{menuItemIngredientId}/delete")]
    public ActionResult Delete(int menuItemIngredientId)
    {
      MenuItemIngredient menuItemIngredient = MenuItemIngredient.Find(menuItemIngredientId);
      menuItemIngredient.Delete();
      return RedirectToAction("Index");
    }

    [HttpGet("/menuItemIngredients/delete")]
    public ActionResult DeleteAll()
    {
      MenuItemIngredient.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/menuItemIngredients/{menuItemIngredientId}/edit")]
    public ActionResult Edit(int menuItemIngredientId)
    {
      MenuItemIngredient menuItemIngredient = MenuItemIngredient.Find(menuItemIngredientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("menuItemIngredient", menuItemIngredient);
      return View(model);
    }

    [HttpPost("/menuItemIngredients/{menuItemIngredientId}/edit")]
    public ActionResult Update(int menuItemIngredientId, string ingredientDescription, int menuItemId, int storeId)
    {
      MenuItemIngredient menuItemIngredient = MenuItemIngredient.Find(menuItemIngredientId);
      menuItemIngredient.Edit(ingredientDescription, menuItemId, storeId);
      return RedirectToAction("Index");
    }
  }
}
