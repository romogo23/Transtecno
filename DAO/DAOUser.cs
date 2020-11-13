using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class DAOUser
    {
        SqlConnection conn = new SqlConnection("");

        public Boolean insertUser() {
            return true;

        }
        public Boolean verifyClient(string id)
        {
            Boolean existsC;
            string query = "SELECT CASE WHEN EXISTS ( SELECT *FROM [Cliente] WHERE (Id_Cliente = @Id_Cliente)) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END ";
            SqlCommand comm2 = new SqlCommand(query, conn);
            comm2.Parameters.AddWithValue("@Id_Cliente", id);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            existsC = (Boolean)comm2.ExecuteScalar();


            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }
            return existsC;

        }

    }
}
