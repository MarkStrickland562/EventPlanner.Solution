using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventPlanner.Models;
using System.Collections.Generic;
using System;

namespace EventPlanner.Tests
{
  [TestClass]
  public class MenuItemIngredientTest : IDisposable
  {
    public MenuItemIngredientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
    }

    public void Dispose()
    {
      MenuItemIngredient.ClearAll();
    }

    [TestMethod]
    public void menuItemIngredientConstructor_CreatesInstanceOfMenuItemIngredient_MenuItemIngredient()
    {
      //Arrange, Act
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);

      //Assert
      Assert.AreEqual(typeof(MenuItemIngredient), newMenuItemIngredient.GetType());
    }

    [TestMethod]
    public void GetIngredientDescription_ReturnsIngredientDescription_String()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);

      //Act
      string result = newMenuItemIngredient.GetIngredientDescription();

      //Assert
      Assert.AreEqual(menuItemIngredientDescription, result);
    }

    [TestMethod]
    public void SetIngredientDescription_SetIngredientDescription_String()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);

      //Act
      string updatedIngredientDescription = "Tomatoes";
      newMenuItemIngredient.SetIngredientDescription(updatedIngredientDescription);
      string result = newMenuItemIngredient.GetIngredientDescription();

      //Assert
      Assert.AreEqual(updatedIngredientDescription, result);
    }

    [TestMethod]
    public void GetMenuItemsId_ReturnsMenuItemsId_Int()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);

      //Act
      int result = newMenuItemIngredient.GetMenuItemsId();

      //Assert
      Assert.AreEqual(menuItemsId, result);
    }

    [TestMethod]
    public void SetMenuItemsId_SetMenuItemsId_Int()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);

      //Act
      int updatedMenuItemsId = 2;
      newMenuItemIngredient.SetMenuItemsId(updatedMenuItemsId);
      int result = newMenuItemIngredient.GetMenuItemsId();

      //Assert
      Assert.AreEqual(updatedMenuItemsId, result);
    }

    [TestMethod]
    public void GetStoreId_ReturnsStoreId_Int()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);

      //Act
      int result = newMenuItemIngredient.GetStoreId();

      //Assert
      Assert.AreEqual(storeId, result);
    }

    [TestMethod]
    public void SetStoreId_SetStoreId_Int()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);

      //Act
      int updatedStoreId = 2;
      newMenuItemIngredient.SetStoreId(updatedStoreId);
      int result = newMenuItemIngredient.GetStoreId();

      //Assert
      Assert.AreEqual(updatedStoreId, result);
    }

    [TestMethod]
    public void GetId_ReturnsMenuItemIngredientId_Int()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);

      //Act
      int result = newMenuItemIngredient.GetId();

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SavesMenuItemIngredientToDatabase_MenuItemIngredientList()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);
      newMenuItemIngredient.Save();

      //Act
      List<MenuItemIngredient> result = MenuItemIngredient.GetAll();
      List<MenuItemIngredient> testList = new List<MenuItemIngredient>{newMenuItemIngredient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllMenuItemIngredientObjects_MenuItemIngredientList()
    {
      //Arrange
      string menuItemIngredientDescription1 = "Avocadoes";
      int menuItemsId1 = 1;
      int storeId1 = 1;
      MenuItemIngredient newMenuItemIngredient1 = new MenuItemIngredient(menuItemIngredientDescription1, menuItemsId1, storeId1);
      newMenuItemIngredient1.Save();

      string menuItemIngredientDescription2 = "Tomatoes";
      int menuItemsId2 = 2;
      int storeId2 = 2;
      MenuItemIngredient newMenuItemIngredient2 = new MenuItemIngredient(menuItemIngredientDescription2, menuItemsId2, storeId2);
      newMenuItemIngredient2.Save();

      List<MenuItemIngredient> newList = new List<MenuItemIngredient> { newMenuItemIngredient1, newMenuItemIngredient2};

      //Act
      List<MenuItemIngredient> result = MenuItemIngredient.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsMenuItemIngredientInDatabase_MenuItemIngredient()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);
      newMenuItemIngredient.Save();

      //Act
      MenuItemIngredient foundMenuItemIngredient = MenuItemIngredient.Find(newMenuItemIngredient.GetId());

      //Assert
      Assert.AreEqual(newMenuItemIngredient, foundMenuItemIngredient);
    }

    [TestMethod]
    public void Delete_DeletesMenuItemIngredientFromDatabase()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);
      newMenuItemIngredient.Save();
      newMenuItemIngredient.Delete();

      //Act
      List<MenuItemIngredient> newList = new List<MenuItemIngredient> { newMenuItemIngredient };
      List<MenuItemIngredient> resultList = MenuItemIngredient.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void DeleteAll_DeletesAllMenuItemIngredientsFromDatabase()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId= 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);
      newMenuItemIngredient.Save();
      MenuItemIngredient.DeleteAll();

      //Act
      List<MenuItemIngredient> newList = new List<MenuItemIngredient> { newMenuItemIngredient };
      List<MenuItemIngredient> resultList = MenuItemIngredient.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void Edit_UpdatesMenuItemIngredientToDatabase()
    {
      //Arrange
      string menuItemIngredientDescription = "Avocadoes";
      int menuItemsId = 1;
      int storeId = 1;
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(menuItemIngredientDescription, menuItemsId, storeId);
      newMenuItemIngredient.Save();

      //Act
      MenuItemIngredient foundMenuItemIngredient = MenuItemIngredient.Find(newMenuItemIngredient.GetId());
      string newIngredientDescription = "Tomatoes";
      int newMenuItemsId = 2;
      int newStoreId = 2;
      foundMenuItemIngredient.Edit(newIngredientDescription, newMenuItemsId, newStoreId);
      MenuItemIngredient updatedMenuItemIngredient = MenuItemIngredient.Find(newMenuItemIngredient.GetId());

      List<MenuItemIngredient> result = MenuItemIngredient.GetAll();
      List<MenuItemIngredient> testList = new List<MenuItemIngredient>{updatedMenuItemIngredient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
  }
}
