using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventPlanner.Models;
using System.Collections.Generic;
using System;

namespace EventPlanner.Tests
{
  [TestClass]
  public class TaskTest : IDisposable
  {
    public TaskTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
    }

    public void Dispose()
    {
      Task.ClearAll();
    }
    [TestMethod]
    public void TaskConstructor_CreatesInstanceOfTask_Task()
    {
      //Arrange, Act
      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);

      //Assert
      Assert.AreEqual(typeof(Task), newTask.GetType());
    }

    [TestMethod]
    public void GetTaskDescription_ReturnsTaskDescription_String()
    {
      //Arrange
      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);

      //Act
      string result = newTask.GetTaskDescription();

      //Assert
      Assert.AreEqual(taskDescription, result);
    }

    [TestMethod]
    public void SetTaskName_SetTaskName_String()
    {
      //Arrange
      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);

      //Act
      string updatedTaskDescription = "Get Ice";
      newTask.SetTaskDescription(updatedTaskDescription);
      string result = newTask.GetTaskDescription();

      //Assert
      Assert.AreEqual(updatedTaskDescription, result);
    }

    [TestMethod]
    public void GetTaskPlannedStartDateTime_ReturnsTaskPlannedStartDateTime_DateTime()
    {
      //Arrange
      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);

      //Act
      DateTime result = newTask.GetTaskPlannedStartDateTime();

      //Assert
      Assert.AreEqual(taskPlannedStartDateTime, result);
    }

    [TestMethod]
    public void SetTaskPlannedStartDateTime_SetTaskPlannedStartDateTime_DateTime()
    {
      //Arrange
      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);

      //Act
      DateTime updatedTaskPlannedStartDateTime = new DateTime(2019, 05, 03);
      newTask.SetTaskPlannedStartDateTime(updatedTaskPlannedStartDateTime);
      DateTime result = newTask.GetTaskPlannedStartDateTime();

      //Assert
      Assert.AreEqual(updatedTaskPlannedStartDateTime, result);
    }

    [TestMethod]
    public void GetId_ReturnsTaskId_Int()
    {
      //Arrange
      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);

      //Act
      int result = newTask.GetId();

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SavesTaskToDatabase_TaskList()
    {
      //Arrange
      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);
      newTask.Save();

      //Act
      List<Task> result = Task.GetAll();
      List<Task> testList = new List<Task>{newTask};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllTaskObjects_TaskList()
    {
      //Arrange
      string taskDescription1 = "Setup Tables";
      DateTime taskPlannedStartDateTime1 = new DateTime(2019, 04, 04);
      Task newTask1 = new Task(taskDescription1, taskPlannedStartDateTime1);
      newTask1.Save();

      string taskDescription2 = "Ice Drinks";
      DateTime taskPlannedStartDateTime2 = new DateTime(2019, 04, 04);
      Task newTask2 = new Task(taskDescription2, taskPlannedStartDateTime2);
      newTask2.Save();

      List<Task> newList = new List<Task> { newTask1, newTask2};

      //Act
      List<Task> result = Task.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsTaskInDatabase_Task()
    {
      //Arrange
      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);
      newTask.Save();

      //Act
      Task foundTask = Task.Find(newTask.GetId());

      //Assert
      Assert.AreEqual(newTask, foundTask);
    }

    [TestMethod]
    public void GetEvents_RetrievesAllEventsWithTask_EventList()
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

      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);
      newTask.Save();

      //Act
      Event foundEvent1 = Event.Find(newEvent1.GetId());
      Event foundEvent2 = Event.Find(newEvent2.GetId());
      Task foundTask = Task.Find(newTask.GetId());

      foundTask.AddEvent(foundEvent1);
      foundTask.AddEvent(foundEvent2);

      List<Event> newList = new List<Event> { newEvent1, newEvent2 };
      List<Event> resultList = foundTask.GetEvents();

      //Assert
      CollectionAssert.AreEqual(newList, resultList);
    }

    [TestMethod]
    public void Delete_DeletesTaskFromDatabase()
    {
      //Arrange
      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);
      newTask.Save();
      newTask.Delete();

      //Act
      List<Task> newList = new List<Task> { newTask };
      List<Task> resultList = Task.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void DeleteAll_DeletesAllTasksFromDatabase()
    {
      //Arrange
      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);
      newTask.Save();
      Task.DeleteAll();

      //Act
      List<Task> newList = new List<Task> { newTask };
      List<Task> resultList = Task.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void Edit_UpdatesTaskToDatabase()
    {
      //Arrange
      string taskDescription = "Setup Tables";
      DateTime taskPlannedStartDateTime = new DateTime(2019, 04, 04);
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime);
      newTask.Save();

      //Act
      Task foundTask = Task.Find(newTask.GetId());
      string newTaskDescription = "Get Ice";
      DateTime newTaskPlannedStartDateTime = new DateTime(2019, 05, 03);
      foundTask.Edit(newTaskDescription, newTaskPlannedStartDateTime);
      Task updatedTask = Task.Find(newTask.GetId());

      List<Task> result = Task.GetAll();
      List<Task> testList = new List<Task>{updatedTask};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_SavesEventTaskToDatabase_EventList()
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
      foundTask.AddEvent(foundEvent);

      List<Event> result = foundTask.GetEvents();
      List<Event> testList = new List<Event>{foundEvent};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Delete_DeletesEventTaskFromDatabase()
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
      foundTask.AddEvent(foundEvent);

      List<Event> result = foundTask.GetEvents();
      foundTask.DeleteEvent(foundEvent);
      List<Event> testList = foundTask.GetEvents();

      //Assert
      CollectionAssert.AreNotEqual(testList, result);
    }
  }
}
