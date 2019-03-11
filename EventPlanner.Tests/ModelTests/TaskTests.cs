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

    // [TestMethod]
    // public void GetTasks_RetrievesAllTasksWithTask_TaskList()
    // {
    //   //Arrange, Act
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Task newTask = new Task(name, hireDate);
    //   newTask.Save();
    //
    //   string name1 = "Tom Jones";
    //   string gender1 = "Male";
    //   int TaskId1 = newTask.GetId();
    //   Task newTask1 = new Task(name1, gender1, TaskId1);
    //   newTask1.Save();
    //
    //   string name2 = "Jane Doe";
    //   string gender2 = "Female";
    //   int TaskId2 = newTask.GetId();
    //   Task newTask2 = new Task(name2, gender2, TaskId2);
    //   newTask2.Save();
    //
    //   List<Task> newList = new List<Task> { newTask1, newTask2 };
    //
    //   List<Task> resultList = newTask.GetTasks();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(newList, resultList);
    // }
    //
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

    // [TestMethod]
    // public void Save_SavesTaskTaskToDatabase_TaskList()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Task newTask = new Task(name, hireDate);
    //   newTask.Save();
    //   string Task = "Colorist";
    //   Task newTask = new Task(Task);
    //   newTask.Save();
    //
    //   //Act
    //   Task foundTask = Task.Find(newTask.GetId());
    //   Task foundTask = Task.Find(newTask.GetId());
    //   foundTask.AddTask(foundTask);
    //
    //   List<Task> result = newTask.GetTasks();
    //   List<Task> testList = new List<Task>{foundTask};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void GetTasks_RetrievesAllTasksForATask_TaskList()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Task newTask = new Task(name, hireDate);
    //   newTask.Save();
    //   string Task1 = "Colorist";
    //   Task newTask1 = new Task(Task1);
    //   newTask1.Save();
    //   string Task2 = "Barber";
    //   Task newTask2 = new Task(Task2);
    //   newTask2.Save();
    //   //Act
    //   Task foundTask = Task.Find(newTask.GetId());
    //   Task foundTask1 = Task.Find(newTask1.GetId());
    //   Task foundTask2 = Task.Find(newTask2.GetId());
    //   foundTask.AddTask(foundTask1);
    //   foundTask.AddTask(foundTask2);
    //
    //   List<Task> result = newTask.GetTasks();
    //   List<Task> testList = new List<Task>{foundTask1, foundTask2};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
  }
}
