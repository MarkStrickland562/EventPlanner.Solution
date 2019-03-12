using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace EventPlanner.Models
{
  public class Invitee
  {
    private string _inviteeName;
    private string _inviteeEmailAddress;
    private int _id;

    public Invitee(string inviteeName, string inviteeEmailAddress, int id = 0)
    {
      _inviteeName = inviteeName;
      _inviteeEmailAddress = inviteeEmailAddress;
      _id = id;
    }

    public string GetInviteeName()
    {
      return _inviteeName;
    }

    public void SetInviteeName(string newInviteeName)
    {
      _inviteeName = newInviteeName;
    }

    public string GetInviteeEmailAddress()
    {
      return _inviteeEmailAddress;
    }

    public void SetInviteeEmailAddress(string newInviteeEmailAddress)
    {
      _inviteeEmailAddress = newInviteeEmailAddress;
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
    //   cmd.CommandText = @"DELETE FROM events_invitees;
    //                       DELETE FROM invitees;";
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
    //   cmd.CommandText = @"INSERT INTO invitees (invitee_name, invitee_email_address)
    //                       VALUES (@inviteeName, @inviteeEmailAddress);";
    //   MySqlParameter inviteeName = new MySqlParameter();
    //   inviteeName.ParameterName = "@inviteeName";
    //   inviteeName.Value = this._inviteeName;
    //   cmd.Parameters.Add(inviteeName);
    //   MySqlParameter inviteeEmailAddress = new MySqlParameter();
    //   inviteeEmailAddress.ParameterName = "@inviteeEmailAddress";
    //   inviteeEmailAddress.Value = this._inviteeEmailAddress;
    //   cmd.Parameters.Add(inviteeEmailAddress);
    //     cmd.ExecuteNonQuery();
    //   _id = (int) cmd.LastInsertedId;
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public static List<invitee> GetAll()
    // {
    //   List<invitee> allinvitees = new List<invitee> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM invitees;";
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while(rdr.Read())
    //   {
    //     int inviteeId = rdr.GetInt32(0);
    //     string inviteeName = rdr.GetString(1);
    //     string inviteeEmailAddress = rdr.Getstring(2);
    //     invitee newinvitee = new invitee(inviteeName, inviteeEmailAddress, inviteeId);
    //     allinvitees.Add(newinvitee);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allinvitees;
    // }
    //
    // public static invitee Find(int id)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM invitees WHERE id = (@searchId);";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = id;
    //   cmd.Parameters.Add(searchId);
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int inviteeId = 0;
    //   string inviteeName = "";
    //   string inviteeEmailAddress = new string(1900, 1, 1);
    //     while(rdr.Read())
    //   {
    //     inviteeId = rdr.GetInt32(0);
    //     inviteeName = rdr.GetString(1);
    //     inviteeEmailAddress = rdr.Getstring(2);
    //     }
    //   invitee newinvitee = new invitee(inviteeName, inviteeEmailAddress, inviteeId);
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //     return newinvitee;
    // }
    //
    // public void Delete()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM events_invitees WHERE invitees_id = (@searchid);
    //                       DELETE FROM invitees WHERE id = (@searchId);";
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
    //   cmd.CommandText = @"DELETE FROM events_invitees;
    //                       DELETE FROM invitees";
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public void Edit(string newinviteeName, string newinviteeEmailAddress)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"UPDATE invitees SET invitee_name = (@inviteeName), invitee_email_address = (@inviteeEmailAddress)
    //                        WHERE id = (@inviteeId);";
    //   MySqlParameter inviteeNameParameter = new MySqlParameter();
    //   inviteeNameParameter.ParameterName = "@inviteeName";
    //   inviteeNameParameter.Value = newinviteeName;
    //   cmd.Parameters.Add(inviteeNameParameter);
    //   MySqlParameter inviteeEmailAddressParameter = new MySqlParameter();
    //   inviteeEmailAddressParameter.ParameterName = "@inviteeEmailAddress";
    //   inviteeEmailAddressParameter.Value = newinviteeEmailAddress;
    //   cmd.Parameters.Add(inviteeEmailAddressParameter);
    //   MySqlParameter inviteeIdParameter = new MySqlParameter();
    //   inviteeIdParameter.ParameterName = "@inviteeId";
    //   inviteeIdParameter.Value = this._id;
    //   cmd.Parameters.Add(inviteeIdParameter);
    //   cmd.ExecuteNonQuery();
    //   _inviteeName = newinviteeName;
    //   _inviteeEmailAddress = newinviteeEmailAddress;
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public void AddEvent(Event newEvent)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"INSERT INTO events_invitees (events_id, invitees_id) VALUES (@eventId, @inviteeId);";
    //   MySqlParameter eventIdParameter = new MySqlParameter();
    //   eventIdParameter.ParameterName = "@eventId";
    //   eventIdParameter.Value = newEvent.GetId();
    //   cmd.Parameters.Add(eventIdParameter);
    //   MySqlParameter inviteeIdParameter = new MySqlParameter();
    //   inviteeIdParameter.ParameterName = "@inviteeId";
    //   inviteeIdParameter.Value = this._id;
    //   cmd.Parameters.Add(inviteeIdParameter);
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public List<Event> GetEvents()
    // {
    //   List<Event> allEventinvitees = new List<Event> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT *
    //                         FROM events
    //                        WHERE id IN (SELECT events_id FROM events_invitees WHERE invitees_id = @inviteeId);";
    //   MySqlParameter inviteeId = new MySqlParameter();
    //   inviteeId.ParameterName = "@inviteeId";
    //   inviteeId.Value = this._id;
    //   cmd.Parameters.Add(inviteeId);
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while(rdr.Read())
    //   {
    //     int eventId = rdr.GetInt32(0);
    //     string eventName = rdr.GetString(1);
    //     string eventDate = rdr.Getstring(2);
    //     string eventLocation = rdr.GetString(3);
    //     int menusId = rdr.GetInt32(4);
    //     Event newEvent = new Event(eventName, eventDate, eventLocation, menusId, eventId);
    //     allEventinvitees.Add(newEvent);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allEventinvitees;
    // }
    //
    // public override bool Equals(System.Object otherinvitee)
    // {
    //   if (!(otherinvitee is invitee))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     invitee newinvitee = (invitee) otherinvitee;
    //     bool idEquality = this.GetId().Equals(newinvitee.GetId());
    //     bool inviteeNameEquality = this.GetinviteeName().Equals(newinvitee.GetinviteeName());
    //     bool inviteeEmailAddressEquality = this.GetinviteeEmailAddress().Equals(newinvitee.GetinviteeEmailAddress());
    //     return (idEquality && inviteeNameEquality && inviteeEmailAddressEquality);
    //   }
    // }
  }
}
