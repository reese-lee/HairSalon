using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    public string Name { get; set; }
    public string Specialty { get; set; }
    public int Id { get; set; }
    public List<Client> Clients { get; set; }

    public static List<Stylist> stylistList = new List<Stylist> {};

    public Stylist (string name, string specialty, int id = 0)
    {
      Name = name;
      Specialty = specialty;
      Id = id;
      Clients = new List<Client> {};
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.Id.Equals(newStylist.Id);
        bool nameEquality = this.Name.Equals(newStylist.Name);
        return (idEquality && nameEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name, specialty, id) VALUES (@name, @specialty, @id);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this.Name;
      cmd.Parameters.Add(name);

      MySqlParameter specialty = new MySqlParameter();
      specialty.ParameterName = "@specialty";
      specialty.Value = this.Specialty;
      cmd.Parameters.Add(specialty);

      MySqlParameter id = new MySqlParameter();
      id.ParameterName = "@id";
      id.Value = this.Id;
      cmd.Parameters.Add(id);

      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylist = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string specialty = rdr.GetString(2);
        Stylist newStylist = new Stylist(name, specialty, id);
        allStylist.Add(newStylist);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylist;
    }

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int StylistId = 0;
      string StylistName = "";
      string StylistSpecialty = "";

      while(rdr.Read())
      {
        StylistId = rdr.GetInt32(0);
        StylistName = rdr.GetString(1);
        StylistSpecialty = rdr.GetString(2);
      }
      Stylist newStylist = new Stylist(StylistName, StylistSpecialty, StylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newStylist;
    }

    public List<Client> GetClients()
    {
      List<Client> allStylistClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylist_id;";
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylist_id";
      stylistId.Value = this.Id;
      cmd.Parameters.Add(stylistId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
          int clientId = rdr.GetInt32(0);
          string clientName = rdr.GetString(1);
          int clientStylistId = rdr.GetInt32(2);
          Client newClient = new Client(clientName, clientStylistId, clientId);
          allStylistClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allStylistClients;
    }

    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM stylists;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }

  }
}
