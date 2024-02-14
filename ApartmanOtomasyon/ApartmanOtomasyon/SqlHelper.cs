using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ApartmanOtomasyon
{
   
    class SqlHelper
    {
        //vs den sql e parametre göndermeyi sonra sqlden olan verileri çekmeye yarıycak
        private string connection_string { get; set; }
        public SqlConnection baglanti { get; set; }
        //her classı çağırdığımızda bunların çalışması için constructor kullanmamız gerek
        public SqlHelper()
        {
            connection_string = @"Data Source=DESKTOP-V3OGBF0\SQLEXPRESS;Initial Catalog=APARTMAN;Integrated Security=True";
            baglanti = new SqlConnection(connection_string);
            
        }
        //sqldeki prosedürleri çalıştırmak için burdan parametre göndermek gerek onun için fonks yazdık
        public void execute_prop(string proc_name,params SqlParameter[] ps)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = proc_name;
            komut.Parameters.AddRange(ps);
            komut.Connection = baglanti;
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        //şimdi verileri sqlden çekmek için yardımcı fonksiyon yzacağız
        public DataTable GetTable(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection_string);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;          
        }
        
     

    }
}
