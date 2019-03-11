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
//      Task.ClearAll();
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

    // [TestMethod]
    // public void SetTaskDate_SetTaskDate_DateTime()
    // {
    //   //Arrange
    //   string TaskName = "July 4th BBQ";
    //   DateTime TaskDate = new DateTime(2019, 04, 04);
    //   string TaskLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId);
    //
    //   //Act
    //   DateTime updatedTaskDate = new DateTime(2019, 05, 03);
    //   newTask.SetTaskDate(updatedTaskDate);
    //   DateTime result = newTask.GetTaskDate();
    //
    //   //Assert
    //   Assert.AreEqual(updatedTaskDate, result);
    // }
    //
    // [TestMethod]
    // public void GetTaskLocation_ReturnsTaskLocation_String()
    // {
    //   //Arrange
    //   string TaskName = "July 4th BBQ";
    //   DateTime TaskDate = new DateTime(2019, 04, 04);
    //   string TaskLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId);
    //
    //   //Act
    //   string result = newTask.GetTaskLocation();
    //
    //   //Assert
    //   Assert.AreEqual(TaskLocation, result);
    // }
    //
    // [TestMethod]
    // public void SetTaskLocation_SetTaskLocation_String()
    // {
    //   //Arrange
    //   string TaskName = "July 4th BBQ";
    //   DateTime TaskDate = new DateTime(2019, 04, 04);
    //   string TaskLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId);
    //
    //   //Act
    //   string updatedTaskLocation = "Seattle";
    //   newTask.SetTaskLocation(updatedTaskLocation);
    //   string result = newTask.GetTaskLocation();
    //
    //   //Assert
    //   Assert.AreEqual(updatedTaskLocation, result);
    // }
    //
    // [TestMethod]
    // public void GetMenusId_ReturnsMenusId_Int()
    // {
    //   //Arrange
    //   string TaskName = "July 4th BBQ";
    //   DateTime TaskDate = new DateTime(2019, 04, 04);
    //   string TaskLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId);
    //
    //   //Act
    //   int result = newTask.GetMenusId();
    //
    //   //Assert
    //   Assert.AreEqual(menusId, result);
    // }
    //
    // [TestMethod]
    // public void SetMenusId_SetMenusId_Int()
    // {
    //   //Arrange
    //   string TaskName = "July 4th BBQ";
    //   DateTime TaskDate = new DateTime(2019, 04, 04);
    //   string TaskLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId);
    //
    //   //Act
    //   int updatedMenusId = 2;
    //   newTask.SetMenusId(updatedMenusId);
    //   int result = newTask.GetMenusId();
    //
    //   //Assert
    //   Assert.AreEqual(updatedMenusId, result);
    // }
    //
    // [TestMethod]
    // public void GetId_ReturnsTaskId_Int()
    // {
    //   //Arrange
    //   string TaskName = "July 4th BBQ";
    //   DateTime TaskDate = new DateTime(2019, 04, 04);
    //   string TaskLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId);
    //
    //   //Act
    //   int result = newTask.GetId();
    //
    //   //Assert
    //   Assert.AreEqual(0, result);
    // }
    //
    // [TestMethod]
    // public void Save_SavesTaskToDatabase_TaskList()
    // {
    //   //Arrange
    //   string TaskName = "July 4th BBQ";
    //   DateTime TaskDate = new DateTime(2019, 04, 04);
    //   string TaskLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId);
    //   newTask.Save();
    //
    //   //Act
    //   List<Task> result = Task.GetAll();
    //   List<Task> testList = new List<Task>{newTask};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void GetAll_ReturnsAllTaskObjects_TaskList()
    // {
    //   //Arrange
    //   string TaskName1 = "July 4th BBQ";
    //   DateTime TaskDate1 = new DateTime(2019, 04, 04);
    //   string TaskLocation1 = "Capitol Hill";
    //   int menusId1 = 1;
    //   Task newTask1 = new Task(TaskName1, TaskDate1, TaskLocation1, menusId1);
    //   newTask1.Save();
    //
    //   string TaskName2 = "Birthday Party";
    //   DateTime TaskDate2 = new DateTime(2019, 05, 03);
    //   string TaskLocation2 = "Saltys";
    //   int menusId2 = 2;
    //   Task newTask2 = new Task(TaskName2, TaskDate2, TaskLocation2, menusId2);
    //   newTask2.Save();
    //
    //   List<Task> newList = new List<Task> { newTask1, newTask2};
    //
    //   //Act
    //   List<Task> result = Task.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(newList, result);
    // }
    //
    // [TestMethod]
    // public void Find_ReturnsTaskInDatabase_Task()
    // {
    //   //Arrange
    //   string TaskName = "July 4th BBQ";
    //   DateTime TaskDate = new DateTime(2019, 04, 04);
    //   string TaskLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId);
    //   newTask.Save();
    //
    //   //Act
    //   Task foundTask = Task.Find(newTask.GetId());
    //
    //   //Assert
    //   Assert.AreEqual(newTask, foundTask);
    // }

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
    // [TestMethod]
    // public void Delete_DeletesTaskFromDatabase()
    // {
    //   //Arrange
    //   string TaskName = "July 4th BBQ";
    //   DateTime TaskDate = new DateTime(2019, 04, 04);
    //   string TaskLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId);
    //   newTask.Save();
    //   newTask.Delete();
    //
    //   //Act
    //   List<Task> newList = new List<Task> { newTask };
    //   List<Task> resultList = Task.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreNotEqual(newList, resultList);
    // }
    //
    // [TestMethod]
    // public void DeleteAll_DeletesAllTasksFromDatabase()
    // {
    //   //Arrange
    //   string TaskName = "July 4th BBQ";
    //   DateTime TaskDate = new DateTime(2019, 04, 04);
    //   string TaskLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId);
    //   newTask.Save();
    //   Task.DeleteAll();
    //
    //   //Act
    //   List<Task> newList = new List<Task> { newTask };
    //   List<Task> resultList = Task.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreNotEqual(newList, resultList);
    // }
    //
    // [TestMethod]
    // public void Edit_UpdatesTaskToDatabase()
    // {
    //   //Arrange
    //   string TaskName = "July 4th BBQ";
    //   DateTime TaskDate = new DateTime(2019, 04, 04);
    //   string TaskLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId);
    //   newTask.Save();
    //
    //   //Act
    //   Task foundTask = Task.Find(newTask.GetId());
    //   string newName = "Birthday Party";
    //   DateTime newTaskDate = new DateTime(2019, 05, 03);
    //   string newTaskLocation = "Saltys";
    //   int newMenusId = 2;
    //   foundTask.Edit(newName, newTaskDate, newTaskLocation, newMenusId);
    //   Task updatedTask = Task.Find(newTask.GetId());
    //
    //   List<Task> result = Task.GetAll();
    //   List<Task> testList = new List<Task>{updatedTask};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }

    // [TestMethod]
    // public void Save_SavesTaskSpecialtyToDatabase_SpecialtyList()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Task newTask = new Task(name, hireDate);
    //   newTask.Save();
    //   string specialty = "Colorist";
    //   Specialty newSpecialty = new Specialty(specialty);
    //   newSpecialty.Save();
    //
    //   //Act
    //   Task foundTask = Task.Find(newTask.GetId());
    //   Specialty foundSpecialty = Specialty.Find(newSpecialty.GetId());
    //   foundTask.AddSpecialty(foundSpecialty);
    //
    //   List<Specialty> result = newTask.GetSpecialties();
    //   List<Specialty> testList = new List<Specialty>{foundSpecialty};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void GetSpecialties_RetrievesAllSpecialtiesForATask_SpecialtyList()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Task newTask = new Task(name, hireDate);
    //   newTask.Save();
    //   string specialty1 = "Colorist";
    //   Specialty newSpecialty1 = new Specialty(specialty1);
    //   newSpecialty1.Save();
    //   string specialty2 = "Barber";
    //   Specialty newSpecialty2 = new Specialty(specialty2);
    //   newSpecialty2.Save();
    //   //Act
    //   Task foundTask = Task.Find(newTask.GetId());
    //   Specialty foundSpecialty1 = Specialty.Find(newSpecialty1.GetId());
    //   Specialty foundSpecialty2 = Specialty.Find(newSpecialty2.GetId());
    //   foundTask.AddSpecialty(foundSpecialty1);
    //   foundTask.AddSpecialty(foundSpecialty2);
    //
    //   List<Specialty> result = newTask.GetSpecialties();
    //   List<Specialty> testList = new List<Specialty>{foundSpecialty1, foundSpecialty2};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
  }
}
