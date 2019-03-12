using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace EventPlanner.Models
{
  public class Store
  {
    private string _storeName;
    private int _id;

    public Store(string storeName, int id = 0)
    {
      _storeName = storeName;
      _id = id;
    }

    public string GetStoreName()
    {
      return _storeName;
    }

    public void SetStoreName(string newStoreName)
    {
      _storeName = newStoreName;
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
      cmd.CommandText = @"DELETE FROM stores;";
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
      cmd.CommandText = @"INSERT INTO stores (store_name)
                          VALUES (@storeName);";
      MySqlParameter storeName = new MySqlParameter();
      storeName.ParameterName = "@storeName";
      storeName.Value = this._storeName;
      cmd.Parameters.Add(storeName);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Store> GetAll()
    {
      List<Store> allStores = new List<Store> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stores;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int storeId = rdr.GetInt32(0);
        string storeName = rdr.GetString(1);
        Store newStore = new Store(storeName, storeId);
        allStores.Add(newStore);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStores;
    }

    public static Store Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stores WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int storeId = 0;
      string storeName = "";
      while(rdr.Read())
      {
        storeId = rdr.GetInt32(0);
        storeName = rdr.GetString(1);
      }
      Store newStore = new Store(storeName, storeId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
        return newStore;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE menu_item_ingredients SET store_id = NULL WHERE store_id = (@searchId);
                            DELETE FROM stores WHERE id = (@searchId);";
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
      cmd.CommandText = @"DELETE FROM stores";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newStoreName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stores SET store_name = (@storeName) WHERE id = (@storeId);";
      MySqlParameter storeNameParameter = new MySqlParameter();
      storeNameParameter.ParameterName = "@storeName";
      storeNameParameter.Value = newStoreName;
      cmd.Parameters.Add(storeNameParameter);
      MySqlParameter storeIdParameter = new MySqlParameter();
      storeIdParameter.ParameterName = "@storeId";
      storeIdParameter.Value = this._id;
      cmd.Parameters.Add(storeIdParameter);
      cmd.ExecuteNonQuery();
      _storeName = newStoreName;
        conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherStore)
    {
      if (!(otherStore is Store))
      {
        return false;
      }
      else
      {
        Store newStore = (Store) otherStore;
        bool idEquality = this.GetId().Equals(newStore.GetId());
        bool storeNameEquality = this.GetStoreName().Equals(newStore.GetStoreName());
        return (idEquality && storeNameEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }
  }
}
