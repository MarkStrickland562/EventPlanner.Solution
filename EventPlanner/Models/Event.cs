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

      // public string GetEventName()
      // {
      //   return _eventName;
      // }
      //
      // public void SetEventName(string newEventName)
      // {
      //   _eventName = newEventName;
      // }
      //
      // public DateTime GetEventDate()
      // {
      //   return _eventDate;
      // }
      //
      // public void SetEventDate(DateTime newEventDate)
      // {
      //   _eventDate = newEventDate;
      // }
      //
      // public string GetEventLocation()
      // {
      //   return _eventLocation;
      // }
      //
      // public void SetEventLocation(string newEventLocation)
      // {
      //   _eventLocation = newEventLocation;
      // }
      //
      // public int GetMenusId()
      // {
      //   return _menusId;
      // }
      //
      // public void SetMenusId(int newMenusId)
      // {
      //   _menusId = newMenusId;
      // }
      //
      // public int GetId()
      // {
      //   return _id;
      // }
      //
      // public static void ClearAll()
      // {
      //   MySqlConnection conn = DB.Connection();
      //   conn.Open();
      //   var cmd = conn.CreateCommand() as MySqlCommand;
      //   cmd.CommandText = @"DELETE FROM events_tasks; DELETE FROM events_invitees; DELETE FROM events;";
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
      //   cmd.CommandText = @"INSERT INTO Events (name, hire_date) VALUES (@name, @hireDate);";
      //   MySqlParameter name = new MySqlParameter();
      //   name.ParameterName = "@name";
      //   name.Value = this._name;
      //   cmd.Parameters.Add(name);
      //   MySqlParameter hireDate = new MySqlParameter();
      //   hireDate.ParameterName = "@hireDate";
      //   hireDate.Value = this._hireDate;
      //   cmd.Parameters.Add(hireDate);
      //   cmd.ExecuteNonQuery();
      //   _id = (int) cmd.LastInsertedId;
      //   conn.Close();
      //   if (conn != null)
      //   {
      //     conn.Dispose();
      //   }
      // }
      //
      // public static List<Event> GetAll()
      // {
      //   List<Event> allEvents = new List<Event> {};
      //   MySqlConnection conn = DB.Connection();
      //   conn.Open();
      //   var cmd = conn.CreateCommand() as MySqlCommand;
      //   cmd.CommandText = @"SELECT * FROM Events;";
      //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
      //   while(rdr.Read())
      //   {
      //     int EventId = rdr.GetInt32(0);
      //     string EventName = rdr.GetString(1);
      //     DateTime EventHireDate = rdr.GetDateTime(2);
      //     Event newEvent = new Event(EventName, EventHireDate, EventId);
      //     allEvents.Add(newEvent);
      //   }
      //   conn.Close();
      //   if (conn != null)
      //   {
      //     conn.Dispose();
      //   }
      //   return allEvents;
      // }
      //
      // public static Event Find(int id)
      // {
      //   MySqlConnection conn = DB.Connection();
      //   conn.Open();
      //   var cmd = conn.CreateCommand() as MySqlCommand;
      //   cmd.CommandText = @"SELECT * FROM Events WHERE id = (@searchId);";
      //   MySqlParameter searchId = new MySqlParameter();
      //   searchId.ParameterName = "@searchId";
      //   searchId.Value = id;
      //   cmd.Parameters.Add(searchId);
      //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
      //   int EventId = 0;
      //   string EventName = "";
      //   DateTime EventHireDate = new DateTime(1900, 1, 1);
      //   while(rdr.Read())
      //   {
      //     EventId = rdr.GetInt32(0);
      //     EventName = rdr.GetString(1);
      //     EventHireDate = rdr.GetDateTime(2);
      //   }
      //   Event newEvent = new Event(EventName, EventHireDate, EventId);
      //   conn.Close();
      //   if (conn != null)
      //   {
      //     conn.Dispose();
      //   }
      //   return newEvent;
      // }
      //
      // public List<Client> GetClients()
      // {
      //   List<Client> allEventClients = new List<Client> {};
      //   MySqlConnection conn = DB.Connection();
      //   conn.Open();
      //   var cmd = conn.CreateCommand() as MySqlCommand;
      //   cmd.CommandText = @"SELECT * FROM Clients WHERE Events_id = @Event_id;";
      //   MySqlParameter EventId = new MySqlParameter();
      //   EventId.ParameterName = "@Event_id";
      //   EventId.Value = this._id;
      //   cmd.Parameters.Add(EventId);
      //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
      //   while(rdr.Read())
      //   {
      //     int clientId = rdr.GetInt32(0);
      //     string clientName = rdr.GetString(1);
      //     string clientGender = rdr.GetString(2);
      //     int clientEventId = rdr.GetInt32(3);
      //     Client newClient = new Client(clientName, clientGender, clientEventId, clientId);
      //     allEventClients.Add(newClient);
      //   }
      //   conn.Close();
      //   if (conn != null)
      //   {
      //     conn.Dispose();
      //   }
      //   return allEventClients;
      // }
      //
      // public void Delete()
      // {
      //   MySqlConnection conn = DB.Connection();
      //   conn.Open();
      //   var cmd = conn.CreateCommand() as MySqlCommand;
      //   cmd.CommandText = @"DELETE FROM Events_specialties WHERE Events_id = (@searchid);
      //                       UPDATE clients SET Events_id = NULL WHERE Events_id = (@searchId);
      //                       DELETE FROM Events WHERE id = (@searchId);";
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
      //   cmd.CommandText = @"DELETE FROM Events_specialties;
      //                       UPDATE clients SET Events_id = NULL;
      //                       DELETE FROM Events";
      //   cmd.ExecuteNonQuery();
      //   conn.Close();
      //   if (conn != null)
      //   {
      //     conn.Dispose();
      //   }
      // }
      //
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

  }
}
