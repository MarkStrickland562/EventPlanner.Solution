using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventPlanner.Models;
using System.Collections.Generic;
using System;

namespace EventPlanner.Tests
{
  [TestClass]
  public class InviteeTest : IDisposable
  {
    public InviteeTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
    }

    public void Dispose()
    {
      Invitee.ClearAll();
    }

    [TestMethod]
    public void inviteeConstructor_CreatesInstanceOfInvitee_Invitee()
    {
      //Arrange, Act
      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);

      //Assert
      Assert.AreEqual(typeof(Invitee), newInvitee.GetType());
    }

    [TestMethod]
    public void GetInviteeName_ReturnsInviteeName_String()
    {
      //Arrange
      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);

      //Act
      string result = newInvitee.GetInviteeName();

      //Assert
      Assert.AreEqual(inviteeName, result);
    }

    [TestMethod]
    public void SetInviteeName_SetInviteeName_String()
    {
      //Arrange
      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);

      //Act
      string updatedInviteeName = "John Smith";
      newInvitee.SetInviteeName(updatedInviteeName);
      string result = newInvitee.GetInviteeName();

      //Assert
      Assert.AreEqual(updatedInviteeName, result);
    }

    [TestMethod]
    public void GetInviteeEmailAddress_ReturnsInviteeEmailAddress_String()
    {
      //Arrange
      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);

      //Act
      string result = newInvitee.GetInviteeEmailAddress();

      //Assert
      Assert.AreEqual(inviteeEmailAddress, result);
    }

    [TestMethod]
    public void SetInviteeEmailAddress_SetInviteeEmailAddress_String()
    {
      //Arrange
      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);

      //Act
      string updatedInviteeEmailAddress = "janedoe@yahoo.com";
      newInvitee.SetInviteeEmailAddress(updatedInviteeEmailAddress);
      string result = newInvitee.GetInviteeEmailAddress();

      //Assert
      Assert.AreEqual(updatedInviteeEmailAddress, result);
    }

    [TestMethod]
    public void GetId_ReturnsInviteeId_Int()
    {
      //Arrange
      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);

      //Act
      int result = newInvitee.GetId();

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SavesInviteeToDatabase_InviteeList()
    {
      //Arrange
      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);
      newInvitee.Save();

      //Act
      List<Invitee> result = Invitee.GetAll();
      List<Invitee> testList = new List<Invitee>{newInvitee};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllInviteeObjects_InviteeList()
    {
      //Arrange
      string inviteeName1 = "Jane Doe";
      string inviteeEmailAddress1 = "janedoe@mail.com";
      Invitee newInvitee1 = new Invitee(inviteeName1, inviteeEmailAddress1);
      newInvitee1.Save();

      string inviteeName2 = "John Smith";
      string inviteeEmailAddress2 = "johnsmith@mail.com";
      Invitee newInvitee2 = new Invitee(inviteeName2, inviteeEmailAddress2);
      newInvitee2.Save();

      List<Invitee> newList = new List<Invitee> { newInvitee1, newInvitee2};

      //Act
      List<Invitee> result = Invitee.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsInviteeInDatabase_Invitee()
    {
      //Arrange
      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);
      newInvitee.Save();

      //Act
      Invitee foundInvitee = Invitee.Find(newInvitee.GetId());

      //Assert
      Assert.AreEqual(newInvitee, foundInvitee);
    }

    [TestMethod]
    public void GetEvents_RetrievesAllEventsWithInvitee_EventList()
    {
      //Arrange
      string eventName1 = "July 4th BBQ";
      DateTime eventDate1 = new DateTime(2019, 07, 04);
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

      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);
      newInvitee.Save();

      //Act
      Event foundEvent1 = Event.Find(newEvent1.GetId());
      Event foundEvent2 = Event.Find(newEvent2.GetId());
      Invitee foundInvitee = Invitee.Find(newInvitee.GetId());

      foundInvitee.AddEvent(foundEvent1);
      foundInvitee.AddEvent(foundEvent2);

      List<Event> newList = new List<Event> { newEvent1, newEvent2 };
      List<Event> resultList = foundInvitee.GetEvents();

      //Assert
      CollectionAssert.AreEqual(newList, resultList);
    }

    [TestMethod]
    public void Delete_DeletesInviteeFromDatabase()
    {
      //Arrange
      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);
      newInvitee.Save();
      newInvitee.Delete();

      //Act
      List<Invitee> newList = new List<Invitee> { newInvitee };
      List<Invitee> resultList = Invitee.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void DeleteAll_DeletesAllinviteesFromDatabase()
    {
      //Arrange
      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);
      newInvitee.Save();
      Invitee.DeleteAll();

      //Act
      List<Invitee> newList = new List<Invitee> { newInvitee };
      List<Invitee> resultList = Invitee.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void Edit_UpdatesInviteeToDatabase()
    {
      //Arrange
      string inviteeName = "Jane Doe";
      string inviteeEmailAddress = "janedoe@mail.com";
      Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress);
      newInvitee.Save();

      //Act
      Invitee foundInvitee = Invitee.Find(newInvitee.GetId());
      string newInviteeName = "John Smith";
      string newInviteeEmailAddress = "johnsmith@yahoo.com";
      foundInvitee.Edit(newInviteeName, newInviteeEmailAddress);
      Invitee updatedInvitee = Invitee.Find(newInvitee.GetId());

      List<Invitee> result = Invitee.GetAll();
      List<Invitee> testList = new List<Invitee>{updatedInvitee};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_SavesEventInviteeToDatabase_EventList()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 07, 04);
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
      foundInvitee.AddEvent(foundEvent);

      List<Event> result = foundInvitee.GetEvents();
      List<Event> testList = new List<Event>{foundEvent};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Delete_DeletesEventInviteeFromDatabase()
    {
      //Arrange
      string eventName = "July 4th BBQ";
      DateTime eventDate = new DateTime(2019, 07, 04);
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
      foundInvitee.AddEvent(foundEvent);

      List<Event> result = foundInvitee.GetEvents();
      foundInvitee.DeleteEvent(foundEvent);
      List<Event> testList = foundInvitee.GetEvents();

      //Assert
      CollectionAssert.AreNotEqual(testList, result);
    }
  }
}
