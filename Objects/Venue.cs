using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker
{
    public class Venue
    {
        private int _id;
        private string _name;

        public Venue(string Name, int Id = 0)
        {
            _id = Id;
            _name = Name;
        }

        public override bool Equals(System.Object otherVenue)
        {
            if (!(otherVenue is Venue))
            {
                return false;
            }
            else
            {
                Venue newVenue = (Venue) otherVenue;
                bool idEquality = this.GetId() == newVenue.GetId();
                bool nameEquality = this.GetName() == newVenue.GetName();
                return (idEquality && nameEquality);
            }
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string newName)
        {
            _name = newName;
        }

        public static List<Venue> GetAll()
        {
            List<Venue> AllVenues = new List<Venue>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int venueId = rdr.GetInt32(0);
                string venueName = rdr.GetString(1);
                Venue newVenue= new Venue(venueName, venueId);
                AllVenues.Add(newVenue);
            }

            DB.CloseQuery(rdr, conn);

            return AllVenues;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO venues (name) OUTPUT INSERTED.id VALUES (@VenueName);", conn);

            cmd.Parameters.Add(new SqlParameter("@VenueName", this.GetName()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            DB.CloseQuery(rdr, conn);
        }

        public static void DeleteAll()
        {
          SqlConnection conn = DB.Connection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("DELETE FROM venues;", conn);

          DB.CloseNonQuery(cmd, conn);
        }
    }
}
