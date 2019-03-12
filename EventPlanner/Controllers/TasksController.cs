// using System.Collections.Generic;
// using System;
// using Microsoft.AspNetCore.Mvc;
// using EventPlanner.Models;
//
// namespace EventPlanner.Controllers
// {
//   public class TasksController : Controller
//   {
//     [HttpGet("/tasks")]
//     public ActionResult Index()
//     {
//       List<Task> allTasks = Task.GetAll();
//       return View(allTasks);
//     }
//
//     [HttpGet("/tasks/new")]
//     public ActionResult New()
//     {
//       return View();
//     }
//     [HttpPost("/tasks/new")]
//     public ActionResult Create(string taskDescription, DateTime taskPlannedStartDateTime)
//     {
//       Task newTask = new Task(taskDescription, taskPlannedStartDateTime);
//       newTask.Save();
//       return RedirectToAction("Index");
//     }
//
//     [HttpGet("/tasks/{taskId}")]
//     public ActionResult Show(int taskId)
//     {
//       Task task = Task.Find(taskId);
//       Task events = Task.GetEvents(eventId);
//       Dictionary<string, object> model = new Dictionary<string, object>();
//       model.Add("task", task);
//       model.Add("events", events);
//       return View(model);
//     }
//
//     [HttpPost("/tasks/{taskId}/event/new")]
//     public ActionResult AddEvent(int taskId, int eventId)
//     {
//       Task task = Task.Find(taskId);
//       task.AddEvent(Event.Find(eventId));
//       return RedirectToAction("Show");
//     }
//     [HttpPost("/tasks/{taskId}/event/new")]
//     public ActionResult DeleteEvent(int taskId, int eventId)
//     {
//       Task task = Task.Find(taskId);
//       task.DeleteEvent(Event.Find(eventId));
//       return RedirectToAction("Show");
//     }
//
//     [HttpPost("/tasks/{taskId}/delete")]
//     public ActionResult Delete(int taskId)
//     {
//       Task.Delete(taskId);
//       return RedirectToAction("Index");
//     }
//     [HttpPost("/tasks/delete")]
//     public ActionResult DeleteAll()
//     {
//       Task.DeleteAll();
//       return RedirectToAction("Index");
//     }
//
//     [HttpGet("/tasks/{taskId}/edit")]
//     public ActionResult Edit(int taskId)
//     {
//       Task task = Task.Find(taskId);
//       Dictionary<string, object> model = new Dictionary<string, object>();
//       model.Add("Task", task);
//       return View(model);
//     }
//     [HttpPost("/tasks/{taskId}/edit")]
//     public ActionResult Update(int taskId, string taskDescription, DateTime taskPlannedStartDateTime)
//     {
//       Task task = Task.Find(taskId);
//       task.Edit(taskId, taskDescription, taskPlannedStartDateTime);
//       return RedirectToAction("Index");
//     }
//   }
// }
