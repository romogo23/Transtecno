using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class DAOInvoiceReceivingSupplier
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);
        public void InsertInvoiceReceivingSupplier(InvoiceReceivingClient invC)
        {
            if (VerifyInvoiceReceivingClient(invC.idClient) == 0)
            {
                String query = "INSERT INTO DESTINATARIO_FACTURA_PROVEEDOR(ID_PROVEEDOR, CORREO, NOMBRE) " +
                    "VALUES(@idProveedor,@email,@name)";

                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@idProveedor", invC.idClient);
                comm.Parameters.AddWithValue("@email", invC.email);
                comm.Parameters.AddWithValue("@name", invC.nameClient);
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

        public int VerifyInvoiceReceivingSupplier(string id)
        {
            String query = "Select count(0) from DESTINATARIO_FACTURA_PROVEEDOR where ID_PROVEEDOR = @idProveedor";
            int verify;
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@idProveedor", id);
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
    }
}
