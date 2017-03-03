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
                string bandSong = rdr.GetString(3);
                Band newBand = new Band(bandName, bandGenre, bandSong, bandId);
            }

            DB.CloseQuery(rdr, conn);

            return AllBands;
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
