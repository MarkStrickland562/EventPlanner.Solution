// using System.Collections.Generic;
// using System;
// using Microsoft.AspNetCore.Mvc;
// using EventPlanner.Models;
//
// namespace EventPlanner.Controllers
// {
//   public class MenuIitemIngredientsController : Controller
//   {
//     [HttpGet("/menuItemIngredients")]
//     public ActionResult Index()
//     {
//       List<MenuItemIngredient> allMenuItemIngredients = MenuItemIngredient.GetAll();
//       return View(allMenuItemIngredients);
//     }
//
//     [HttpGet("/menuItemIngredients/new")]
//     public ActionResult New()
//     {
//       return View();
//     }
//     [HttpPost("/menuItemIngredients/new")]
//     public ActionResult Create(string ingredientDescription, int menuItemId, int storeId)
//     {
//       MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(ingredientDescription, menuItemId, storeId);
//       newMenuItemIngredient.Save();
//       return RedirectToAction("Index");
//     }
//
//     [HttpGet("/menuItemIngredients/{menuItemIngredientId}")]
//     public ActionResult Show(int menuItemIngredientId)
//     {
//       MenuItemIngredient menuItemIngredient = MenuItemIngredient.Find(menuItemIngredientId);
//       MenuItemIngredient menuItems = MenuItemIngredient.GetMenuItem(menuItemIngredientId);
//       Dictionary<string, object> model = new Dictionary<string, object>();
//       model.Add("menuItemIngredient", menuItemIngredient);
//       model.Add("menuItems", menuItems);
//       return View(model);
//     }
//
//     [HttpPost("/menuItemIngredients/{menuItemIngredientId}/items/new")]
//     public ActionResult AddMenuItem(int menuItemIngredientId, int menuItemId)
//     {
//       MenuItemIngredient menuItemIngredient = MenuItemIngredient.Find(menuItemIngredientId);
//       menuItemIngredient.AddMenuItem(Menu.Find(menuItemId));
//       return RedirectToAction("Show");
//     }
//     [HttpPost("/menuItemIngredients/{menuItemIngredientId}/items/new")]
//     public ActionResult DeleteMenuItem(int menuItemIngredientId, int menuItemId)
//     {
//       MenuItemIngredient menuItemIngredient = MenuItemIngredient.Find(menuItemIngredientId);
//       menuItemIngredient.DeleteMenuItem(Menu.Find(menuItemId));
//       return RedirectToAction("Show");
//     }
//
//     [HttpPost("/menuItemIngredients/{menuItemIngredientId}/delete")]
//     public ActionResult Delete(int menuItemIngredientId)
//     {
//       MenuItemIngredient.Delete(menuItemIngredientId);
//       return RedirectToAction("Index");
//     }
//     [HttpPost("/menuItemIngredients/delete")]
//     public ActionResult DeleteAll()
//     {
//       MenuItemIngredient.DeleteAll();
//       return RedirectToAction("Index");
//     }
//
//     [HttpGet("/menuItemIngredients/{menuItemIngredientId}/edit")]
//     public ActionResult Edit(int menuItemIngredientId)
//     {
//       MenuItemIngredient menuItemIngredient = MenuItemIngredient.Find(menuItemIngredientId);
//       Dictionary<string, object) model = new Dictionary<string, object>();
//       model.Add("menuItemIngredient", menuItemIngredient);
//       return View(model);
//     }
//     [HttpPost("/menuItemIngredients/{menuItemIngredientId}/edit")]
//     public ActionResult Update(int menuItemIngredientId, string ingredientDescription, int menuItemId, int storeId)
//     {
//       MenuItemIngredient menuItemIngredient = Menu.Find(menuItemIngredientId);
//       menuItemIngredient.Edit(menuItemIngredientId, ingredientDescription, menuItemId, storeId);
//       return RedirectToAction("Index");
//     }
//   }
// }
