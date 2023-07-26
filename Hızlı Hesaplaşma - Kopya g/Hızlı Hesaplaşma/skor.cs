using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Hızlı_Hesaplaşma
{
    public partial class skor : Form
    {
        public skor()
        {
            InitializeComponent();
        }
           

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



          
        }
         
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void skor_Load(object sender, EventArgs e)
        {
            string connectionString = ""; // Veritabanı bağlantı dizesi  acces mdb uzatısını yazınız
            string query = "SELECT * FROM skor"; // Skor tablosunu sorgulama sorgusu

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable; // DataGridView'e verileri bağlama
                                                 
             
            }

        }

        private void skor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kapatma işlemi engellendi
            e.Cancel = true;

            // Diğer forma geçiş işlemini gerçekleştirin
            seviye svy = new seviye();
            svy.Show();

            // Mevcut formu gizleyin
            this.Hide();
        }
    }
}
