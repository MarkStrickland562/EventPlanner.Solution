using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using EventPlanner.Models;

namespace EventPlanner.Controllers
{
  public class StoresController : Controller
  {
    [HttpGet("/stores")]
    public ActionResult Index()
    {
      List<Store> allStores = Store.GetAll();
      return View(allStores);
    }

    [HttpGet("/stores/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/stores/new")]
    public ActionResult Create(string storeName)
    {
      Store newStore = new Store(storeName);
      newStore.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stores/{storeId}")]
    public ActionResult Show(int storeId)
    {
      Store store = Store.Find(storeId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("stores", store);
      return View(model);
    }

    [HttpGet("/stores/{storeId}/delete")]
    public ActionResult Delete(int storeId)
    {
      Store store = Store.Find(storeId);
      store.Delete();
      return RedirectToAction("Index");
    }
    [HttpGet("/stores/delete")]
    public ActionResult DeleteAll()
    {
      Store.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/stores/{storeId}/edit")]
    public ActionResult Edit(int storeId)
    {
      Store store = Store.Find(storeId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("stores", store);
      return View(model);
    }
    [HttpPost("/stores/{storeId}/edit")]
    public ActionResult Update(int storeId, string storeName)
    {
      Store store = Store.Find(storeId);
      store.Edit(storeName);
      return RedirectToAction("Index");
    }
  }
}
