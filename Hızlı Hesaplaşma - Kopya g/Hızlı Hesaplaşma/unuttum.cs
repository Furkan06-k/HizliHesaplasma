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
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace Hızlı_Hesaplaşma
{
    public partial class unuttum : Form
    {
        public unuttum()
        {
            InitializeComponent();
            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            toolTip1.ToolTipTitle = "UYARI"; //tooltipin başlık ismi
            toolTip1.AutomaticDelay = 200; //milisaniye sonra tooltiplerin görüntülenmesi. Varsayılan değeri =500ms
            toolTip1.SetToolTip(this.textBox1, "şifreniz en az 8 karakterli olmalıdır");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "";// acces mdb uzatısını yazınız
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string email = textBox1.Text;
                string query = "SELECT * FROM kayıtOl WHERE email = '" + email + "'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string Sifre = reader["Sifre"].ToString();
                    MailMessage message = new MailMessage();
                    SmtpClient client = new SmtpClient();// e-postanın gönderileceği sunucuya bağlanmak için gerkli bilgilerin içerdiği kod.
                    client.Credentials = new NetworkCredential("", "");//  Mail adresinizi ve şifrenizi giriniz     client.Credentials satırı, SMTP sunucusuna erişmek için kullanılacak kimlik bilgilerini
                    client.Port = 587;//port numarası
                    client.Host = "smtp.office365.com";// Office 365 SMTP sunucusu
                    client.EnableSsl = true;//iletişimlerin güvenliğini sağlamak için kullanılan bir şifreleme protokolüdür.
                    message.To.Add(email);//e-postanın gönderileceği alıcının e-posta adresini eklemeyi sağlar
                    message.From = new MailAddress("");//Mail adreesinizi yazınız
                    message.Subject = "Şifremi Unuttum";
                    message.Body = "Şifre: " + "";// Şifrenizi yazınız     unuttuğu şifre, veritabanından okunan değer kullanılarak oluşturuluyor.
                    client.Send(message); //e - posta göndermek için SmtpClient nesnesinin Send() metodu çağrılıyor
                    MessageBox.Show("Mail adresinize şifre gönderildi.");
                    connection.Close();
                    this.Hide();
                    giriş grs = new giriş();
                    grs.Show();
                    this.Close();
                }
                else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Mail adresini giriniz");
                }
                else
                {
                    MessageBox.Show("Mail adresi bulunamadı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            giriş grş = new giriş();
            grş.Show();
            this.Hide();
        }
    }
}