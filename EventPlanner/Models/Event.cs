using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace EventPlanner.Models
{
  public class Event
  {
    private string _eventName;
    private DateTime _eventDate;
    private string _eventLocation;
    private int _menusId;
    private int _id;

    public Event(string eventName, DateTime eventDate, string eventLocation, int menusId, int id = 0)
    {
      _eventName = eventName;
      _eventDate = eventDate;
      _eventLocation = eventLocation;
      _menusId = menusId;
      _id = id;
    }

    public string GetEventName()
    {
      return _eventName;
    }

    public void SetEventName(string newEventName)
    {
      _eventName = newEventName;
    }

    public DateTime GetEventDate()
    {
      return _eventDate;
    }

    public void SetEventDate(DateTime newEventDate)
    {
      _eventDate = newEventDate;
    }

    public string GetEventLocation()
    {
      return _eventLocation;
    }

    public void SetEventLocation(string newEventLocation)
    {
      _eventLocation = newEventLocation;
    }

    public int GetMenusId()
    {
      return _menusId;
    }

    public void SetMenusId(int newMenusId)
    {
      _menusId = newMenusId;
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
      cmd.CommandText = @"DELETE FROM events_tasks; DELETE FROM events_invitees; DELETE FROM events;";
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
      cmd.CommandText = @"INSERT INTO Events (name, event_date, event_location, menus_id)
                          VALUES (@eventName, @eventDate, @eventLocation, @menusId);";
      MySqlParameter eventName = new MySqlParameter();
      eventName.ParameterName = "@eventName";
      eventName.Value = this._eventName;
      cmd.Parameters.Add(eventName);
      MySqlParameter eventDate = new MySqlParameter();
      eventDate.ParameterName = "@eventDate";
      eventDate.Value = this._eventDate;
      cmd.Parameters.Add(eventDate);
      MySqlParameter eventLocation = new MySqlParameter();
      eventLocation.ParameterName = "@eventLocation";
      eventLocation.Value = this._eventLocation;
      cmd.Parameters.Add(eventLocation);
      MySqlParameter menusId = new MySqlParameter();
      menusId.ParameterName = "@menusId";
      menusId.Value = this._menusId;
      cmd.Parameters.Add(menusId);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Event> GetAll()
    {
      List<Event> allEvents = new List<Event> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM events;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int eventId = rdr.GetInt32(0);
        string eventName = rdr.GetString(1);
        DateTime eventDate = rdr.GetDateTime(2);
        string eventLocation = rdr.GetString(3);
        int menusId = rdr.GetInt32(4);
        Event newEvent = new Event(eventName, eventDate, eventLocation, menusId, eventId);
        allEvents.Add(newEvent);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allEvents;
    }

    public static Event Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM Events WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int eventId = 0;
      string eventName = "";
      DateTime eventDate = new DateTime(1900, 1, 1);
      string eventLocation = "";
      int menusId = 0;
      while(rdr.Read())
      {
        eventId = rdr.GetInt32(0);
        eventName = rdr.GetString(1);
        eventDate = rdr.GetDateTime(2);
        eventLocation = rdr.GetString(3);
        menusId = rdr.GetInt32(4);
      }
      Event newEvent = new Event(eventName, eventDate, eventLocation, menusId, eventId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
        return newEvent;
    }

    // public List<Task> GetTasks()
    // {
    //   List<Task> allEventTasks = new List<Task> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT *
    //                         FROM tasks
    //                        WHERE task_id IN (SELECT task_id FROM events_tasks WHERE events_id = @Event_id);";
    //   MySqlParameter eventId = new MySqlParameter();
    //   eventId.ParameterName = "@Event_id";
    //   eventId.Value = this._id;
    //   cmd.Parameters.Add(eventId);
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while(rdr.Read())
    //   {
    //     int taskId = rdr.GetInt32(0);
    //     string taskDescription = rdr.GetString(1);
    //     DateTime plannedStartDateTime = rdr.GetDateTime(2);
    //     Task newTask = new Task(taskDescription, plannedStartDateTime, taskId);
    //     allEventTasks.Add(newTask);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allEventTasks;
    // }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM events_tasks WHERE events_id = (@searchid);
                          DELETE FROM events_invitees WHERE events_id = (@searchId);
                          DELETE FROM events WHERE id = (@searchId);";
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
                          DELETE FROM events_invitees;
                          DELETE FROM events";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
      
      // public void Edit(string newName, DateTime newHireDate)
      // {
      //   MySqlConnection conn = DB.Connection();
      //   conn.Open();
      //   var cmd = conn.CreateCommand() as MySqlCommand;
      //   cmd.CommandText = @"UPDATE Events SET name = (@EventName), hire_date = (@EventHireDate) WHERE id = (@EventId);";
      //   MySqlParameter EventNameParameter = new MySqlParameter();
      //   EventNameParameter.ParameterName = "@EventName";
      //   EventNameParameter.Value = newName;
      //   cmd.Parameters.Add(EventNameParameter);
      //   MySqlParameter EventHireDateParameter = new MySqlParameter();
      //   EventHireDateParameter.ParameterName = "@EventHireDate";
      //   EventHireDateParameter.Value = newHireDate;
      //   cmd.Parameters.Add(EventHireDateParameter);
      //   MySqlParameter EventIdParameter = new MySqlParameter();
      //   EventIdParameter.ParameterName = "@EventId";
      //   EventIdParameter.Value = this._id;
      //   cmd.Parameters.Add(EventIdParameter);
      //   cmd.ExecuteNonQuery();
      //   _name = newName;
      //   _hireDate = newHireDate;
      //   conn.Close();
      //   if (conn != null)
      //   {
      //     conn.Dispose();
      //   }
      // }
      //
      // public void AddSpecialty(Specialty newSpecialty)
      // {
      //   MySqlConnection conn = DB.Connection();
      //   conn.Open();
      //   var cmd = conn.CreateCommand() as MySqlCommand;
      //   cmd.CommandText = @"INSERT INTO Events_specialties (Events_id, specialties_id) VALUES (@EventId, @specialtyId);";
      //   MySqlParameter specialtyIdParameter = new MySqlParameter();
      //   specialtyIdParameter.ParameterName = "@specialtyId";
      //   specialtyIdParameter.Value = newSpecialty.GetId();
      //   cmd.Parameters.Add(specialtyIdParameter);
      //   MySqlParameter EventIdParameter = new MySqlParameter();
      //   EventIdParameter.ParameterName = "@EventId";
      //   EventIdParameter.Value = this._id;
      //   cmd.Parameters.Add(EventIdParameter);
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
      //                         FROM Events
      //                         JOIN Events_specialties ON (Events.id = Events_specialties.Events_id)
      //                         JOIN specialties ON (Events_specialties.specialties_id = specialties.id)
      //                        WHERE Events.id = (@EventId);";
      //   MySqlParameter EventIdParameter = new MySqlParameter();
      //   EventIdParameter.ParameterName = "@EventId";
      //   EventIdParameter.Value = this._id;
      //   cmd.Parameters.Add(EventIdParameter);
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

    public override bool Equals(System.Object otherEvent)
    {
      if (!(otherEvent is Event))
      {
        return false;
      }
      else
      {
        Event newEvent = (Event) otherEvent;
        bool idEquality = this.GetId().Equals(newEvent.GetId());
        bool eventNameEquality = this.GetEventName().Equals(newEvent.GetEventName());
        bool eventDateEquality = this.GetEventDate().Equals(newEvent.GetEventDate());
        bool eventLocationEquality = this.GetEventLocation().Equals(newEvent.GetEventLocation());
        bool menusIdEquality = this.GetMenusId().Equals(newEvent.GetMenusId());
        return (idEquality && eventNameEquality && eventDateEquality && eventLocationEquality && menusIdEquality);
      }
    }
  }
}
