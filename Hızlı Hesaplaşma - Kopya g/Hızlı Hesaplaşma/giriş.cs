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
    public partial class giriş : Form
    {
        public giriş()
        {
            InitializeComponent();
            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            linkLabel1.Parent = pictureBox1;
            linkLabel1.BackColor = Color.Transparent;
            checkBox1.Parent = pictureBox1;
            checkBox1.BackColor = Color.Transparent;
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            toolTip1.ToolTipTitle = "UYARI"; // Tooltip'in başlık ismi
            toolTip1.AutomaticDelay = 200; // Milisaniye sonra tooltip'lerin görüntülenmesi. Varsayılan değeri = 500ms
            toolTip1.SetToolTip(this.textBox1, "@ işaretini, büyük harf, küçük harflere dikkat ediniz"); // Textbox1 için tooltip ayarı
            toolTip1.SetToolTip(this.textBox2, "şifrenizi eksiksiz doğru bir şekilde giriniz"); // Textbox2 için tooltip ayarı
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            login yeni = new login();
            yeni.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            unuttum unt = new unuttum();
            unt.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = ("");// acces mdb uzatısını yazınız

            OleDbConnection bag;
            bag = new OleDbConnection(connectionString);
            bag.Open();
            OleDbCommand giris = new OleDbCommand("select * from KayıtOl where Email=@Email and Sifre=@Sifre", bag);
            giris.Parameters.AddWithValue("@Email", textBox1.Text);
            giris.Parameters.AddWithValue("@Sifre", textBox2.Text);
            OleDbDataReader oku = giris.ExecuteReader();
            if (oku.Read())
            {
                this.Hide();
                seviye svy = new seviye();
                svy.ShowDialog();
                this.Close();
                bag.Close();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
                bag.Close();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.UserName = textBox1.Text; // Kullanıcının uygulamaya giriş yaparken girdiği kullanıcı adını uygulama ayarlarına kaydetmek için kullanılır.
                Properties.Settings.Default.Password = textBox2.Text;
                // Properties - Ayarlar
            }
            else
            {
                Properties.Settings.Default.UserName = string.Empty;
                Properties.Settings.Default.Password = string.Empty;
            }

            Properties.Settings.Default.Save();
            // Settings.settings kısmında ayarları kaydederek kullanılacak son ayarların güncellenmesini sağlar.
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // TextBox2'nin metni değiştiğinde yapılması gereken işlemler
        }

        private void giriş_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                // UserName daha önce bir kullanıcı adı kaydedilmişse, if bloğunun içindeki kod çalışır
                // Empty, boş bir string nesnesi oluşturarak, UserName özelliğinin şu anda boş olup olmadığını kontrol eder
                textBox1.Text = Properties.Settings.Default.UserName; // Önceden kaydedilmiş kullanıcı adı varsa, sonraki sefer uygulamayı açtığında kaydedilmiş kullanıcı adı TextBox'ında görüntülenmesini sağlar.
                textBox2.Text = Properties.Settings.Default.Password;
                checkBox1.Checked = true; // Uygulama ilk yüklendiğinde daha önce kaydedilmiş bir kullanıcı adı ve şifre varsa işaretler
            }
        }
    }
}