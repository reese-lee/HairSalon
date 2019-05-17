using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Specialty
  {
    public string Type { get; set; }
    public int Id { get; set; }

    public Specialty()
    {

    }

    public Specialty (string type)
    {
      Type = type;
      // Id = id;
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
      cmd.CommandText = @"INSERT INTO specialties (id, type) VALUES (@id, @type);";

      MySqlParameter type = new MySqlParameter();
      type.ParameterName = "@type";
      type.Value = this.type;
      cmd.Parameters.Add(type);

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
      cmd.CommandText = @"DELETE FROM specialties;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialties = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string type = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(type);
        allSpecialties.Add(newSpecialty);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }

    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int SpecialtyId = 0;
      string type = "";

      while(rdr.Read())
      {
        SpecialtyId = rdr.GetInt32(0);
        SpecialtyType = rdr.GetString(1);
      }
      Specialty newSpecialty = new Specialty(SpecialtyType, SpecialtyId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newSpecialty;
    }

    public void AddStylist(Stylist newStylist)
     {
       MySqlConnection conn = DB.Connection();
       conn.Open();
       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"INSERT INTO assignments (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";
       MySqlParameter stylist_id = new MySqlParameter();
       stylist_id.ParameterName = "@StylistId";
       stylist_id.Value = newStylist.GetId();
       cmd.Parameters.Add(stylist_id);
       MySqlParameter specialty_id = new MySqlParameter();
       specialty_id.ParameterName = "@SpecialtyId";
       specialty_id.Value = _id;
       cmd.Parameters.Add(specialty_id);
       cmd.ExecuteNonQuery();
       conn.Close();
       if(conn != null)
       {
         conn.Dispose();
       }
     }

    public List<Stylist> GetStylists()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM SpecialtiesController
      JOIN assignments ON (specialties.id = assignments.specialty_id)
      JOIN stylists ON (assignments.stylist_id = stylists.id)
      WHERE specialties.id = @specialty_id;";

      MySqlParameter specialtyId = new MySqlParameter();
      specialtyId.ParameterName = "@specialty_id";
      specialtyId.Value = this.Id;
      cmd.Parameters.Add(stylistId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Stylist> stylists = new List<Stylist>{};
      while(rdr.Read())
      {
          int stylistId = rdr.GetInt32(0);
          string stylistName = rdr.GetString(1);
          Stylist newStylist = new Stylist(stylistName, stylistId);
          stylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return stylists;
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
