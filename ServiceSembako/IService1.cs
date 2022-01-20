using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceSembako
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string order(int IdOrder, string namaPembeli, string alamat, int jmlPesanan, int totalHarga, int IdProduct);
        [OperationContract]
        string product(int IdProduct, string namaProduct, int harga, int stok, string deskripsi);
        [OperationContract]
        List<Order> Orders();
        [OperationContract]
        List<Product> Products();
    }

    public class Order
    {
        [DataMember]
        public int IdOrder { get; set; }
        [DataMember]
        public string namaPembeli { get; set; }
        [DataMember] 
        public string alamat { get; set; }
        [DataMember] 
        public int jmlPesanan { get; set; }
        [DataMember] 
        public int totalHarga { get; set; }
        [DataMember] 
        public string namaProduct { get; set; }
    }
    public class Product
    {
        [DataMember] 
        public int IdProduct { get; set; }
        [DataMember] 
        public string namaProduct { get; set; }
        [DataMember] 
        public int harga { get; set; }
        [DataMember] 
        public int stok { get; set; }
        [DataMember] 
        public string deskripsi { get; set; }
    }

   
}
