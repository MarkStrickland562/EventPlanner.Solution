using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventPlanner.Models;
using System.Collections.Generic;
using System;

namespace EventPlanner.Tests
{
  [TestClass]
  public class MenuTest : IDisposable
  {
    public MenuTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
    }

    public void Dispose()
    {
      Menu.ClearAll();
    }

    [TestMethod]
    public void menuConstructor_CreatesInstanceOfMenu_Menu()
    {
      //Arrange, Act
      string menuTheme = "BBQ";
      Menu newMenu = new Menu(menuTheme);

      //Assert
      Assert.AreEqual(typeof(Menu), newMenu.GetType());
    }

    [TestMethod]
    public void GetMenuTheme_ReturnsMenuTheme_String()
    {
      //Arrange
      string menuTheme = "BBQ";
      Menu newMenu = new Menu(menuTheme);

      //Act
      string result = newMenu.GetMenuTheme();

      //Assert
      Assert.AreEqual(menuTheme, result);
    }

    [TestMethod]
    public void SetMenuTheme_SetMenuTheme_String()
    {
      //Arrange
      string menuTheme = "BBQ";

      Menu newMenu = new Menu(menuTheme);

      //Act
      string updatedMenuTheme = "Mexican";
      newMenu.SetMenuTheme(updatedMenuTheme);
      string result = newMenu.GetMenuTheme();

      //Assert
      Assert.AreEqual(updatedMenuTheme, result);
    }

    [TestMethod]
    public void GetId_ReturnsMenuId_Int()
    {
      //Arrange
      string menuTheme = "BBQ";
      Menu newMenu = new Menu(menuTheme);

      //Act
      int result = newMenu.GetId();

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SavesMenuToDatabase_MenuList()
    {
      //Arrange
      string menuTheme = "BBQ";
      Menu newMenu = new Menu(menuTheme);
      newMenu.Save();

      //Act
      List<Menu> result = Menu.GetAll();
      List<Menu> testList = new List<Menu>{newMenu};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllMenuObjects_MenuList()
    {
      //Arrange
      string menuTheme1 = "BBQ";
      Menu newMenu1 = new Menu(menuTheme1);
      newMenu1.Save();

      string menuTheme2 = "John Smith";
      Menu newMenu2 = new Menu(menuTheme2);
      newMenu2.Save();

      List<Menu> newList = new List<Menu> { newMenu1, newMenu2};

      //Act
      List<Menu> result = Menu.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsMenuInDatabase_Menu()
    {
      //Arrange
      string menuTheme = "BBQ";
      Menu newMenu = new Menu(menuTheme);
      newMenu.Save();

      //Act
      Menu foundMenu = Menu.Find(newMenu.GetId());

      //Assert
      Assert.AreEqual(newMenu, foundMenu);
    }

    [TestMethod]
    public void Delete_DeletesMenuFromDatabase()
    {
      //Arrange
      string menuTheme = "BBQ";
      Menu newMenu = new Menu(menuTheme);
      newMenu.Save();
      newMenu.Delete();

      //Act
      List<Menu> newList = new List<Menu> { newMenu };
      List<Menu> resultList = Menu.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void DeleteAll_DeletesAllMenusFromDatabase()
    {
      //Arrange
      string menuTheme = "BBQ";
      Menu newMenu = new Menu(menuTheme);
      newMenu.Save();
      Menu.DeleteAll();

      //Act
      List<Menu> newList = new List<Menu> { newMenu };
      List<Menu> resultList = Menu.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void Edit_UpdatesMenuToDatabase()
    {
      //Arrange
      string menuTheme = "BBQ";
      Menu newMenu = new Menu(menuTheme);
      newMenu.Save();

      //Act
      Menu foundMenu = Menu.Find(newMenu.GetId());
      string newMenuTheme = "Mexican";
      foundMenu.Edit(newMenuTheme);
      Menu updatedMenu = Menu.Find(newMenu.GetId());

      List<Menu> result = Menu.GetAll();
      List<Menu> testList = new List<Menu>{updatedMenu};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_SavesMenuMenuItemToDatabase_MenuList()
    {
      //Arrange
      string menuTheme = "BBQ";
      int menusId = 1;
      Menu newMenu = new Menu(menuTheme, menusId);
      newMenu.Save();

      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);
      newMenuItem.Save();

      //Act
      Menu foundMenu = Menu.Find(newMenu.GetId());
      MenuItem foundMenuItem = MenuItem.Find(newMenuItem.GetId());
      foundMenu.AddMenuItem(foundMenuItem);

      List<MenuItem> result = foundMenu.GetMenuItems();
      List<MenuItem> testList = new List<MenuItem>{foundMenuItem};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Delete_DeletesMenuMenuItemFromDatabase()
    {
      //Arrange
      string menuTheme = "BBQ";
      int menusId = 1;
      Menu newMenu = new Menu(menuTheme, menusId);
      newMenu.Save();

      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);
      newMenuItem.Save();

      //Act
      Menu foundMenu = Menu.Find(newMenu.GetId());
      MenuItem foundMenuItem = MenuItem.Find(newMenuItem.GetId());
      foundMenu.AddMenuItem(foundMenuItem);
      List<MenuItem> testList = new List<MenuItem>{foundMenuItem};
      foundMenu.DeleteMenuItem(foundMenuItem);
      List<MenuItem> result = foundMenu.GetMenuItems();

      //Assert
      CollectionAssert.AreNotEqual(testList, result);
    }
  }
}
