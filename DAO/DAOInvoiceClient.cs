using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class DAOInvoiceClient
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString); //poner la ruta de la base de datos en línea
        SqlConnection conn2 = new SqlConnection(Properties.Settings.Default.connString);
        public void InsertProduct(Product p)
        {
            String query = "INSERT INTO Producto(Codigo,Nombre,Precio_Venta,Cantidad_Inventario,Producto_Activo,Unidad,Categoria) VALUES(@code,@name,@price,@quantity,@active,@unity,@category)";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@code", p.Code);
            comm.Parameters.AddWithValue("@name", p.Name);
            comm.Parameters.AddWithValue("@price", p.Price);
            comm.Parameters.AddWithValue("@quantity", p.Quantity);
            comm.Parameters.AddWithValue("@active", p.Active);
            comm.Parameters.AddWithValue("@unity", p.Unity);
            comm.Parameters.AddWithValue("@category", p.Category);
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
