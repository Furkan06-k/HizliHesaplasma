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
    public partial class kayıt : Form
    {
        public kayıt()
        {
            InitializeComponent();
            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            toolTip1.ToolTipTitle = "UYARI"; //tooltipin başlık ismi
            toolTip1.AutomaticDelay = 200; //milisaniye sonra tooltiplerin görüntülenmesi. Varsayılan değeri =500ms
            toolTip1.SetToolTip(this.textBox1, "adınızı giriniz");
            toolTip1.SetToolTip(this.textBox2, "soyadınızı giriniz");
            toolTip1.SetToolTip(this.textBox3, "@ işaretini, büyük harf, küçük harflere dikkat ediniz");
            toolTip1.SetToolTip(this.textBox4, "şifreniz en az 8 karakterli olmalıdır");

        }
        OleDbConnection baglantı = new OleDbConnection("");// acces mdb uzatısını yazınız
        OleDbCommand emir;
        OleDbCommand komut = new OleDbCommand();//bağlantımıza komut verdik
        OleDbDataAdapter da;

        private void kayıtol()
        {
            if (baglantı.State == ConnectionState.Closed)
            {
                baglantı.Open(); // Bağlantıyı sadece bir kez açın
            }
            OleDbCommand komut = new OleDbCommand();//bağlantımıza komut verdik
            komut.Connection = baglantı;// bağlantımızı komutla ilişkilendirdik
            komut.CommandText = ("Select * From KayıtOl");//hangi tablodan veri  çekecegimizi yazdık
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Close();
            baglantı.Close();// BAĞLANTI KAPIYORUZ
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            login yeni = new login();
            yeni.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length < 8)
            {
                MessageBox.Show("Şifreniz en az 8 karakter uzunluğunda olmalıdır.", "Şifre Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                baglantı.Open();// baglantı açtık
            OleDbCommand komut = new OleDbCommand("INSERT INTO KayıtOl (Ad,Soyad,Email,Sifre) VALUES ('" + textBox1.Text.ToString() + "', '" + textBox2.Text.ToString() + "', '" + textBox3.Text.ToString() + "', '" + textBox4.Text.ToString() + "')", baglantı);
            komut.ExecuteNonQuery(); //parametreyi geri döndürüyor
            kayıtol();
           
          
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            baglantı.Close();
            giriş grş = new giriş();
            grş.Show();
            this.Hide();    
        }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
    }

