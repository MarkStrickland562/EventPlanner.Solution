using System;
using MySql.Data.MySqlClient;
using EventPlanner;

namespace EventPlanner.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}
