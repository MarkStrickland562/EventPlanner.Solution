using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace EventPlanner.Models
{
  public class Task
  {
    private string _taskDescription;
    private DateTime _taskPlannedStartDateTime;
    private int _id;

    public Task(string taskDescription, DateTime taskPlannedStartDateTime, int id = 0)
    {
      _taskDescription = taskDescription;
      _taskPlannedStartDateTime = taskPlannedStartDateTime;
      _id = id;
    }

    public string GetTaskDescription()
    {
      return _taskDescription;
    }

    public void SetTaskDescription(string newTaskDescription)
    {
      _taskDescription = newTaskDescription;
    }

    public DateTime GetTaskPlannedStartDateTime()
    {
      return _taskPlannedStartDateTime;
    }

    public void GetTaskPlannedStartDateTime_ReturnsTaskPlannedStartDateTime_DateTime(DateTime newTaskPlannedStartDateTime)
    {
      _taskPlannedStartDateTime = newTaskPlannedStartDateTime;
    }

    public void SetTaskPlannedStartDateTime(DateTime newTaskPlannedStartDateTime)
    {
      _taskPlannedStartDateTime = newTaskPlannedStartDateTime;
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
      cmd.CommandText = @"DELETE FROM events_tasks;
                          DELETE FROM tasks;";
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
      cmd.CommandText = @"INSERT INTO Tasks (task_description, planned_start_datetime)
                          VALUES (@taskDescription, @taskPlannedStartDateTime);";
      MySqlParameter taskDescription = new MySqlParameter();
      taskDescription.ParameterName = "@taskDescription";
      taskDescription.Value = this._taskDescription;
      cmd.Parameters.Add(taskDescription);
      MySqlParameter taskPlannedStartDateTime = new MySqlParameter();
      taskPlannedStartDateTime.ParameterName = "@taskPlannedStartDateTime";
      taskPlannedStartDateTime.Value = this._taskPlannedStartDateTime;
      cmd.Parameters.Add(taskPlannedStartDateTime);
        cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Task> GetAll()
    {
      List<Task> allTasks = new List<Task> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM tasks;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int taskId = rdr.GetInt32(0);
        string taskDescription = rdr.GetString(1);
        DateTime taskPlannedStartDateTime = rdr.GetDateTime(2);
        Task newTask = new Task(taskDescription, taskPlannedStartDateTime, taskId);
        allTasks.Add(newTask);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allTasks;
    }

    public static Task Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM tasks WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int taskId = 0;
      string taskDescription = "";
      DateTime taskPlannedStartDateTime = new DateTime(1900, 1, 1);
        while(rdr.Read())
      {
        taskId = rdr.GetInt32(0);
        taskDescription = rdr.GetString(1);
        taskPlannedStartDateTime = rdr.GetDateTime(2);
        }
      Task newTask = new Task(taskDescription, taskPlannedStartDateTime, taskId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
        return newTask;
    }

    // // public List<Task> GetTasks()
    // // {
    // //   List<Task> allTaskTasks = new List<Task> {};
    // //   MySqlConnection conn = DB.Connection();
    // //   conn.Open();
    // //   var cmd = conn.CreateCommand() as MySqlCommand;
    // //   cmd.CommandText = @"SELECT *
    // //                         FROM tasks
    // //                        WHERE task_id IN (SELECT task_id FROM Tasks_tasks WHERE Tasks_id = @Task_id);";
    // //   MySqlParameter TaskId = new MySqlParameter();
    // //   TaskId.ParameterName = "@Task_id";
    // //   TaskId.Value = this._id;
    // //   cmd.Parameters.Add(TaskId);
    // //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    // //   while(rdr.Read())
    // //   {
    // //     int taskId = rdr.GetInt32(0);
    // //     string taskDescription = rdr.GetString(1);
    // //     DateTime plannedStartDateTime = rdr.GetDateTime(2);
    // //     Task newTask = new Task(taskDescription, plannedStartDateTime, taskId);
    // //     allTaskTasks.Add(newTask);
    // //   }
    // //   conn.Close();
    // //   if (conn != null)
    // //   {
    // //     conn.Dispose();
    // //   }
    // //   return allTaskTasks;
    // // }
    //

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM events_tasks WHERE tasks_id = (@searchid);
                          DELETE FROM tasks WHERE id = (@searchId);";
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
      cmd.CommandText = @"DELETE FROM events_tasks;
                          DELETE FROM tasks";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newTaskDescription, DateTime newTaskPlannedStartDateTime)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE tasks SET task_description = (@taskDescription), planned_start_datetime = (@taskPlannedStartDateTime)
                           WHERE id = (@taskId);";
      MySqlParameter taskDescriptionParameter = new MySqlParameter();
      taskDescriptionParameter.ParameterName = "@taskDescription";
      taskDescriptionParameter.Value = newTaskDescription;
      cmd.Parameters.Add(taskDescriptionParameter);
      MySqlParameter taskPlannedStartDateTimeParameter = new MySqlParameter();
      taskPlannedStartDateTimeParameter.ParameterName = "@taskPlannedStartDateTime";
      taskPlannedStartDateTimeParameter.Value = newTaskPlannedStartDateTime;
      cmd.Parameters.Add(taskPlannedStartDateTimeParameter);
      MySqlParameter taskIdParameter = new MySqlParameter();
      taskIdParameter.ParameterName = "@taskId";
      taskIdParameter.Value = this._id;
      cmd.Parameters.Add(taskIdParameter);
      cmd.ExecuteNonQuery();
      _taskDescription = newTaskDescription;
      _taskPlannedStartDateTime = newTaskPlannedStartDateTime;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

      // public void AddSpecialty(Specialty newSpecialty)
      // {
      //   MySqlConnection conn = DB.Connection();
      //   conn.Open();
      //   var cmd = conn.CreateCommand() as MySqlCommand;
      //   cmd.CommandText = @"INSERT INTO Tasks_specialties (Tasks_id, specialties_id) VALUES (@TaskId, @specialtyId);";
      //   MySqlParameter specialtyIdParameter = new MySqlParameter();
      //   specialtyIdParameter.ParameterName = "@specialtyId";
      //   specialtyIdParameter.Value = newSpecialty.GetId();
      //   cmd.Parameters.Add(specialtyIdParameter);
      //   MySqlParameter TaskIdParameter = new MySqlParameter();
      //   TaskIdParameter.ParameterName = "@TaskId";
      //   TaskIdParameter.Value = this._id;
      //   cmd.Parameters.Add(TaskIdParameter);
      //   cmd.ExecuteNonQuery();
      //   conn.Close();
      //   if (conn != null)
      //   {
      //     conn.Dispose();
      //   }
      // }
      //
      // public List<Specialty> GetSpecialties()
      // {
      //   MySqlConnection conn = DB.Connection();
      //   conn.Open();
      //   var cmd = conn.CreateCommand() as MySqlCommand;
      //   cmd.CommandText = @"SELECT specialties.*
      //                         FROM Tasks
      //                         JOIN Tasks_specialties ON (Tasks.id = Tasks_specialties.Tasks_id)
      //                         JOIN specialties ON (Tasks_specialties.specialties_id = specialties.id)
      //                        WHERE Tasks.id = (@TaskId);";
      //   MySqlParameter TaskIdParameter = new MySqlParameter();
      //   TaskIdParameter.ParameterName = "@TaskId";
      //   TaskIdParameter.Value = this._id;
      //   cmd.Parameters.Add(TaskIdParameter);
      //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      //   List<Specialty> specialtyList = new List<Specialty>{};
      //   while(rdr.Read())
      //   {
      //     int specialtyId = rdr.GetInt32(0);
      //     string specialty= rdr.GetString(1);
      //     Specialty newSpecialty = new Specialty(specialty, specialtyId);
      //     specialtyList.Add(newSpecialty);
      //   }
      //   conn.Close();
      //   if (conn != null)
      //   {
      //      conn.Dispose();
      //   }
      //   return specialtyList;
      // }

    public override bool Equals(System.Object otherTask)
    {
      if (!(otherTask is Task))
      {
        return false;
      }
      else
      {
        Task newTask = (Task) otherTask;
        bool idEquality = this.GetId().Equals(newTask.GetId());
        bool taskDescriptionEquality = this.GetTaskDescription().Equals(newTask.GetTaskDescription());
        bool taskPlannedStartDateTimeEquality = this.GetTaskPlannedStartDateTime().Equals(newTask.GetTaskPlannedStartDateTime());
        return (idEquality && taskDescriptionEquality && taskPlannedStartDateTimeEquality);
      }
    }
  }
}
