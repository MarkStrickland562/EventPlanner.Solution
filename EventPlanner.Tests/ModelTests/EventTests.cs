using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventPlanner.Models;
using System.Collections.Generic;
using System;

namespace EventPlanner.Tests
{
  [TestClass]
  public class EventTest : IDisposable
  {
    public EventTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_test;";
    }

    public void Dispose()
    {
//      Event.ClearAll();
    }

    [TestMethod]
    public void EventConstructor_CreatesInstanceOfEvent_Event()
    {
      //Arrange, Act
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);

      //Assert
      Assert.AreEqual(typeof(Event), newEvent.GetType());
    }

  }
}
