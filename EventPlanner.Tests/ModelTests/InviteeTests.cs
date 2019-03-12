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

    // [TestMethod]
    // public void Find_ReturnsinviteeInDatabase_invitee()
    // {
    //   //Arrange
    //   string inviteeName = "Jane Doe";
    //   string inviteeEmailAddress = "janedoe@mail.com";
    //   invitee newinvitee = new invitee(inviteeName, inviteeEmailAddress);
    //   newinvitee.Save();
    //
    //   //Act
    //   invitee foundinvitee = invitee.Find(newinvitee.GetId());
    //
    //   //Assert
    //   Assert.AreEqual(newinvitee, foundinvitee);
    // }
    //
    // [TestMethod]
    // public void GetEvents_RetrievesAllEventsWithinvitee_EventList()
    // {
    //   //Arrange
    //   string eventName1 = "July 4th BBQ";
    //   string eventDate1 = "janedoe@mail.com";
    //   string eventLocation1 = "Capitol Hill";
    //   int menusId1 = 1;
    //   Event newEvent1 = new Event(eventName1, eventDate1, eventLocation1, menusId1);
    //   newEvent1.Save();
    //
    //   string eventName2 = "Birthday Party";
    //   string eventDate2 = new string(2019, 05, 03);
    //   string eventLocation2 = "Saltys";
    //   int menusId2 = 2;
    //   Event newEvent2 = new Event(eventName2, eventDate2, eventLocation2, menusId2);
    //   newEvent2.Save();
    //
    //   string inviteeName = "Jane Doe";
    //   string inviteeEmailAddress = "janedoe@mail.com";
    //   invitee newinvitee = new invitee(inviteeName, inviteeEmailAddress);
    //   newinvitee.Save();
    //
    //   //Act
    //   Event foundEvent1 = Event.Find(newEvent1.GetId());
    //   Event foundEvent2 = Event.Find(newEvent2.GetId());
    //   invitee foundinvitee = invitee.Find(newinvitee.GetId());
    //
    //   foundinvitee.AddEvent(foundEvent1);
    //   foundinvitee.AddEvent(foundEvent2);
    //
    //   List<Event> newList = new List<Event> { newEvent1, newEvent2 };
    //   List<Event> resultList = foundinvitee.GetEvents();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(newList, resultList);
    // }
    //
    // [TestMethod]
    // public void Delete_DeletesinviteeFromDatabase()
    // {
    //   //Arrange
    //   string inviteeName = "Jane Doe";
    //   string inviteeEmailAddress = "janedoe@mail.com";
    //   invitee newinvitee = new invitee(inviteeName, inviteeEmailAddress);
    //   newinvitee.Save();
    //   newinvitee.Delete();
    //
    //   //Act
    //   List<invitee> newList = new List<invitee> { newinvitee };
    //   List<invitee> resultList = invitee.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreNotEqual(newList, resultList);
    // }
    //
    // [TestMethod]
    // public void DeleteAll_DeletesAllinviteesFromDatabase()
    // {
    //   //Arrange
    //   string inviteeName = "Jane Doe";
    //   string inviteeEmailAddress = "janedoe@mail.com";
    //   invitee newinvitee = new invitee(inviteeName, inviteeEmailAddress);
    //   newinvitee.Save();
    //   invitee.DeleteAll();
    //
    //   //Act
    //   List<invitee> newList = new List<invitee> { newinvitee };
    //   List<invitee> resultList = invitee.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreNotEqual(newList, resultList);
    // }
    //
    // [TestMethod]
    // public void Edit_UpdatesinviteeToDatabase()
    // {
    //   //Arrange
    //   string inviteeName = "Jane Doe";
    //   string inviteeEmailAddress = "janedoe@mail.com";
    //   invitee newinvitee = new invitee(inviteeName, inviteeEmailAddress);
    //   newinvitee.Save();
    //
    //   //Act
    //   invitee foundinvitee = invitee.Find(newinvitee.GetId());
    //   string newinviteeName = "John Smith";
    //   string newinviteeEmailAddress = new string(2019, 05, 03);
    //   foundinvitee.Edit(newinviteeName, newinviteeEmailAddress);
    //   invitee updatedinvitee = invitee.Find(newinvitee.GetId());
    //
    //   List<invitee> result = invitee.GetAll();
    //   List<invitee> testList = new List<invitee>{updatedinvitee};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void Save_SavesEventinviteeToDatabase_EventList()
    // {
    //   //Arrange
    //   string eventName = "July 4th BBQ";
    //   string eventDate = "janedoe@mail.com";
    //   string eventLocation = "Capitol Hill";
    //   int menusId = 1;
    //   Event newEvent = new Event(eventName, eventDate, eventLocation, menusId);
    //   newEvent.Save();
    //
    //   string inviteeName = "Jane Doe";
    //   string inviteeEmailAddress = "janedoe@mail.com";
    //   invitee newinvitee = new invitee(inviteeName, inviteeEmailAddress);
    //   newinvitee.Save();
    //
    //   //Act
    //   Event foundEvent = Event.Find(newEvent.GetId());
    //   invitee foundinvitee = invitee.Find(newinvitee.GetId());
    //   foundinvitee.AddEvent(foundEvent);
    //
    //   List<Event> result = foundinvitee.GetEvents();
    //   List<Event> testList = new List<Event>{foundEvent};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
  }
}
