using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventPlanner.Models;
using System.Collections.Generic;
using System;

namespace EventPlanner.Tests
{
  [TestClass]
  public class StoreTest : IDisposable
  {
    public StoreTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
    }

    public void Dispose()
    {
      Store.ClearAll();
    }

    [TestMethod]
    public void storeConstructor_CreatesInstanceOfStore_Store()
    {
      //Arrange, Act
      string storeName = "Costco";
      Store newStore = new Store(storeName);

      //Assert
      Assert.AreEqual(typeof(Store), newStore.GetType());
    }

    [TestMethod]
    public void GetStoreName_ReturnsStoreName_String()
    {
      //Arrange
      string storeName = "Costco";
      Store newStore = new Store(storeName);

      //Act
      string result = newStore.GetStoreName();

      //Assert
      Assert.AreEqual(storeName, result);
    }

    [TestMethod]
    public void SetStoreName_SetStoreName_String()
    {
      //Arrange
      string storeName = "Costco";

      Store newStore = new Store(storeName);

      //Act
      string updatedStoreName = "QFC";
      newStore.SetStoreName(updatedStoreName);
      string result = newStore.GetStoreName();

      //Assert
      Assert.AreEqual(updatedStoreName, result);
    }

    [TestMethod]
    public void GetId_ReturnsStoreId_Int()
    {
      //Arrange
      string storeName = "Costco";
      Store newStore = new Store(storeName);

      //Act
      int result = newStore.GetId();

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SavesStoreToDatabase_StoreList()
    {
      //Arrange
      string storeName = "Costco";
      Store newStore = new Store(storeName);
      newStore.Save();

      //Act
      List<Store> result = Store.GetAll();
      List<Store> testList = new List<Store>{newStore};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllStoreObjects_StoreList()
    {
      //Arrange
      string storeName1 = "Costco";
      Store newStore1 = new Store(storeName1);
      newStore1.Save();

      string storeName2 = "John Smith";
      Store newStore2 = new Store(storeName2);
      newStore2.Save();

      List<Store> newList = new List<Store> { newStore1, newStore2};

      //Act
      List<Store> result = Store.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsStoreInDatabase_Store()
    {
      //Arrange
      string storeName = "Costco";
      Store newStore = new Store(storeName);
      newStore.Save();

      //Act
      Store foundStore = Store.Find(newStore.GetId());

      //Assert
      Assert.AreEqual(newStore, foundStore);
    }

    [TestMethod]
    public void Delete_DeletesStoreFromDatabase()
    {
      //Arrange
      string storeName = "Costco";
      Store newStore = new Store(storeName);
      newStore.Save();
      newStore.Delete();

      //Act
      List<Store> newList = new List<Store> { newStore };
      List<Store> resultList = Store.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void DeleteAll_DeletesAllStoresFromDatabase()
    {
      //Arrange
      string storeName = "Costco";
      Store newStore = new Store(storeName);
      newStore.Save();
      Store.DeleteAll();

      //Act
      List<Store> newList = new List<Store> { newStore };
      List<Store> resultList = Store.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void Edit_UpdatesStoreToDatabase()
    {
      //Arrange
      string storeName = "Costco";
      Store newStore = new Store(storeName);
      newStore.Save();

      //Act
      Store foundStore = Store.Find(newStore.GetId());
      string newStoreName = "QFC";
      foundStore.Edit(newStoreName);
      Store updatedStore = Store.Find(newStore.GetId());

      List<Store> result = Store.GetAll();
      List<Store> testList = new List<Store>{updatedStore};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
  }
}
