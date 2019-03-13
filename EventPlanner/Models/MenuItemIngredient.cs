using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace EventPlanner.Models
{
  public class MenuItemIngredient
  {
    private string _ingredientDescription;
    private int _menuItemsId;
    private int _storeId;
    private int _id;

    public MenuItemIngredient(string ingredientDescription, int menuItemsId, int storeId, int id = 0)
    {
      _ingredientDescription = ingredientDescription;
      _menuItemsId = menuItemsId;
      _storeId = storeId;
      _id = id;
    }

    public string GetIngredientDescription()
    {
      return _ingredientDescription;
    }

    public void SetIngredientDescription(string newIngredientDescription)
    {
      _ingredientDescription = newIngredientDescription;
    }

    public int GetMenuItemsId()
    {
      return _menuItemsId;
    }

    public void SetMenuItemsId(int newMenuItemsId)
    {
      _menuItemsId = newMenuItemsId;
    }

    public int GetStoreId()
    {
      return _storeId;
    }

    public void SetStoreId(int newStoreId)
    {
      _storeId = newStoreId;
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
      cmd.CommandText = @"DELETE FROM menu_item_ingredients;";
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
      cmd.CommandText = @"INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
                          VALUES (@ingredientDescription, @menuItemsId, @storeId);";
      MySqlParameter ingredientDescription = new MySqlParameter();
      ingredientDescription.ParameterName = "@ingredientDescription";
      ingredientDescription.Value = this._ingredientDescription;
      cmd.Parameters.Add(ingredientDescription);
      MySqlParameter menuItemsId = new MySqlParameter();
      menuItemsId.ParameterName = "@menuItemsId";
      menuItemsId.Value = this._menuItemsId;
      cmd.Parameters.Add(menuItemsId);
      MySqlParameter storeId = new MySqlParameter();
      storeId.ParameterName = "@storeId";
      storeId.Value = this._storeId;
      cmd.Parameters.Add(storeId);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<MenuItemIngredient> GetAll()
    {
      List<MenuItemIngredient> allMenuItemIngredients = new List<MenuItemIngredient> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM menu_item_ingredients;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int menuItemIngredientId = rdr.GetInt32(0);
        string ingredientDescription = rdr.GetString(1);
        int menuItemsId = rdr.GetInt32(2);
        int storeId = rdr.GetInt32(3);
        MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(ingredientDescription, menuItemsId, storeId, menuItemIngredientId);
        allMenuItemIngredients.Add(newMenuItemIngredient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allMenuItemIngredients;
    }

    public static MenuItemIngredient Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM menu_item_ingredients WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int menuItemIngredientId = 0;
      string ingredientDescription = "";
      int menuItemsId = 0;
      int storeId = 0;
      while(rdr.Read())
      {
        menuItemIngredientId = rdr.GetInt32(0);
        ingredientDescription = rdr.GetString(1);
        menuItemsId = rdr.GetInt32(2);
        storeId = rdr.GetInt32(3);
      }
      MenuItemIngredient newMenuItemIngredient = new MenuItemIngredient(ingredientDescription, menuItemsId, storeId, menuItemIngredientId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
        return newMenuItemIngredient;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM menu_item_ingredients WHERE id = (@searchId);";
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
      cmd.CommandText = @"DELETE FROM menu_item_ingredients";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newIngredientDescription, int newMenuItemsId, int newStoreId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE menu_item_ingredients
                             SET ingredient_description = (@ingredientDescription),
                                 menu_items_id = (@menuItemsId),
                                store_id = (@storeId)
                           WHERE id = (@menuItemIngredientId);";
      MySqlParameter ingredientDescriptionParameter = new MySqlParameter();
      ingredientDescriptionParameter.ParameterName = "@ingredientDescription";
      ingredientDescriptionParameter.Value = newIngredientDescription;
      cmd.Parameters.Add(ingredientDescriptionParameter);
      MySqlParameter menuItemsIdParameter = new MySqlParameter();
      menuItemsIdParameter.ParameterName = "@menuItemsId";
      menuItemsIdParameter.Value = newMenuItemsId;
      cmd.Parameters.Add(menuItemsIdParameter);
      MySqlParameter storeIdParameter = new MySqlParameter();
      storeIdParameter.ParameterName = "@storeId";
      storeIdParameter.Value = newStoreId;
      cmd.Parameters.Add(storeIdParameter);
      MySqlParameter menuItemIngredientIdParameter = new MySqlParameter();
      menuItemIngredientIdParameter.ParameterName = "@menuItemIngredientId";
      menuItemIngredientIdParameter.Value = this._id;
      cmd.Parameters.Add(menuItemIngredientIdParameter);
      cmd.ExecuteNonQuery();
      _ingredientDescription = newIngredientDescription;
      _menuItemsId = newMenuItemsId;
      _storeId = newStoreId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherMenuItemIngredient)
    {
      if (!(otherMenuItemIngredient is MenuItemIngredient))
      {
        return false;
      }
      else
      {
        MenuItemIngredient newMenuItemIngredient = (MenuItemIngredient) otherMenuItemIngredient;
        bool idEquality = this.GetId().Equals(newMenuItemIngredient.GetId());
        bool ingredientDescriptionEquality = this.GetIngredientDescription().Equals(newMenuItemIngredient.GetIngredientDescription());
        bool menuItemsIdEquality = this.GetMenuItemsId().Equals(newMenuItemIngredient.GetMenuItemsId());
        bool storeIdEquality = this.GetStoreId().Equals(newMenuItemIngredient.GetStoreId());
        return (idEquality && ingredientDescriptionEquality && menuItemsIdEquality && storeIdEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }
  }
}
