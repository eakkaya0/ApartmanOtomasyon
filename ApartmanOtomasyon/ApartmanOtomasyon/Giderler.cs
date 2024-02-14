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
    public partial class Giderler : Form
    {
        public Giderler()
        {
            InitializeComponent();
        }
        SqlHelper sh = new SqlHelper();
       
        private void button_giderler_ekle_Click(object sender, EventArgs e)
        {
           
            
            string giderisim="";
            //bu işlemleri group boxun içindeki komtrollerden yani checkbox itemlerden erişip de yapabiliriz foreach ile
            //foreach(Conrol item in GroupBox1.controls)
            //{

            //}
            if(check_elektrik.Checked==true)
            {
                giderisim = "Elektrik,Su";
            }
            if (check_su.Checked == true)
            {
                giderisim = "Elektrik,Su";
            }

           if (check_asansor.Checked == true)
            {
                giderisim = check_asansor.Text;
            }
            if (check_temizlik.Checked == true)
            {
                giderisim = check_temizlik.Text;
            }
            if(check_asansor.Checked==false && check_su.Checked == false && check_elektrik.Checked == false&& check_temizlik.Checked == false)
            {
                MessageBox.Show("Lütfen bilgileri boş bırakmayınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int gider = (int)numericUpDown1.Value;
                DateTime yeni = dateTimePicker1.Value;
                SqlParameter p1 = new SqlParameter("gider_isim", giderisim);
                SqlParameter p2 = new SqlParameter("tarih", yeni);
                SqlParameter p3 = new SqlParameter("para", gider);
                sh.execute_prop("gider_ekle", p1, p2, p3);
            }
           
        }

        private void Giderler_Load(object sender, EventArgs e)
        {
            DataTable canan = sh.GetTable("select *from Gider_tablosu");
            foreach (DataRow item in canan.Rows)
            {
                listBox1.Items.Add(item["Gider_ismi"].ToString());
                listBox2.Items.Add(item["Para"].ToString()+" TL");
                listBox3.Items.Add(item["Tarih"].ToString());
            }
         
        }
    }
}
