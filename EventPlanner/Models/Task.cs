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

    // public static void ClearAll()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM Tasks_tasks; DELETE FROM Tasks_invitees; DELETE FROM Tasks;";
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
    //   cmd.CommandText = @"INSERT INTO Tasks (name, Task_date, Task_location, menus_id)
    //                       VALUES (@TaskName, @TaskDate, @TaskLocation, @menusId);";
    //   MySqlParameter TaskName = new MySqlParameter();
    //   TaskName.ParameterName = "@TaskName";
    //   TaskName.Value = this._TaskName;
    //   cmd.Parameters.Add(TaskName);
    //   MySqlParameter TaskDate = new MySqlParameter();
    //   TaskDate.ParameterName = "@TaskDate";
    //   TaskDate.Value = this._TaskDate;
    //   cmd.Parameters.Add(TaskDate);
    //   MySqlParameter TaskLocation = new MySqlParameter();
    //   TaskLocation.ParameterName = "@TaskLocation";
    //   TaskLocation.Value = this._TaskLocation;
    //   cmd.Parameters.Add(TaskLocation);
    //   MySqlParameter menusId = new MySqlParameter();
    //   menusId.ParameterName = "@menusId";
    //   menusId.Value = this._menusId;
    //   cmd.Parameters.Add(menusId);
    //   cmd.ExecuteNonQuery();
    //   _id = (int) cmd.LastInsertedId;
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public static List<Task> GetAll()
    // {
    //   List<Task> allTasks = new List<Task> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM Tasks;";
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while(rdr.Read())
    //   {
    //     int TaskId = rdr.GetInt32(0);
    //     string TaskName = rdr.GetString(1);
    //     DateTime TaskDate = rdr.GetDateTime(2);
    //     string TaskLocation = rdr.GetString(3);
    //     int menusId = rdr.GetInt32(4);
    //     Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId, TaskId);
    //     allTasks.Add(newTask);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allTasks;
    // }
    //
    // public static Task Find(int id)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM Tasks WHERE id = (@searchId);";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = id;
    //   cmd.Parameters.Add(searchId);
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int TaskId = 0;
    //   string TaskName = "";
    //   DateTime TaskDate = new DateTime(1900, 1, 1);
    //   string TaskLocation = "";
    //   int menusId = 0;
    //   while(rdr.Read())
    //   {
    //     TaskId = rdr.GetInt32(0);
    //     TaskName = rdr.GetString(1);
    //     TaskDate = rdr.GetDateTime(2);
    //     TaskLocation = rdr.GetString(3);
    //     menusId = rdr.GetInt32(4);
    //   }
    //   Task newTask = new Task(TaskName, TaskDate, TaskLocation, menusId, TaskId);
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //     return newTask;
    // }
    //
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
    // public void Delete()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM Tasks_tasks WHERE Tasks_id = (@searchid);
    //                       DELETE FROM Tasks_invitees WHERE Tasks_id = (@searchId);
    //                       DELETE FROM Tasks WHERE id = (@searchId);";
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
    //   cmd.CommandText = @"DELETE FROM Tasks_tasks;
    //                       DELETE FROM Tasks_invitees;
    //                       DELETE FROM Tasks";
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    //   public void Edit(string newTaskName, DateTime newTaskDate, string newTaskLocation, int newMenusId)
    //   {
    //     MySqlConnection conn = DB.Connection();
    //     conn.Open();
    //     var cmd = conn.CreateCommand() as MySqlCommand;
    //     cmd.CommandText = @"UPDATE Tasks SET name = (@TaskName), Task_date = (@TaskDate), Task_location = (@TaskLocation), menus_id = (@menusId)
    //                          WHERE id = (@TaskId);";
    //     MySqlParameter TaskNameParameter = new MySqlParameter();
    //     TaskNameParameter.ParameterName = "@TaskName";
    //     TaskNameParameter.Value = newTaskName;
    //     cmd.Parameters.Add(TaskNameParameter);
    //     MySqlParameter TaskDateParameter = new MySqlParameter();
    //     TaskDateParameter.ParameterName = "@TaskDate";
    //     TaskDateParameter.Value = newTaskDate;
    //     cmd.Parameters.Add(TaskDateParameter);
    //     MySqlParameter TaskLocationParameter = new MySqlParameter();
    //     TaskLocationParameter.ParameterName = "@TaskLocation";
    //     TaskLocationParameter.Value = newTaskLocation;
    //     cmd.Parameters.Add(TaskLocationParameter);
    //     MySqlParameter menusIdParameter = new MySqlParameter();
    //     menusIdParameter.ParameterName = "@menusId";
    //     menusIdParameter.Value = newMenusId;
    //     cmd.Parameters.Add(menusIdParameter);
    //     MySqlParameter TaskIdParameter = new MySqlParameter();
    //     TaskIdParameter.ParameterName = "@TaskId";
    //     TaskIdParameter.Value = this._id;
    //     cmd.Parameters.Add(TaskIdParameter);
    //     cmd.ExecuteNonQuery();
    //     _TaskName = newTaskName;
    //     _TaskDate = newTaskDate;
    //     _TaskLocation = newTaskLocation;
    //     _menusId = newMenusId;
    //     conn.Close();
    //     if (conn != null)
    //     {
    //       conn.Dispose();
    //     }
    //   }

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

    // public override bool Equals(System.Object otherTask)
    // {
    //   if (!(otherTask is Task))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     Task newTask = (Task) otherTask;
    //     bool idEquality = this.GetId().Equals(newTask.GetId());
    //     bool taskDescriptionEquality = this.GetTaskDescription().Equals(newTask.GetTaskDescription());
    //     bool taskPlannedStartDateTimeEquality = this.GetTaskPlannedStartDateTime().Equals(newTask.GetTaskPlannedStartDateTime());
    //     return (idEquality && taskDescriptionEquality && taskPlannedStartDateTimeEquality);
    //   }
    // }
  }
}
