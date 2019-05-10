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
    //
    // public override bool Equals(System.Object otherStylist)
    // {
    //   if (!(otherStylist is Stylist))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     Stylist newStylist = (Stylist) otherStylist;
    //     bool idEquality = this.Id.Equals(newStylist.Id);
    //     bool nameEquality = this.Type.Equals(newStylist.Type);
    //     return (idEquality && nameEquality);
    //   }
    // }
    //
    // public void Save()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@name);";
    //   MySqlParameter type = new MySqlParameter();
    //   type.ParameterName = "@type";
    //   type.Value = this.Type;
    //   cmd.Parameters.Add(type);
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public static void ClearAll()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM stylists;";
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public static List<Stylist> GetAll()
    // {
    //   List<Stylist> allStylist = new List<Stylist> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM stylists;";
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //
    //   while (rdr.Read())
    //   {
    //     int id = rdr.GetInt32(0);
    //     string name = rdr.GetString(1);
    //     string specialty = rdr.GetString(2);
    //     Stylist newStylist = new Stylist(name, specialty, id);
    //     allStylist.Add(newStylist);
    //   }
    //
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allStylist;
    // }
    //
    // public static Stylist Find(int id)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";
    //
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = id;
    //   cmd.Parameters.Add(searchId);
    //
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int StylistId = 0;
    //   string StylistType = "";
    //
    //   while(rdr.Read())
    //   {
    //     StylistType = rdr.GetString(0);
    //     StylistId = rdr.GetInt32(1);
    //   }
    //   Stylist newStylist = new Stylist(StylistType, StylistId);
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return newStylist;
    // }
    //
    // public static void DeleteAll()
    // {
    //     MySqlConnection conn = DB.Connection();
    //     conn.Open();
    //     var cmd = conn.CreateCommand() as MySqlCommand;
    //     cmd.CommandText = @"DELETE FROM stylists;";
    //     cmd.ExecuteNonQuery();
    //     conn.Close();
    //     if (conn != null)
    //     {
    //         conn.Dispose();
    //     }
    // }

  }
}
