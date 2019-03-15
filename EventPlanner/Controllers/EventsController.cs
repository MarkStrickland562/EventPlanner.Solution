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
      List<Event> allEvents = Event.GetAll();
      return View(allEvents);
    }

    [HttpGet("/events/new")]
    public ActionResult New()
    {
      List<Menu> allMenus = Menu.GetAll();
      return View(allMenus);
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
      Event selectedEvent = Event.Find(eventId);
      Menu eventMenu = Menu.Find(selectedEvent.GetMenusId());
      List<Task> tasks = selectedEvent.GetTasks();
      List<Invitee> invitees = selectedEvent.GetInvitees();
      List<Task> allTasks = Task.GetAll();
      List<Invitee> allInvitees = Invitee.GetAll();
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("selectedEvent", selectedEvent);
      model.Add("tasks", tasks);
      model.Add("invitees", invitees);
      model.Add("eventMenu", eventMenu);
      model.Add("allInvitees", allInvitees);
      model.Add("allTasks", allTasks);
      return View(model);
    }

    [HttpPost("/events/{eventId}/tasks/new")]
    public ActionResult AddTask(int eventId, int taskId)
    {
      Event selectedEvent = Event.Find(eventId);
      selectedEvent.AddTask(Task.Find(taskId));
      return RedirectToAction("Show");
    }
    [HttpGet("/events/{eventId}/tasks/{tasksId}/delete")]
    public ActionResult DeleteTask(int eventId, int tasksId)
    {
      Event selectedEvent = Event.Find(eventId);
      selectedEvent.DeleteTask(Task.Find(tasksId));
      return RedirectToAction("Show");
    }

    [HttpPost("/events/{eventId}/invitees/new")]
    public ActionResult AddInvitee(int eventId, int inviteeId)
    {
      Event selectedEvent = Event.Find(eventId);
      selectedEvent.AddInvitee(Invitee.Find(inviteeId));
      return RedirectToAction("Show");
    }
    [HttpGet("/events/{eventId}/invitees/{inviteesId}/delete")]
    public ActionResult DeleteInvitee(int eventId, int inviteesId)
    {
      Event selectedEvent = Event.Find(eventId);
      selectedEvent.DeleteInvitee(Invitee.Find(inviteesId));
      return RedirectToAction("Show");
    }

    [HttpGet("/events/{eventId}/delete")]
    public ActionResult Delete(int eventId)
    {
      Event selectedEvent = Event.Find(eventId);
      selectedEvent.Delete();
      return RedirectToAction("Index");
    }

    [HttpGet("/events/delete")]
    public ActionResult DeleteAll()
    {
      Event.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/events/{eventId}/edit")]
    public ActionResult Edit(int eventId)
    {
      Event selectedEvent = Event.Find(eventId);
      Menu eventMenu = Menu.Find(selectedEvent.GetMenusId());
      List<Menu> allMenus = Menu.GetAll();
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("selectedEvent", selectedEvent);
      model.Add("eventMenu", eventMenu);
      model.Add("allMenus", allMenus);
      return View(model);

    }
    [HttpPost("/events/{eventId}/edit")]
    public ActionResult Update(int eventId, string name, DateTime eventDate, string eventLocation, int menuId)
    {
      Event selectedEvent = Event.Find(eventId);
      selectedEvent.Edit(name, eventDate, eventLocation, menuId);
      return RedirectToAction("Index");
    }
  }
}
