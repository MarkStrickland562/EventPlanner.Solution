using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using EventPlanner.Models;

namespace EventPlanner.Controllers
{
  public class EventsController : Controller
  {
    [HttpGet("/events")]
    public ActionResult Index()
    {
      List<Events> allEvents = Event.GetAll();
      return View(allEvents);
    }

    [HttpGet("/events/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/events/new")]
    public ActionResult Create(string name, DateTime eventDate, string eventLocation, int menuId)
    {
      Event newEvent = new Event(name, eventDate, eventLocation, menuId);
      newEvent.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/events/{eventId}")]
    public ActionResult Show(int eventId)
    {
      Event event = Event.Find(eventId);
      Event tasks = event.GetTasks(eventId);
      Event invitees = event.GetInvitees(eventId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("event", event);
      model.Add("tasks", tasks);
      model.Add("invitees", invitees);
      return View(model);
    }

    [HttpPost("/events/{eventId}/tasks/new")]
    public ActionResult AddTask(int eventId, int taskId)
    {
      Event event = Event.Find(eventId);
      event.AddTask(Task.Find(taskId));
      return RedirectToAction("Show");
    }

    [HttpPost("/events/{eventId}/tasks/delete")]
    public ActionResult DeleteTask(int eventId, int taskId)
    {
      Event event = Event.Find(eventId);
      event.DeleteTask(Task.Find(taskId));
      return RedirectToAction("Show");
    }

    [HttpPost("/events/{eventId}/invitees/new")]
    public ActionResult AddInvitee(int eventId, int inviteeId)
    {
      Event event = Event.Find(eventId);
      event.AddTask(Invitee.Find(inviteeId));
      return RedirectToAction("Show");
    }

    [HttpPost("/events/{eventId}/invitees/delete")]
    public ActionResult DeleteInvitee(int eventId, int inviteeId)
    {
      Event event = Event.Find(eventId);
      event.DeleteTask(Invitee.Find(inviteeId));
      return RedirectToAction("Show");
    }

    [HttpPost("/events/{eventId}/delete")]
    public ActionResult Delete(int eventId)
    {
      Event.Delete(eventId);
      return RedirectToAction("Index");
    }
    [HttpPost("/events/delete")]
    public ActionResult DeleteAll()
    {
      Event.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/events/{eventId}/edit")]
    public ActionResult Edit(int eventId)
    {
      Event event = Event.Find(eventId);
      Dictionary<string, object) model = new Dictionary<string, object>();
      model.Add("event", event);
      return View(model);
    }
    [HttpGet("/events/{eventId}/edit")]
    public ActionResult Update(int eventId, string name, string name, DateTime eventDate, string eventLocation, int menuId)
    {
      Event event = Event.Find(eventId);
      event.Edit(eventId, name, eventDate, eventLocation, menuId);
      return RedirectToAction("Index");
    }
  }
}
