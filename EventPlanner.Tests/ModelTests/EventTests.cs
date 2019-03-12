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

    [TestMethod]
    public void GetTasks_RetrievesAllTasksWithEvent_TaskList()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
      newEvent.Save();

      string taskDescription1 = "Setup Tables";
      DateTime taskPlannedStartDateTime1 = new DateTime(2019, 04, 04);
      Task newTask1 = new Task(taskDescription1, taskPlannedStartDateTime1);
      newTask1.Save();

      string taskDescription2 = "Ice Drinks";
      DateTime taskPlannedStartDateTime2 = new DateTime(2019, 04, 04);
      Task newTask2 = new Task(taskDescription2, taskPlannedStartDateTime2);
      newTask2.Save();

      //Act
      Event foundEvent = Event.Find(newEvent.GetId());
      Task foundTask1 = Task.Find(newTask1.GetId());
      Task foundTask2 = Task.Find(newTask2.GetId());
      foundEvent.AddTask(foundTask1);
      foundEvent.AddTask(foundTask2);

      List<Task> newList = new List<Task> { newTask1, newTask2 };

      //Act
      List<Task> resultList = foundEvent.GetTasks();

      //Assert
      CollectionAssert.AreEqual(newList, resultList);
    }

    [TestMethod]
    public void GetInvitees_RetrievesAllInviteesWithEvent_InviteeList()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
      newEvent.Save();

      string inviteeName1 = "Jane Doe";
      string inviteeEmailAddress1 = "janedoe@mail.com";
      Invitee newInvitee1 = new Invitee(inviteeName1, inviteeEmailAddress1);
      newInvitee1.Save();

      string inviteeName2 = "John Smith";
      string inviteeEmailAddress2 = "johnsmith@yahoo.com";
      Invitee newInvitee2 = new Invitee(inviteeName2, inviteeEmailAddress2);
      newInvitee2.Save();

      //Act
      Event foundEvent = Event.Find(newEvent.GetId());
      Invitee foundInvitee1 = Invitee.Find(newInvitee1.GetId());
      Invitee foundInvitee2 = Invitee.Find(newInvitee2.GetId());
      foundEvent.AddInvitee(foundInvitee1);
      foundEvent.AddInvitee(foundInvitee2);

      List<Invitee> newList = new List<Invitee> { newInvitee1, newInvitee2 };

      //Act
      List<Invitee> resultList = foundEvent.GetInvitees();

      //Assert
      CollectionAssert.AreEqual(newList, resultList);
    }

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

    [TestMethod]
    public void DeleteAll_DeletesAllEventsFromDatabase()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
      newEvent.Save();
      Event.DeleteAll();

      //Act
      List<Event> newList = new List<Event> { newEvent };
      List<Event> resultList = Event.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void Edit_UpdatesEventToDatabase()
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
      string newName = "Birthday Party";
      DateTime newEventDate = new DateTime(2019, 05, 03);
      string newEventLocation = "Saltys";
      int newMenusId = 2;
      foundEvent.Edit(newName, newEventDate, newEventLocation, newMenusId);
      Event updatedEvent = Event.Find(newEvent.GetId());

      List<Event> result = Event.GetAll();
      List<Event> testList = new List<Event>{updatedEvent};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_SavesEventTaskToDatabase_TaskList()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
      newEvent.Save();

      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);
      newTask.Save();

      //Act
      Event foundEvent = Event.Find(newEvent.GetId());
      Task foundTask = Task.Find(newTask.GetId());
      foundEvent.AddTask(foundTask);

      List<Task> result = newEvent.GetTasks();
      List<Task> testList = new List<Task>{foundTask};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Delete_DeletesTaskFromEventFromDatabase()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
      newEvent.Save();

      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);
      newTask.Save();

      //Act
      Event foundEvent = Event.Find(newEvent.GetId());
      Task foundTask = Task.Find(newTask.GetId());
      foundEvent.AddTask(foundTask);

      List<Task> testList = new List<Task>{foundTask};
      foundEvent.DeleteTask(foundTask);
      List<Task> result = foundEvent.GetTasks();

      //Assert
      CollectionAssert.AreNotEqual(testList, result);
    }

    [TestMethod]
    public void Save_SavesEventInviteeToDatabase_InviteeList()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
      newEvent.Save();

      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);
      newInvitee.Save();

      //Act
      Event foundEvent = Event.Find(newEvent.GetId());
      Invitee foundInvitee = Invitee.Find(newInvitee.GetId());
      foundEvent.AddInvitee(foundInvitee);

      List<Invitee> result = newEvent.GetInvitees();
      List<Invitee> testList = new List<Invitee>{foundInvitee};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Delete_DeletesInviteeFromEventFromDatabase()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";
      int menusId = 1;
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
      newEvent.Save();

      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);
      newInvitee.Save();

      //Act
      Event foundEvent = Event.Find(newEvent.GetId());
      Invitee foundInvitee = Invitee.Find(newInvitee.GetId());
      foundEvent.AddInvitee(foundInvitee);

      List<Invitee> testList = new List<Invitee>{foundInvitee};
      foundEvent.DeleteInvitee(foundInvitee);
      List<Invitee> result = foundEvent.GetInvitees();

      //Assert
      CollectionAssert.AreNotEqual(testList, result);
    }

    [TestMethod]
    public void GetMenu_RetrievesEventMenuFromDatabase_MenuList()
    {
      //Arrange
      string menuTheme = "BBQ";
      Menu newMenu = new Menu(menuTheme);
      newMenu.Save();
      int menusId = newMenu.GetId();

      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 04, 04);
      string eventLocation = "Capitol Hill";

      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
      newEvent.Save();

      //Act
      Event foundEvent = Event.Find(newEvent.GetId());
      Menu foundMenu = Menu.Find(newMenu.GetId());
      List<Menu> result = foundEvent.GetMenu();
      List<Menu> testList = new List<Menu>{foundMenu};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
  }
}
