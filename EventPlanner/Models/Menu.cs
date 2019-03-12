using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace EventPlanner.Models
{
  public class Menu
  {
    private string _menuTheme;
    private string _menuEmailAddress;
    private int _id;

    public Menu(string menuTheme, int id = 0)
    {
      _menuTheme = menuTheme;
      _id = id;
    }

    public string GetMenuTheme()
    {
      return _menuTheme;
    }

    public void SetMenuTheme(string newMenuTheme)
    {
      _menuTheme = newMenuTheme;
    }

    public int GetId()
    {
      return _id;
    }
    
    // public static void ClearAll()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM menus_menu_items;
    //                       DELETE FROM menus;";
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public void Save()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"INSERT INTO menus (menu_theme)
    //                       VALUES (@menuTheme);";
    //   MySqlParameter menuTheme = new MySqlParameter();
    //   menuTheme.ParameterName = "@menuTheme";
    //   menuTheme.Value = this._menuTheme;
    //   cmd.Parameters.Add(menuTheme);
    //   cmd.ExecuteNonQuery();
    //   _id = (int) cmd.LastInsertedId;
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public static List<Menu> GetAll()
    // {
    //   List<Menu> allMenus = new List<Menu> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM menus;";
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while(rdr.Read())
    //   {
    //     int menuId = rdr.GetInt32(0);
    //     string menuTheme = rdr.GetString(1);
    //     Menu newMenu = new Menu(menuTheme, menuId);
    //     allMenus.Add(newMenu);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allMenus;
    // }
    //
    // public static Menu Find(int id)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM menus WHERE id = (@searchId);";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = id;
    //   cmd.Parameters.Add(searchId);
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int menuId = 0;
    //   string menuTheme = "";
    //   while(rdr.Read())
    //   {
    //     menuId = rdr.GetInt32(0);
    //     menuTheme = rdr.GetString(1);
    //   }
    //   Menu newMenu = new Menu(menuTheme, menuId);
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //     return newMenu;
    // }
    //
    // public void Delete()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM menus_menu_items = WHERE menus_id = (@searchid);
    //                       DELETE FROM menus WHERE id = (@searchId);";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = this._id;
    //   cmd.Parameters.Add(searchId);
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public static void DeleteAll()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM menus_menu_items;
    //                       DELETE FROM menus";
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public void Edit(string newMenuTheme)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"UPDATE menus SET menu_theme = (@menuTheme) WHERE id = (@menuId);";
    //   MySqlParameter menuThemeParameter = new MySqlParameter();
    //   menuThemeParameter.ParameterName = "@menuTheme";
    //   menuThemeParameter.Value = newMenuTheme;
    //   cmd.Parameters.Add(menuThemeParameter);
    //   MySqlParameter menuIdParameter = new MySqlParameter();
    //   menuIdParameter.ParameterName = "@menuId";
    //   menuIdParameter.Value = this._id;
    //   cmd.Parameters.Add(menuIdParameter);
    //   cmd.ExecuteNonQuery();
    //   _menuTheme = newmenuTheme;
    //     conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public override bool Equals(System.Object otherMenu)
    // {
    //   if (!(otherMenu is Menu))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     Menu newMenu = (Menu) otherMenu;
    //     bool idEquality = this.GetId().Equals(newMenu.GetId());
    //     bool menuThemeEquality = this.GetMenuTheme().Equals(newMenu.GetMenuTheme());
    //     return (idEquality && menuThemeEquality);
    //   }
    // }
  }
}
