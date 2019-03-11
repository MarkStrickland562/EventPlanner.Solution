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

    //[TestMethod]
    // public void SetName_SetName_String()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Stylist newStylist = new Stylist(name, hireDate);
    //
    //   //Act
    //   string updatedName = "Sharon Smith";
    //   newStylist.SetName(updatedName);
    //   string result = newStylist.GetName();
    //
    //   //Assert
    //   Assert.AreEqual(updatedName, result);
    // }

    // [TestMethod]
    // public void GetHireDate_ReturnsHireDate_DateTime()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Stylist newStylist = new Stylist(name, hireDate);
    //
    //   //Act
    //   DateTime result = newStylist.GetHireDate();
    //
    //   //Assert
    //   Assert.AreEqual(hireDate, result);
    // }
    //
    // [TestMethod]
    // public void SetHireDate_SetHireDate_DateTime()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Stylist newStylist = new Stylist(name, hireDate);
    //
    //   //Act
    //   DateTime updatedHireDate = new DateTime(2019, 02, 28);
    //   newStylist.SetHireDate(updatedHireDate);
    //   DateTime result = newStylist.GetHireDate();
    //
    //   //Assert
    //   Assert.AreEqual(updatedHireDate, result);
    // }
    //
    // [TestMethod]
    // public void Save_SavesStylistToDatabase_StylistList()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Stylist newStylist = new Stylist(name, hireDate);
    //   newStylist.Save();
    //
    //   //Act
    //   List<Stylist> result = Stylist.GetAll();
    //   List<Stylist> testList = new List<Stylist>{newStylist};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void GetAll_ReturnsAllStylistObjects_StylistList()
    // {
    //   //Arrange
    //   string name1 = "Betty Clark";
    //   DateTime hireDate1 = new DateTime(2019, 01, 01);
    //   Stylist newStylist1 = new Stylist(name1, hireDate1);
    //   newStylist1.Save();
    //
    //   string name2 = "Sharon Smith";
    //   DateTime hireDate2 = new DateTime(2019, 02, 28);
    //   Stylist newStylist2 = new Stylist(name2, hireDate2);
    //   newStylist2.Save();
    //
    //   List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2};
    //
    //   //Act
    //   List<Stylist> result = Stylist.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(newList, result);
    // }
    //
    // [TestMethod]
    // public void Find_ReturnsStylistInDatabase_Stylist()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Stylist newStylist = new Stylist(name, hireDate);
    //   newStylist.Save();
    //
    //   //Act
    //   Stylist foundStylist = Stylist.Find(newStylist.GetId());
    //
    //   //Assert
    //   Assert.AreEqual(newStylist, foundStylist);
    // }
    //
    // [TestMethod]
    // public void GetClients_RetrievesAllClientsWithStylist_ClientList()
    // {
    //   //Arrange, Act
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Stylist newStylist = new Stylist(name, hireDate);
    //   newStylist.Save();
    //
    //   string name1 = "Tom Jones";
    //   string gender1 = "Male";
    //   int stylistId1 = newStylist.GetId();
    //   Client newClient1 = new Client(name1, gender1, stylistId1);
    //   newClient1.Save();
    //
    //   string name2 = "Jane Doe";
    //   string gender2 = "Female";
    //   int stylistId2 = newStylist.GetId();
    //   Client newClient2 = new Client(name2, gender2, stylistId2);
    //   newClient2.Save();
    //
    //   List<Client> newList = new List<Client> { newClient1, newClient2 };
    //
    //   List<Client> resultList = newStylist.GetClients();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(newList, resultList);
    // }
    //
    // [TestMethod]
    // public void Delete_DeletesStylistFromDatabase()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Stylist newStylist = new Stylist(name, hireDate);
    //   newStylist.Save();
    //   newStylist.Delete();
    //
    //   //Act
    //   List<Stylist> newList = new List<Stylist> { newStylist };
    //   List<Stylist> resultList = Stylist.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreNotEqual(newList, resultList);
    // }
    //
    // [TestMethod]
    // public void DeleteAll_DeletesAllStylistsFromDatabase()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Stylist newStylist = new Stylist(name, hireDate);
    //   newStylist.Save();
    //   Stylist.DeleteAll();
    //
    //   //Act
    //   List<Stylist> newList = new List<Stylist> { newStylist };
    //   List<Stylist> resultList = Stylist.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreNotEqual(newList, resultList);
    // }
    //
    // [TestMethod]
    // public void Edit_UpdatesStylistToDatabase()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Stylist newStylist = new Stylist(name, hireDate);
    //   newStylist.Save();
    //
    //   //Act
    //   Stylist foundStylist = Stylist.Find(newStylist.GetId());
    //   string newName = "Betty C. Clark";
    //   DateTime newHireDate = new DateTime(2019, 02, 28);
    //   foundStylist.Edit(newName, newHireDate);
    //   Stylist updatedStylist = Stylist.Find(newStylist.GetId());
    //
    //   List<Stylist> result = Stylist.GetAll();
    //   List<Stylist> testList = new List<Stylist>{foundStylist};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void Save_SavesStylistSpecialtyToDatabase_SpecialtyList()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Stylist newStylist = new Stylist(name, hireDate);
    //   newStylist.Save();
    //   string specialty = "Colorist";
    //   Specialty newSpecialty = new Specialty(specialty);
    //   newSpecialty.Save();
    //
    //   //Act
    //   Stylist foundStylist = Stylist.Find(newStylist.GetId());
    //   Specialty foundSpecialty = Specialty.Find(newSpecialty.GetId());
    //   foundStylist.AddSpecialty(foundSpecialty);
    //
    //   List<Specialty> result = newStylist.GetSpecialties();
    //   List<Specialty> testList = new List<Specialty>{foundSpecialty};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void GetSpecialties_RetrievesAllSpecialtiesForAStylist_SpecialtyList()
    // {
    //   //Arrange
    //   string name = "Betty Clark";
    //   DateTime hireDate = new DateTime(2019, 01, 01);
    //   Stylist newStylist = new Stylist(name, hireDate);
    //   newStylist.Save();
    //   string specialty1 = "Colorist";
    //   Specialty newSpecialty1 = new Specialty(specialty1);
    //   newSpecialty1.Save();
    //   string specialty2 = "Barber";
    //   Specialty newSpecialty2 = new Specialty(specialty2);
    //   newSpecialty2.Save();
    //   //Act
    //   Stylist foundStylist = Stylist.Find(newStylist.GetId());
    //   Specialty foundSpecialty1 = Specialty.Find(newSpecialty1.GetId());
    //   Specialty foundSpecialty2 = Specialty.Find(newSpecialty2.GetId());
    //   foundStylist.AddSpecialty(foundSpecialty1);
    //   foundStylist.AddSpecialty(foundSpecialty2);
    //
    //   List<Specialty> result = newStylist.GetSpecialties();
    //   List<Specialty> testList = new List<Specialty>{foundSpecialty1, foundSpecialty2};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
  }
}
