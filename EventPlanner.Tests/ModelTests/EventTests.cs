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
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
    }

    public void Dispose()
    {
      Event.ClearAll();
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

    [TestMethod]
    public void GetEventName_ReturnsEventName_String()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);

      //Act
      string result = newEvent.GetEventName();

      //Assert
      Assert.AreEqual(eventName, result);
    }

    [TestMethod]
    public void SetEventName_SetEventName_String()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);

      //Act
      string updatedEventName = "Birthday Party";
      newEvent.SetEventName(updatedEventName);
      string result = newEvent.GetEventName();

      //Assert
      Assert.AreEqual(updatedEventName, result);
    }

    [TestMethod]
    public void GetHireDate_ReturnsHireDate_DateTime()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);

      //Act
      DateTime result = newEvent.GetEventDate();

      //Assert
      Assert.AreEqual(eventDate, result);
    }

    [TestMethod]
    public void SetEventDate_SetEventDate_DateTime()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);

      //Act
      DateTime updatedEventDate = new DateTime(2019, 05, 03);
      newEvent.SetEventDate(updatedEventDate);
      DateTime result = newEvent.GetEventDate();

      //Assert
      Assert.AreEqual(updatedEventDate, result);
    }

    [TestMethod]
    public void GetEventLocation_ReturnsEventLocation_String()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);

      //Act
      string result = newEvent.GetEventLocation();

      //Assert
      Assert.AreEqual(eventLocation, result);
    }

    [TestMethod]
    public void SetEventLocation_SetEventLocation_String()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);

      //Act
      string updatedEventLocation = "Seattle";
      newEvent.SetEventLocation(updatedEventLocation);
      string result = newEvent.GetEventLocation();

      //Assert
      Assert.AreEqual(updatedEventLocation, result);
    }

    [TestMethod]
    public void GetMenusId_ReturnsMenusId_Int()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);

      //Act
      int result = newEvent.GetMenusId();

      //Assert
      Assert.AreEqual(menusId, result);
    }

    [TestMethod]
    public void SetMenusId_SetMenusId_Int()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);

      //Act
      int updatedMenusId = 2;
      newEvent.SetMenusId(updatedMenusId);
      int result = newEvent.GetMenusId();

      //Assert
      Assert.AreEqual(updatedMenusId, result);
    }

    [TestMethod]
    public void GetId_ReturnsEventId_Int()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);

      //Act
      int result = newEvent.GetId();

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SavesEventToDatabase_EventList()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
      newEvent.Save();

      //Act
      List<Event> result = Event.GetAll();
      List<Event> testList = new List<Event>{newEvent};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllEventObjects_EventList()
    {
      //Arrange
      string eventName1 = "July 4th BBQ";
      DateTime eventDate1 = new DateTime(2019, 04, 04);
      string eventLocation1 = "Capitol Hill";
      int menusId1 = 1;
      Event newEvent1 = new Event(eventName1, eventDate1, eventLocation1, menusId1);
      newEvent1.Save();

      string eventName2 = "Birthday Party";
      DateTime eventDate2 = new DateTime(2019, 05, 03);
      string eventLocation2 = "Saltys";
      int menusId2 = 2;
      Event newEvent2 = new Event(eventName2, eventDate2, eventLocation2, menusId2);
      newEvent2.Save();

      List<Event> newList = new List<Event> { newEvent1, newEvent2};

      //Act
      List<Event> result = Event.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsEventInDatabase_Event()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
      newEvent.Save();

      //Act
      Event foundEvent = Event.Find(newEvent.GetId());

      //Assert
      Assert.AreEqual(newEvent, foundEvent);
    }

    // [TestMethod]
    // public void GetTasks_RetrievesAllTasksWithEvent_TaskList()
    // {
    //   //Arrange, Act
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Event newEvent = new Event(name, hireDate);
    //   newEvent.Save();
    //
    //   string name1 = "Tom Jones";
    //   string gender1 = "Male";
    //   int EventId1 = newEvent.GetId();
    //   Task newTask1 = new Task(name1, gender1, EventId1);
    //   newTask1.Save();
    //
    //   string name2 = "Jane Doe";
    //   string gender2 = "Female";
    //   int EventId2 = newEvent.GetId();
    //   Task newTask2 = new Task(name2, gender2, EventId2);
    //   newTask2.Save();
    //
    //   List<Task> newList = new List<Task> { newTask1, newTask2 };
    //
    //   List<Task> resultList = newEvent.GetTasks();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(newList, resultList);
    // }
    //
    [TestMethod]
    public void Delete_DeletesEventFromDatabase()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
      newEvent.Save();
      newEvent.Delete();

      //Act
      List<Event> newList = new List<Event> { newEvent };
      List<Event> resultList = Event.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }
    
    // [TestMethod]
    // public void DeleteAll_DeletesAllEventsFromDatabase()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Event newEvent = new Event(name, hireDate);
    //   newEvent.Save();
    //   Event.DeleteAll();
    //
    //   //Act
    //   List<Event> newList = new List<Event> { newEvent };
    //   List<Event> resultList = Event.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreNotEqual(newList, resultList);
    // }
    //
    // [TestMethod]
    // public void Edit_UpdatesEventToDatabase()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Event newEvent = new Event(name, hireDate);
    //   newEvent.Save();
    //
    //   //Act
    //   Event foundEvent = Event.Find(newEvent.GetId());
    //   string newName = "Betty C. Clark";
    //   DateTime newHireDate = new DateTime(2019, 02, 28);
    //   foundEvent.Edit(newName, newHireDate);
    //   Event updatedEvent = Event.Find(newEvent.GetId());
    //
    //   List<Event> result = Event.GetAll();
    //   List<Event> testList = new List<Event>{foundEvent};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void Save_SavesEventSpecialtyToDatabase_SpecialtyList()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Event newEvent = new Event(name, hireDate);
    //   newEvent.Save();
    //   string specialty = "Colorist";
    //   Specialty newSpecialty = new Specialty(specialty);
    //   newSpecialty.Save();
    //
    //   //Act
    //   Event foundEvent = Event.Find(newEvent.GetId());
    //   Specialty foundSpecialty = Specialty.Find(newSpecialty.GetId());
    //   foundEvent.AddSpecialty(foundSpecialty);
    //
    //   List<Specialty> result = newEvent.GetSpecialties();
    //   List<Specialty> testList = new List<Specialty>{foundSpecialty};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void GetSpecialties_RetrievesAllSpecialtiesForAEvent_SpecialtyList()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Event newEvent = new Event(name, hireDate);
    //   newEvent.Save();
    //   string specialty1 = "Colorist";
    //   Specialty newSpecialty1 = new Specialty(specialty1);
    //   newSpecialty1.Save();
    //   string specialty2 = "Barber";
    //   Specialty newSpecialty2 = new Specialty(specialty2);
    //   newSpecialty2.Save();
    //   //Act
    //   Event foundEvent = Event.Find(newEvent.GetId());
    //   Specialty foundSpecialty1 = Specialty.Find(newSpecialty1.GetId());
    //   Specialty foundSpecialty2 = Specialty.Find(newSpecialty2.GetId());
    //   foundEvent.AddSpecialty(foundSpecialty1);
    //   foundEvent.AddSpecialty(foundSpecialty2);
    //
    //   List<Specialty> result = newEvent.GetSpecialties();
    //   List<Specialty> testList = new List<Specialty>{foundSpecialty1, foundSpecialty2};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
  }
}
