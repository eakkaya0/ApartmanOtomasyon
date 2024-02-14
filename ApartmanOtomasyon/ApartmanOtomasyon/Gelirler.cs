using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmanOtomasyon
{
    public partial class Gelirler : Form
    {
        public Gelirler()
        {
            InitializeComponent();
        }
        SqlHelper sh = new SqlHelper();
        private void button_gelir_ekle_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem!=null && numericUpDown1.Value!=null &&dateTimePicker1.Value!=null)
            {
                int daireno = Convert.ToInt32(comboBox1.Text);
                int aidat = Convert.ToInt32(numericUpDown1.Value);
                DateTime yeni = dateTimePicker1.Value;
                SqlParameter p1 = new SqlParameter("daire", daireno);
                SqlParameter p2 = new SqlParameter("tarih", yeni);
                SqlParameter p3 = new SqlParameter("tutar", aidat);
                sh.execute_prop("odeme_al", p1, p2, p3);
            }
            else
            {
                MessageBox.Show("Lütfen bilgileri boş bırakmayınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }



        }

        private void Gelirler_Load(object sender, EventArgs e)
        {
            DataTable canan = sh.GetTable("select *from AidatOdemesi");
            foreach (DataRow item in canan.Rows)
            {
                listBox1.Items.Add(item["DaireNo"].ToString());
                listBox2.Items.Add(item["Aidat"].ToString()+" TL");
                listBox3.Items.Add(item["Tarih"].ToString());
            }

            //SqlConnection can = new SqlConnection();
            //can.ConnectionString = @"Data Source=DESKTOP-V3OGBF0\SQLEXPRESS;Initial Catalog=APARTMAN;Integrated Security=True";
            //SqlCommand komut = new SqlCommand("select *from AidatOdemesi", can);
            //can.Open();
            //SqlDataReader okuyucu = komut.ExecuteReader(); //execute reader veriyi okunacak türe çevirir sqldatareader de okumaya yarar
            //while (okuyucu.Read())//sql data  readerde sql deki tablolardaki sütünlar 0 ,1,2 olarak tutulur
            //{
            //    listBox1.Items.Add(okuyucu[1].ToString());
            //    listBox2.Items.Add(okuyucu[2].ToString());
            //    listBox3.Items.Add(okuyucu[3].ToString());
            //}
            //okuyucu.Close();
            //can.Close();


        }
    }
}
