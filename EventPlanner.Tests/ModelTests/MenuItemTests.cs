using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventPlanner.Models;
using System.Collections.Generic;
using System;

namespace EventPlanner.Tests
{
  [TestClass]
  public class MenuItemTest : IDisposable
  {
    public MenuItemTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_tests;";
    }

    public void Dispose()
    {
      MenuItem.ClearAll();
    }

    [TestMethod]
    public void menuItemConstructor_CreatesInstanceOfMenuItem_MenuItem()
    {
      //Arrange, Act
      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);

      //Assert
      Assert.AreEqual(typeof(MenuItem), newMenuItem.GetType());
    }

    [TestMethod]
    public void GetMenuItemDescription_ReturnsMenuItemDescription_String()
    {
      //Arrange
      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);

      //Act
      string result = newMenuItem.GetMenuItemDescription();

      //Assert
      Assert.AreEqual(menuItemDescription, result);
    }

    [TestMethod]
    public void SetMenuItemDescription_SetMenuItemDescription_String()
    {
      //Arrange
      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);

      //Act
      string updatedMenuItemDescription = "Baked Beans";
      newMenuItem.SetMenuItemDescription(updatedMenuItemDescription);
      string result = newMenuItem.GetMenuItemDescription();

      //Assert
      Assert.AreEqual(updatedMenuItemDescription, result);
    }

    [TestMethod]
    public void GetId_ReturnsMenuItemId_Int()
    {
      //Arrange
      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);

      //Act
      int result = newMenuItem.GetId();

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SavesMenuItemToDatabase_MenuItemList()
    {
      //Arrange
      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);
      newMenuItem.Save();

      //Act
      List<MenuItem> result = MenuItem.GetAll();
      List<MenuItem> testList = new List<MenuItem>{newMenuItem};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllMenuItemObjects_MenuItemList()
    {
      //Arrange
      string menuItemDescription1 = "Potato Salad";
      MenuItem newMenuItem1 = new MenuItem(menuItemDescription1);
      newMenuItem1.Save();

      string menuItemDescription2 = "Baked Beans";
      MenuItem newMenuItem2 = new MenuItem(menuItemDescription2);
      newMenuItem2.Save();

      List<MenuItem> newList = new List<MenuItem> { newMenuItem1, newMenuItem2};

      //Act
      List<MenuItem> result = MenuItem.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsMenuItemInDatabase_MenuItem()
    {
      //Arrange
      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);
      newMenuItem.Save();

      //Act
      MenuItem foundMenuItem = MenuItem.Find(newMenuItem.GetId());

      //Assert
      Assert.AreEqual(newMenuItem, foundMenuItem);
    }

    [TestMethod]
    public void GetMenus_RetrievesAllMenusWithMenuItem_MenuList()
    {
      //Arrange
      string menuTheme1 = "BBQ";
      int menusId1 = 1;
      Menu newMenu1 = new Menu(menuTheme1, menusId1);
      newMenu1.Save();

      string menuTheme2 = "Mexican";
      int menusId2 = 2;
      Menu newMenu2 = new Menu(menuTheme2, menusId2);
      newMenu2.Save();

      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);
      newMenuItem.Save();

      //Act
      Menu foundMenu1 = Menu.Find(newMenu1.GetId());
      Menu foundMenu2 = Menu.Find(newMenu2.GetId());
      MenuItem foundMenuItem = MenuItem.Find(newMenuItem.GetId());

      foundMenuItem.AddMenu(foundMenu1);
      foundMenuItem.AddMenu(foundMenu2);

      List<Menu> newList = new List<Menu> { newMenu1, newMenu2 };
      List<Menu> resultList = foundMenuItem.GetMenus();

      //Assert
      CollectionAssert.AreEqual(newList, resultList);
    }

    [TestMethod]
    public void Delete_DeletesMenuItemFromDatabase()
    {
      //Arrange
      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);
      newMenuItem.Save();
      newMenuItem.Delete();

      //Act
      List<MenuItem> newList = new List<MenuItem> { newMenuItem };
      List<MenuItem> resultList = MenuItem.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void DeleteAll_DeletesAllmenuItemsFromDatabase()
    {
      //Arrange
      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);
      newMenuItem.Save();
      MenuItem.DeleteAll();

      //Act
      List<MenuItem> newList = new List<MenuItem> { newMenuItem };
      List<MenuItem> resultList = MenuItem.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void Edit_UpdatesMenuItemToDatabase()
    {
      //Arrange
      string menuItemDescription = "Potato Salad";
      MenuItem newMenuItem = new MenuItem(menuItemDescription);
      newMenuItem.Save();

      //Act
      MenuItem foundMenuItem = MenuItem.Find(newMenuItem.GetId());
      string newMenuItemDescription = "Baked Beans";
      foundMenuItem.Edit(newMenuItemDescription);
      MenuItem updatedMenuItem = MenuItem.Find(newMenuItem.GetId());

      List<MenuItem> result = MenuItem.GetAll();
      List<MenuItem> testList = new List<MenuItem>{updatedMenuItem};

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
      foundMenuItem.AddMenu(foundMenu);

      List<Menu> result = foundMenuItem.GetMenus();
      List<Menu> testList = new List<Menu>{foundMenu};

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
      foundMenuItem.AddMenu(foundMenu);

      List<Menu> testList = new List<Menu>{foundMenu};
      foundMenuItem.DeleteMenu(foundMenu);
      List<Menu> result = foundMenuItem.GetMenus();

      //Assert
      CollectionAssert.AreNotEqual(testList, result);
    }
  
  }
}
