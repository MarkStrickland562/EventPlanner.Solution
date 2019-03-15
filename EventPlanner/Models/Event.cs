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
      cmd.CommandText = @"INSERT INTO events (name, event_date, event_location, menus_id)
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

    public List<Task> GetTasks()
    {
      List<Task> allEventTasks = new List<Task> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT *
                            FROM tasks
                           WHERE id IN (SELECT tasks_id FROM events_tasks WHERE events_id = @eventId);";
      MySqlParameter eventId = new MySqlParameter();
      eventId.ParameterName = "@eventId";
      eventId.Value = this._id;
      cmd.Parameters.Add(eventId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int taskId = rdr.GetInt32(0);
        string taskDescription = rdr.GetString(1);
        DateTime plannedStartDateTime = rdr.GetDateTime(2);
        Task newTask = new Task(taskDescription, plannedStartDateTime, taskId);
        allEventTasks.Add(newTask);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allEventTasks;
    }

    public List<Invitee> GetInvitees()
    {
      List<Invitee> allEventInvitees = new List<Invitee> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT *
                            FROM invitees
                           WHERE id IN (SELECT invitees_id FROM events_invitees WHERE events_id = @eventId);";
      MySqlParameter eventId = new MySqlParameter();
      eventId.ParameterName = "@eventId";
      eventId.Value = this._id;
      cmd.Parameters.Add(eventId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int inviteeId = rdr.GetInt32(0);
        string inviteeName = rdr.GetString(1);
        string inviteeEmailAddress = rdr.GetString(2);
        Invitee newInvitee = new Invitee(inviteeName, inviteeEmailAddress, inviteeId);
        allEventInvitees.Add(newInvitee);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allEventInvitees;
    }

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

    public void Edit(string newEventName, DateTime newEventDate, string newEventLocation, int newMenusId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE events SET name = (@eventName), event_date = (@eventDate), event_location = (@eventLocation), menus_id = (@menusId)
                           WHERE id = (@eventId);";
      MySqlParameter eventNameParameter = new MySqlParameter();
      eventNameParameter.ParameterName = "@eventName";
      eventNameParameter.Value = newEventName;
      cmd.Parameters.Add(eventNameParameter);
      MySqlParameter eventDateParameter = new MySqlParameter();
      eventDateParameter.ParameterName = "@eventDate";
      eventDateParameter.Value = newEventDate;
      cmd.Parameters.Add(eventDateParameter);
      MySqlParameter eventLocationParameter = new MySqlParameter();
      eventLocationParameter.ParameterName = "@eventLocation";
      eventLocationParameter.Value = newEventLocation;
      cmd.Parameters.Add(eventLocationParameter);
      MySqlParameter menusIdParameter = new MySqlParameter();
      menusIdParameter.ParameterName = "@menusId";
      menusIdParameter.Value = newMenusId;
      cmd.Parameters.Add(menusIdParameter);
      MySqlParameter eventIdParameter = new MySqlParameter();
      eventIdParameter.ParameterName = "@eventId";
      eventIdParameter.Value = this._id;
      cmd.Parameters.Add(eventIdParameter);
      cmd.ExecuteNonQuery();
      _eventName = newEventName;
      _eventDate = newEventDate;
      _eventLocation = newEventLocation;
      _menusId = newMenusId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void AddTask(Task newTask)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO events_tasks (events_id, tasks_id) VALUES (@eventId, @taskId);";
      MySqlParameter taskIdParameter = new MySqlParameter();
      taskIdParameter.ParameterName = "@taskId";
      taskIdParameter.Value = newTask.GetId();
      cmd.Parameters.Add(taskIdParameter);
      MySqlParameter eventIdParameter = new MySqlParameter();
      eventIdParameter.ParameterName = "@eventId";
      eventIdParameter.Value = this._id;
      cmd.Parameters.Add(eventIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void DeleteTask(Task newTask)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM events_tasks WHERE events_id = (@eventId) AND tasks_id = (@taskId);";
      MySqlParameter taskIdParameter = new MySqlParameter();
      taskIdParameter.ParameterName = "@taskId";
      taskIdParameter.Value = newTask.GetId();
      cmd.Parameters.Add(taskIdParameter);
      MySqlParameter eventIdParameter = new MySqlParameter();
      eventIdParameter.ParameterName = "@eventId";
      eventIdParameter.Value = this._id;
      cmd.Parameters.Add(eventIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void AddInvitee(Invitee newInvitee)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO events_invitees (events_id, invitees_id) VALUES (@eventId, @inviteeId);";
      MySqlParameter inviteeIdParameter = new MySqlParameter();
      inviteeIdParameter.ParameterName = "@inviteeId";
      inviteeIdParameter.Value = newInvitee.GetId();
      cmd.Parameters.Add(inviteeIdParameter);
      MySqlParameter eventIdParameter = new MySqlParameter();
      eventIdParameter.ParameterName = "@eventId";
      eventIdParameter.Value = this._id;
      cmd.Parameters.Add(eventIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void DeleteInvitee(Invitee newInvitee)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM events_invitees WHERE events_id = (@eventId) AND invitees_id = (@inviteeId);";
      MySqlParameter inviteeIdParameter = new MySqlParameter();
      inviteeIdParameter.ParameterName = "@inviteeId";
      inviteeIdParameter.Value = newInvitee.GetId();
      cmd.Parameters.Add(inviteeIdParameter);
      MySqlParameter eventIdParameter = new MySqlParameter();
      eventIdParameter.ParameterName = "@eventId";
      eventIdParameter.Value = this._id;
      cmd.Parameters.Add(eventIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Menu> GetMenu()
    {
      List<Menu> allMenus = new List<Menu> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT *
                            FROM menus
                           WHERE id = (SELECT menus_id FROM events WHERE id = @eventId);";
      MySqlParameter eventId = new MySqlParameter();
      eventId.ParameterName = "@eventId";
      eventId.Value = this._id;
      cmd.Parameters.Add(eventId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int menusId = rdr.GetInt32(0);
        string menuTheme = rdr.GetString(1);
        Menu newMenu = new Menu(menuTheme, menusId);
        allMenus.Add(newMenu);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allMenus;
    }

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

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }
  }
}
