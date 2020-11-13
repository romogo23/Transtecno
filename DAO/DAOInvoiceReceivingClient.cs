using DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class DAOInvoiceReceivingClient
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString); 
        public void InsertInvoiceClient(InvoiceReceivingClient invC)
        {
            String query = "INSERT INTO DESTINATARIO_FACTURA_CLIENTE(ID_CLIENTE, CORREO, NOMBRE) " +
                "VALUES(@idClient,@email,@nameClient)";

            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@idClient", invC.idClient);
            comm.Parameters.AddWithValue("@email", invC.email);
            comm.Parameters.AddWithValue("@nameClient", invC.nameClient);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public int InsertInvoiceClient(InvoiceReceivingClient invC)
        {
            String query = "Select count(0) from DESTINATARIO_FACTURA_CLIENTE where ID_CLIENTE = @idClient ";

            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@idClient", invC.idClient);
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
}
