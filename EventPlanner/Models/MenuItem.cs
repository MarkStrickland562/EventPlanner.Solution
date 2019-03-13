using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace EventPlanner.Models
{
  public class MenuItem
  {
    private string _menuItemDescription;
    private int _id;

    public MenuItem(string menuItemDescription, int id = 0)
    {
      _menuItemDescription = menuItemDescription;
      _id = id;
    }

    public string GetMenuItemDescription()
    {
      return _menuItemDescription;
    }

    public void SetMenuItemDescription(string newMenuItemDescription)
    {
      _menuItemDescription = newMenuItemDescription;
    }

    public int GetId()
    {
      return _id;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM menus_menu_items;
                          DELETE FROM menu_item_ingredients;
                          DELETE FROM menu_items;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO menu_items (menu_item_description)
                          VALUES (@menuItemDescription);";
      MySqlParameter menuItemDescription = new MySqlParameter();
      menuItemDescription.ParameterName = "@menuItemDescription";
      menuItemDescription.Value = this._menuItemDescription;
      cmd.Parameters.Add(menuItemDescription);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<MenuItem> GetAll()
    {
      List<MenuItem> allMenuItems = new List<MenuItem> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM menu_items;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int menuItemId = rdr.GetInt32(0);
        string menuItemDescription = rdr.GetString(1);
        MenuItem newMenuItem = new MenuItem(menuItemDescription, menuItemId);
        allMenuItems.Add(newMenuItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allMenuItems;
    }

    public static MenuItem Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM menu_items WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int menuItemId = 0;
      string menuItemDescription = "";
      while(rdr.Read())
      {
        menuItemId = rdr.GetInt32(0);
        menuItemDescription = rdr.GetString(1);
      }
      MenuItem newMenuItem = new MenuItem(menuItemDescription, menuItemId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
        return newMenuItem;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM menus_menu_items WHERE menu_items_id = (@searchId);
                          DELETE FROM menu_item_ingredients WHERE menu_items_id = (@searchId);
                          DELETE FROM menu_items WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this._id;
      cmd.Parameters.Add(searchId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM menus_menu_items;
                          DELETE FROM menu_item_ingredients;
                          DELETE FROM menu_items;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newMenuItemDescription)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE menu_items SET menu_item_description = (@menuItemDescription)
                           WHERE id = (@menuItemId);";
      MySqlParameter menuItemDescriptionParameter = new MySqlParameter();
      menuItemDescriptionParameter.ParameterName = "@menuItemDescription";
      menuItemDescriptionParameter.Value = newMenuItemDescription;
      cmd.Parameters.Add(menuItemDescriptionParameter);
      MySqlParameter menuItemIdParameter = new MySqlParameter();
      menuItemIdParameter.ParameterName = "@menuItemId";
      menuItemIdParameter.Value = this._id;
      cmd.Parameters.Add(menuItemIdParameter);
      cmd.ExecuteNonQuery();
      _menuItemDescription = newMenuItemDescription;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void AddMenu(Menu newMenu)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO menus_menu_items (menus_id, menu_items_id) VALUES (@menuId, @menuItemId);";
      MySqlParameter menuIdParameter = new MySqlParameter();
      menuIdParameter.ParameterName = "@menuId";
      menuIdParameter.Value = newMenu.GetId();
      cmd.Parameters.Add(menuIdParameter);
      MySqlParameter menuItemIdParameter = new MySqlParameter();
      menuItemIdParameter.ParameterName = "@menuItemId";
      menuItemIdParameter.Value = this._id;
      cmd.Parameters.Add(menuItemIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void DeleteMenu(Menu newMenu)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM menus_menu_items WHERE menus_id = (@menuId) AND menu_items_id = (@menuItemId);";
      MySqlParameter menuIdParameter = new MySqlParameter();
      menuIdParameter.ParameterName = "@menuId";
      menuIdParameter.Value = newMenu.GetId();
      cmd.Parameters.Add(menuIdParameter);
      MySqlParameter menuItemIdParameter = new MySqlParameter();
      menuItemIdParameter.ParameterName = "@menuItemId";
      menuItemIdParameter.Value = this._id;
      cmd.Parameters.Add(menuItemIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Menu> GetMenus()
    {
      List<Menu> allMenus = new List<Menu> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT *
                            FROM menus
                           WHERE id IN (SELECT menus_id FROM menus_menu_items WHERE menu_items_id = @menuItemId);";
      MySqlParameter menuItemId = new MySqlParameter();
      menuItemId.ParameterName = "@menuItemId";
      menuItemId.Value = this._id;
      cmd.Parameters.Add(menuItemId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int menuId = rdr.GetInt32(0);
        string menuTheme = rdr.GetString(1);
        Menu newMenu = new Menu(menuTheme, menuId);
        allMenus.Add(newMenu);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allMenus;
    }

    public override bool Equals(System.Object otherMenuItem)
    {
      if (!(otherMenuItem is MenuItem))
      {
        return false;
      }
      else
      {
        MenuItem newMenuItem = (MenuItem) otherMenuItem;
        bool idEquality = this.GetId().Equals(newMenuItem.GetId());
        bool menuItemDescriptionEquality = this.GetMenuItemDescription().Equals(newMenuItem.GetMenuItemDescription());
        return (idEquality && menuItemDescriptionEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }
  }
}
