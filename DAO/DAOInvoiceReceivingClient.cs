using DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOInvoiceReceivingClient
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString); 
        public void InsertInvoiceReceivingClient(InvoiceReceivingClient invC)
        {
            if (VerifyInvoiceReceivingClient(invC.idClient) == 0) {
                String query = "INSERT INTO DESTINATARIO_FACTURA_CLIENTE(ID_CLIENTE, CORREO, NOMBRE) " +
                    "VALUES(@idClient,@email,@nameClient)";

                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@idClient", invC.idClient);
                comm.Parameters.AddWithValue("@email", invC.email);
                comm.Parameters.AddWithValue("@nameClient", invC.nameClient);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                comm.ExecuteNonQuery();
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
            }
        }

        public int VerifyInvoiceReceivingClient(string id)
        {
            String query = "Select count(0) from DESTINATARIO_FACTURA_CLIENTE where ID_CLIENTE = @idClient ";
            int verify;
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@idClient", id);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            verify = comm.ExecuteNonQuery();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            return verify; 
        }

        public int ListClients(string id)
        {
            String query = "Select count(0) from DESTINATARIO_FACTURA_CLIENTE where ID_CLIENTE = @idClient ";
            int verify;
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@idClient", id);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            verify = comm.ExecuteNonQuery();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            return verify;
        }



        //public List<String> LoadDetail(int id)
        //{
        //    String query = "Select * from DESTINATARIO_FACTURA_CLIENTE where NOMBRE like 'c%'";
        //    List<String> listClientsName = new List<String>();
        //    SqlCommand comm = new SqlCommand(query, conn);
        //    comm.Parameters.AddWithValue("@id_Order", id);
        //    SqlDataReader reader2;

        //    if (conn.State != System.Data.ConnectionState.Open)
        //    {
        //        conn.Open();
        //    }

        //    reader2 = comm.ExecuteReader();
        //    if (reader2.HasRows)
        //    {
        //        while (reader2.Read())
        //        {
        //            listClientsName.Add(new InvoiceReceivingClient( reader2["ID_CLIENTE"].ToString(), reader2["CORREO"].ToString(), reader2["NOMBRE"].ToString()));
        //        }
        //    }


        //    if (conn.State != System.Data.ConnectionState.Closed)
        //    {
        //        conn.Close();

        //    }


        //    return listClientsName;
        //}

 

    }
}
