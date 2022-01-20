using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceSembako
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string koneksi = "Data Source=LAPTOP-GTRP6JSV;Initial Catalog=SembakoPat;Persist Security Info=True; User ID=sa;password=nova2000";
        SqlConnection conn;
        SqlCommand cmd;
        public string order(int IdOrder, string namaPembeli, string alamat, int jmlPesanan, int totalHarga, int IdProduct)
        {
            string a = "gagal";
            try 
            {
                //nama table jangan ORDER karena order adalah fungsing tersendiri di sql
                string sql = "INSERT INTO dbo.Pesan VALUES ('" + IdOrder +"','" + namaPembeli +"','" + alamat +"','" + jmlPesanan +"','" + totalHarga + "','" + IdProduct+"')";
                conn = new SqlConnection(koneksi);
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                a = "Sukses";
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return a;
        }           

        public string product(int IdProduct, string namaProduct, int harga, int stok, string deskripsi)
        {
            string a = "gagal";
            try
            {
                string sql = "INSERT INTO dbo.Product VALUES ('" + IdProduct + "','" + namaProduct + "','" + harga + "','" + stok + "','" + deskripsi + "')";
                conn = new SqlConnection(koneksi);
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                a = "Sukses";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return a;
        }
        public List<Order> Orders()
        {
            List<Order> orders = new List<Order>();
            try
            {
                string sql = "SELECT Id_Order, namaPembeli, Alamat, jmlPesanan, totalHarga, namaProduct FROM dbo.Pesan JOIN dbo.Product ON dbo.Pesan.Id_Product = dbo.Product.Id_Product";
                conn = new SqlConnection(koneksi);
                cmd = new SqlCommand(sql, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Order data = new Order();
                    data.IdOrder = reader.GetInt32(0);
                    data.namaPembeli = reader.GetString(1);
                    data.alamat = reader.GetString(2);
                    data.jmlPesanan = reader.GetInt32(3);
                    data.totalHarga = reader.GetInt32(4);
                    data.namaProduct = reader.GetString(5);

                    orders.Add(data);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return orders;
        }

        public List<Product> Products()
        {
            List<Product> products = new List<Product>();
            try
            {
                string sql = "SELECT * FROM dbo.Product";
                conn = new SqlConnection(koneksi);
                cmd = new SqlCommand(sql, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product data = new Product();
                    data.IdProduct = reader.GetInt32(0);
                    data.namaProduct = reader.GetString(1);
                    data.harga = reader.GetInt32(2);
                    data.stok = reader.GetInt32(3);
                    data.deskripsi = reader.GetString(4);

                    products.Add(data);
                }
                conn.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return products;
        }
    }
}
