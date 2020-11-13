using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOM;

namespace DAO
{
    class DAOInvoiceClient
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString); //poner la ruta de la base de datos en línea
        SqlConnection conn2 = new SqlConnection(Properties.Settings.Default.connString);
        public void InsertInvoiceClient(InvoiceClient invC)
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
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public String LastProduct()
        {
            String query = "SELECT MAX(Codigo) FROM Producto";
            SqlCommand comm = new SqlCommand(query, conn);
            String code = "";
            SqlDataReader reader;
            conn.Open();
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    code = reader.GetString(0);

                }
            }

            return code;
        }


        public Product LoadProduct(Product p)
        {
            String query = "SELECT * FROM Producto WHERE Codigo = @code";
            Product temp = new Product();
            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataReader reader;
            comm.Parameters.AddWithValue("@code", p.Code);
            conn.Open();
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    temp = new Product(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetBoolean(4), reader.GetString(5), reader.GetString(6));
                }
            }


            return temp;

        }


        public List<Product> LoadProducts()
        {
            String query = "SELECT * FROM Producto";
            List<Product> products = new List<Product>();
            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataReader reader;
            conn.Open();
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    products.Add(new Product(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetBoolean(4), reader.GetString(5), reader.GetString(6)));
                }
            }


            return products;
        }

        public Product LoadProductId(String id)
        {
            String query = "SELECT * FROM Producto WHERE Codigo = @code";
            Product temp = new Product();
            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataReader reader;
            comm.Parameters.AddWithValue("@code", id);
            conn.Open();
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    temp = new Product(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetBoolean(4), reader.GetString(5), reader.GetString(6));
                }
            }


            return temp;

        }



        

    }
}
