using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
    public class DB
    {
        SqlConnection conn = new SqlConnection(DBConfiguration.ConnectionString);
        return conn;
    }
}
