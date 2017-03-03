using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker
{
    public class Band
    {
        private int _id;
        private string _name;
        private string _genre;
        private string _song;

        public Band(string Name, string Genre, string Song, int Id = 0)
        {
            _id = Id;
            _name = Name;
            _genre = Genre;
            _song = Song;
        }

        public override bool Equals(System.Object otherBand)
        {
            if (!(otherBand is Band))
            {
                return false;
            }
            else
            {
                Band newBand = (Band) otherBand;
                bool idEquality = (this.GetId() == newBand.GetId());
                bool nameEquality = (this.GetName() == newBand.GetName());
                bool genreEquality = (this.GetGenre() == newBand.GetGenre());
                bool songEquality = (this.GetSong() == newBand.GetSong());
                return (idEquality && nameEquality && genreEquality && songEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
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

        public string GetGenre()
        {
            return _genre;
        }
        public void SetGenre(string newGenre)
        {
            _genre = newGenre;
        }

        public string GetSong()
        {
            return _song;
        }
        public void SetSong(string newSong)
        {
            _song = newSong;
        }

        public static List<Band> GetAll()
        {
            List<Band> AllBands = new List<Band>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM bands;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int bandId = rdr.GetInt32(0);
                string bandName = rdr.GetString(1);
                string bandGenre = rdr.GetString(2);
                string bandSong = rdr.GetString(3);;
                Band newBand = new Band(bandName, bandGenre, bandSong, bandId);
                AllBands.Add(newBand);
            }

            DB.CloseQuery(rdr, conn);

            return AllBands;
        }


        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO bands (name, genre, song) OUTPUT INSERTED.id VALUES (@BandName, @BandGenre, @BandSong);", conn);

            cmd.Parameters.Add(new SqlParameter("@BandName", this.GetName()));
            cmd.Parameters.Add(new SqlParameter("@BandGenre", this.GetGenre()));
            cmd.Parameters.Add(new SqlParameter("@BandSong", this.GetSong()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            DB.CloseQuery(rdr, conn);
        }

        public static Band Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM bands WHERE id = @BandId;", conn);

            cmd.Parameters.Add(new SqlParameter("@BandId", id.ToString()));

            SqlDataReader rdr = cmd.ExecuteReader();

            int foundBandId = 0;
            string foundBandName = null;
            string foundBandGenre = null;
            string foundBandSong = null;
            int foundBandRating = 0;

            while(rdr.Read())
            {
                foundBandId = rdr.GetInt32(0);
                foundBandName = rdr.GetString(1);
                foundBandGenre = rdr.GetString(2);
                foundBandSong = rdr.GetString(3);
            }

            Band foundBand = new Band(foundBandName, foundBandGenre, foundBandSong, foundBandId);

            DB.CloseQuery(rdr, conn);

            return foundBand;
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM bands;", conn);

            DB.CloseNonQuery(cmd, conn);
        }
    }
}
