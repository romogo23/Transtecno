using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOM;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOInvoiceClient
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);


        public Boolean InsertInvoiceClient(InvoiceClient invC)
        {
            DAOInvoiceReceivingClient invoiceReceivingClient = new DAOInvoiceReceivingClient();
            if (invoiceReceivingClient.VerifyInvoiceReceivingClient(invC.idClient) == 0)
            {

                String query = "INSERT INTO FACTURA_CLIENTE(NUMERO_FACTURA,ID_CLIENTE,FECHA_PAGO,ID_METODO_PAGO, METODO_PAGO," +
                 "MONTO,ESTADO, CONDICION_PAGO) VALUES(@code,@name,@price,@quantity,@active,@unity,@category)";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@numberInvoice", invC.numberInvoice);
                comm.Parameters.AddWithValue("@idClient", invC.idClient);
                comm.Parameters.AddWithValue("@paymentDate", invC.paymentDate);
                comm.Parameters.AddWithValue("@idPayMethod", invC.idPayMethod);
                comm.Parameters.AddWithValue("@payMethod", invC.payMethod);
                comm.Parameters.AddWithValue("@money", invC.money);
                comm.Parameters.AddWithValue("@condition", invC.condition);
                comm.Parameters.AddWithValue("@paymentCondition", invC.paymentCondition);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                comm.ExecuteNonQuery();
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}

