using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    public string ClientName { get; set; }
    public int StylistId { get; set; }
    public int Id { get; set; }

     // public Stylist GetStylist()
     // {
     //   return Stylist.Find(StylistId);
     // }

    public static List<Client> restList = new List<Client> {};

    public Client()
    {

    }

    public Client (string clientName, int stylistId)
    {
      ClientName = clientName;
      StylistId = stylistId;
      // Id = id;
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
        string clientName = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        int id = rdr.GetInt32(0);
        Client newClient = new Client(clientName, stylistId);
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
      int clientId = 0;
      string clientName = "";
      int clientStylistId = 0;

      while(rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        clientName = rdr.GetString(1);
        clientStylistId = rdr.GetInt32(2);
      }
      Client newClient = new Client(clientName, clientStylistId);
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
        bool descriptionEquality = (this.ClientName == newClient.ClientName);
        bool categoryEquality = this.StylistId == newClient.StylistId;
        return (idEquality && descriptionEquality && categoryEquality);
      }
    }

    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO clients (clientName, stylist_id) VALUES (@clientName, @stylist_id);";

        MySqlParameter clientName = new MySqlParameter();
        clientName.ParameterName = "@clientName";
        clientName.Value = this.ClientName;
        cmd.Parameters.Add(clientName);

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
      cmd.CommandText = @"UPDATE clients SET clientName = @newName WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = Id;
      cmd.Parameters.Add(searchId);

      MySqlParameter clientName = new MySqlParameter();
      clientName.ParameterName = "@newName";
      clientName.Value = newName;

      cmd.Parameters.Add(clientName);
      cmd.ExecuteNonQuery();
      ClientName = newName;

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = Id;
      cmd.Parameters.Add(searchId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }

 }
}
