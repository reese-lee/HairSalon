using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    public string Name { get; set; }
    public int StylistId { get; set; }
    public int Id { get; set; }

     // public Stylist GetStylist()
     // {
     //   return Stylist.Find(StylistId);
     // }

    public static List<Client> restList = new List<Client> {};

    public Client (string name, int stylistId, int id = 0)
    {
      Name = name;
      StylistId = stylistId;
      Id = id;
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string name = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        int id = rdr.GetInt32(0);
        Client newClient = new Client(name, stylistId, id);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      string name = "";
      int stylistId = 0;

      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        stylistId = rdr.GetInt32(2);
      }
      Client newClient = new Client(name, stylistId, id);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newClient;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.Id == newClient.Id;
        bool descriptionEquality = (this.Name == newClient.Name);
        bool categoryEquality = this.StylistId == newClient.StylistId;
        return (idEquality && descriptionEquality && categoryEquality);
      }
    }

    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@name, @stylist_id);";

        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@name";
        name.Value = this.Name;
        cmd.Parameters.Add(name);

        MySqlParameter stylistId = new MySqlParameter();
        stylistId.ParameterName = "@stylist_id";
        stylistId.Value = this.StylistId;

        cmd.Parameters.Add(stylistId);
        cmd.ExecuteNonQuery();
        Id = (int) cmd.LastInsertedId;

        conn.Close();

        if (conn != null)
        {
            conn.Dispose();
        }
    }

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET name = @newName WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = Id;
      cmd.Parameters.Add(searchId);

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newName;

      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      Name = newName;

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
    }

 }
}
