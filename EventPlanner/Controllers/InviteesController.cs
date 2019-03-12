// using System.Collections.Generic;
// using System;
// using Microsoft.AspNetCore.Mvc;
// using EventPlanner.Models;
//
// namespace EventPlanner.Controllers
// {
//   public class InviteesController : Controller
//   {
//     [HttpGet("/invitees")]
//     public ActionResult Index()
//     {
//       List<Invitee> allInvitees = Invitee.GetAll();
//       return View(allInvitees);
//     }
//
//     [HttpGet("/invitees/new")]
//     public ActionResult New()
//     {
//       return View();
//     }
//     [HttpPost("/invitees/new")]
//     public ActionResult Create(string inviteeName, string inviteeEmailAddress)
//     {
//       Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);
//       newInvitee.Save();
//       return RedirectToAction("Index");
//     }
//
//     [HttpGet("/invitees/{inviteeId}")]
//     public ActionResult Show(int inviteeId)
//     {
//       Invitee invitee = Invitee.Find(inviteeId);
//       Invitee events = Invitee.GetEvents(eventId);
//       Dictionary<string, object> model = new Dictionary<string, object>();
//       model.Add("invitee", invitee);
//       model.Add("events", events);
//       return View(model);
//     }
//
//     [HttpPost("/invitees/{inviteeId}/event/new")]
//     public ActionResult AddEvent(int inviteeId, int eventId)
//     {
//       Invitee invitee = Invitee.Find(inviteeId);
//       invitee.AddEvent(Event.Find(eventId));
//       return RedirectToAction("Show");
//     }
//     [HttpPost("/invitees/{inviteeId}/event/new")]
//     public ActionResult DeleteEvent(int inviteeId, int eventId)
//     {
//       Invitee invitee = Invitee.Find(inviteeId);
//       invitee.DeleteEvent(Event.Find(eventId));
//       return RedirectToAction("Show");
//     }
//
//     [HttpPost("/invitees/{inviteeId}/delete")]
//     public ActionResult Delete(int inviteeId)
//     {
//       Invitee.Delete(inviteeId);
//       return RedirectToAction("Index");
//     }
//     [HttpPost("/invitees/delete")]
//     public ActionResult DeleteAll()
//     {
//       Invitee.DeleteAll();
//       return RedirectToAction("Index");
//     }
//
//     [HttpGet("/invitees/{inviteeId}/edit")]
//     public ActionResult Edit(int inviteeId)
//     {
//       Invitee invitee = Invitee.Find(inviteeId);
//       Dictionary<string, object> model = new Dictionary<string, object>();
//       model.Add("Invitee", invitee);
//       return View(model);
//     }
//     [HttpPost("/invitees/{inviteeId}/edit")]
//     public ActionResult Update(int inviteeId, string inviteeName, string inviteeEmailAddress)
//     {
//       Invitee invitee = Invitee.Find(inviteeId);
//       invitee.Edit(inviteeId, inviteeName, inviteeEmailAddress);
//       return RedirectToAction("Index");
//     }
//   }
// }
