using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
    public class DB
    {
        public static SqlConnection Connection()
        {
            SqlConnection conn = new SqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }

        public static void CloseQuery(SqlDataReader rdr, SqlConnection conn)
        {
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static void CloseNonQuery(SqlCommand cmd, SqlConnection conn)
        {
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
